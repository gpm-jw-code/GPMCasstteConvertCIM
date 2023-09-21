using CommunityToolkit.HighPerformance.Buffers;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.UI_UserControls;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.clsConverterPort;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsCasstteConverter : ISECSHandShakeable
    {
        public enum PLC_CONN_INTERFACE
        {
            MX,
            MC
        }
        internal bool simulation_mode = false;

        protected virtual string BitMapFileName_EQ { get; set; } = "src\\PLC_Bit_Map_EQ.csv";
        protected virtual string WordMapFileName_EQ { get; set; } = "src\\PLC_Word_Map_EQ.csv";
        protected virtual string BitMapFileName_CIM { get; set; } = "src\\PLC_Bit_Map_CIM.csv";
        protected virtual string WordMapFileName_CIM { get; set; } = "src\\PLC_Word_Map_CIM.csv";

        protected PLC_CONN_INTERFACE plcInterface = PLC_CONN_INTERFACE.MC;
        public virtual List<clsConverterPort> PortDatas { get; set; } = new List<clsConverterPort>();

        public clsCasstteConverter()
        {

        }
        internal clsCasstteConverter(string name, UscCasstteConverter mainGUI, Dictionary<int, clsPortProperty> portProperties)
        {
            this.Name = name;
            EQPData = new Data.clsEQPData();

            for (int i = 0; i < portProperties.Count; i++)
            {
                var portProp = portProperties[i];
                PortDatas.Add(new clsConverterPort(portProp, this));
            }

            this.plcInterface = PLC_CONN_INTERFACE.MC;
            LoadPLCMapData();
            this.mainGUI = mainGUI;
            this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();

        }

        internal clsCasstteConverter(int index, string name, UscCasstteConverter mainGUI, CONVERTER_TYPE converterType, Dictionary<int, clsPortProperty> portProperties)
        {
            this.Name = name;
            EQPData = new clsEQPData();

            for (int i = 0; i < portProperties.Count; i++)
            {
                var portProp = portProperties[i];
                PortDatas.Add(new clsConverterPort(portProp, this));
            }
            this.converterType = converterType;
            this.index = index;
            LoadPLCMapData();
            this.mainGUI = mainGUI;
            this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();

        }

        protected virtual void PortModbusServersActive()
        {
            foreach (var item in PortDatas)
            {
                item.ModbusServerActive();
            }
        }


        protected async void EQPInterfaceClockMonitor()
        {
            await Task.Delay(4000);
            _ = Task.Factory.StartNew(async () =>
            {
                int lastInterfaceClock = -1;
                while (true)
                {
                    PLCInterfaceClockDown = lastInterfaceClock == EQPData.InterfaceClock;
                    if (PLCInterfaceClockDown)
                    {
                        if (lastInterfaceClock != -1)
                        {

                            AlarmManager.AddWarning(ALARM_CODES.ALIVE_CLOCK_EQP_DOWN, Name, false);
                            ResetEQPHandshakeBits();

                        }
                    }
                    else
                    {
                        AlarmManager.TryRemoveAlarm(ALARM_CODES.ALIVE_CLOCK_EQP_DOWN, Name);
                    }
                    lastInterfaceClock = EQPData.InterfaceClock;
                    await Task.Delay(TimeSpan.FromSeconds(4));
                }
            });
            EQPData.PropertyChanged += (sender, arg) =>
            {
                if (arg.PropertyName == nameof(EQPData.InterfaceClock))
                {
                    //AlarmManager.TryRemoveAlarm(ALARM_CODES.ALIVE_CLOCK_EQP_DOWN, Name);
                    PLCInterfaceClockDown = false;
                }
            };
        }


        internal List<clsMemoryAddress> LinkBitMap { get; set; } = new List<clsMemoryAddress>();
        internal List<clsMemoryAddress> LinkWordMap { get; set; } = new List<clsMemoryAddress>();

        internal List<clsMemoryAddress> WIP_Port1_BCR_ID_Addresses => LinkWordMap.FindAll(ad => ad.PropertyName.Contains("WIPInfo_Port1_BCR_ID_"));
        internal clsMemoryAddress EQPInterfaceClockAddress => LinkWordMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP && lp.EProperty == PROPERTY.Interface_Clock);

        public McInterfaceOptions mcInterfaceOptions { get; private set; } = new McInterfaceOptions();

        internal CIMComponent.MXCompHandler mxInterface;
        internal clsMCE71Interface? mcInterface = new clsMCE71Interface();

        private Task? RetryTask;
        private Common.CONNECTION_STATE _connectionState = Common.CONNECTION_STATE.DISCONNECTED;

        public CONVERTER_TYPE converterType { get; }
        public int index { get; }

        internal UscCasstteConverter mainGUI;
        internal frmModbusTCPServer modbusServerGUI;

        internal bool monitor = true;

        #region 事件

        /// <summary>
        /// 手動/自動模式切換請求
        /// </summary>
        internal event EventHandler<AUTO_MANUAL_MODE> RackModeChangeOnRequest;
        public event EventHandler<EventArgs> EQPOnline_Local_OnRequest;
        public event EventHandler<EventArgs> EQPOnline_Remote_OnRequest;
        public event EventHandler<EventArgs> EQPOffline_OnRequset;
        public event EventHandler EQPInterfaceClockShutdown;
        #endregion


        internal Common.CONNECTION_STATE connectionState
        {
            get => _connectionState;
            set
            {
                if (_connectionState != value)
                {
                    _connectionState = value;
                    ConnectionStateChanged?.Invoke(this, _connectionState);
                }
            }
        }
        internal bool Connected { get; private set; }
        internal bool PLCInterfaceClockDown { get; private set; }
        public int MXLogic_Station_Number = 1;
        public string Name { get; set; } = "";
        internal Data.clsEQPData EQPData { get; set; }
        internal Data.clsAGVSData AGVSData { get; private set; } = new Data.clsAGVSData();

        internal event EventHandler<Common.CONNECTION_STATE>? ConnectionStateChanged;
        internal clsMemoryGroupOptions EQPMemOptions { get; private set; }
        internal clsMemoryGroupOptions EQPOutputMemOptions { get; private set; } = new clsMemoryGroupOptions("X0000", "X0015", "W0000", "W0001", false, true);
        internal clsMemoryGroupOptions CIMinputMemOptions { get; private set; } = new clsMemoryGroupOptions("X0100", "X0115", "W0000", "W0001", false, true);
        internal clsMemoryGroupOptions CIMMemOptions { get; private set; }
        public bool AlarmResetFlag { get; internal set; }
        private bool _MxOpened = true;
        private Exception MxOpenException;
        public bool MxOpened
        {
            get => _MxOpened;
            set
            {
                if (_MxOpened != value)
                {
                    if (!value)
                    {
                        Utility.SystemLogger.Error($"MX Open Fail...Logic Station Number = {MXLogic_Station_Number}", MxOpenException);
                        AlarmManager.AddAlarm(ALARM_CODES.MX_INTERFACE_OPEN_FAIL, Name);
                    }
                    _MxOpened = value;
                }
            }
        }
        internal virtual async Task<bool> ActiveAsync(McInterfaceOptions mcInterfaceOptions)
        {
            await Task.Delay(1);
            try
            {
                connectionState = Common.CONNECTION_STATE.CONNECTING;
                this.mcInterfaceOptions = mcInterfaceOptions;
                int connRetCode = -1;

                bool connected = await Task.Run(() =>
                {
                    if (plcInterface == PLC_CONN_INTERFACE.MC)
                    {
                        return mcInterface.Open(mcInterfaceOptions, out connRetCode, enuDataType: clsMC_TCPCnt.enuDataType.ByteArr_02);
                    }
                    else
                    {
                        try
                        {
                            mxInterface = new CIMComponent.MXCompHandler();
                            connRetCode = mxInterface.Open(MXLogic_Station_Number);
                            return connRetCode == 0;
                        }
                        catch (Exception ex)
                        {
                            MxOpenException = ex;
                            MxOpened = false;
                            return false;
                        }
                    }

                });
                connectionState = connRetCode == 0 ? Common.CONNECTION_STATE.CONNECTED : Common.CONNECTION_STATE.DISCONNECTED;

                if (connectionState != Common.CONNECTION_STATE.CONNECTED)
                {
                    if (RetryTask == null)
                        RetryConnectAsync();
                }
                return connected;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async void RetryConnectAsync()
        {
            await Task.Delay(1);
            RetryTask = Task.Run(async () =>
            {
                while (!await ActiveAsync(mcInterfaceOptions))
                {
                    Thread.Sleep(1000);
                }
                RetryTask = null;
            });
        }

        protected void DataSyncTask()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1);
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    SyncMemData();
                    stopwatch.Stop();
                    if (index == 0)
                    {

                    }
                }
            });
        }


        protected virtual void CIMInterfaceClockUpdate()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(4));

                    var interfaceClockAddress = LinkWordMap.FirstOrDefault(w => w.EOwner == clsMemoryAddress.OWNER.CIM && w.EProperty == PROPERTY.Interface_Clock);
                    if (interfaceClockAddress != null)
                    {
                        int clock = (int)interfaceClockAddress.Value;
                        int newClock = clock + 1;
                        newClock = newClock == 256 ? 0 : newClock;
                        CIMMemOptions.memoryTable.WriteBinary(interfaceClockAddress.Address, newClock);
                    }

                }

            });
        }

        protected async Task PLCMemorySyncTask()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(10);
                        if (_connectionState != Common.CONNECTION_STATE.CONNECTED)
                        {
                            continue;
                        }
                        if (!simulation_mode)
                        {
                            int ret_code = -1;
                            try
                            {
                                if (monitor)
                                {
                                    if (plcInterface == PLC_CONN_INTERFACE.MC)
                                    {
                                        ret_code = mcInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                        ret_code = mcInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                        ret_code = mcInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                        ret_code = mcInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);
                                    }
                                    else
                                    {
                                        ret_code = mxInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                        ret_code = mxInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                        ret_code = mxInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                        ret_code = mxInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);
                                    }
                                }
                            }
                            catch (SocketException ex)
                            {
                                //ResetEQPHandshakeBits();
                                _connectionState = Common.CONNECTION_STATE.DISCONNECTED;
                                RetryConnectAsync();
                            }
                            catch (Exception ex)
                            {
                                //RetryConnectAsync();
                                continue;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }

                }
            });
        }
        private void ResetEQPHandshakeBits()
        {
            foreach (clsConverterPort port in PortDatas)
            {
                string Load_Request_address = port.PortEQBitAddress[PROPERTY.Load_Request];
                string Unload_Request_address = port.PortEQBitAddress[PROPERTY.Unload_Request];
                string Port_Status_Down_address = port.PortEQBitAddress[PROPERTY.Port_Status_Down];

                EQPMemOptions.memoryTable.WriteOneBit(Load_Request_address, false);
                EQPMemOptions.memoryTable.WriteOneBit(Unload_Request_address, false);
                EQPMemOptions.memoryTable.WriteOneBit(Port_Status_Down_address, false);
            }
        }

        protected virtual void SyncMemData()
        {
            try
            {

                //讀取
                foreach (var item in LinkWordMap)
                {

                    if (item.EOwner == clsMemoryAddress.OWNER.EQP)
                    {
                        item.Value = EQPMemOptions.memoryTable.ReadBinary(item.Address);
                        //EQPData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                    }
                    else
                    {
                        item.Value = CIMMemOptions.memoryTable.ReadBinary(item.Address);
                        //AGVSData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                    }
                }
                //寫入
                foreach (var item in LinkBitMap)
                {

                    if (item.EOwner == clsMemoryAddress.OWNER.EQP)
                    {
                        item.Value = EQPMemOptions.memoryTable.ReadOneBit(item.Address);
                        //EQPData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                    }
                    else
                    {
                        item.Value = CIMMemOptions.memoryTable.ReadOneBit(item.Address);
                        //AGVSData.TrySetPropertyValue(item.PropertyName, item.Value, out bool valChanged);
                    }
                }

                bool[] cim_bit_states = new bool[CIMMemOptions.bitSize];
                int[] cim_word_datas = new int[CIMMemOptions.wordSize];

                bool[] eqp_bit_states = new bool[EQPMemOptions.bitSize];
                int[] eqp_word_datas = new int[EQPMemOptions.wordSize];

                CIMMemOptions.memoryTable.ReadBit(CIMMemOptions.bitStartAddress, CIMMemOptions.bitSize, ref cim_bit_states);
                CIMMemOptions.memoryTable.ReadWord(CIMMemOptions.wordStartAddress, CIMMemOptions.wordSize, ref cim_word_datas);
                EQPMemOptions.memoryTable.ReadBit(EQPMemOptions.bitStartAddress, EQPMemOptions.bitSize, ref eqp_bit_states);
                EQPMemOptions.memoryTable.ReadWord(EQPMemOptions.wordStartAddress, EQPMemOptions.wordSize, ref eqp_word_datas);

                List<clsMemoryAddress> cimBitData = LinkBitMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM);
                List<clsMemoryAddress> eqpBitData = LinkBitMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP);

                List<clsMemoryAddress> cimWordData = LinkWordMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM);
                List<clsMemoryAddress> eqpWordData = LinkWordMap.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP);

                for (int i = 0; i < cim_bit_states.Length; i++)
                {
                    cimBitData[i].Value = cim_bit_states[i];
                }

                for (int i = 0; i < cim_word_datas.Length; i++)
                {
                    cimWordData[i].Value = cim_word_datas[i];
                }


                for (int i = 0; i < eqp_bit_states.Length; i++)
                {
                    eqpBitData[i].Value = eqp_bit_states[i];
                }
                for (int i = 0; i < eqp_word_datas.Length; i++)
                {
                    eqpWordData[i].Value = eqp_word_datas[i];
                }

                PLCMemoryDatatToEQDataDTO();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected virtual void PLCMemoryDatatToEQDataDTO()
        {
            try
            {
                //EQP 
                EQPData.EQP_RUN = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_RUN).Value;
                EQPData.EQP_IDLE = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_IDLE).Value;
                EQPData.EQP_DOWN = (bool)LinkBitMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_DOWN).Value;
                EQPData.InterfaceClock = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Interface_Clock).Value;
                EQPData.EQP_ON_OFFLine_Mode_Status = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.EQP_ON_OFFLine_Mode_Status).Value;
                EQPData.Warning_Report_Index = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Report_Index).Value;
                EQPData.Warning_Code_1_16 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_1_16).Value;
                EQPData.Warning_Code_17_32 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_17_32).Value;
                EQPData.Warning_Code_33_48 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Warning_Code_33_48).Value;
                EQPData.Alarm_Report_Index = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Report_Index).Value;
                EQPData.Alarm_Code_1_16 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_1_16).Value;
                EQPData.Alarm_Code_17_32 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_17_32).Value;
                EQPData.Alarm_Code_33_48 = (int)LinkWordMap.First(f => f.EScope == EQ_SCOPE.EQ && f.EProperty == PROPERTY.Alarm_Code_33_48).Value;

                //PORTS
                EQ_SCOPE[] Ports = PortDatas.Count == 1 ? new EQ_SCOPE[1] { EQ_SCOPE.PORT1 } : new EQ_SCOPE[2] { EQ_SCOPE.PORT1, EQ_SCOPE.PORT2 };
                for (int i = 0; i < Ports.Length; i++)
                {
                    EQ_SCOPE port = Ports[i];
                    clsConverterPort EQPORT = PortDatas[i];

                    //AGV 訊號
                    try
                    {
                        //交握訊號
                        EQPORT.AGVSignals.VALID = (bool)LinkBitMap.FirstOrDefault(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.VALID)?.Value;
                        EQPORT.AGVSignals.TR_REQ = (bool)LinkBitMap.FirstOrDefault(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.TR_REQ)?.Value;
                        EQPORT.AGVSignals.BUSY = (bool)LinkBitMap.FirstOrDefault(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.BUSY)?.Value;
                        EQPORT.AGVSignals.COMPT = (bool)LinkBitMap.FirstOrDefault(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.COMPT)?.Value;
                        EQPORT.AGVSignals.AGV_READY = (bool)LinkBitMap.FirstOrDefault(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.AGV_READY)?.Value;
                    }
                    catch (Exception ex)
                    {

                    }
                    EQPORT.AGVSignals.To_EQ_Up = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.To_EQ_Up).Value;
                    EQPORT.AGVSignals.To_EQ_Low = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.To_EQ_Low).Value;
                    EQPORT.AGVSignals.CMD_Reserve_Up = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.CMD_reserve_Up).Value;
                    EQPORT.AGVSignals.CMD_Reserve_Low = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.CMD_reserve_Low).Value;

                    AGVSData.Signals[i] = EQPORT.AGVSignals;

                    //EQP Bit data
                    try
                    {
                        EQPORT.L_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.L_REQ).Value;
                        EQPORT.U_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.U_REQ).Value;
                        EQPORT.EQ_READY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_READY).Value;
                        EQPORT.EQ_BUSY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_BUSY).Value;
                    }
                    catch (Exception ex)
                    {
                    }

                    EQPORT.LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                    EQPORT.UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;
                    EQPORT.PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                    bool port_status_down = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                    EQPORT.PortStatusDown = port_status_down;

                    EQPORT.LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                    EQPORT.LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;
                    EQPORT.DoorOpened = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Door_Opened).Value;
                    EQPORT.TB_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.TB_DOWN_POS).Value;

                    EQPORT.CarrierWaitINSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitIn_System_Request).Value;
                    EQPORT.CarrierWaitOUTSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitOut_System_Report).Value;
                    EQPORT.CarrierRemovedCompletedReport = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_Removed_Completed_Report).Value;

                    EQPORT.Port_Mode_Change_Accept = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Change_Accept).Value;
                    EQPORT.Port_Mode_Changed_Refuse = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Refuse).Value;
                    EQPORT.Port_Mode_Changed_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Report).Value;
                    EQPORT.Port_Disabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Disabled_Report).Value;
                    EQPORT.Port_Enabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Enabled_Report).Value;

                    //EQP word data


                    EQPORT.PortType = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.Port_Type_Status).Value;
                    EQPORT.Port_Auto_Manual_Mode_Status = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.Port_Auto_Manual_Mode_Status).Value;
                    try
                    {

                        EQPORT.WIPInfo_BCR_ID_1 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_1).Value;
                        EQPORT.WIPInfo_BCR_ID_2 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_2).Value;
                        EQPORT.WIPInfo_BCR_ID_3 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_3).Value;
                        EQPORT.WIPInfo_BCR_ID_4 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_4).Value;
                        EQPORT.WIPInfo_BCR_ID_5 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_5).Value;
                        EQPORT.WIPInfo_BCR_ID_6 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_6).Value;
                        EQPORT.WIPInfo_BCR_ID_7 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_7).Value;
                        EQPORT.WIPInfo_BCR_ID_8 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_8).Value;
                        EQPORT.WIPInfo_BCR_ID_9 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_9).Value;
                        EQPORT.WIPInfo_BCR_ID_10 = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_10).Value;
                        EQPORT.WIPINFO_BCR_ID = EQPORT.GetWIPIDFromMem();
                    }
                    catch (Exception ed)
                    {

                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 開啟模擬器
        /// </summary>
        internal void OpenSimulatorUI()
        {
            mainGUI?.OpenConvertPLCSumulator();
        }
        protected virtual void LoadPLCMapData()
        {
            try
            {
                LoadLinkMapData(BitMapFileName_EQ, WordMapFileName_EQ, out List<clsMemoryAddress> eq_bit_link_map, out List<clsMemoryAddress> eq_word_link_map);
                LoadLinkMapData(BitMapFileName_CIM, WordMapFileName_CIM, out List<clsMemoryAddress> cim_bit_link_map, out List<clsMemoryAddress> cim_word_link_map);

                LinkBitMap.AddRange(cim_bit_link_map);
                LinkBitMap.AddRange(eq_bit_link_map);

                LinkWordMap.AddRange(cim_word_link_map);
                LinkWordMap.AddRange(eq_word_link_map);

                string eqp_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;
                string eqp_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.EQP).Address;

                string cim_bitStartAddress = LinkBitMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_bitEndAddress = LinkBitMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_wordStartAddress = LinkWordMap.First(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;
                string cim_wordEndAddress = LinkWordMap.Last(i => i.EOwner == clsMemoryAddress.OWNER.CIM).Address;


                EQPMemOptions = new clsMemoryGroupOptions(eqp_bitStartAddress, eqp_bitEndAddress, eqp_wordStartAddress, eqp_wordEndAddress);
                CIMMemOptions = new clsMemoryGroupOptions(cim_bitStartAddress, cim_bitEndAddress, cim_wordStartAddress, cim_wordEndAddress);

            }
            catch (Exception ex)
            {
            }
        }


        private void LoadLinkMapData(string bitFile, string wordFile, out List<clsMemoryAddress> bitAddressList, out List<clsMemoryAddress> wordAddressList)
        {
            bitAddressList = new List<clsMemoryAddress>();
            wordAddressList = new List<clsMemoryAddress>();

            string temp_bitMapFile = $"bitmap_temp_{DateTime.Now.Ticks}.csv";
            string temp_wordMapFile = $"wordmap_temp_{DateTime.Now.Ticks}.csv";
            if (File.Exists(bitFile))
            {
                File.Copy(bitFile, temp_bitMapFile);
                string[] context = File.ReadAllLines(temp_bitMapFile);
                File.Delete(temp_bitMapFile);
                ArraySegment<string> context_removeHead = new ArraySegment<string>(context, 1, context.Length - 1);
                bitAddressList = context_removeHead.Select(line => CreateMemoryAddress(line, clsMemoryAddress.DATA_TYPE.BIT)).ToList();
            }
            if (File.Exists(wordFile))
            {
                File.Copy(wordFile, temp_wordMapFile);
                string[] context = File.ReadAllLines(temp_wordMapFile);
                File.Delete(temp_wordMapFile);
                ArraySegment<string> context_removeHead = new ArraySegment<string>(context, 1, context.Length - 1);
                wordAddressList = context_removeHead.Select(line => CreateMemoryAddress(line, clsMemoryAddress.DATA_TYPE.WORD)).ToList();
            }
            bitAddressList = bitAddressList.FindAll(ad => ad.Address != "").ToList();
            wordAddressList = wordAddressList.FindAll(ad => ad.Address != "").ToList();
        }

        private clsMemoryAddress CreateMemoryAddress(string context_line, clsMemoryAddress.DATA_TYPE data_type)
        {
            string[] lineSplited = context_line.Split(',');
            try
            {

                return new clsMemoryAddress(data_type)
                {
                    Address = lineSplited[0],
                    Owner = lineSplited[1],
                    DataName = lineSplited[2],
                    DataFormat = lineSplited[3],
                    Explanation = lineSplited[4],
                    Scope = lineSplited[5],
                    PropertyName = lineSplited[6],
                    Link_Modbus_Register_Number = lineSplited[7] == "" ? -1 : int.Parse(lineSplited[7]),
                    EQ_Name = lineSplited[8] == "" ? EQ_NAMES.Unkown : Enum.GetValues(typeof(EQ_NAMES)).Cast<EQ_NAMES>().First(E => E.ToString() == lineSplited[8])

                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ReplyHOSTOfflineRequest()
        {
        }

        public void ReplyHostOnlineRequest()
        {
        }
    }
}
