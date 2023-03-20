using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsAGVSData;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Item = Secs4Net.Item;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class clsConverterPort
    {
        public int PortNo { get; private set; }
        public clsCasstteConverter converterParent { get; }

        public string PortID = "Port 1";
        public event EventHandler<clsConverterPort> ModeChangeOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitInOnRequest;
        public event EventHandler<clsConverterPort> CarrierWaitOutOnReport;
        public event EventHandler<clsConverterPort> CarrierRemovedCompletedOnReport;
        public event EventHandler<clsConverterPort> OnValidSignalActive;

        public clsConverterPort()
        {
        }

        public clsConverterPort(int PortNo, clsCasstteConverter converterParent)
        {
            this.PortNo = PortNo;
            this.converterParent = converterParent;

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


        public async void PortOutOfServiceReport()
        {
            var msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                                Item.U4(0),//DATAID,
                                Item.U2((ushort)CEID.PortOutOfServiceReport), //CEID
                                Item.L(
                                    Item.L(
                                     Item.U2(12),//RPTID,
                                     Item.L(
                                         Item.A(PortID)
                                       )
                                     )
                                  )
                               )
            };
            var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
        }

        public async void PortInServiceReport()
        {
            var msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                              Item.U4(0),//DATAID,
                              Item.U2((ushort)CEID.PortInServiceReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(PortID)
                                     )
                                   )
                                )
                             )
            };
            var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
        }
        public async void PortTypeInputReport()
        {
            var msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                              Item.U4(0),//DATAID,
                              Item.U2((ushort)CEID.PortTypeInputReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(PortID)
                                     )
                                   )
                                )
                             )
            };
            var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
        }
        public async void PortTypeOutputReport()
        {
            var msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                              Item.U4(0),//DATAID,
                              Item.U2((ushort)CEID.PortTypeOutputReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(PortID)
                                     )
                                   )
                                )
                             )
            };
            var replyMsg = await DevicesManager.secs_host_for_mcs.SendAsync(msg);
        }
        private bool CarrierWaitIn_Reply = false;
        private bool CarrierWaitIn_Accept = false;
        public async Task<bool> WaitMCSAccpectCarrierIn(int T_timout = 20)
        {
            CarrierWaitIn_Reply = false;
            CarrierWaitIn_Accept = false;

            bool isEventReportAck = false;
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));

            while (!isEventReportAck)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    return false;
                }
                try
                {
                    var msc_reply = await DevicesManager.secs_host_for_mcs.SendAsync(EVENT_REPORT.CarrierWaitInReportMessage(WIPINFO_BCR_ID, "", ""));
                    isEventReportAck = true;
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(1);
            }

            DevicesManager.secs_host_for_mcs.OnPrimaryMessageRecieve += Secs_client_OnPrimaryMessageRecieve;

            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(T_timout));
            while (!CarrierWaitIn_Reply)
            {
                try
                {
                    await Task.Delay(1, cancellationTokenSource.Token);
                }
                catch (TaskCanceledException ex)
                {
                    //表示timeout
                    break;
                }
            }
            DevicesManager.secs_host_for_mcs.OnPrimaryMessageRecieve -= Secs_client_OnPrimaryMessageRecieve;
            return CarrierWaitIn_Accept && CarrierWaitIn_Reply;
        }

        public async Task CarrierWaitOutReply()
        {

            EQ_SCOPE port_no = PortNo == 1 ? EQ_SCOPE.PORT1 : EQ_SCOPE.PORT2;
            var carrier_wait_out_reply_address = converterParent.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == PROPERTY.Carrier_WawitOut_System_Reply).Address;
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, true);
            while (CarrierWaitOUTSystemRequest)
            {
                await Task.Delay(1);
            }
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

            try
            {

                await DevicesManager.secs_client_for_agvs.SendAsync(EVENT_REPORT.CarrierWaitOutReportMessage(WIPINFO_BCR_ID, "", ""));
            }
            catch (Exception ex)
            {

            }

        }

        public async Task<bool> CarrierWaitInReply(bool accpect, int T_timeout = 5000)
        {
            bool timeout = false;

            PROPERTY wait_in_ = accpect ? PROPERTY.Carrier_WaitIn_System_Accept : PROPERTY.Carrier_WaitIn_System_Refuse;
            EQ_SCOPE port_no = PortNo == 1 ? EQ_SCOPE.PORT1 : EQ_SCOPE.PORT2;

            var carrier_wait_in_result_flag_address = converterParent.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == wait_in_).Address;
            var carrier_wait_in_reply_address = converterParent.LinkBitMap.First(mem => mem.EOwner == clsMemoryAddress.OWNER.CIM && mem.EScope == port_no && mem.EProperty == PROPERTY.Carrier_WaitIn_System_Reply).Address;

            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);

            Stopwatch sw = Stopwatch.StartNew();
            while (CarrierWaitINSystemRequest)
            {
                if (sw.ElapsedMilliseconds > T_timeout)
                {
                    timeout = true;
                    break;
                }
                await Task.Delay(1);
            }

            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
            converterParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);

            return timeout;

        }
        private void Secs_client_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper messagePrimary)
        {
            Task.Factory.StartNew(() =>
            {
                var mcs_msg = messagePrimary.PrimaryMessage;
                bool IsRCMD = mcs_msg.TryGetRCMDAction(out RCMD RCMD);
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.TRANSFER)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = true;
                }
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.NOTRANSFER)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = false;
                }
            });
        }



    }
}
