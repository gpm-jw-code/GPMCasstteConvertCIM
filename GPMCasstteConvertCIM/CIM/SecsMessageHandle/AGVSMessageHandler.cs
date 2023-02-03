using GPMCasstteConvertCIM.GPM_SECS;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CIM.SecsMessageHandle
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


            var secs_host = sender as SECSBase;
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;
            Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] From AGVS : {_primaryMessage.ToSml()}");
            var secondaryMsg = await CIMDevices.secs_client.SendAsync(_primaryMessage);
            Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] MCS Reply : {secondaryMsg.ToSml()}");
            bool reply_to_agvs_success = await _primaryMessageWrapper.TryReplyAsync(secondaryMsg);

            Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] Message Transfer Finish");
        }
    }
}
