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
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms.Design;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsAGVSData;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using Item = Secs4Net.Item;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort : IModbusHSable
    {
        public clsConverterPort()
        {
        }

        public clsConverterPort(clsPortProperty property, clsCasstteConverter converterParent)
        {
            this.Properties = property;
            CSTIDOnPort = property.PreviousOnPortID;
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

        public clsCasstteConverter EQParent { get; internal set; }

        public clsPortProperty Properties = new clsPortProperty();
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;
        /// <summary>
        /// 當CIM拒絕轉換架Wait out請求事件
        /// </summary>
        public event EventHandler<clsConverterPort> OnWaitOutRefuseByCIM;
        public string PortNameWithEQName => EQParent.Name + $"-[{Properties.PortID}]";
        public string EqName => EQParent.Name;

        public string PortName => Properties.PortID;
        public string portNoName => $"PORT{Properties.PortNo + 1}";

        public string ModbusIP => Properties.ModbusServer_IP;
        public int ModbusPort => Properties.ModbusServer_PORT;
        public string ModbusHost => $"{ModbusIP}:{ModbusPort}";

        internal PortUnitType EPortType => Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(etype => (int)etype == _PortType);

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
        internal List<clsMemoryAddress> EQModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.EQP && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
        internal List<clsMemoryAddress> CIMModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.Link_Modbus_Register_Number != -1);
        private CIMComponent.MemoryTable VirtualMemoryTable => EQParent.CIMMemOptions.memoryTable;


        public void ModbusServerActive()
        {
            if (Properties.ModbusServer_Enable)
            {
                BuildModbusTCPServer(new frmModbusTCPServer());
                SyncRegisterData();
            }
        }

        private void AGVSignals_OnValidSignalActive(object? sender, EventArgs e)
        {
            OnValidSignalActive?.Invoke(this, this);
        }

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
        public bool LoadRequest { get; set; } = false;
        public bool UnloadRequest { get; set; } = false;
        private bool _PortExist = false;
        public bool PortExist
        {
            get => _PortExist;
            set
            {
                if (_PortExist != value)
                {
                    //Task.Run(() =>
                    //{
                    //    if (value)
                    //        ReportCarrierInstalledToMCS();
                    //    else
                    //        ReportCarrierRemovedCompToMCS();
                    //});
                    _PortExist = value;
                }
            }
        }
        public bool EQP_Status_Run { get; set; } = false;
        public bool EQP_Status_Idle { get; set; } = false;
        public bool EQP_Status_Down { get; set; } = false;
        public bool L_REQ { get; set; } = false;
        public bool U_REQ { get; set; } = false;
        public bool EQ_READY { get; set; } = false;
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
        public string WIPINFO_BCR_ID
        {
            get => _WIPINFO_BCR_ID;
            set
            {
                if (_WIPINFO_BCR_ID != value)
                {
                    _WIPINFO_BCR_ID = value;
                    if (value != "")
                    {
                        Utility.SystemLogger.Info($"Port {PortName} BCR ID Updated = {_WIPINFO_BCR_ID}");
                        WIPUPdateTime = DateTime.Now;
                        TUNID = CreateTUNID();
                        string cst = IsBCR_READ_ERROR() ? TUNID : value;
                        InstallCarrier(cst + "");
                    }
                    else
                    {
                        Utility.SystemLogger.Info($"Port {PortName} BCR ID Clear-ON PORT={CSTIDOnPort}");
                        RemoveCarrier(CSTIDOnPort + "");
                    }
                }
            }
        }
        private int TUNIDLFOW = 1;
        private string CreateTUNID()
        {
            TUNIDLFOW += 1;
            if (TUNIDLFOW >= int.MaxValue)
            {
                TUNIDLFOW = 1;
            }
            return $"TUN032{TUNIDLFOW.ToString("D5")}";

        }
        private async Task RemoveCarrier(string cst_id)
        {
            UpdateModbusBCRReport(true);
            Properties.IsInstalledLastTime = false;
            DevicesManager.SaveDeviceConnectionOpts();
            Utility.SystemLogger.Info($"{PortName}-Remove Carrier_{cst_id}");
            bool remove_reported = await SecsEventReport(CEID.CarrierRemovedCompletedReport, cst_id + "");
        }
        private async Task InstallCarrier(string cst_id)
        {
            if (!PortExist)
                return;

            if (Properties.IsInstalledLastTime && cst_id != Properties.PreviousOnPortID)
            {
                await RemoveCarrier(Properties.PreviousOnPortID);
            }

            Properties.PreviousOnPortID = cst_id;
            CSTIDOnPort = cst_id + "";
            Properties.IsInstalledLastTime = true;
            Properties.CarrierInstallTime = DateTime.Now;
            DevicesManager.SaveDeviceConnectionOpts();
            Utility.SystemLogger.Info($"{PortName}-Install Carrier_{cst_id}");
            UpdateModbusBCRReport();
            await SecsEventReport(CEID.CarrierInstallCompletedReport, cst_id);

        }

        private void UpdateModbusBCRReport(bool isClearBCR = false)
        {
            Utility.SystemLogger.Info($"{PortName} Update BCR ID to CIM Memory Table");
            clsMemoryAddress? agvs_msg_1_address = EQParent.LinkWordMap.FirstOrDefault(v => v.EProperty == PROPERTY.AGVS_MSG_1);
            clsMemoryAddress? agvs_msg_download_inedx_address = EQParent.LinkWordMap.FirstOrDefault(v => v.EProperty == PROPERTY.AGVS_MSG_DOWNLOAD_INDEX);
            if (agvs_msg_1_address != null)
            {
                int[] bcr_id_ints = isClearBCR ? new int[10] : new int[10] { WIPInfo_BCR_ID_1, WIPInfo_BCR_ID_2, WIPInfo_BCR_ID_3, WIPInfo_BCR_ID_4, WIPInfo_BCR_ID_5, WIPInfo_BCR_ID_6, WIPInfo_BCR_ID_7, WIPInfo_BCR_ID_8, WIPInfo_BCR_ID_9, WIPInfo_BCR_ID_10 };
                EQParent.CIMMemOptions.memoryTable.WriteWord(agvs_msg_1_address.Address, ref bcr_id_ints);

                //Update Report Index(+1)
                int[] vals = new int[1];
                EQParent.CIMMemOptions.memoryTable.ReadWord(agvs_msg_download_inedx_address.Address, 1, ref vals);
                vals[0] = vals[0] == int.MaxValue ? 0 : vals[0] + 1;
                EQParent.CIMMemOptions.memoryTable.WriteWord(agvs_msg_download_inedx_address.Address, ref vals);
                //Update Report Index(+1)---END
            }
            else
            {
                Utility.SystemLogger.Info($"{PortName} Update BCR ID to CIM Memory Table");
            }
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

        public bool EQ_BUSY { get; internal set; }
        public bool PortStatusDown { get; set; }
        public bool LD_UP_POS { get; internal set; }
        public bool LD_DOWN_POS { get; internal set; }
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
                        CarrierInstallTime = DateTime.Now;
                        Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(1000);
                            Utility.SystemLogger.Info($"{PortName}-Carrier Wait In Request ON , With CST ID＝{CSTIDOnPort}");
                            bool wait_in_accept = false;
                            if (WIPINFO_BCR_ID != "" && !IsBCR_READ_ERROR() && PortExist)
                            {
                                if (!SECSState.IsOnline || !SECSState.IsRemote)
                                {
                                    wait_in_accept = true;
                                    Utility.SystemLogger.Info($"CIM  Accept  Carrier Wait IN Request first because MCS isn't ONLINE _ REMOTE");
                                    await CarrierWaitInReply(wait_in_accept, 30000);
                                    return;
                                }

                                Utility.SystemLogger.Info($"Wait S2F41 or S2F49 Message reachded..");
                                await SecsEventReport(CEID.CarrierWaitIn, WIPINFO_BCR_ID);
                                Utility.SystemLogger.Info($"{(CurrentCSTHasTransferTaskFlag ? "S2F49_Transfer" : "S2F41_No_Transfer")} Message reachded!");
                                wait_in_accept = CurrentCSTHasTransferTaskFlag;
                                Utility.SystemLogger.Info($"MCS {(wait_in_accept ? "Accept" : "Reject")} Carrier Wait IN Request..");
                            }
                            else
                            {
                                wait_in_accept = false;
                                Utility.SystemLogger.Info($"{PortName}-Carrier Wait In Request Reject, Cause: {(!PortExist ? $"No any cargo in Equipment" : $" With CST ID Incorrect , CST ID ＝{WIPINFO_BCR_ID}")}");
                                AlarmManager.AddWarning(!PortExist ? ALARM_CODES.CARRIER_WAIT_IN_BUT_NO_CARGO_IN_EQ : ALARM_CODES.CARRIER_WAIT_IN_BUT_BCR_ID_IS_EMPTY, Properties.PortID);
                            }

                            (bool confirm, ALARM_CODES alarm_code) result = await CarrierWaitInReply(wait_in_accept, 30000);
                            CurrentCSTHasTransferTaskFlag = false; //reset flag
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
                                Utility.SystemLogger.Info($"Carrier Wait In HS Finish");
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
                        Utility.SystemLogger.Info("Carrier Wait out Request bit ON ");
                        bool wait_out_accept = PortExist;
                        if (!wait_out_accept)
                        {
                            AlarmManager.AddAlarm(ALARM_CODES.CARRIER_WAIT_OUT_BUT_NO_CARGO_IN_EQ, PortName, true);
                            OnWaitOutRefuseByCIM?.Invoke(this, this);
                        }
                        //Secs Report
                        if (SECSState.IsRemote)
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
                                    bool IsBCRReadFail = IsBCR_READ_ERROR() | WIPINFO_BCR_ID == "";

                                    if (IsBCRReadFail)//讀取失敗=>報TUN
                                    {
                                        //如果Retry在107 之前完成,最後要清107
                                        if (CSTIDOnPort == CSTID_From_TransferCompletedReport)
                                        {
                                            Utility.SystemLogger.Info($"BCR Carrier ID Read Fail.  BCR Reader={WIPINFO_BCR_ID}, Carrier Installed Report To MCS  With CST Virtual ID={CSTIDOnPort}");
                                            Utility.SystemLogger.Info($"[Before Wait out Report To_MCS - BCR ID Read Fail] Remove 107 Carrier ID({CSTIDOnPort}) First");
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
                                            Utility.SystemLogger.Info($"Carrier ID Miss match CST ID From Transfer Task = {CSTID_From_TransferCompletedReport}, BCR Reader={WIPINFO_BCR_ID}");
                                            Utility.SystemLogger.Info($"[Before Wait out Report To_MCS - ID Missmatch] Remove 107 Carrier ID({CSTID_From_TransferCompletedReport}) First");
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
                            Utility.SystemLogger.Info($"PLC Carrier Wait Out HS Start");
                            try
                            {
                                bool success_hs = await CarrierWaitOutReply(Utility.IsHotRunMode ? true : wait_out_accept, 10000);
                                if (!success_hs)
                                {
                                    Utility.SystemLogger.Info($"PLC  Carrier Wait  Out HS Error!");
                                }

                            }
                            catch (Exception ex)
                            {
                                Utility.SystemLogger.Info($"PLC  Carrier Wait  Out HS ex! {ex.Message},{ex.StackTrace}");

                            }
                            if (!SECSState.IsRemote && EPortType != PortUnitType.Output && PortExist)
                            {

                                Utility.SystemLogger.Info($"After Carrier waitout HS done and Now is Local Mode, GPM_CIM Start Request PLC Port Type Change to OUTPUT");
                                bool plc_accpet = false;
                                int cnt = 0;
                                while (!plc_accpet)
                                {
                                    await Task.Delay(100);
                                    plc_accpet = await ModeChangeRequestHandshake(Utility.IsHotRunMode ? PortUnitType.Input : PortUnitType.Output, "GPM_CIM");
                                    Utility.SystemLogger.Info($"PLC Reject OUTPUT MODE Request. Retry-{cnt}");
                                    await Task.Delay(1000);
                                    cnt++;
                                    if (cnt >= 11)
                                    {
                                        Utility.SystemLogger.Info($"Retry times reach 11 ... .Port {PortName} Can't  change to OUTPUT MODE.");
                                        break;
                                    }
                                }

                            }
                        });


                    }
                    _CarrierWaitOUTSystemRequest = value;
                }
            }
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
                        Utility.SystemLogger.Info($"Carrier Remove Completed HS Start");
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
                    Task.Factory.StartNew(async () =>
                    {
                        try
                        {
                            await Task.Delay(1000);
                            await PortTypeReport();
                        }
                        catch (Exception ex)
                        {
                            Utility.SystemLogger.Error("Error Occur when Port Type Changed and Report To MCS", ex);
                        }
                    });
                }
                _PortType = value;

            }
        }

        internal async Task PortTypeReport()
        {
            if (EPortType == PortUnitType.Input | (EPortType == PortUnitType.Input_Output && MCSReservePortType == PortUnitType.Input))
                await SecsEventReport(CEID.PortTypeInputReport);
            if (EPortType == PortUnitType.Output | (EPortType == PortUnitType.Input_Output && MCSReservePortType == PortUnitType.Output))
                await SecsEventReport(CEID.PortTypeOutputReport);
        }


    }
}
