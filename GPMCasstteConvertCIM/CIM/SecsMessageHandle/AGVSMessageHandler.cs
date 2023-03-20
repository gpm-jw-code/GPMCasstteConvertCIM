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
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;

            Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] From AGVS : {_primaryMessage.ToSml()}");

            SecsMessage secondaryMsg = await DevicesManager.secs_host_for_mcs.SendAsync(_primaryMessage);

            if (_primaryMessage.ReplyExpected)
            {
                Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] MCS Reply : {secondaryMsg.ToSml()}");
                bool reply_to_agvs_success = await _primaryMessageWrapper.TryReplyAsync(secondaryMsg);
                Utility.SystemLogger.Info($"[AGVS SECS Message > MCS] Message Transfer Finish");
            }
        }
    }
}
