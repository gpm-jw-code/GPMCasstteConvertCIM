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


            if (_primaryMessage.S == 2 && _primaryMessage.F == 33) // Define Report
            {
                SECSMessageHelper.DefineReport(_primaryMessage);
            }
            if (_primaryMessage.S == 2 && _primaryMessage.F == 35) // Link Event Report
            {
                SECSMessageHelper.LinkEventReport(_primaryMessage);
            }
            if (_primaryMessage.S == 2 && _primaryMessage.F == 41)
            {
                _primaryMessage.TryGetRCMDAction(out SECSMessageHelper.RCMD cmd);
                RCMDHandler(_primaryMessageWrapper, cmd);
                return;
            }
            TransmitMsgToAGVS(_primaryMessageWrapper);
            return;

            if (_primaryMessage.S == 1 && _primaryMessage.F == 13) // 
            {
                Utility.SystemLogger?.Info($"HOST要求 [設備連線建立]_{_primaryMessage}");
                _primaryMessage.TryGetConnectRequestParam(out string _mdln, out string _softrev);
                TransmitMsgToAGVS(_primaryMessageWrapper);
                //reply = _primaryMessageWrapper.TryReplyAsync(SECSMessageHelper.COMMUNICATION.EstablishCommunicationRequestAcknowledgeMessage(SECSMessageHelper.COMMACK.Accepted, _mdln, _softrev)).Result;
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
            else if (_primaryMessage.S == 6 && _primaryMessage.F == 11)
            {
                _primaryMessageWrapper.TryReplyAsync(new SecsMessage(6, 12)
                {
                    SecsItem = B(0)
                });
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
            try
            {
                var primaryMsgFromMcs = _primaryMessageWrapper.PrimaryMessage;
                Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] From MCS : {primaryMsgFromMcs.ToSml()}");

                SecsMessage secondaryMsgFromAGVS = await DevicesManager.secs_client_for_agvs.SendAsync(primaryMsgFromMcs);

                Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] AGVS Reply : {secondaryMsgFromAGVS.ToSml()}");

                if (primaryMsgFromMcs.S == 1 && primaryMsgFromMcs.F == 3) //TODO 再加上 svid 2005/2009資訊 
                {

                    var SVIDItemList = primaryMsgFromMcs.SecsItem.Items.ToList();
                    //找到2009是第幾個
                    Item? CurrentPortStatesItems = SVIDItemList.FirstOrDefault(item => item.FirstValue<ushort>() == 2005);
                    Item? PortTypesItems = SVIDItemList.FirstOrDefault(item => item.FirstValue<ushort>() == 2009);
                    
                    if (CurrentPortStatesItems != null)
                    {
                        int PortTypes = primaryMsgFromMcs.SecsItem.Items.ToList().FindIndex(item => item == PortTypesItems);
                    }

                    if (PortTypesItems != null)
                    {
                        int PortTypes = primaryMsgFromMcs.SecsItem.Items.ToList().FindIndex(item => item == PortTypesItems);
                    }

                    //secondaryMsgFromAGVS.SecsItem.Items[0][0].Items.Append();
                }

                //回傳給MCS
                bool reply_to_mcs_succss = await _primaryMessageWrapper.TryReplyAsync(secondaryMsgFromAGVS);

                Utility.SystemLogger.Info($"[MCS SECS Message > AGVS] Message Transfer Finish");
            }
            catch (Exception ex)
            {

            }

        }
    }
}
