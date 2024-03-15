using AGVSystemCommonNet6.Log;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Text.Json.Serialization;
using System.Windows.Forms.Design;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsAGVSData;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using Item = Secs4Net.Item;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort : IModbusHSable, INotifyPropertyChanged
    {
        public static event EventHandler<clsConverterPort> OnWaitInReqRaiseButStatusError;
        public clsConverterPort()
        {
        }

        public clsConverterPort(clsPortProperty property, clsCasstteConverter converterParent)
        {
            this.Properties = property;
            this.EQParent = converterParent;

            AGVSignals = new clsHS_Status_Signals();
            AGVSignals.OnValidSignalActive += AGVSignals_OnValidSignalActive;
            SECSState.OnMCSOnlineRemote += SECSState_OnMCSOnlineRemote;
        }
        public enum EQ_PORT_LD_STATE
        {
            Load,
            Unload,
            Busy
        }

        public EQ_PORT_LD_STATE PortStateSimulation { get; set; } = EQ_PORT_LD_STATE.Busy;
        public clsCasstteConverter EQParent { get; internal set; }

        public clsPortProperty Properties = new clsPortProperty();
        private IO_MODE _IOSignalMode = IO_MODE.FromIOModule;
        public IO_MODE IOSignalMode
        {
            get => _IOSignalMode;
            set
            {
                _IOSignalMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsIOSimulating"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnloadRequest"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadRequest"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));

            }
        }
        internal Stopwatch wait_in_timer = new Stopwatch();
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;
        /// <summary>
        /// 當CIM拒絕轉換架Wait out請求事件
        /// </summary>
        public event EventHandler<clsConverterPort> OnWaitOutRefuseByCIM;
        public event PropertyChangedEventHandler? PropertyChanged;

        public string PortNameWithEQName => EQParent.Name + $"-[{Properties.PortID}]";
        public string EqName => EQParent.Name;

        public string PortName => Properties.PortID;
        public string portNoName => $"PORT{Properties.PortNo + 1}";

        public string ModbusIP => Properties.ModbusServer_IP;
        public int ModbusPort => Properties.ModbusServer_PORT;
        public string ModbusHost => $"{ModbusIP}:{ModbusPort}";

        public bool IsIOSimulating => IOSignalMode == IO_MODE.FromCIMSimulation;

        public virtual PortUnitType EPortType => Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(etype => (int)etype == _PortType);

        public string StatusMemStartAddress => PortEQBitAddress.Count == 0 ? "" : PortEQBitAddress.First(kp => kp.Key == PROPERTY.Load_Request).Value;

        internal Dictionary<PROPERTY, string> PortCIMBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.FindAll(a => a.EProperty != PROPERTY.Unknown).ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        internal Dictionary<PROPERTY, string> PortCIMWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName);
                return portAddress.FindAll(a => a.EProperty != PROPERTY.Unknown).ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        internal Dictionary<PROPERTY, string> PortEQBitAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.EProperty != PROPERTY.Unknown);
                return portAddress.FindAll(a => a.EProperty != PROPERTY.Unknown).ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        internal Dictionary<PROPERTY, string> PortEQWordAddress
        {
            get
            {
                List<clsMemoryAddress> portAddress = EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName);
                return portAddress.FindAll(a => a.EProperty != PROPERTY.Unknown).ToDictionary(ad => ad.EProperty, ad => ad.Address);
            }
        }

        internal List<clsMemoryAddress> EQModbusLinkBitAddress => EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        internal List<clsMemoryAddress> CIMModbusLinkBitAddress => EQParent.LinkBitMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        internal List<clsMemoryAddress> EQModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        internal List<clsMemoryAddress> CIMModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.Link_Modbus_Register_Number != -1);
        protected virtual CIMComponent.MemoryTable VirtualMemoryTable => EQParent.CIMMemOptions.memoryTable;


        internal clsMemoryAddress load_request_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.Load_Request);
        internal clsMemoryAddress unload_request_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.Unload_Request);
        internal clsMemoryAddress port_status_down_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.Port_Status_Down);
        internal clsMemoryAddress ld_up_pose_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.LD_UP_POS);
        internal clsMemoryAddress ld_down_pose_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.LD_DOWN_POS);
        internal clsMemoryAddress port_exist_address => EQModbusLinkBitAddress.FirstOrDefault(a => a.EProperty == Enums.PROPERTY.Port_Exist);


        internal bool IsLoadHSRunning
        {
            get
            {
                return AGVSignals.AnySignalON() && L_REQ;
            }
        }
        internal bool IsUnloadHSRunning
        {
            get
            {
                return AGVSignals.AnySignalON() && U_REQ;
            }
        }

        public clsHS_Status_Signals AGVSignals { get; set; }

        public bool ReadyStatus { get; set; } = false;
        private bool _LoadRequest = false;
        private bool _UnloadRequest = false;
        private bool _EQP_Status_Down = false;
        private bool _PortStatusDown = false;
        private bool _LD_UP_POS = false;
        private bool _LD_DOWN_POS = false;
        public bool LoadRequest
        {
            get => (bool)(IsIOSimulating ? load_request_address.ControlValue : _LoadRequest);
            set
            {
                if (_LoadRequest != value)
                {
                    _LoadRequest = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadRequest"));
                }
            }

        }
        public bool UnloadRequest
        {
            get => (bool)(IsIOSimulating ? unload_request_address.ControlValue : _UnloadRequest);
            set
            {
                if (_UnloadRequest != value)
                {
                    _UnloadRequest = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnloadRequest"));
                }
            }

        }
        private bool _PortExist = false;
        public bool PortExist
        {
            get => (bool)(IsIOSimulating ? port_exist_address.ControlValue : _PortExist);
            set
            {
                if (_PortExist != value)
                {
                    _PortExist = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortExist"));

                }
            }
        }

        public bool PortStatusDown
        {
            get => (bool)(IsIOSimulating ? port_status_down_address.ControlValue : _PortStatusDown);
            set
            {
                if (_PortStatusDown != value)
                {
                    _PortStatusDown = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));

                }
            }
        }

        public bool LD_UP_POS
        {
            get => (bool)(IsIOSimulating ? ld_up_pose_address.ControlValue : _LD_UP_POS);
            set
            {
                if (_LD_UP_POS != value)
                {
                    _LD_UP_POS = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LD_UP_POS"));

                }
            }
        }

        public bool LD_DOWN_POS
        {
            get => (bool)(IsIOSimulating ? ld_down_pose_address.ControlValue : _LD_DOWN_POS);
            set
            {
                if (_LD_DOWN_POS != value)
                {
                    _LD_DOWN_POS = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LD_DOWN_POS"));

                }
            }
        }

        public bool EQP_Status_Run { get; set; } = false;
        public bool EQP_Status_Idle { get; set; } = false;
        public bool EQP_Status_Down
        {
            get => _EQP_Status_Down;
            set
            {
                if (_EQP_Status_Down != value)
                {
                    _EQP_Status_Down = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EQP_Status_Down"));
                }
            }

        }
        private bool _L_REQ = false;
        public bool L_REQ
        {
            get => _L_REQ;
            set
            {
                if (_L_REQ != value)
                {
                    if (!value & !AGV_COMPT & AGV_VALID)
                    {
                        Utility.SystemLogger.Warning($"{PortName}->L_REQ OFF 但AGV_COMPT尚未ON!");
                    }
                    _L_REQ = value;

                }
            }
        }
        private bool _U_REQ = false;
        public bool U_REQ
        {
            get => _U_REQ;
            set
            {
                if (_U_REQ != value)
                {
                    if (!value & !AGV_COMPT & AGV_VALID)
                    {
                        Utility.SystemLogger.Warning($"{PortName}->U_REQ OFF 但AGV_COMPT尚未ON!");
                    }
                    _U_REQ = value;
                }
            }
        }
        private bool _EQ_READY = false;
        public bool EQ_READY
        {
            get => _EQ_READY;
            set
            {
                if (_EQ_READY != value)
                {
                    if (!value)
                    {
                        if (!AGV_COMPT & AGV_VALID)
                        {
                            Utility.SystemLogger.Warning($"{PortName}->L_REQ OFF 但AGV_COMPT尚未ON!");
                        }
                        Utility.SystemLogger.Info($"{PortName}->EQ_READY OFF => 交握結束");
                        Task.Run(async () =>
                        {
                            PORT_Change_Out_CancelTokenSource = await RequestEQPortChangeToOUTPUT();
                        });

                    }
                    else
                    {
                        Utility.SystemLogger.Info($"{PortName}->EQ_READY ON => EQ允許AGV侵入");

                        if (PORT_Change_Out_CancelTokenSource != null && !PORT_Change_Out_CancelTokenSource.IsCancellationRequested)
                        {
                            PORT_Change_Out_CancelTokenSource.Cancel();
                            Utility.SystemLogger.Warning($"{PortName}->Port Changed to OUTPUT Process Cancel Request raised");
                        }
                    }
                    _EQ_READY = value;
                }
            }
        }


        private bool _EQ_BUSY = false;
        public bool EQ_BUSY
        {
            get => _EQ_BUSY;
            set
            {
                if (_EQ_BUSY != value)
                {
                    _EQ_BUSY = value;
                    if (!_EQ_BUSY && Utility.SysConfigs.CIMHandshakingWithAGVWhenAGV_READY_EQ_BUSY_Waiting_interlock) //ON=>OFF
                    {
                        EQHandshakeInterLockMonitor();
                    }
                }
            }
        }


        public bool UP_READY { get; set; } = false;
        public bool LOW_READY { get; set; } = false;
        public bool Manual_Load_Complete { get; set; } = false;
        public bool Manual_UnLoad_Complete { get; set; } = false;


        public int PortModeStatus { get; set; }

        public int AGVSConnectStatus { get; set; }

        public int RackModeRequest { get; set; }
        public int PortModeRequest { get; set; }

        public int WIPInfo_BCR_ID_1 { get; set; }
        public int WIPInfo_BCR_ID_2 { get; set; }
        public int WIPInfo_BCR_ID_3 { get; set; }
        public int WIPInfo_BCR_ID_4 { get; set; }
        public int WIPInfo_BCR_ID_5 { get; set; }
        public int WIPInfo_BCR_ID_6 { get; set; }
        public int WIPInfo_BCR_ID_7 { get; set; }
        public int WIPInfo_BCR_ID_8 { get; set; }
        public int WIPInfo_BCR_ID_9 { get; set; }
        public int WIPInfo_BCR_ID_10 { get; set; }

        public DateTime CarrierInstallTime { get; private set; } = DateTime.Now;
        public AUTO_MANUAL_MODE EPortAutoStatus
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(AUTO_MANUAL_MODE)).Cast<AUTO_MANUAL_MODE>().First(en => Port_Auto_Manual_Mode_Status == (int)en);

                }
                catch (Exception)
                {
                    return AUTO_MANUAL_MODE.Unknown;
                }
            }
        }

        public string _WIPINFO_BCR_ID = "";
        public DateTime WIPUPdateTime { get; set; } = DateTime.MinValue;
        internal bool IsBCR_READ_ERROR()
        {
            bool IsErrorRead = _WIPINFO_BCR_ID.Contains("ERROR");
            if (IsErrorRead)
                Utility.SystemLogger.Info($"TS Barcode Read Fail. {_WIPINFO_BCR_ID} Is Error");
            return IsErrorRead;
        }
        public string CSTID_From_TransferCompletedReport = "";
        public string CSTIDOnPort = "";
        private string TUNID = "";
        private bool BCRRetryTriggeringFlag = false;
        public string WIPINFO_BCR_ID
        {
            get => _WIPINFO_BCR_ID;
            set
            {
                if (_WIPINFO_BCR_ID != value)
                {
                    _WIPINFO_BCR_ID = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WIPINFO_BCR_ID"));

                    if (value != "")
                    {
                        string thisPortDUID = string.Empty;
                        bool isDUIDHappen = JudgeDUCSTORNOT(value, out var portsHasSameID);
                        if (isDUIDHappen)
                        {
                            SetDUID(portsHasSameID, out thisPortDUID);
                        }
                        Utility.SystemLogger.Info($"Port {PortName} BCR ID Updated = {_WIPINFO_BCR_ID}");
                        WIPUPdateTime = DateTime.Now;
                        string cst = string.Empty;
                        if (IsBCR_READ_ERROR())
                        {
                            TUNID = CreateTUNID();
                            cst = TUNID;
                        }
                        else
                            cst = (isDUIDHappen ? thisPortDUID : value);
                        InstallCarrier(cst + "");
                    }
                    else
                    {
                        BCRRetryTriggeringFlag = PortExist;
                        Utility.SystemLogger.Info($"Port {PortName} BCR ID Clear-ON PORT={CSTIDOnPort}");
                        RemoveCarrier(CSTIDOnPort + "");
                    }
                }
            }
        }


        #region AGV交握訊號

        private bool _AGV_VALID = false;
        private bool _AGV_READY = false;
        private bool _AGV_TR_REQ = false;
        private bool _AGV_BUSY = false;
        private bool _AGV_COMPT = false;
        private bool _To_EQ_Up = false;
        private bool _To_EQ_Low = false;
        private bool _CMD_Reserve_Up = false;
        private bool _CMD_Reserve_Low = false;

        public bool AGV_VALID
        {
            get => _AGV_VALID;
            set
            {
                if (_AGV_VALID != value)
                {

                    _AGV_VALID = value;
                    LogAGVHandshakeSignalChange("AGV_VALID", value);
                    if (value)
                    {
                        Utility.SystemLogger.Info($"{PortName}->AGV_VALID ON => AGV與設備交握 嘗試侵入設備");
                    }
                }
            }
        }

        public bool AGV_READY
        {
            get => _AGV_READY;
            set
            {
                if (_AGV_READY != value)
                {
                    _AGV_READY = value;
                    LogAGVHandshakeSignalChange("AGV_READY", value);
                }
            }
        }
        public bool AGV_TR_REQ
        {
            get => _AGV_TR_REQ;
            set
            {
                if (_AGV_TR_REQ != value)
                {
                    _AGV_TR_REQ = value;
                    LogAGVHandshakeSignalChange("AGV_TR_REQ", value);
                }
            }
        }
        public bool AGV_BUSY
        {
            get => _AGV_BUSY;
            set
            {
                if (_AGV_BUSY != value)
                {
                    _AGV_BUSY = value;
                    LogAGVHandshakeSignalChange("AGV_BUSY", value);
                }
            }
        }
        public bool AGV_COMPT
        {
            get => _AGV_COMPT;
            set
            {
                if (_AGV_COMPT != value)
                {
                    _AGV_COMPT = value;
                    LogAGVHandshakeSignalChange("AGV_COMPT", value);
                }
            }
        }

        public bool To_EQ_UP
        {
            get => _To_EQ_Up;
            set
            {
                if (_To_EQ_Up != value)
                {
                    _To_EQ_Up = value;
                    LogAGVHandshakeSignalChange("To_EQ_UP", value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("To_EQ_UP"));
                }
            }
        }

        public bool To_EQ_Low
        {
            get => _To_EQ_Low;
            set
            {
                if (_To_EQ_Low != value)
                {
                    _To_EQ_Low = value;
                    LogAGVHandshakeSignalChange("To_EQ_Low", value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("To_EQ_Low"));
                }
            }
        }

        public bool CMD_Reserve_Up
        {
            get => _CMD_Reserve_Up;
            set
            {
                if (_CMD_Reserve_Up != value)
                {
                    _CMD_Reserve_Up = value;
                    LogAGVHandshakeSignalChange("CMD_Reserve_Up", value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CMD_Reserve_Up"));
                }
            }
        }

        public bool CMD_Reserve_Low
        {
            get => _CMD_Reserve_Low;
            set
            {
                if (_CMD_Reserve_Low != value)
                {
                    _CMD_Reserve_Low = value;
                    LogAGVHandshakeSignalChange("CMD_Reserve_Low", value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CMD_Reserve_Low"));

                }
            }
        }

        #endregion




        public async Task ModbusServerActive()
        {
            await Task.Delay(1);

            if (Properties.AGVHandshakeModbusGatewayActive)
                ActiveAGVHSModbusGateway(out var errmrMsg);

            if (Properties.ModbusServer_Enable)
            {
                try
                {
                    if (await BuildModbusTCPServer(new frmModbusTCPServer()))
                    {
                        Utility.SystemLogger.Info($"ModbusTcp Server-0.0.0.0:{modbus_server.Port} is serving.", false);
                        SyncModbusDataWorker();
                    }
                    else
                    {
                        Utility.SystemLogger.Warning($"ModbusTcp Server-0.0.0.0:{modbus_server.Port} build FAIL");
                    }
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error(ex);
                }
            }
        }


        public class clsAGVHandshakeState
        {
            public bool AGV_VALID { get; set; }
            public bool AGV_TR_REQ { get; set; }
            public bool AGV_BUSY { get; set; }
            public bool AGV_READY { get; set; }
            public bool AGV_COMPT { get; set; }
        }
        internal clsAGVHandshakeState agv_hs_status = new clsAGVHandshakeState();

        internal void RaiseStatusIOChangeInvoke()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LoadRequest"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UnloadRequest"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PortStatusDown"));
        }
        private void AGVSignals_OnValidSignalActive(object? sender, EventArgs e)
        {
            OnValidSignalActive?.Invoke(this, this);
        }

        private void SetDUID(IEnumerable<clsConverterPort> portsHasSameID, out string thisPortDUID)
        {
            CSTIDOnPort = thisPortDUID = CreateDUID();
            Task.Factory.StartNew(async () =>
            {
                foreach (var port in portsHasSameID)
                {
                    var uiid = CreateDUID();
                    Utility.SystemLogger.Info($"Try Change {port.PortName} to DUID={uiid}");
                    await port.InstallCarrier(uiid);
                }
            });
        }

        private bool JudgeDUCSTORNOT(string value, out IEnumerable<clsConverterPort> doubleUIDPorts)
        {
            doubleUIDPorts = null;
            doubleUIDPorts = DevicesManager.GetAllPorts().Where(port => port.PortName != PortName).Where(port => port.CSTIDOnPort == value);
            return doubleUIDPorts.Any();
        }

        private static int TUNIDLFOW
        {
            get => Utility.SysConfigs.TUNFlowNumberUsed;
            set
            {
                Utility.SysConfigs.TUNFlowNumberUsed = value;
                Utility.SaveConfigs();
            }
        }
        private static int DUIDLFOW
        {
            get => Utility.SysConfigs.DUFlowNumberUsed;
            set
            {
                Utility.SysConfigs.DUFlowNumberUsed = value;
                Utility.SaveConfigs();
            }
        }
        private string CreateTUNID()
        {
            var unid = $"{Utility.SysConfigs.UnknowCargoIDHead}{TUNIDLFOW.ToString("D5")}";
            if (Debugger.IsAttached)
            {
                Utility.SystemLogger.Info($"UNID={unid}");
            }
            TUNIDLFOW += 1;
            if (TUNIDLFOW >= int.MaxValue)
            {
                TUNIDLFOW = 1;
            }
            return unid;

        }

        private string CreateDUID()
        {
            var duid = $"DU{DUIDLFOW.ToString("D5")}";
            if (Debugger.IsAttached)
            {
                Utility.SystemLogger.Info($"UNID={duid}");
            }
            DUIDLFOW += 1;
            if (DUIDLFOW >= int.MaxValue)
            {
                DUIDLFOW = 0;
            }
            return duid;

        }

        private async void SECSState_OnMCSOnlineRemote(object? sender, EventArgs e)
        {

            if (!IsCarrierWaitInQueuing)
            {
                Utility.SystemLogger.Info($"SECS Online Remote_No Carrier Wait In ");
                return;
            }

            //檢查在席
            if (!PortExist)
            {
                Utility.SystemLogger.Info($"Carrier Wait In But Carrier Not Exist");
                return;
            }
            //檢查ID
            if (WIPINFO_BCR_ID == "" | IsBCR_READ_ERROR())
            {
                if (IsBCR_READ_ERROR())
                    Utility.SystemLogger.Info($"Carrier Wait In and Carrier Exist But Carrier ID Is Empty");
                else
                    Utility.SystemLogger.Info($"Carrier Wait In and Carrier Exist But Carrier ID Read Fail");
                return;
            }

            //檢查LOAD/UNLOAD REQUEST 訊號
            if (!await WaitLoadUnloadRequestON())
            {
                Utility.SystemLogger.Info($"Carrier Wait In But UNLOAD REQUEST  OFF");
                return;
            }

            Utility.SystemLogger.Info($"Carrier Wait In Report When ONLINE REMOTE. ");
            bool ret = await SecsEventReport(CEID.CarrierWaitIn);
            Utility.SystemLogger.Info($"Carrier Wait In Report When ONLINE REMOTE => {(ret ? "SUCCESS" : "FAIL")} ");
            IsCarrierWaitInQueuing = false;

        }

        internal async Task RemoveCarrier(string cst_id, bool checkPortType = true)
        {
            UpdateModbusBCRReport("", isClearBCR: true);
            Properties.IsInstalled = false;
            Properties.CarrierInstallTime = DateTime.MinValue;
            DevicesManager.SaveDeviceConnectionOpts();
            Utility.SystemLogger.Info($"{PortName}-Remove Carrier_{cst_id}");
            //要上報MCS的條件 
            //1. 在設定檔中有設定需要判斷OUTPUT 且當下為OUTPUT
            //2. 在設定檔中有設定不需要判斷OUTPUT 
            if (Properties.NeverReportCarrierRemove)
            {
                Utility.SystemLogger.Warning($"[{PortName}]Carrier Remove Event not Report to MCS ,because 'NeverReportCarrierRemove' setting is actived.");
                return;
            }
            if (checkPortType == false || (!Properties.RemoveCarrierMCSReportOnlyInOUTPUTMODE || (Properties.RemoveCarrierMCSReportOnlyInOUTPUTMODE & EPortType == PortUnitType.Output)))
            {
                Utility.SystemLogger.Info($"[{PortName}] Carrier removed Report to MCS Start");
                bool remove_reported = await SecsEventReport(CEID.CarrierRemovedCompletedReport, cst_id + "");
                Utility.SystemLogger.Info($"[{PortName}] Carrier removed Report to MCS Result = {(remove_reported ? "Success" : "Fail")}");
            }
            else
            {
                Utility.SystemLogger.Warning($"[{PortName}] BCR ID Clear but Port Type ={EPortType}, Carrier removed not REPORT to MCS");
            }

            if (Properties.IsConverter)
            {
                _ = Task.Run(async () =>
                {
                    (bool confirm, string response, string errorMsg) result = await API.KGAGVS.RackStatusAPI.DeleteCSTID(Properties.NameInAGVS, 1, cst_id);
                    Utility.SystemLogger.Info($"Delete CST ID API請求結果={result.ToJson()}");
                });
            }
        }
        internal async Task InstallCarrier(string cst_id)
        {
            if (!PortExist)
                return;



            if (Properties.IsInstalled && cst_id != Properties.PreviousOnPortID)
            {
                await RemoveCarrier(Properties.PreviousOnPortID);
            }

            if (Properties.IsConverter)
            {
                _ = Task.Run(async () =>
                {
                    (bool confirm, string response, string errorMsg) result = await API.KGAGVS.RackStatusAPI.AddCSTID(Properties.NameInAGVS, 1, cst_id);
                    Utility.SystemLogger.Info($"Add CST ID API請求結果 ={result.ToJson()}");
                });
            }
            Properties.PreviousOnPortID = cst_id;
            CSTIDOnPort = cst_id + "";
            Properties.IsInstalled = true;
            Properties.CarrierInstallTime = DateTime.Now;
            DevicesManager.SaveDeviceConnectionOpts();
            Utility.SystemLogger.Info($"{PortName}-Install Carrier_{cst_id}");
            UpdateModbusBCRReport(cst_id);
            await SecsEventReport(CEID.CarrierInstallCompletedReport, cst_id);

        }

        public void UpdateModbusBCRReport(string cst_id_on_port, bool isClearBCR = false)
        {
            try
            {
                Utility.SystemLogger.Info($"{PortName} Update BCR ID to CIM Memory Table");
                clsMemoryAddress? agvs_msg_1_address = EQParent.LinkWordMap.FirstOrDefault(v => Properties.PortNo == 0 ? v.EProperty == PROPERTY.AGVS_MSG_1 : v.EProperty == PROPERTY.AGVS_MSG_17);
                clsMemoryAddress? agvs_msg_download_inedx_address = EQParent.LinkWordMap.FirstOrDefault(v => v.EProperty == PROPERTY.AGVS_MSG_DOWNLOAD_INDEX);
                if (agvs_msg_1_address != null)
                {
                    int[] ascii_bytes = cst_id_on_port.ToASCIIWords();
                    //int[] bcr_id_ints = isClearBCR ? new int[10] : new int[10] { WIPInfo_BCR_ID_1, WIPInfo_BCR_ID_2, WIPInfo_BCR_ID_3, WIPInfo_BCR_ID_4, WIPInfo_BCR_ID_5, WIPInfo_BCR_ID_6, WIPInfo_BCR_ID_7, WIPInfo_BCR_ID_8, WIPInfo_BCR_ID_9, WIPInfo_BCR_ID_10 };
                    int[] bcr_id_ints = isClearBCR ? new int[10] : ascii_bytes;
                    ReportBCRToAGVS(agvs_msg_1_address, agvs_msg_download_inedx_address, bcr_id_ints);
                }
                else
                {
                    Utility.SystemLogger.Info($"{PortName} Update BCR ID to CIM Memory Table");
                }
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error(ex);
                AlarmManager.AddAlarm(ALARM_CODES.BCRID_SYNC_TO_AGVS_WORD_REGION_FAIL, PortName);
            }
        }

        protected virtual void ReportBCRToAGVS(clsMemoryAddress? agvs_msg_1_address, clsMemoryAddress? agvs_msg_download_inedx_address, int[] bcr_id_ints)
        {
            EQParent.CIMMemOptions.memoryTable.WriteWord(agvs_msg_1_address.Address, ref bcr_id_ints);
            int[] vals = new int[1];
            EQParent.CIMMemOptions.memoryTable.ReadWord(agvs_msg_download_inedx_address.Address, 1, ref vals);
            vals[0] = vals[0] == int.MaxValue ? 0 : vals[0] + 1;
            EQParent.CIMMemOptions.memoryTable.WriteWord(agvs_msg_download_inedx_address.Address, ref vals);
        }

        internal string GetWIPIDFromMem()
        {
            List<int> ints = new List<int>() {
                 WIPInfo_BCR_ID_1,
                 WIPInfo_BCR_ID_2,
                 WIPInfo_BCR_ID_3,
                 WIPInfo_BCR_ID_4,
                 WIPInfo_BCR_ID_5,
                 WIPInfo_BCR_ID_6,
                 WIPInfo_BCR_ID_7,
                 WIPInfo_BCR_ID_8,
                 WIPInfo_BCR_ID_9,
                 WIPInfo_BCR_ID_10
                };
            string id = ints.FindAll(i => i != 0).ToASCII();
            return id;
        }

        /// <summary>
        /// Port是否在交握中
        /// </summary>
        public bool IsEQHandshaking => (LoadRequest || UnloadRequest) && (L_REQ || U_REQ);
        public bool IsAGVHandshaking => AGV_VALID && AGV_TR_REQ;
        public bool DoorOpened { get; internal set; }
        public bool TB_DOWN_POS { get; internal set; }


        private bool _CarrierWaitINSystemRequest;
        public bool CarrierWaitINSystemRequest
        {
            get => _CarrierWaitINSystemRequest;
            internal set
            {

                if (value != _CarrierWaitINSystemRequest)
                {
                    _CarrierWaitINSystemRequest = value;
                    if (_CarrierWaitINSystemRequest)
                    {
                        wait_in_timer.Restart();
                        CarrierInstallTime = DateTime.Now;
                        Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(1000);
                            Utility.SystemLogger.Info($"[{PortName}] -Carrier Wait In Request ON , With CST ID＝{CSTIDOnPort}");

                            bool wait_in_accept = false;
                            if (Properties.SecsReport)
                            {

                                if (WIPINFO_BCR_ID != "" && !IsBCR_READ_ERROR() && PortExist)
                                {
                                    if (!SECSState.IsOnline || !SECSState.IsRemote)
                                    {
                                        wait_in_accept = true;
                                        Utility.SystemLogger.Info($"[{PortName}] CIM  Accept  Carrier Wait IN Request first because MCS isn't ONLINE _ REMOTE");
                                        await CarrierWaitInReply(wait_in_accept, 30000);
                                        return;
                                    }

                                    bool mcs_accpet_wait_in = Debugger.IsAttached ? true : await SecsEventReport(CEID.CarrierWaitIn, WIPINFO_BCR_ID);

                                    if (mcs_accpet_wait_in && Properties.CarrierWaitInNeedWaitingS2F41OrS2F49)
                                    {
                                        Utility.SystemLogger.Info($"Wait S2F41 or S2F49 Message reachded and Accepted by AGVs");
                                        wait_in_accept = await WaitTransferTaskDownloaded();
                                        if (wait_in_accept)
                                            Utility.SystemLogger.Info($"[{PortName}] {(AGVsReplyMCSTransferTaskReqFlag ? "S2F49_Transfer" : "S2F41_No_Transfer")} Message reachded!");
                                        Utility.SystemLogger.Info($"[{PortName}] MCS {(wait_in_accept ? "Accept" : "Reject")} Carrier Wait IN Request..");
                                    }
                                    else
                                    {
                                        wait_in_accept = mcs_accpet_wait_in;
                                    }
                                }
                                else
                                {
                                    wait_in_accept = false;
                                    Utility.SystemLogger.Info($"{PortName}-Carrier Wait In Request Reject, Cause: {(!PortExist ? $"No any cargo in Equipment" : $" With CST ID Incorrect , CST ID ＝{WIPINFO_BCR_ID}")}");
                                    AlarmManager.AddWarning(!PortExist ? ALARM_CODES.CARRIER_WAIT_IN_BUT_NO_CARGO_IN_EQ : ALARM_CODES.CARRIER_WAIT_IN_BUT_BCR_ID_IS_EMPTY, Properties.PortID);

                                    OnWaitInReqRaiseButStatusError?.Invoke(this, this);
                                }

                            }
                            else
                                wait_in_accept = true;

                            (bool confirm, ALARM_CODES alarm_code) result = await CarrierWaitInReply(wait_in_accept, 30000);
                            AGVsReplyMCSTransferTaskReqFlag = false; //reset flag
                            if (!wait_in_accept)
                            {
                                await SecsEventReport(CEID.CarrierWaitOut);
                            }

                            if (!result.confirm)
                            {
                                AlarmManager.AddAlarm(result.alarm_code, PortNameWithEQName);
                            }
                            else
                            {
                                Utility.SystemLogger.Info($"[{PortName}] Carrier Wait In HS Finish");
                            }
                        });
                    }
                }
            }
        }


        private bool _CarrierWaitOUTSystemRequest;
        public bool CarrierWaitOUTSystemRequest
        {
            get => _CarrierWaitOUTSystemRequest;
            internal set
            {
                if (value != _CarrierWaitOUTSystemRequest)
                {
                    if (value)
                    {
                        Utility.SystemLogger.Info($"[{PortName}] Carrier Wait out Request bit ON ");
                        bool wait_out_accept = PortExist;
                        if (!wait_out_accept && Properties.SecsReport)
                        {
                            AlarmManager.AddAlarm(ALARM_CODES.CARRIER_WAIT_OUT_BUT_NO_CARGO_IN_EQ, PortName, true);
                            OnWaitOutRefuseByCIM?.Invoke(this, this);
                        }
                        //Secs Report
                        if (SECSState.IsRemote && Properties.SecsReport)
                        {
                            Task.Factory.StartNew(async () =>
                            {
                                await Task.Delay(1000);
                                //要等TransferComplete上報後才報
                                bool transfer_completed_reported = await WaitAGVSTransferCompleteReported();
                                if (transfer_completed_reported && PortExist)
                                {
                                    await Task.Delay(3000);
                                    var isCSTIDMismatch = WIPINFO_BCR_ID != CSTID_From_TransferCompletedReport;
                                    bool IsBCRReadFail = IsBCR_READ_ERROR() || WIPINFO_BCR_ID == "";

                                    if (IsBCRReadFail)//讀取失敗=>報TUN
                                    {
                                        //如果Retry在107 之前完成,最後要清107
                                        if (CSTIDOnPort == CSTID_From_TransferCompletedReport)
                                        {
                                            Utility.SystemLogger.Info($"[{PortName}] BCR Carrier ID Read Fail.  BCR Reader={WIPINFO_BCR_ID}, Carrier Installed Report To MCS  With CST Virtual ID={CSTIDOnPort}");
                                            Utility.SystemLogger.Info($"[{PortName}] [Before Wait out Report To_MCS - BCR ID Read Fail] Remove 107 Carrier ID({CSTIDOnPort}) First");
                                            await RemoveCarrier(CSTIDOnPort + "");
                                            await Task.Delay(100);
                                            var _TUNID = CreateTUNID();
                                            await InstallCarrier(_TUNID);
                                        }
                                    }
                                    else
                                    {
                                        if (isCSTIDMismatch)//讀取成功但與107 Carrier ID不符
                                        {
                                            Utility.SystemLogger.Info($"[{PortName}] Carrier ID Miss match CST ID From Transfer Task = {CSTID_From_TransferCompletedReport}, BCR Reader={WIPINFO_BCR_ID}");
                                            Utility.SystemLogger.Info($"[{PortName}] [Before Wait out Report To_MCS - ID Missmatch] Remove 107 Carrier ID({CSTID_From_TransferCompletedReport}) First");
                                            await RemoveCarrier(CSTID_From_TransferCompletedReport + "");
                                            await Task.Delay(100);
                                            await InstallCarrier(WIPINFO_BCR_ID);
                                        }
                                    }
                                    await Task.Delay(1000);
                                    Utility.SystemLogger.Info($"{PortName}-Carrier Wait Out Report to MCS with CSTID = {CSTIDOnPort}");
                                    await SecsEventReport(CEID.CarrierWaitOut, CSTIDOnPort);
                                    Carrier_TransferCompletedFlag = false;
                                    CarrierInstallTime = DateTime.Now;
                                }
                                if (!PortExist)
                                {
                                    Utility.SystemLogger.Info($"{PortName}-Carrier Wait Out but No Cargo in EQ. Cariier Install and WaitOut doesn't report To MCS");
                                }
                            });
                        }

                        Task.Factory.StartNew(async () =>
                        {
                            Utility.SystemLogger.Info($"[{PortName}] PLC Carrier Wait Out HS Start");
                            try
                            {
                                bool success_hs = await CarrierWaitOutReply(Utility.IsHotRunMode ? true : wait_out_accept, 10000);
                                if (!success_hs)
                                {
                                    Utility.SystemLogger.Info($"[{PortName}] PLC  Carrier Wait  Out HS Error!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Utility.SystemLogger.Info($"[{PortName}] PLC  Carrier Wait  Out HS ex! {ex.Message},{ex.StackTrace}");

                            }
                        });


                    }
                    _CarrierWaitOUTSystemRequest = value;
                }
            }
        }
        public class clsPortChangeToOutState
        {
            public bool IsMCSRemote { get; }

            [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
            public PortUnitType CurrentPortType { get; }
            [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
            public CONVERTER_TYPE EQ_TYPE { get; }
            public bool PortHasCargo { get; }
            public clsPortChangeToOutState(bool IsMCSOnline, PortUnitType CurrentPortType, CONVERTER_TYPE EQ_TYPE, bool PortHasCargo)
            {
                this.IsMCSRemote = IsMCSOnline;
                this.CurrentPortType = CurrentPortType;
                this.EQ_TYPE = EQ_TYPE;
                this.PortHasCargo = PortHasCargo;
            }
            public bool ChangeToOutputAllowed => !(IsMCSRemote || CurrentPortType == PortUnitType.Output || EQ_TYPE == CONVERTER_TYPE.SYS_2_SYS || !PortHasCargo);
        }
        private CancellationTokenSource PORT_Change_Out_CancelTokenSource = null;
        /// <summary>
        /// 要求設備將PORT切換為OUTPUT
        /// </summary>
        /// <returns></returns>
        private async Task<CancellationTokenSource> RequestEQPortChangeToOUTPUT()
        {


            clsPortChangeToOutState PortChgOutPoutCase = new clsPortChangeToOutState(SECSState.IsRemote, EPortType, EQParent.converterType, PortExist);
            if (!PortChgOutPoutCase.ChangeToOutputAllowed)
            {
                Utility.SystemLogger.Info($"[{PortName}] NOT NEED TO Change PORT TYPE to OUTPUT. \r\n-PortChgOutPoutCase:\r\n{PortChgOutPoutCase.ToJson()}");
                return null;
            }

            if (!Properties.AutoChangeToOUTPUTWhenAGVLoadedInOFFLineMode)
            {
                Utility.SystemLogger.Warning($"[{PortName}]  Auto change to OUTPUT mode feature disabled");
                return null;
            }
            CancellationTokenSource portChangCancelCts = new CancellationTokenSource();

            _ = Task.Run(async () =>
            {
                Utility.SystemLogger.Info($"[{PortName}] After Carrier waitout HS done and Now is Local Mode, GPM_CIM Start Request PLC Port Type Change to OUTPUT, State:\r\n{PortChgOutPoutCase.ToJson()}");
                bool plc_accpet = false;
                int cnt = 0;
                while (!plc_accpet)
                {
                    await Task.Delay(100);
                    if (portChangCancelCts.IsCancellationRequested)
                    {
                        portChangCancelCts = null;
                        Utility.SystemLogger.Warning($"P[{PortName}] ORT OUTPUT MODE Request CANCELED");
                        return;
                    }
                    plc_accpet = await ModeChangeRequestHandshake(Utility.IsHotRunMode ? PortUnitType.Input : PortUnitType.Output, "GPM_CIM");
                    Utility.SystemLogger.Info($"[{PortName}] PLC Reject OUTPUT MODE Request. Retry-{cnt}");
                    await Task.Delay(1000);
                    cnt++;
                    if (cnt >= 11)
                    {
                        Utility.SystemLogger.Info($"[{PortName}] Retry times reach 11 ... .Port {PortName} Can't  change to OUTPUT MODE.");
                        break;
                    }
                }
            });
            return portChangCancelCts;
        }

        private bool _CarrierRemovedCompletedReport;
        private bool _CarrierRemovedReportedFlag = false;
        public bool CarrierRemovedCompletedReport
        {
            get => _CarrierRemovedCompletedReport;
            internal set
            {

                if (value != _CarrierRemovedCompletedReport)
                {
                    _CarrierRemovedCompletedReport = value;
                    if (_CarrierRemovedCompletedReport)
                    {
                        Utility.SystemLogger.Info($"[{PortName}] -Carrier Remove Completed HS Start");
                        CarrierRemovedCompletedReply();
                    }
                }
            }
        }
        public bool Port_Mode_Change_Accept { get; internal set; }
        public bool Port_Mode_Changed_Refuse { get; internal set; }
        public bool _Port_Mode_Changed_Report = false;
        public bool Port_Mode_Changed_Report
        {
            get => _Port_Mode_Changed_Report;
            set
            {
                if (_Port_Mode_Changed_Report != value)
                {
                    _Port_Mode_Changed_Report = value;
                    if (_Port_Mode_Changed_Report)
                    {
                        PortTypeChangedReportHandshake();
                    }
                }
            }
        }

        public bool Port_Disabled_Report { get; internal set; }
        private bool _Port_Enabled_Report = false;
        public bool Port_Enabled_Report
        {
            get => _Port_Enabled_Report;
            set
            {
                if (_Port_Enabled_Report != value)
                {
                    if (value)
                        SecsEventReport(CEID.PortInServiceReport);
                    else
                        SecsEventReport(CEID.PortOutOfServiceReport);

                    Properties.InSerivce = value;
                    _Port_Enabled_Report = value;
                }
            }
        }
        public PortUnitType previousPortType = PortUnitType.Input;
        public int Port_Auto_Manual_Mode_Status { get; internal set; }
        private int _PortType = 0;
        /// <summary>
        /// 0: INput , 1: Output , 2: In-Output
        /// </summary>
        public int PortType
        {
            get => _PortType;
            set
            {
                if (_PortType != value)
                {
                    _PortType = value;
                    Utility.SystemLogger.Info($"{PortName} Port Type Change to {EPortType}");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EPortType"));
                    Task.Factory.StartNew(async () =>
                    {
                        try
                        {
                            await Task.Delay(1000);
                            await PortTypeReport();
                        }
                        catch (Exception ex)
                        {
                            Utility.SystemLogger.Error($"[{PortName}] Error Occur when Port Type Changed and Report To MCS", ex);
                        }
                    });
                }


            }
        }

        internal async Task PortTypeReport()
        {
            if (EPortType == PortUnitType.Input || (EPortType == PortUnitType.Input_Output && MCSReservePortType == PortUnitType.Input))
                await SecsEventReport(CEID.PortTypeInputReport);
            if (EPortType == PortUnitType.Output || (EPortType == PortUnitType.Input_Output && MCSReservePortType == PortUnitType.Output))
                await SecsEventReport(CEID.PortTypeOutputReport);
        }
        private bool _EQ_BUSY_CIM_CONTROL = false;
        internal bool EQ_BUSY_CIM_CONTROL
        {
            get => _EQ_BUSY_CIM_CONTROL;
            set
            {
                if (_EQ_BUSY_CIM_CONTROL != value)
                {
                    _EQ_BUSY_CIM_CONTROL = value;
                    Utility.SystemLogger.Warning($"[{PortName}] EQ_BUSY_CIM_CONTROL => [{(value ? "ON" : "OFF")}]");
                }
            }
        }
        private bool _AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING = false;
        internal bool AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING
        {
            get => _AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING;
            set
            {
                if (_AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING != value)
                {
                    _AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING = value;
                    Utility.SystemLogger.Warning($"[{PortName}] AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING => [{(value ? "ON" : "OFF")}]");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void EQHandshakeInterLockMonitor()
        {
            if (!IsEQHandshaking || !IsAGVHandshaking)
                return;

            //監視EQ_BUSY OFF之後，AGV_READY 是否持續ON著等待EQ_BUSY ON
            Task.Factory.StartNew(async () =>
            {
                CancellationTokenSource WaitAGV_READY_OFF = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                while (true)
                {
                    await Task.Delay(10);
                    if (!AGV_READY || !IsEQHandshaking || !IsAGVHandshaking)
                    {
                        return;
                    }

                    if (WaitAGV_READY_OFF.IsCancellationRequested)
                    {
                        WaitingAGV_READY_OFF_Worker();
                        return;
                    }
                }
            });

        }

        private async void WaitingAGV_READY_OFF_Worker()
        {
            Utility.SystemLogger.Warning($"[{PortName}] 因AGV持續等待 EQ_BUSY ON , 但EQ_BUSY已經ON=>OFF，CIM介入");


            bool LD_Pose_Correct = (L_REQ && LD_UP_POS) || (U_REQ && LD_DOWN_POS);
            if (!LD_Pose_Correct)
            {
                Utility.SystemLogger.Warning($"[{PortName}] CIM嘗試介入交握，但設備撈爪位置不正確(Req:{(L_REQ ? "入料" : "出料")}, Loader Pose:{(!LD_UP_POS && !LD_DOWN_POS ? "未知" : LD_UP_POS ? "上位" : "下位")})。");
                return;
            }

            AlarmManager.AddWarning(ALARM_CODES.AGV_READY_EQ_BUSY_INTERLOCK_CIM_SOLUTION, PortName, true);
            AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING = true;
            await Task.Factory.StartNew(async () =>
            {
                EQ_BUSY_CIM_CONTROL = false;

                Utility.SystemLogger.Warning($"[{PortName}] CIM Handshaking with AGV Start. Waiting AGV_READY OFF..");
                while (AGV_READY)
                {
                    await Task.Delay(1000);
                    EQ_BUSY_CIM_CONTROL = true;
                    await Task.Delay(1000);
                    EQ_BUSY_CIM_CONTROL = false;
                    await Task.Delay(3000);
                }
                EQ_BUSY_CIM_CONTROL = AGV_READY_WAITING_EQ_BUSYON_INTER_LOCKING = false;
                if (!IsEQHandshaking | !PortStatusDown | !IsAGVHandshaking)
                {
                    Utility.SystemLogger.Warning($"[{PortName}] Waiting AGV_READY Process end. Because EQ/AGV Handshake is interupted");
                    AlarmManager.AddAlarm(ALARM_CODES.AGV_EQ_Handshake_Fail_AFTER_EQ_BUSY_OFF, PortName, true);
                }
                else
                {
                    Utility.SystemLogger.Warning($"[{PortName}] AGV_READY OFF After EQ_BUSY_CIM_CONTROL bit ON, CIM/AGV Handshake done.");
                }
            });
        }


    }
}
