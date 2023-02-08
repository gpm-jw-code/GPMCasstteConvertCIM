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

namespace GPMCasstteConvertCIM.CIM.SecsMessageHandle
{
    internal class MCSMessageHandler
    {

        internal static void PrimaryMessageOnReceivedAsync(object? sender, PrimaryMessageWrapper _primaryMessageWrapper)
        {
            var secs_client = sender as SECSBase;
            using SecsMessage _primaryMessage = _primaryMessageWrapper.PrimaryMessage;

            bool reply = false;
            if (_primaryMessage.S == 1 && _primaryMessage.F == 13) // 
            {
                Utility.SystemLogger?.Info($"HOST要求 [設備連線建立]_{_primaryMessage}");
                _primaryMessage.TryGetConnectRequestParam(out string _mdln, out string _softrev);
                reply = _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.COMMUNICATION.EstablishCommunicationRequestAcknowledgeMessage(SECSMessageHelper.COMMACK.Accepted, _mdln, _softrev)).Result;
            }
            else if (_primaryMessage.S == 1 && _primaryMessage.F == 17) //HOST要求 [設備上線]
            {

                Utility.SystemLogger?.Info($"HOST要求 [設備上線]_{_primaryMessage}");
                reply = _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.ONOFFLINE.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Accepted)).Result;
                //await _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.ONOFFLINE.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Not_Allowed));

                secs_client.SendAsync(SECSMessageHelper.EVENT_REPORT.ChangeOnLineLocalModeEventReportMessage(12, "CASSTTE_CONVERT_1"));

            }
            else if (_primaryMessage.S == 1 && _primaryMessage.F == 15) //HOST要求 [設備下線]
            {
                Utility.SystemLogger?.Info($"HOST要求 [設備下線]_{_primaryMessage}");
                reply = _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.ONOFFLINE.OffLineRequestAcknowledgeMessage()).Result;
                //await _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.ONOFFLINE.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Not_Allowed));
                secs_client.SendAsync(SECSMessageHelper.EVENT_REPORT.ChangeOfflineModeEventReportMessage(12, "CASSTTE_CONVERT_1"));

            }
            else if (_primaryMessage.S == 2 && _primaryMessage.F == 41)
            {
                _primaryMessage.TryGetRCMDAction(out SECSMessageHelper.RCMD cmd);
                RCMDHandler(_primaryMessageWrapper, cmd);
            }
            else if (_primaryMessage.S == 2 && _primaryMessage.F == 49)
            {
                _primaryMessage.TryGetRCMDAction(out SECSMessageHelper.RCMD cmd);
                RCMDHandler(_primaryMessageWrapper, cmd);
            }
        }

        private static void RCMDHandler(PrimaryMessageWrapper _primaryMessageWrapper, SECSMessageHelper.RCMD cmd)
        {
            switch (cmd)
            {
                case SECSMessageHelper.RCMD.CANCEL:
                    break;
                case SECSMessageHelper.RCMD.ABORT:
                    break;
                case SECSMessageHelper.RCMD.PAUSE:
                    break;
                case SECSMessageHelper.RCMD.RESUME:
                    break;
                case SECSMessageHelper.RCMD.SCAN:
                    break;
                case SECSMessageHelper.RCMD.PRIORITYUPDATE:
                    break;
                case SECSMessageHelper.RCMD.PORTTYPECHG:
                    break;
                case SECSMessageHelper.RCMD.INSTALL:
                    break;
                case SECSMessageHelper.RCMD.REMOVE:
                    break;
                case SECSMessageHelper.RCMD.CDAPURGE:
                    break;
                case SECSMessageHelper.RCMD.RESERVE:
                    break;
                case SECSMessageHelper.RCMD.RESERVESTORAGE:
                    break;
                case SECSMessageHelper.RCMD.CANCELRESERVESTORAGE:
                    break;
                case SECSMessageHelper.RCMD.TRANSFER:
                    break;
                default:
                    break;
            }
            TransmitMsgToAGVS(_primaryMessageWrapper);
        }

        private static async void TransmitMsgToAGVS(PrimaryMessageWrapper _primaryMessageWrapper)
        {
            Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] From MCS : {_primaryMessageWrapper.PrimaryMessage.ToSml()}");

            SecsMessage secondaryMsgFromAGVS = await DevicesManager.secs_host.SendAsync(_primaryMessageWrapper.PrimaryMessage);

            Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] AGVS Reply : {secondaryMsgFromAGVS.ToSml()}");

            //回傳給MCS
            bool reply_to_mcs_succss = await _primaryMessageWrapper.TryReplyAsync(secondaryMsgFromAGVS);

            Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] Message Transfer Finish");

        }
    }
}
