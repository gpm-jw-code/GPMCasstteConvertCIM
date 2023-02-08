using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsAGVSData;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsPortData
    {
        public int PortNo { get; private set; }
        public event EventHandler<clsPortData> ModeChangeOnRequest;
        public event EventHandler<clsPortData> CarrierWaitInOnRequest;
        public event EventHandler<clsPortData> CarrierWaitOutOnReport;
        public event EventHandler<clsPortData> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsPortData> OnValidSignalActive;

        public clsPortData()
        {
        }

        public clsPortData(int PortNo)
        {
            this.PortNo = PortNo;

            AGVSignals = new clsHS_Status_Signals();
            AGVSignals.OnValidSignalActive += AGVSignals_OnValidSignalActive;
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
        public bool PortExist { get; set; } = false;
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



        private bool _Mode_Change_Request = false;
        public bool Mode_Change_Request
        {
            get => _Mode_Change_Request;
            set
            {
                if (_Mode_Change_Request != value)
                {
                    _Mode_Change_Request = value;
                    if (_Mode_Change_Request)
                    {
                        ModeChangeOnRequest?.Invoke(this, this);
                    }
                }
            }
        }
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


        public PortUnitType EPortModeStatus
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(en => PortModeStatus == (int)en);
                }
                catch (Exception)
                {
                    return PortUnitType.Input_Output;
                }
            }
        }
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
        public AGVS_CONNECT_STATUS EAGVSConnectStatus
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(AGVS_CONNECT_STATUS)).Cast<AGVS_CONNECT_STATUS>().First(en => AGVSConnectStatus == (int)en);

                }
                catch (Exception)
                {
                    return AGVS_CONNECT_STATUS.Unknown;
                }

            }
        }

        public AUTO_MANUAL_MODE ERackModeRequest
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(AUTO_MANUAL_MODE)).Cast<AUTO_MANUAL_MODE>().First(en => RackModeRequest == (int)en);

                }
                catch (Exception)
                {
                    return AUTO_MANUAL_MODE.Unknown;
                }

            }
        }

        public PortUnitType EPortModeRequest
        {
            get
            {
                try
                {
                    return Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().First(en => PortModeRequest == (int)en);

                }
                catch (Exception)
                {
                    return PortUnitType.Input;
                }

            }
        }

        public string WIPINFO_BCR_ID
        {
            get
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
                return ints.ToASCII();
            }
        }

        public bool EQ_BUSY { get; internal set; }
        public bool PortStatusDown { get; internal set; }
        public bool LD_UP_POS { get; internal set; }
        public bool LD_DOWN_POS { get; internal set; }
        public bool DoorOpened { get; internal set; }

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
                        CarrierWaitInOnRequest?.Invoke(this, this);
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
                    _CarrierWaitOUTSystemRequest = value;
                    if (_CarrierWaitOUTSystemRequest)
                    {
                        CarrierWaitOutOnReport?.Invoke(this, this);
                    }
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
                        CarrierRemovedCompletedOnReport?.Invoke(this, this);
                    }
                }
            }
        }
        public bool Port_Mode_Change_Accept { get; internal set; }
        public bool Port_Mode_Changed_Refuse { get; internal set; }
        public bool Port_Mode_Changed_Report { get; internal set; }
        public bool Port_Disabled_Report { get; internal set; }
        public bool Port_Enabled_Report { get; internal set; }
        public int Port_Auto_Manual_Mode_Status { get; internal set; }
    }
}
