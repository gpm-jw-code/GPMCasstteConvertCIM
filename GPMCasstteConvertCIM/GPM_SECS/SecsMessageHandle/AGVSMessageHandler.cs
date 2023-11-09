using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using static Secs4Net.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPMCasstteConvertCIM.CasstteConverter;

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{
    internal class AGVSMessageHandler
    {
        internal static event EventHandler OnAGVSOnline_Local;
        internal static event EventHandler OnAGVSOnline_Remote;
        internal static event EventHandler OnAGVSOffline;
        private static SECSBase MCS => DevicesManager.secs_host_for_mcs;
        private static SECSBase AGVS => DevicesManager.secs_client_for_agvs;
        /// <summary>
        /// 處理AGVS PrimaryMessage >>轉送給MCS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal async static void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            byte ack6 = 0;

            Utility.SystemLogger.SecsTransferLog($"Primary Mesaage Recieved From AGVS");

            using SecsMessage _primaryMessage_FromAGVS = _primaryMessageWrapper.PrimaryMessage;

            AGVS.MsgSendOutInvokeHandle(_primaryMessage_FromAGVS, false);

            Utility.SystemLogger.SecsTransferLog($"Primary Mesaage From AGVS : {_primaryMessage_FromAGVS.ToSml()}");

            _primaryMessageWrapper.PrimaryMessage.Name = "AGVS_To_CIM";
            clsConverterPort port = null;
            bool IsTransferCompleteToTSReport = false;
            if (_primaryMessage_FromAGVS.IsAGVSTransferCompletedReport(out string port_id, out string carrier_id_from_agvs_transferComplete))
            {
                port = DevicesManager.GetPortByPortID(port_id);
                IsTransferCompleteToTSReport = (port != null);
            }

            if (IsTransferCompleteToTSReport && !port.IsCarrierInstallReported)
            {
                port.IsCarrierInstallReported = true;
            }

            var S = _primaryMessage_FromAGVS.S;
            var F = _primaryMessage_FromAGVS.F;

            if (S == 1 && F == 13)
            {
                SecsMessage Establish_Communication_Request_DENIED_Acknowledge = new SecsMessage(1, 14, false)
                {
                    SecsItem = L(
                            B(1),
                            L(
                                A(""),
                                A("")
                             )
                        )
                };
                if (MCS.connector == null)
                {
                    Utility.SystemLogger.SecsTransferLog($"MCS Not Connected, Send S1F14  COMMACK =1 (Denied)");
                    _primaryMessageWrapper.TryReplyAsync(Establish_Communication_Request_DENIED_Acknowledge);
                    return;
                }
                if (MCS.connector.State != ConnectionState.Selected)
                {
                    Utility.SystemLogger.SecsTransferLog($"MCS Not Selected, Send S1F14  COMMACK =1 (Denied)");
                    _primaryMessageWrapper.TryReplyAsync(Establish_Communication_Request_DENIED_Acknowledge);
                    return;
                }
            }



            Utility.SystemLogger.SecsTransferLog($"Start Transfer To MCS");
            MCS.MsgSendOutInvokeHandle(_primaryMessage_FromAGVS, true);
            SecsMessage secondaryMsgFromMCS = await MCS.SendMsg(_primaryMessage_FromAGVS, msg_name: "AGVS->CIM");


            if (secondaryMsgFromMCS.S == 1 && secondaryMsgFromMCS.F == 4)
            {
                //TODO if has 2004 , add port data
            }


            if (_primaryMessage_FromAGVS.ReplyExpected)
            {
                Utility.SystemLogger.SecsTransferLog($"MCS Reply : {secondaryMsgFromMCS.ToSml()}");
                AGVS.MsgSendOutInvokeHandle(secondaryMsgFromMCS, true);
                bool reply_to_agvs_success = await _primaryMessageWrapper.TryReplyAsync(secondaryMsgFromMCS);
                if (reply_to_agvs_success)
                    Utility.SystemLogger.SecsTransferLog($"Message Reply to AGVS Finish");
                else
                    Utility.SystemLogger.SecsTransferLog($"Message Reply to AGVS Fail..");
            }

            try
            {
                if (_primaryMessage_FromAGVS.S == 6 && _primaryMessage_FromAGVS.F == 12)
                    ack6 = _primaryMessage_FromAGVS.SecsItem.FirstValue<byte>();

                if (_primaryMessage_FromAGVS.IsAGVSOnlineReport(out bool isRemote))
                {
                    SECSState.IsOnline = true;
                    SECSState.IsRemote = isRemote;

                    if (ack6 == 0)
                    {
                        if (isRemote)
                            OnAGVSOnline_Remote?.Invoke("", EventArgs.Empty);
                        else
                            OnAGVSOnline_Local?.Invoke("", EventArgs.Empty);
                    }
                }
                if (_primaryMessage_FromAGVS.IsAGVSOfflineReport())
                {
                    SECSState.IsOnline = false;
                    if (ack6 == 0)
                        OnAGVSOffline?.Invoke("", EventArgs.Empty);
                }
                if (IsTransferCompleteToTSReport)
                {
                    port.TransferCompletedInvoke(carrier_id_from_agvs_transferComplete);
                }
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.SecsTransferLog($"Transfer Exception (AGVS -> MCS) ! [{ex}]");
                AlarmManager.AddWarning(ALARM_CODES.ONLINE_MODE_MONITORING_ERROR, "AGVSMHANDLER", false);
            }

        }
    }
}
