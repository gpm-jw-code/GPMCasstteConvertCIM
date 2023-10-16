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

            Utilities.Utility.SystemLogger.Info($"{requester_name} Request [{Properties.PortID}] Change Port Type To {portUnitType}");

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

            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
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
            Utilities.Utility.SystemLogger.Info($"PLC Reply {plc_accept} ,[{Properties.PortID}] Change Port Type To {portUnitType}");

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
                clsMemoryAddress eq_to_cim_report_adress = EQParent.LinkBitMap.First(i => i.EOwner == OWNER.EQP && i.EScope.ToString() == portNoName && i.EProperty == PROPERTY.Port_Mode_Changed_Report);
                string cim_2_eq_reply_address = PortCIMBitAddress[PROPERTY.Port_Mode_Changed_Report_Reply];
                //ON CIM BIT
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(cim_2_eq_reply_address, true);
                CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                bool timeout = false;
                //等待EQ OFF BIT
                while ((bool)eq_to_cim_report_adress.Value)
                {
                    Thread.Sleep(1);
                    if (cts.IsCancellationRequested)
                    {
                        timeout = true;//T3 Timeout
                        break;
                    }
                }
                //OFF CIM BIT
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(cim_2_eq_reply_address, false);
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
            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, true);
            CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromSeconds(5000));
            while (CarrierRemovedCompletedReport)
            {
                if (cst.IsCancellationRequested)
                {
                    AlarmManager.AddWarning(ALARM_CODES.CarrierRemovedCompolete_HS_EQ_Timeout, Properties.PortID);
                    break;
                }
                await Task.Delay(1);
            }
            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_removed_com_reply_address, false);
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
                PortCIMBitAddress.TryGetValue(PROPERTY.Carrier_WaitOut_System_Refuse, out string wait_out_refuse_address);

                EQParent.CIMMemOptions.memoryTable.WriteOneBit(wait_out_refuse_address, !wait_out_accept);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, true);

                Utility.SystemLogger.Info($"Carrier Wait Out HS Start_ {carrier_wait_out_reply_address} ON");
                CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromMilliseconds(EQ_T_timeout));
                while (CarrierWaitOUTSystemRequest)
                {
                    if (cst.IsCancellationRequested)
                    {
                        Utility.SystemLogger.Info($"Carrier Wait Out HS => EQ Timeout");
                        AlarmManager.AddWarning(ALARM_CODES.CarrierWaitOut_HS_EQ_Timeout, Properties.PortID);
                        break;
                    }
                    await Task.Delay(1);
                }
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(wait_out_refuse_address, false);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

                Utility.SystemLogger.Info($"Carrier Wait Out HS Done");

                return true;
            }
            else
            {
                return false;
            }
        }



        public async Task<(bool confirm, ALARM_CODES alarm_code)> CarrierWaitInReply(bool wait_in_accept, int EQ_T_timeout = 5000)
        {
            Utility.SystemLogger.Info($"Carrier Wait In HS Start");
            bool timeout = false;
            PROPERTY wait_in_ = wait_in_accept ? PROPERTY.Carrier_WaitIn_System_Accept : PROPERTY.Carrier_WaitIn_System_Refuse;
            string? carrier_wait_in_result_flag_address = PortCIMBitAddress[wait_in_];
            string? carrier_wait_in_reply_address = PortCIMBitAddress[PROPERTY.Carrier_WaitIn_System_Reply];

            PortUnitType _portType = this.EPortType;
            if (_portType == PortUnitType.Input)
            {
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
                await Task.Delay(300);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);
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

                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);
            }
            else if (_portType == PortUnitType.Input_Output)
            {
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
                await Task.Delay(300);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);
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
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);
            }
            else if (_portType == PortUnitType.Output)
            {
                Utility.SystemLogger.Info($"Carrier Wait In HS Failed");
            }

            return (!timeout, timeout ? ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout : ALARM_CODES.None);

        }

        internal async Task<bool> WaitAGVSTransferCompleteReported()
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(25));
            Utility.SystemLogger.Info($"{PortName} Wait AGVS Transfer Completed Reported");
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
        private bool CurrentCSTHasTransferTaskFlag = false;


        internal void CstTransferInvoke()
        {
            CurrentCSTHasTransferTaskFlag = true;
        }

        internal void NoTransferNotifyInovke(string carrier_id, string cstid)
        {
            NoTransferNotifyFlag = true;
            OnMCSNoTransferNotify?.Invoke(this, new Tuple<string, string>(carrier_id, cstid));
        }

        internal async void TransferCompletedInvoke(string carrier_id)
        {
            CSTID_From_TransferCompletedReport = carrier_id;
            if (WIPINFO_BCR_ID == carrier_id)
                Carrier_TransferCompletedFlag = true;
        }
    }
}
