using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
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

        /// <summary>
        /// 處理AGVS PrimaryMessage >>轉送給MCS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal async static void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {

            Utility.SystemLogger.SecsTransferLog($"Primary Mesaage Recieved From AGVS");

            using SecsMessage _primaryMessage_FromAGVS = _primaryMessageWrapper.PrimaryMessage;
            bool IsOnlineRemoteReport = _primaryMessage_FromAGVS.IsAGVSOnlineReport();

            Utility.SystemLogger.SecsTransferLog($"Primary Mesaage From AGVS : {_primaryMessage_FromAGVS.ToSml()}");

            _primaryMessageWrapper.PrimaryMessage.Name = "AGVS_To_CIM";

            Utility.SystemLogger.SecsTransferLog($"Start Transfer To MCS");
            SecsMessage secondaryMsgFromMCS = await DevicesManager.secs_host_for_mcs.ActiveSendMsgAsync(_primaryMessage_FromAGVS);

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

            //

        }
    }
}
