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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="portUnitType"></param>
        /// <returns></returns>
        internal async Task<bool> ModeChangeRequestHandshake(PortUnitType portUnitType)
        {

            Utilities.Utility.SystemLogger.Info($"MCS Request [{Properties.PortID}] Change Port Type To {portUnitType}");

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


        public async void PortModeChangedReportHandshake()
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


        public async void PortOutOfServiceReport()
        {
            Task tk = new Task(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    Name = "Port Out of Service",
                    SecsItem = Item.L(
                                      Item.U4(DataID_Cylic_Use),//DATAID,
                                      Item.U2((ushort)CEID.PortOutOfServiceReport), //CEID
                                      Item.L(
                                          Item.L(
                                           Item.U2(12),//RPTID,
                                           Item.L(
                                               Item.A(Properties.PortID)
                                             )
                                           )
                                        )
                                     )
                };

                SecsMessage? replyMsg = null;
                replyMsg = await MCS.ActiveSendMsgAsync(msg);
                if (replyMsg.IsS9F7())
                    AlarmManager.AddWarning(ALARM_CODES.MCS_PORT_OUT_SERVICE_REPORT_FAIL, Properties.PortID);
                else
                    Utilities.Utility.SystemLogger.Info($"PortOutOfServiceReport Done. \r\n MCS Reply \r\n{replyMsg.ToSml()}");
                await Task.Delay(1000);

            });
            tk.Start();

        }
        public async void PortInServiceReport()
        {
            Task tk = new Task(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    Name = "Port In Service",
                    SecsItem = Item.L(
                                      Item.U4(DataID_Cylic_Use),//DATAID,
                                      Item.U2((ushort)CEID.PortInServiceReport), //CEID
                                      Item.L(
                                          Item.L(
                                           Item.U2(12),//RPTID,
                                           Item.L(
                                               Item.A(Properties.PortID)
                                             )
                                           )
                                        )
                                     )
                };
                SecsMessage? replyMsg = null;
                replyMsg = await MCS.ActiveSendMsgAsync(msg);
                if (replyMsg.IsS9F7())
                    AlarmManager.AddWarning(ALARM_CODES.MCS_PORT_IN_SERVICE_REPORT_FAIL, Properties.PortID);
                else
                    Utilities.Utility.SystemLogger.Info($"PortInServiceReport Done. \r\n MCS Reply \r\n {replyMsg.ToSml()}");
            });
            tk.Start();
        }
        public async void PortTypeInputReport()
        {
            Task tk = new Task(async () =>
            {
                var msg = new SecsMessage(6, 11)
                {
                    Name = "Port Type In",
                    SecsItem = Item.L(
                              Item.U4(DataID_Cylic_Use),//DATAID,
                              Item.U2((ushort)CEID.PortTypeInputReport), //CEID
                              Item.L(
                                  Item.L(
                                   Item.U2(12),//RPTID,
                                   Item.L(
                                       Item.A(Properties.PortID)
                                     )
                                   )
                                )
                             )
                };
                SecsMessage? replyMsg = null;

                replyMsg = await MCS.ActiveSendMsgAsync(msg);
                if (replyMsg.IsS9F7())
                    AlarmManager.AddWarning(ALARM_CODES.MCS_PORT_TYPE_INPUT_REPORT_FAIL, Properties.PortID);
                else
                    Utilities.Utility.SystemLogger.Info($"PortTypeInputReport Done. \r\n MCS Reply \r\n {replyMsg.ToSml()}");

            });
            tk.Start();
        }
        public async void PortTypeOutputReport()
        {
            Task tk = new Task(async () =>
             {
                 var msg = new SecsMessage(6, 11)
                 {
                     Name = "Port Type Out",
                     SecsItem = Item.L(
                               Item.U4(DataID_Cylic_Use),//DATAID,
                               Item.U2((ushort)CEID.PortTypeOutputReport), //CEID
                               Item.L(
                                   Item.L(
                                    Item.U2(12),//RPTID,
                                    Item.L(
                                        Item.A(Properties.PortID)
                                      )
                                    )
                                 )
                              )
                 };
                 SecsMessage? replyMsg = null;
                 replyMsg = await MCS.ActiveSendMsgAsync(msg);
                 if (replyMsg.IsS9F7())
                     AlarmManager.AddWarning(ALARM_CODES.MCS_PORT_TYPE_OUTPUT_REPORT_FAIL, Properties.PortID);
                 else
                     Utilities.Utility.SystemLogger.Info($"PortTypeInputReport Done. \r\n MCS Reply \r\n {replyMsg.ToSml()}");
             });
            tk.Start();
        }

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
                    var msc_reply = await MCS.ActiveSendMsgAsync(EVENT_REPORT.CarrierWaitInReportMessage(WIPINFO_BCR_ID, Properties.PortID, ""));//TODO Zone Name ?
                    if (msc_reply.IsS9F7())
                    {
                        AlarmManager.AddWarning(ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_DISCONNECT, Properties.PortID);
                        AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_WAITIN_REPORT_FAIL, Properties.PortID);
                        return false;
                    }
                    isEventReportAck = true;
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(1);
            }

            MCS.OnPrimaryMessageRecieve += Secs_client_OnPrimaryMessageRecieve;

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
            MCS.OnPrimaryMessageRecieve -= Secs_client_OnPrimaryMessageRecieve;
            return CarrierWaitIn_Accept && CarrierWaitIn_Reply;
        }
        public async Task CarrierRemovedCompletedReply()
        {
            var carrier_removed_com_reply_address = PortCIMBitAddress[PROPERTY.Carrier_Removed_Completed_Report_Reply];

            //上報MCS
            _ = Task.Factory.StartNew(async () =>
            {
                try
                {
                    var response = await MCS.ActiveSendMsgAsync(EVENT_REPORT.CarrierRemovedCompletedReportMessage(Previous_WIPINFO_BCR_ID, Properties.PortID, "", EPortAutoStatus == AUTO_MANUAL_MODE.AUTO)); //TODO Zone Name ?
                    if (response.IsS9F7())
                        AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL, Properties.PortID);
                }
                catch (Exception ex)
                {
                    AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL, Properties.PortID);
                }
            });

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

        public async Task<bool> CarrierWaitOutReply()
        {
            Utility.SystemLogger.Warning($"Carrier Wait Out HS Start_2 CHeck");

            if (PortCIMBitAddress.TryGetValue(PROPERTY.Carrier_WaitOut_System_Reply, out string carrier_wait_out_reply_address))
            {
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, true);

                Utility.SystemLogger.Info($"Carrier Wait Out HS Start_ {carrier_wait_out_reply_address} ON");
                CancellationTokenSource cst = new CancellationTokenSource(TimeSpan.FromSeconds(5));
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
                EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_out_reply_address, false);

                _ = Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(1500);
                    try
                    {
                        Utility.SystemLogger.Info($"Carrier Wait Out Report to MCS");

                        var response = await MCS.ActiveSendMsgAsync(EVENT_REPORT.CarrierWaitOutReportMessage(WIPINFO_BCR_ID, Properties.PortID, ""));//TODO Zone Name ?
                        if (response.IsS9F7())
                            AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL, Properties.PortID);
                    }
                    catch (Exception ex)
                    {
                        AlarmManager.AddWarning(ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL, Properties.PortID);
                        Utility.SystemLogger.Info($"Carrier Wait Out Report to MCS - {ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL},{ex.Message}");

                    }


                });

                Utility.SystemLogger.Info($"Carrier Wait Out HS Done");

                return true;
            }
            else
            {
                return false;
            }


        }


        public async Task<bool> CarrierWaitInReply(int T_timeout = 5000)
        {
            Utilities.Utility.SystemLogger.Info($"等待MCS Accept Carrier Wait IN Request..");

            //送訊息給SECS HOST 
            SecsMessage? msc_reply = await MCS.ActiveSendMsgAsync(EVENT_REPORT.CarrierWaitInReportMessage(WIPINFO_BCR_ID, Properties.PortID, ""));//TODO Zone Name ?

            bool mcs_accpet = msc_reply.SecsItem.FirstValue<byte>() == 0;
            Utilities.Utility.SystemLogger.Info($"MCS Wait IN ACK:{mcs_accpet} {msc_reply.ToSml()}");

            bool timeout = false;
            PROPERTY wait_in_ = mcs_accpet ? PROPERTY.Carrier_WaitIn_System_Accept : PROPERTY.Carrier_WaitIn_System_Refuse;

            string? carrier_wait_in_result_flag_address = PortCIMBitAddress[wait_in_];
            string? carrier_wait_in_reply_address = PortCIMBitAddress[PROPERTY.Carrier_WaitIn_System_Reply];

            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, true);
            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, true);

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

            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_reply_address, false);
            EQParent.CIMMemOptions.memoryTable.WriteOneBit(carrier_wait_in_result_flag_address, false);

            return timeout;

        }
        private void Secs_client_OnPrimaryMessageRecieve(object? sender, PrimaryMessageWrapper messagePrimary)
        {
            Task.Factory.StartNew(() =>
            {
                var mcs_msg = messagePrimary.PrimaryMessage;
                bool IsRCMD = mcs_msg.TryGetRCMDAction_S2F49(out RCMD RCMD, out Item parameterGroups);
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.TRANSFER)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = true;
                }
                if (IsRCMD && RCMD == SECSMessageHelper.RCMD.NOTRANSFERNOTIFY)
                {
                    CarrierWaitIn_Reply = true;
                    CarrierWaitIn_Accept = false;

                    AlarmManager.AddWarning(ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_REJECT, Properties.PortID);
                }
            });
        }
    }
}
