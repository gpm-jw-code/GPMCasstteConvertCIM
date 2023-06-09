﻿using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Secs4Net;
using Secs4Net.Sml;
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
            this.EQParent = converterParent;

            AGVSignals = new clsHS_Status_Signals();
            AGVSignals.OnValidSignalActive += AGVSignals_OnValidSignalActive;

            SECSState.OnMCSOnlineRemote += SECSState_OnMCSOnlineRemote;

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
            if (WIPINFO_BCR_ID == "")
            {
                Utility.SystemLogger.Info($"Carrier Wait In and Carrier Exist But Carrier ID Is Empty");
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

        public clsCasstteConverter EQParent { get; }

        public clsPortProperty Properties = new clsPortProperty();
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;
        public string PortNameWithEQName => EQParent.Name + $"-[{Properties.PortID}]";

        public string portNoName => $"PORT{Properties.PortNo + 1}";
        internal PortUnitType EPortType => Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(etype => (int)etype == _PortType);


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
        internal List<clsMemoryAddress> CIMModbusLinkWordAddress => EQParent.LinkWordMap.FindAll(ad => ad.EOwner == OWNER.CIM && ad.EScope.ToString() == portNoName && ad.Link_Modbus_Register_Number != -1);
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

        public string Previous_WIPINFO_BCR_ID { get; internal set; } = "";
        public string _WIPINFO_BCR_ID = "";
        public DateTime WIPUPdateTime { get; set; } = DateTime.MinValue;
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
                        Previous_WIPINFO_BCR_ID = value;
                        WIPUPdateTime = DateTime.Now;
                        Utility.SystemLogger.Info($"Port {Properties.PortID} WIP Updated : {_WIPINFO_BCR_ID}");
                    }
                }
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
                    Previous_WIPINFO_BCR_ID = WIPINFO_BCR_ID;
                    CarrierInstallTime = DateTime.Now;
                    _CarrierWaitINSystemRequest = value;
                    if (_CarrierWaitINSystemRequest)
                    {

                        Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(1000);
                            bool wait_in_accept = false;
                            if (WIPINFO_BCR_ID != "")
                            {
                                if (!SECSState.IsOnline && !SECSState.IsRemote)
                                {
                                    wait_in_accept = true;
                                    Utility.SystemLogger.Info($"CIM  Accept  Carrier Wait IN Request first because MCS isn't ONLINE _ REMOTE");
                                }
                                else
                                {

                                    bool lduld_req = await WaitLoadUnloadRequestON();
                                    if (!lduld_req)
                                        return;

                                    if (!IsCarrierInstallReported)
                                    {
                                        await SecsEventReport(CEID.CarrierInstallCompletedReport, WIPINFO_BCR_ID);
                                        IsCarrierInstallReported = true;
                                    }
                                    wait_in_accept = await SecsEventReport(CEID.CarrierWaitIn);
                                    Utility.SystemLogger.Info($"MCS {(wait_in_accept ? "Accept" : "Reject")} Carrier Wait IN Request..");
                                }
                            }
                            else
                            {
                                AlarmManager.AddWarning(ALARM_CODES.CARRIER_WAIT_IN_BUT_BCR_ID_IS_EMPTY, Properties.PortID);
                                wait_in_accept = false;
                            }

                            (bool confirm, ALARM_CODES alarm_code) result = await CarrierWaitInReply(wait_in_accept, 30000);

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
                        Previous_WIPINFO_BCR_ID = WIPINFO_BCR_ID;
                        CarrierInstallTime = DateTime.Now;
                        Utility.SystemLogger.Info("Carrier Wait out Request bit ON ");

                        Task.Factory.StartNew(async () =>
                        {
                            await Task.Delay(1000);
                            //先等轉換架Load.Unload Request ON 
                            bool lduld_req = await WaitLoadUnloadRequestON();
                            if (!lduld_req)
                                return;
                            if (!IsCarrierInstallReported)
                            {
                                await SecsEventReport(CEID.CarrierInstallCompletedReport, WIPINFO_BCR_ID);
                                IsCarrierInstallReported = true;
                            }
                            await SecsEventReport(CEID.CarrierWaitOut);
                        });

                        Task.Factory.StartNew(async () =>
                        {
                            Utility.SystemLogger.Info($"PLC Carrier Wait  Out HS Start");
                            try
                            {
                                bool success_hs = await CarrierWaitOutReply(10000);
                                if (!success_hs)
                                {
                                    Utility.SystemLogger.Info($"PLC  Carrier Wait  Out HS Error!");
                                }
                            }
                            catch (Exception ex)
                            {
                                Utility.SystemLogger.Info($"PLC  Carrier Wait  Out HS ex! {ex.Message},{ex.StackTrace}");

                            }
                        });


                    }
                    _CarrierWaitOUTSystemRequest = value;
                }
            }
        }

        private bool _CarrierRemovedCompletedReport;
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
                        IsCarrierInstallReported = false;
                        Utility.SystemLogger.Info($"Carrier Remove Completed Report Start");
                        SecsEventReport(CEID.CarrierRemovedCompletedReport);
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
