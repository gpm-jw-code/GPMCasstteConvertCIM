﻿using AGVSystemCommonNet6.Log;
using CommunityToolkit.HighPerformance.Buffers;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Devices.Options;
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
        internal bool _simulation_mode = false;
        internal bool simulation_mode
        {
            get => _simulation_mode;
            set
            {
                if (_simulation_mode != value)
                {
                    _simulation_mode = value;
                    Utility.SystemLogger.Info($"{Name} Simulation Mode Changed :{(value ? "Opened" : "Closed")}");
                    if (value)
                        IsPLCMemoryDataReadDone = true;
                }
            }
        }


        protected virtual string BitMapFileName_EQ { get; set; } = "src\\PLC_Bit_Map_EQ.csv";
        protected virtual string WordMapFileName_EQ { get; set; } = "src\\PLC_Word_Map_EQ.csv";
        protected virtual string BitMapFileName_CIM { get; set; } = "src\\PLC_Bit_Map_CIM.csv";
        protected virtual string WordMapFileName_CIM { get; set; } = "src\\PLC_Word_Map_CIM.csv";

        protected PLC_CONN_INTERFACE plcInterface = PLC_CONN_INTERFACE.MC;
        public virtual List<clsConverterPort> PortDatas { get; set; } = new List<clsConverterPort>();
        internal bool IsPLCDataUpdated = false;
        internal bool IsPLCMemoryDataReadDone = false;
        internal clsIOLOgger _IOLogger;
        public class clsIOLOgger : LoggerBase
        {
            internal clsIOLOgger(RichTextBox? richTextBox, string saveFolder, string subFolderName) : base(richTextBox, saveFolder, subFolderName)
            {
                base.FileNameHeaderDisplay = "IO_";
            }

            public new void Log(string msg, string subFolder = "")
            {
                base.Info(msg, subFolder: subFolder);
            }
            public new void Trace(string msg, string subFolder = "")
            {
                base.Log(msg, LOG_LEVEL.DEBUG, subFolder: subFolder);
            }
        }
        public clsCasstteConverter()
        {

        }
        internal clsCasstteConverter(ConverterEQPInitialOption eqOptions)
        {

            this.Options = eqOptions;
            this.Name = eqOptions.Name;
            _IOLogger = new clsIOLOgger(null, Utility.SysConfigs.Log.SyslogFolder, $"IO_Log/{Name}");
            EQPData = new clsEQPData();

            for (int i = 0; i < eqOptions.Ports.Count; i++)
            {
                var portProp = eqOptions.Ports[i];
                CreatePortInstance(portProp);

            }
            this.converterType = eqOptions.ConverterType;
            this.index = eqOptions.DeviceId;
            LoadPLCMapData();
            this.mainGUI = (UscCasstteConverter)eqOptions.mainUI;
            this.mainGUI.casstteConverter = this;
            PortModbusServersActive();
            EQPInterfaceClockMonitor();
            CIMInterfaceClockUpdate();
            PLCMemorySyncTask();
            DataSyncTask();
            RegistMemoryAddressValuesChangedEvent();
        }

        protected virtual void CreatePortInstance(clsPortProperty portProp)
        {
            PortDatas.Add(new clsConverterPort(portProp, this));
        }

        protected void RegistMemoryAddressValuesChangedEvent()
        {
            foreach (var item in LinkBitMap)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }

            foreach (var item in LinkWordMap)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        protected virtual void Item_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            clsMemoryAddress add = (clsMemoryAddress)sender;
            if (add == null)
                return;

            var owner_str = add.EOwner == clsMemoryAddress.OWNER.CIM ? "CIM/AGVS" : "EQ";
            try
            {
                if (add.EScope == EQ_SCOPE.PORT1 || add.EScope == EQ_SCOPE.PORT2)
                {
                    var portID = add.EScope == EQ_SCOPE.PORT1 ? 0 : 1;
                    var port = PortDatas.FirstOrDefault(p => p.Properties.PortNo == portID);
                    var portName = port == null ? "" : port.PortName;
                    _IOLogger.Log($"{Name}-{portName} -->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]", portName);
                }
                else
                {
                    _IOLogger.Log($"{Name} -->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]", Name);
                }
            }
            catch (Exception ex)
            {
                _IOLogger.Log(ex.Message);
                _IOLogger.Log($"{Name} -->[{owner_str}]{add.DataName}({add.Address}) Changed to [{add.Value}]", Name);
            }
        }

        protected virtual async void PortModbusServersActive()
        {
            foreach (var item in PortDatas)
            {
                item.ModbusServerActive();
            }
        }


        protected virtual async void EQPInterfaceClockMonitor()
        {
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
                            Utility.SystemLogger.Info($"{Name} EQ Interface Clock Timeout=> ResetEQPHandshakeBits");
                            ResetEQPHandshakeBits();
                            mcInterface.Close();
                            mcInterface.loMCTcpCtrl.Close();
                            await Task.Delay(1000);
                        }
                    }
                    else
                    {
                        AlarmManager.TryRemoveAlarm(ALARM_CODES.ALIVE_CLOCK_EQP_DOWN, Name);
                    }
                    lastInterfaceClock = EQPData.InterfaceClock;
                    await Task.Delay(TimeSpan.FromSeconds(8));
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

        public ConverterEQPInitialOption Options { get; }
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
                bool connected = false;
                connectionState = Common.CONNECTION_STATE.CONNECTING;
                await Task.Delay(1000);
                this.mcInterfaceOptions = mcInterfaceOptions;
                int connRetCode = -1;
                if (plcInterface == PLC_CONN_INTERFACE.MC)
                {
                    connected = await Task.Run(() =>
                    {
                        return mcInterface.Open(mcInterfaceOptions, out connRetCode, enuDataType: clsMC_TCPCnt.enuDataType.ByteArr_02);
                    });
                }
                else
                {
                    try
                    {
                        mxInterface = new CIMComponent.MXCompHandler();
                        connRetCode = mxInterface.Open(MXLogic_Station_Number);
                        connected = connRetCode == 0;
                    }
                    catch (Exception ex)
                    {
                        MxOpenException = ex;
                        MxOpened = false;
                        connected = false;
                    }
                }
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

        private async Task RetryConnectAsync()
        {
            await Task.Delay(1);
            RetryTask = Task.Run(async () =>
            {
                while (!await ActiveAsync(mcInterfaceOptions))
                {
                    await Task.Delay(1000);
                    _plc_IF_WRITE_ret_code = -1;
                    _plc_IF_READ_ret_code = -1;
                }
                _plc_IF_WRITE_ret_code = -1;
                _plc_IF_READ_ret_code = -1;
                RetryTask = null;
            });
        }

        protected virtual void DataSyncTask()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(50);
                    await SyncMemData();
                }
            });
        }


        protected virtual async Task CIMInterfaceClockUpdate()
        {
            _ = Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(4));

                    try
                    {
                        await cimMemoryTableWriteSemLock.WaitAsync();

                        var interfaceClockAddress = LinkWordMap.FirstOrDefault(w => w.EOwner == clsMemoryAddress.OWNER.CIM && w.EProperty == PROPERTY.Interface_Clock);
                        if (interfaceClockAddress != null)
                        {
                            int clock = (int)interfaceClockAddress.Value;
                            int newClock = clock + 1;
                            newClock = newClock == 256 ? 0 : newClock;
                            CIMMemOptions.memoryTable.WriteBinary(interfaceClockAddress.Address, newClock);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        cimMemoryTableWriteSemLock.Release();
                    }
                }

            });
        }
        int _plc_IF_READ_ret_code = -1;
        int _plc_IF_WRITE_ret_code = -1;

        int PLC_IF_READ_Ret_Code
        {
            get => _plc_IF_READ_ret_code;
            set
            {
                if (_plc_IF_READ_ret_code != value)
                {
                    _plc_IF_READ_ret_code = value;
                    if (value != 0)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.PLC_IF_READ_FAIL, $"{Name}({mcInterfaceOptions.RemoteIP}:{mcInterfaceOptions.RemotePort})");
                    }
                }
            }
        }
        int PLC_IF_WRITE_Ret_Code
        {
            get => _plc_IF_WRITE_ret_code;
            set
            {
                if (_plc_IF_WRITE_ret_code != value)
                {
                    _plc_IF_WRITE_ret_code = value;
                    if (value != 0)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.PLC_IF_WRITE_FAIL, $"{Name}({mcInterfaceOptions.RemoteIP}:{mcInterfaceOptions.RemotePort})");
                    }
                }
            }
        }
        internal SemaphoreSlim cimMemoryTableWriteSemLock = new SemaphoreSlim(1, 1);
        protected async Task PLCMemorySyncTask()
        {
            _ = Task.Run(async () =>
             {
                 while (true)
                 {
                     try
                     {
                         await Task.Delay(50);
                         if (_connectionState != Common.CONNECTION_STATE.CONNECTED)
                         {
                             continue;
                         }
                         if (simulation_mode)
                         {
                             await Task.Delay(50);
                             IsPLCMemoryDataReadDone = true;
                             continue;
                         }

                         try
                         {
                             if (monitor)
                             {
                                 if (plcInterface == PLC_CONN_INTERFACE.MC)
                                 {
                                     PLC_IF_WRITE_Ret_Code = mcInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                     PLC_IF_WRITE_Ret_Code = mcInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);



                                     if (PLC_IF_WRITE_Ret_Code == 0)
                                     {
                                         //讀回確認
                                         PLC_IF_READ_Ret_Code = mcInterface.ReadBit(ref CIMMemOptions.memoryTable_read_back, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                         PLC_IF_READ_Ret_Code = mcInterface.ReadWord(ref CIMMemOptions.memoryTable_read_back, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);

                                         PLC_IF_READ_Ret_Code = mcInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                         PLC_IF_READ_Ret_Code = mcInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);
                                         IsPLCMemoryDataReadDone = PLC_IF_READ_Ret_Code == 0;
                                     }

                                 }
                                 else
                                 {
                                     try
                                     {
                                         await cimMemoryTableWriteSemLock.WaitAsync();
                                         PLC_IF_WRITE_Ret_Code = mxInterface.WriteBit(ref CIMMemOptions.memoryTable, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                         PLC_IF_WRITE_Ret_Code = mxInterface.WriteWord(ref CIMMemOptions.memoryTable, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);
                                         if (PLC_IF_WRITE_Ret_Code == 0)
                                         {

                                             //讀回確認
                                             PLC_IF_READ_Ret_Code = mxInterface.ReadBit(ref CIMMemOptions.memoryTable_read_back, CIMMemOptions.bitRegionName, CIMMemOptions.bitStartAddress_no_region, CIMMemOptions.bitSize);
                                             PLC_IF_READ_Ret_Code = mxInterface.ReadWord(ref CIMMemOptions.memoryTable_read_back, CIMMemOptions.wordRegionName, CIMMemOptions.wordStartAddress_no_region, CIMMemOptions.wordSize);

                                             PLC_IF_READ_Ret_Code = mxInterface.ReadBit(ref EQPMemOptions.memoryTable, EQPMemOptions.bitRegionName, EQPMemOptions.bitStartAddress_no_region, EQPMemOptions.bitSize);
                                             PLC_IF_READ_Ret_Code = mxInterface.ReadWord(ref EQPMemOptions.memoryTable, EQPMemOptions.wordRegionName, EQPMemOptions.wordStartAddress_no_region, EQPMemOptions.wordSize);
                                             IsPLCMemoryDataReadDone = PLC_IF_READ_Ret_Code == 0;
                                         }
                                     }
                                     catch (Exception)
                                     {

                                     }
                                     finally
                                     {
                                         cimMemoryTableWriteSemLock.Release();
                                     }
                                 }

                             }
                         }
                         catch (SocketException ex)
                         {
                             Utility.SystemLogger.Error(ex);
                             _connectionState = Common.CONNECTION_STATE.DISCONNECTED;
                             RetryConnectAsync();
                         }
                         catch (Exception ex)
                         {
                             Utility.SystemLogger.Error(ex);
                             continue;
                         }

                     }
                     catch (Exception ex)
                     {
                         Utility.SystemLogger.Error(ex);
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

                string[] addressList = new string[3] { Load_Request_address, Unload_Request_address, Port_Status_Down_address };
                foreach (var address in addressList)
                {
                    try
                    {
                        var oristate = EQPMemOptions.memoryTable.ReadOneBit(address);
                        if (oristate)
                        {
                            EQPMemOptions.memoryTable.WriteOneBit(address, false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Utility.SystemLogger.Error(ex);
                    }
                }
            }
        }

        protected virtual async Task SyncMemData()
        {
            try
            {
                var cimMap = simulation_mode || Debugger.IsAttached ? CIMMemOptions.memoryTable : CIMMemOptions.memoryTable_read_back;
                var eqMap = EQPMemOptions.memoryTable;

                foreach (var item in LinkWordMap)
                {

                    if (item.EOwner == clsMemoryAddress.OWNER.EQP)
                    {
                        item.Value = eqMap.ReadBinary(item.Address);
                    }
                    else
                    {
                        item.Value = cimMap.ReadBinary(item.Address);
                    }
                }
                foreach (var item in LinkBitMap)
                {

                    if (item.EOwner == clsMemoryAddress.OWNER.EQP)
                    {
                        item.Value = eqMap.ReadOneBit(item.Address);
                    }
                    else
                    {
                        item.Value = cimMap.ReadOneBit(item.Address);
                    }
                }
                PLCMemoryDatatToEQDataDTO();

            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error("SyncMemData Function Exception Happen", ex);
                throw ex;
            }
        }
        protected virtual void PLCMemoryDatatToEQDataDTO()
        {
            bool IsSimulation = Debugger.IsAttached;
            try
            {
                //EQP 
                try
                {

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

                }
                catch (Exception ex)
                {

                }
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
                        if (Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 && Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                            Utility.SystemLogger.Error(ex.Message, ex);
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

                        EQPORT.agv_handshake_modbus_master?.StoreEQOutpus(new bool[] { EQPORT.L_REQ, EQPORT.U_REQ, EQPORT.EQ_READY, EQPORT.EQ_BUSY });

                    }
                    catch (Exception ex)
                    {
                        if (Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 && Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                            Utility.SystemLogger.Error(ex.Message, ex);
                    }

                    EQPORT.LoadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Load_Request).Value;
                    EQPORT.UnloadRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Unload_Request).Value;
                    //EQPORT.PortExist = IsSimulation ? EQPORT.Properties.IsInstalled : (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                    EQPORT.PortExist = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Exist).Value;
                    bool port_status_down = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Status_Down).Value;
                    EQPORT.PortStatusDown = port_status_down;

                    EQPORT.LD_UP_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_UP_POS).Value;
                    EQPORT.LD_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.LD_DOWN_POS).Value;

                    EQPORT.CarrierWaitINSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitIn_System_Request).Value;
                    EQPORT.CarrierWaitOUTSystemRequest = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_WaitOut_System_Report).Value;
                    EQPORT.CarrierRemovedCompletedReport = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Carrier_Removed_Completed_Report).Value;
                    EQPORT.Port_Mode_Change_Accept = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Change_Accept).Value;
                    EQPORT.Port_Mode_Changed_Refuse = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Refuse).Value;

                    try
                    {

                        EQPORT.TB_DOWN_POS = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.TB_DOWN_POS).Value;
                        EQPORT.Port_Mode_Changed_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Mode_Changed_Report).Value;
                        EQPORT.Port_Disabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Disabled_Report).Value;
                        EQPORT.Port_Enabled_Report = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Port_Enabled_Report).Value;
                        EQPORT.DoorOpened = (bool)LinkBitMap.First(f => f.EScope == port && f.EProperty == PROPERTY.Door_Opened).Value;
                    }
                    catch (Exception ex)
                    {
                        if (Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 && Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                            Utility.SystemLogger.Error(ex.Message, ex);

                    }
                    //EQP word data


                    UpdatePortType(port, EQPORT);
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
                        UPdateCarrierIDFromMemeoryTable(EQPORT);
                        //EQPORT.WIPINFO_BCR_ID = IsSimulation ? EQPORT.Properties.PreviousOnPortID : EQPORT.GetWIPIDFromMem();
                    }
                    catch (Exception ex)
                    {
                        if (Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 && Utility.SysConfigs.Project != Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                            Utility.SystemLogger.Error(ex.Message, ex);
                    }
                }
                IsPLCDataUpdated = IsPLCMemoryDataReadDone == true;
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error(ex.Message, ex);
            }

        }

        protected virtual void UpdatePortType(EQ_SCOPE port, clsConverterPort EQPORT)
        {
            EQPORT.PortType = (int)LinkWordMap.First(f => !f.IsCIMUse && f.EScope == port && f.EProperty == PROPERTY.Port_Type_Status).Value;
        }

        protected virtual void UPdateCarrierIDFromMemeoryTable(clsConverterPort EQPORT)
        {
            EQPORT.WIPINFO_BCR_ID = EQPORT.GetWIPIDFromMem();
        }

        /// <summary>
        /// 開啟模擬器
        /// </summary>
        internal void OpenSimulatorUI()
        {
            simulation_mode = true;
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
                Utility.SystemLogger.Error(ex.Message, ex);
                MessageBox.Show($"LoadPLCMapData Error\r\n{ex.Message}\r\n{ex.StackTrace}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                EQ_NAMES EQName = EQ_NAMES.TS_1;
                try
                {
                    EQName = lineSplited[8] == "" ? EQ_NAMES.Unkown : Enum.GetValues(typeof(EQ_NAMES)).Cast<EQ_NAMES>().First(E => E.ToString() == lineSplited[8]);
                }
                catch (Exception)
                {
                    EQName = EQ_NAMES.Unkown;
                }

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
                    EQ_Name = EQName
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

        internal void InitPortStatus()
        {
            PortDatas.ForEach(port =>
             {
                 if (port.PortExist && port.Properties.IsInstalled)
                 {
                     if (port.IsBCR_READ_ERROR())
                         port.InstallCarrier(port.CSTIDOnPort);
                     else
                     {
                         port.InstallCarrier(port.WIPINFO_BCR_ID);
                     }
                 }
                 else if (!port.PortExist && port.Properties.IsInstalled)
                 {
                     port.RemoveCarrier(port.Properties.PreviousOnPortID, false);
                 }
                 Utility.SystemLogger.Warning($"{port.PortName} Port Install Status initialize done.");
             });
        }
    }
}
