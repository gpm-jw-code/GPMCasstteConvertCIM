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
    public class clsCasstteConverter : ISECSHandShakeable
    {
        internal bool simulation_mode = false;
        private string BitMapFileName_EQ = "src\\PLC_Bit_Map_EQ.csv";
        private string WordMapFileName_EQ = "src\\PLC_Word_Map_EQ.csv";
        private string BitMapFileName_CIM = "src\\PLC_Bit_Map_CIM.csv";
        private string WordMapFileName_CIM = "src\\PLC_Word_Map_CIM.csv";

        public enum PLC_CONN_INTERFACE
        {
            MX,
            MC
        }
        public clsCasstteConverter()
        {

        }


        internal clsCasstteConverter(string name, UscCasstteConverter mainGUI, Dictionary<int, clsPortProperty> portProperties
           )
        {
            this.Name = name;
            EQPData = new Data.clsEQPData();

            for (int i = 0; i < portProperties.Count; i++)
            {
                var portProp = portProperties[i];
                PortDatas.Add(new clsConverterPort(portProp, this));
            }

            this.plcInterface = PLC_CONN_INTERFACE.MX;
            LoadPLCMapData();
            this.mainGUI = mainGUI;
            this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();

        }

        internal clsCasstteConverter(string name, UscCasstteConverter mainGUI, CONVERTER_TYPE converterType, Dictionary<int, clsPortProperty> portProperties
            , PLC_CONN_INTERFACE _interface = PLC_CONN_INTERFACE.MX)
        {
            this.Name = name;
            EQPData = new Data.clsEQPData();

            for (int i = 0; i < portProperties.Count; i++)
            {
                var portProp = portProperties[i];
                PortDatas.Add(new clsConverterPort(portProp, this));
            }

            this.plcInterface = _interface;
            this.converterType = converterType;
            LoadPLCMapData();
            this.mainGUI = mainGUI;
            this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();

        }

        virtual protected void PortModbusServersActive()
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

        public McInterfaceOptions InterfaceOptions { get; private set; } = new McInterfaceOptions();

        internal CIMComponent.MXCompHandler mxInterface;
        internal clsMCE71Interface? mcInterface = new clsMCE71Interface();

        private Task? RetryTask;
        private Common.CONNECTION_STATE _connectionState = Common.CONNECTION_STATE.DISCONNECTED;

        public CONVERTER_TYPE converterType { get; }

        virtual internal UscCasstteConverter mainGUI { get; set; }
        internal frmModbusTCPServer modbusServerGUI;

        internal bool monitor = true;
        public List<clsConverterPort> PortDatas { get; set; } = new List<clsConverterPort>();

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
        public string Name { get; set; } = "";
        internal Data.clsEQPData EQPData { get; set; }

        protected PLC_CONN_INTERFACE plcInterface = PLC_CONN_INTERFACE.MC;

        internal Data.clsAGVSData AGVSData { get; private set; } = new Data.clsAGVSData();

        internal event EventHandler<Common.CONNECTION_STATE>? ConnectionStateChanged;
        internal clsMemoryGroupOptions EQPMemOptions { get; set; }
        internal clsMemoryGroupOptions EQPOutputMemOptions { get; private set; }/* = new clsMemoryGroupOptions("X0", "X15", "W0", "W1", false, true);*/
        internal clsMemoryGroupOptions CIMinputMemOptions { get; private set; }/* = new clsMemoryGroupOptions("X100", "X115", "W0", "W1", false, true);*/
        internal clsMemoryGroupOptions CIMMemOptions { get; set; }
        public bool AlarmResetFlag { get; internal set; }

        virtual internal async Task<bool> ActiveAsync(McInterfaceOptions InterfaceOptions)
        {
            await Task.Delay(1);
            try
            {
                connectionState = Common.CONNECTION_STATE.CONNECTING;
                this.InterfaceOptions = InterfaceOptions;
                int connRetCode = -1;

                bool connected = await Task.Run(() =>
                {
                    if (plcInterface == PLC_CONN_INTERFACE.MX)
                    {
                        try
                        {
                            mxInterface = new CIMComponent.MXCompHandler();
                        }
                        catch (Exception ex)
                        {
                            Utility.SystemLogger.Error("MXCompHanler_Entitize_Fail", ex);
                            AlarmManager.AddAlarm(ALARM_CODES.MXCompHanler_Entitize_Fail, this.GetType().Name, false);
                            return false;
                        }
                        connRetCode = mxInterface.Open(1);
                        if (connRetCode != 0)
                        {
                            Utility.SystemLogger.Error("MXCompHanler_Open_Fail", new Exception());
                            AlarmManager.AddAlarm(ALARM_CODES.MXCompHanler_Open_Fail, this.GetType().Name, false);
                        }
                        return connRetCode == 0;
                    }
                    else
                        return mcInterface.Open(InterfaceOptions, out connRetCode, enuDataType: clsMC_TCPCnt.enuDataType.ByteArr_02);
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
                while (!await ActiveAsync(InterfaceOptions))
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
                    //TODO 資料解析
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    SyncMemData();
                    stopwatch.Stop();
                }
            });
        }


        protected void CIMInterfaceClockUpdate()
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

        protected virtual async Task PLCMemorySyncTask()
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
                        Stopwatch sw = Stopwatch.StartNew();
                        if (!simulation_mode)
                        {
                            int ret_code = -1;
                            try
                            {
                                if (monitor)
                                {

                                    if (plcInterface == PLC_CONN_INTERFACE.MX)
                                    {

                                        var ret_code_wb = mxInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                        var ret_code_ww = mxInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                        var ret_code_rb = mxInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                        var ret_code_rw = mxInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);

                                    }
                                    else
                                    {
                                        var ret_code_wb = mcInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                        var ret_code_ww = mcInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                        var ret_code_rb = mcInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                        var ret_code_rw = mcInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);

                                    }
                                }
                            }
                            catch (SocketException ex)
                            {
                                Utility.SystemLogger.Error($"PLC Read Memory SocketException ERROR_[{plcInterface}]_{ex.Message}", ex);
                                _connectionState = Common.CONNECTION_STATE.DISCONNECTED;
                                RetryConnectAsync();
                            }
                            catch (Exception ex)
                            {

                                Utility.SystemLogger.Error($"PLC Read Memory ERROR_[{plcInterface}]_{ex.Message}", ex);
                                continue;
                            }
                        }
                        sw.Stop();

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

        virtual protected void SyncMemData()
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

        virtual protected void PLCMemoryDatatToEQDataDTO()
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


                //AGV 訊號
                PortDatas[i].AGVSignals.VALID = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.VALID).Value;
                PortDatas[i].AGVSignals.TR_REQ = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.TR_REQ).Value;
                PortDatas[i].AGVSignals.BUSY = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.BUSY).Value;
                PortDatas[i].AGVSignals.COMPT = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.COMPT).Value;
                PortDatas[i].AGVSignals.AGV_READY = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.AGV_READY).Value;
                PortDatas[i].AGVSignals.To_EQ_Up = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.To_EQ_Up).Value;
                PortDatas[i].AGVSignals.To_EQ_Low = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.To_EQ_Low).Value;
                PortDatas[i].AGVSignals.CMD_Reserve_Up = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.CMD_reserve_Up).Value;
                PortDatas[i].AGVSignals.CMD_Reserve_Low = (bool)LinkBitMap.First(f => f.EOwner == clsMemoryAddress.OWNER.CIM && f.EScope == port && f.EProperty == PROPERTY.CMD_reserve_Low).Value;

                AGVSData.Signals[i] = PortDatas[i].AGVSignals;

                //EQP Bit data
                PortDatas[i].L_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.L_REQ).Value;
                PortDatas[i].U_REQ = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.U_REQ).Value;
                PortDatas[i].EQ_READY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_READY).Value;
                PortDatas[i].EQ_BUSY = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.EQ_BUSY).Value;
                PortDatas[i].LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                PortDatas[i].UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;

                PortDatas[i].PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                bool port_status_down = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                PortDatas[i].PortStatusDown = port_status_down;

                PortDatas[i].LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                PortDatas[i].LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;
                PortDatas[i].DoorOpened = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Door_Opened).Value;
                PortDatas[i].TB_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.TB_DOWN_POS).Value;

                PortDatas[i].CarrierWaitINSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitIn_System_Request).Value;
                PortDatas[i].CarrierWaitOUTSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitOut_System_Report).Value;
                PortDatas[i].CarrierRemovedCompletedReport = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_Removed_Completed_Report).Value;

                PortDatas[i].Port_Mode_Change_Accept = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Change_Accept).Value;
                PortDatas[i].Port_Mode_Changed_Refuse = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Refuse).Value;
                PortDatas[i].Port_Mode_Changed_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Report).Value;
                PortDatas[i].Port_Disabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Disabled_Report).Value;
                PortDatas[i].Port_Enabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Enabled_Report).Value;

                //EQP word data
                PortDatas[i].PortType = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Type_Status).Value;

                PortDatas[i].PortModeStatus = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Type_Status).Value;
                PortDatas[i].Port_Auto_Manual_Mode_Status = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Auto_Manual_Mode_Status).Value;
                PortDatas[i].WIPInfo_BCR_ID_1 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_1).Value;
                PortDatas[i].WIPInfo_BCR_ID_2 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_2).Value;
                PortDatas[i].WIPInfo_BCR_ID_3 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_3).Value;
                PortDatas[i].WIPInfo_BCR_ID_4 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_4).Value;
                PortDatas[i].WIPInfo_BCR_ID_5 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_5).Value;
                PortDatas[i].WIPInfo_BCR_ID_6 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_6).Value;
                PortDatas[i].WIPInfo_BCR_ID_7 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_7).Value;
                PortDatas[i].WIPInfo_BCR_ID_8 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_8).Value;
                PortDatas[i].WIPInfo_BCR_ID_9 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_9).Value;
                PortDatas[i].WIPInfo_BCR_ID_10 = (int)LinkWordMap.First(f => f.EScope == port && f.EProperty == PROPERTY.WIP_Information_BCR_10).Value;
            }
        }


        /// <summary>
        /// 開啟模擬器
        /// </summary>
        internal void OpenSimulatorUI()
        {
            mainGUI?.OpenConvertPLCSumulator();
        }
        virtual public void LoadPLCMapData()
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
