using CIMComponent;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System.Diagnostics;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public virtual MemoryTable CIMMemoryTable
        {
            get
            {
                return EQParent.CIMMemOptions.memoryTable;
            }
        }
        private SECSBase MCS => DevicesManager.secs_host_for_mcs;
        private bool CarrierWaitIn_Reply = false;
        private bool CarrierWaitIn_Accept = false;
        private bool Carrier_TransferCompletedFlag = false;

        /// <summary>
        /// MCS ->CIM : ModeChangeReques
        /// </summary>
        /// <param name="portUnitType"></param>
        /// <returns></returns>
        internal async Task<bool> ModeChangeRequestHandshake(PortUnitType portUnitType, string requester_name = "MCS")
        {

            if (EPortType == portUnitType)
            {
                Utility.SystemLogger.Info($"[{requester_name}] Request [{Properties.PortID}] Change Port Type To {portUnitType}, But Port Already {portUnitType}");
                return true;
            }
            Utility.SystemLogger.Info($"[{requester_name}] Request [{Properties.PortID}] Change Port Type To {portUnitType}");

            bool plc_accept = false;
            string port_type_data_address_name = PortCIMWordAddress[PROPERTY.Port_Type_Status];
            string cim_2_eq_port_mode_change_req_address_name = PortCIMBitAddress[PROPERTY.Port_Mode_Change_Request];
            string eq_2_cim_port_mode_change_accept_address_name = PortEQBitAddress[PROPERTY.Port_Mode_Change_Accept];
            string eq_2_cim_port_mode_change_refuse_address_name = PortEQBitAddress[PROPERTY.Port_Mode_Changed_Refuse];

            var plc_accept_address = EQParent.LinkBitMap.First(ad => ad.Address == eq_2_cim_port_mode_change_accept_address_name);
            var plc_refuse_address = EQParent.LinkBitMap.First(ad => ad.Address == eq_2_cim_port_mode_change_refuse_address_name);

            //write porttype data to word memory
            VirtualMemoryTable.WriteBinary(port_type_data_address_name, (int)portUnitType);
            await Task.Delay(1000);
            //On CIM Bit
            VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, true);
            //wait EQ Bit on

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(Debugger.IsAttached ? 15 : 5));
            bool timeout = false;
            while (!(bool)plc_accept_address.Value && !(bool)plc_refuse_address.Value)
            {
                await Task.Delay(10);
                if (cts.IsCancellationRequested)
                {
                    VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, false);
                    VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
                    AlarmManager.AddAlarm(ALARM_CODES.PortTypeChangeRequest_HS_EQ_Timeout, Properties.PortID);
                    Utilities.Utility.SystemLogger.Warning($"ModeChangeRequestHandshake EQ Timeout");
                    return false;
                }
            }
            plc_accept = (bool)plc_accept_address.Value;
            Utility.SystemLogger.Info($"PLC Reply {plc_accept} ,[{Properties.PortID}] Change Port Type To {portUnitType}");

            VirtualMemoryTable.WriteOneBit(cim_2_eq_port_mode_change_req_address_name, false);
            cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            while ((bool)plc_accept_address.Value | (bool)plc_refuse_address.Value)
            {
                await Task.Delay(10);
                if (cts.IsCancellationRequested)
                {
                    VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
                    return false;
                }
            }
            VirtualMemoryTable.WriteBinary(port_type_data_address_name, 0);
            return plc_accept;
        }



        /// <summary>
        /// EQ->CIM : Port Type Changed Report
        /// </summary>
        public async void PortTypeChangedReportHandshake()
        {
            _ = Task.Factory.StartNew(() =>
            {
                Utility.SystemLogger.Info($"{PortName}- Port Type Changed Handshake Start !(Changed to {EPortType})");
                clsMemoryAddress eq_to_cim_report_adress = EQParent.LinkBitMap.First(i => i.EOwner == OWNER.EQP && i.EScope.ToString() == portNoName && i.EProperty == PROPERTY.Port_Mode_Changed_Report);
                string cim_2_eq_reply_address = PortCIMBitAddress[PROPERTY.Port_Mode_Changed_Report_Reply];
                //ON CIM BIT
                CIMMemoryTable.WriteOneBit(cim_2_eq_reply_address, true);
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                bool timeout = false;
                //等待EQ OFF BIT
                while ((bool)eq_to_cim_report_adress.Value)
                {
                    Thread.Sleep(1);
                    if (cts.IsCancellationRequested)
                    {
                        timeout = true;//T3 Timeout
                        AlarmManager.AddAlarm(ALARM_CODES.PortTypeChangedReport_HS_EQ_Timeout, PortName);
                        Utility.SystemLogger.Info($"{PortName}- Port Type Changed Handshake EQP Timeout({eq_to_cim_report_adress.Address}) Not OFF...(Changed to {EPortType})");
                        break;
                    }
                }
                //OFF CIM BIT
                CIMMemoryTable.WriteOneBit(cim_2_eq_reply_address, false);
                Utility.SystemLogger.Info($"{PortName}- Port Type Changed Handshake Finish !(Changed to {EPortType})");
                cts.Dispose();

            });
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task CarrierRemovedCompletedReply()
        {
            var carrier_removed_com_reply_address = PortCIMBitAddress[PROPERTY.Carrier_Removed_Completed_Report_Reply];
            CIMMemoryTable.WriteOneBit(carrier_removed_com_reply_address, true);
            CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            while (CarrierRemovedCompletedReport)
            {
                if (cst.IsCancellationRequested)
                {
                    Utility.SystemLogger.Info($"[{PortName}] Carrier Remove Completed HS Fail-> EQ Timeout");
                    AlarmManager.AddWarning(ALARM_CODES.CarrierRemovedCompolete_HS_EQ_Timeout, PortName);
                    break;
                }
                await Task.Delay(1);
            }
            CIMMemoryTable.WriteOneBit(carrier_removed_com_reply_address, false);
            Utility.SystemLogger.Info($"[{PortName}] Carrier Remove Completed HS Finish");

            Utility.SystemLogger.Info($"[{PortName}] -Carrier Remove Completed HS Completed!");

        }

        /// <summary>
        ///  EQ->CIM->MCS : Carrier Wait out 
        /// </summary>
        /// <param name="EQ_T_timeout"></param>
        /// <returns></returns>
        public async Task<bool> CarrierWaitOutReply(bool wait_out_accept, int EQ_T_timeout = 5000)
        {
            if (PortCIMBitAddress.TryGetValue(PROPERTY.Carrier_WaitOut_System_Reply, out string carrier_wait_out_reply_address))
            {
                CIMMemoryTable.WriteOneBit(carrier_wait_out_reply_address, true);

                Utility.SystemLogger.Info($"[{PortName}] Carrier Wait Out HS Start_ {carrier_wait_out_reply_address} ON");
                CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromMilliseconds(EQ_T_timeout));
                while (CarrierWaitOUTSystemRequest)
                {
                    if (cst.IsCancellationRequested)
                    {
                        Utility.SystemLogger.Info($"[{PortName}] Carrier Wait Out HS => EQ Timeout");
                        AlarmManager.AddWarning(ALARM_CODES.CarrierWaitOut_HS_EQ_Timeout, Properties.PortID);
                        break;
                    }
                    await Task.Delay(1);
                }
                CIMMemoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

                Utility.SystemLogger.Info($"[{PortName}] Carrier Wait Out HS Done");

                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<(bool confirm, ALARM_CODES alarm_code)> CarrierWaitInReply(bool wait_in_accept, int EQ_T_timeout = 5000)
        {
            Utility.SystemLogger.Info($"[{PortName}]-Carrier Wait In HS Start");
            bool timeout = false;
            PROPERTY wait_in_ = wait_in_accept ? PROPERTY.Carrier_WaitIn_System_Accept : PROPERTY.Carrier_WaitIn_System_Refuse;
            string? carrier_wait_in_result_flag_address = PortCIMBitAddress[wait_in_];
            string? carrier_wait_in_reply_address = PortCIMBitAddress[PROPERTY.Carrier_WaitIn_System_Reply];

            PortUnitType _portType = this.EPortType;
            if (_portType == PortUnitType.Input)
            {
                CIMMemoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
                await Task.Delay(300);
                CIMMemoryTable.WriteOneBit(carrier_wait_in_reply_address, true);
                Stopwatch sw = Stopwatch.StartNew();
                while (CarrierWaitINSystemRequest)
                {
                    if (sw.ElapsedMilliseconds > EQ_T_timeout)
                    {
                        timeout = true;
                        break;
                    }
                    await Task.Delay(1);
                }

                CIMMemoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
                CIMMemoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);
            }
            else if (_portType == PortUnitType.Input_Output)
            {
                CIMMemoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
                await Task.Delay(300);
                CIMMemoryTable.WriteOneBit(carrier_wait_in_reply_address, true);
                Stopwatch sw = Stopwatch.StartNew();
                while (CarrierWaitINSystemRequest)
                {
                    if (sw.ElapsedMilliseconds > EQ_T_timeout)
                    {
                        timeout = true;
                        break;
                    }
                    await Task.Delay(1);
                }
                CIMMemoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
                CIMMemoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);
            }
            else if (_portType == PortUnitType.Output)
            {
                Utility.SystemLogger.Info($"[{PortName}] Carrier Wait In HS Failed");
            }
            wait_in_timer.Stop();

            Utility.SystemLogger.Info($"[{PortName}]-Carrier Wait In HS FINISH!");
            return (!timeout, timeout ? ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout : ALARM_CODES.None);

        }

        internal async Task<bool> WaitAGVSTransferCompleteReported()
        {
            int timeout = Debugger.IsAttached ? 5 : 90;
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeout));
            Utility.SystemLogger.Info($"{PortName} Wait AGVS Transfer Completed Reported(Timeout Setting = {timeout} sec)");
            while (!Carrier_TransferCompletedFlag)
            {
                await Task.Delay(1);
                if (cts.IsCancellationRequested)
                {
                    Utility.SystemLogger.Info($"{PortName} Wait AGVS Transfer Completed Reported Timeout....");
                    return false;
                }
            }

            Utility.SystemLogger.Info($"{PortName} AGVS Transfer Completed Reported Done.");
            return true;
        }
        internal async Task<bool> WaitLoadUnloadRequestON()
        {
            Utility.SystemLogger.Info("Wait_Load/Unload Request ON...");
            CancellationTokenSource cancelWaitCts = new CancellationTokenSource(TimeSpan.FromSeconds(20));
            while (!LoadRequest && !UnloadRequest)
            {
                if (cancelWaitCts.IsCancellationRequested)
                {
                    Utility.SystemLogger.Warning("Wait Load/Unload Request Bit ON TIMEOUT (20)  when MCS Transfer command downloaded.");
                    AlarmManager.AddAlarm(ALARM_CODES.WAIT_Load_Unload_Request_Bit_ON_When_MCS_Transfering, Properties.PortID);
                    return false;
                }
                await Task.Delay(1);
            }
            Utility.SystemLogger.Info("Load/Unload Request Bit ON.. contiune");
            return true;
        }

        private bool NoTransferNotifyFlag = false;
        private bool AGVsReplyMCSTransferTaskReqFlag = false;
        private bool AGVsAcceptMCSTransferTaskReq = false;


        internal void CstTransferAcceptInvoke()
        {
            AGVsAcceptMCSTransferTaskReq = true;
            AGVsReplyMCSTransferTaskReqFlag = true;
            Utility.SystemLogger.Info($"{PortName}({Properties.PortID}) AGVS Accept Transfer Task");
        }
        internal void CstTransferRejectInvoke()
        {
            AGVsAcceptMCSTransferTaskReq = false;
            AGVsReplyMCSTransferTaskReqFlag = true;
            Utility.SystemLogger.Info($"{PortName}({Properties.PortID}) AGVS Reject Transfer Task");
        }


        internal void NoTransferNotifyInovke(string carrier_id, string cstid, string reason)
        {
            NoTransferNotifyFlag = true;
            OnMCSNoTransferNotify?.Invoke(this, new Tuple<string, string, string>(carrier_id, cstid, reason));
        }

        internal async void TransferCompletedInvoke(string carrier_id)
        {
            Utility.SystemLogger.Info($"{PortName}- AGVS Transfer Cargo To {PortName} Compelted  |AGVS->MCS");
            CSTID_From_TransferCompletedReport = CSTIDOnPort = carrier_id;
            Carrier_TransferCompletedFlag = true;
        }
    }
}
