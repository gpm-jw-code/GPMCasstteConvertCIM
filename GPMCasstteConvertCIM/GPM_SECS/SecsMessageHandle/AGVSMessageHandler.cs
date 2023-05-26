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

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle
{
    internal class AGVSMessageHandler
    {
        internal static event EventHandler OnAGVSOnline;
        internal static event EventHandler OnAGVSOffline;
        private static SECSBase MCS => DevicesManager.secs_host_for_mcs;
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

            Utility.SystemLogger.SecsTransferLog($"Primary Mesaage From AGVS : {_primaryMessage_FromAGVS.ToSml()}");

            _primaryMessageWrapper.PrimaryMessage.Name = "AGVS_To_CIM";

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
            
            SecsMessage secondaryMsgFromMCS = await MCS.SendMsg(_primaryMessage_FromAGVS);


            if (secondaryMsgFromMCS.S == 1 && secondaryMsgFromMCS.F == 4)
            {
                //TODO if has 2004 , add port data
            }
           

            if (_primaryMessage_FromAGVS.ReplyExpected)
            {
                Utility.SystemLogger.SecsTransferLog($"MCS Reply : {secondaryMsgFromMCS.ToSml()}");

                bool reply_to_agvs_success = await _primaryMessageWrapper.TryReplyAsync(secondaryMsgFromMCS);
                if (reply_to_agvs_success)
                    Utility.SystemLogger.SecsTransferLog($"Message Reply to AGVS Finish");
                else
                    Utility.SystemLogger.SecsTransferLog($"Message Reply to AGVS Fail..");
            }

            try
            {
                if (_primaryMessage_FromAGVS.S == 6 && _primaryMessage_FromAGVS.F == 12)
                {
                    ack6 = _primaryMessage_FromAGVS.SecsItem.FirstValue<byte>();
                }
                if (_primaryMessage_FromAGVS.IsAGVSOnlineReport())
                {
                    if (ack6 == 0)
                        OnAGVSOnline?.Invoke("", EventArgs.Empty);
                }
                if (_primaryMessage_FromAGVS.IsAGVSOfflineReport())
                {
                    if (ack6 == 0)
                        OnAGVSOffline?.Invoke("", EventArgs.Empty);
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
