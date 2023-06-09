﻿using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        private string speficCarrierID = "";
        /// <summary>
        /// 是否等待Wait In
        /// </summary>
        internal bool IsCarrierWaitInQueuing = false;

        internal async Task<bool> SecsEventReport(CEID ceid, string carrier_id)
        {
            speficCarrierID = carrier_id;
            return await SecsEventReport(ceid);
        }
        public async Task<bool> SecsEventReport(CEID ceid)
        {
            if ((ceid == CEID.CarrierWaitIn | ceid == CEID.CarrierWaitOut) && EQParent.converterType == Enums.CONVERTER_TYPE.IN_SYS)
                return true;

            Utility.SystemLogger.Info($"Event Report(CEID={ceid}) To MCS.");
            SecsMessage msgSend = await CreateMsgByCEID(ceid);

            //Offline
            if (!SECSState.IsOnline && !SECSState.IsRemote)
            {
                if (ceid == CEID.CarrierWaitIn)
                {
                    Utility.SystemLogger.Info($"CarrierWaitIn But MCS Not Online-Remote.  IsCarrierWaitInQueuing = true");
                    IsCarrierWaitInQueuing = true;
                    return true;
                }
                else if (ceid == CEID.CarrierRemovedCompletedReport | ceid == CEID.CarrierWaitOut)
                    IsCarrierWaitInQueuing = false;
            }


            if (ceid == CEID.CarrierWaitOut)
                await WaitTransferCompleted();

            try
            {
                SecsMessage msgReply = await MCS.SendMsg(msgSend);
                if (msgReply.IsS9F7())
                {
                    AlarmManager.AddWarning(ALARM_CODES.Port_Event_Report_Timeout, Properties.PortID);
                    return false;
                }
                else
                {
                    Utility.SystemLogger.Info($"Event Report MCS Reply = {msgReply.ToSml()}");
                    if (ceid == CEID.CarrierWaitIn)
                    {
                        bool mcs_accpet = msgReply.SecsItem.FirstValue<byte>() == 0;
                        return mcs_accpet && await WaitTransferTaskDownloaded();
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                AlarmManager.AddWarning(ALARM_CODES.Port_Event_Report_Code_Error, Properties.PortID);
                return false;
            }

        }


        private async Task<SecsMessage> CreateMsgByCEID(CEID ceid)
        {
            string carrier_id = speficCarrierID != "" ? speficCarrierID.ToString() : (Previous_WIPINFO_BCR_ID != "" ? Previous_WIPINFO_BCR_ID : WIPINFO_BCR_ID);
            string port_id = Properties.PortID;

            speficCarrierID = "";

            bool isAutoMode = EPortAutoStatus == Enums.AUTO_MANUAL_MODE.AUTO;
            switch (ceid)
            {
                case CEID.CarrierWaitIn:
                    await WaitBARCODEREADIN();
                    return EventsMsg.CarrierWaitIn(carrier_id, port_id);
                case CEID.CarrierWaitOut:
                    return EventsMsg.CarrierWaitOut(carrier_id, port_id);
                case CEID.CarrierInstallCompletedReport:
                    return EventsMsg.CarrierInstalled(carrier_id, port_id, isAutoMode);
                case CEID.CarrierRemovedCompletedReport:
                    return EventsMsg.CarrierRemovedCompleted(carrier_id, port_id, isAutoMode);

                case CEID.PortOutOfServiceReport:
                    return EventsMsg.PortService(port_id, false);
                case CEID.PortInServiceReport:
                    return EventsMsg.PortService(port_id, true);

                case CEID.PortTypeInputReport:
                    return EventsMsg.PortType(port_id, PortUnitType.Input);
                case CEID.PortTypeOutputReport:
                    return EventsMsg.PortType(port_id, PortUnitType.Output);

                default:
                    throw new NotImplementedException();
            }
        }

        private async Task WaitBARCODEREADIN()
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            while (WIPINFO_BCR_ID == "")
            {
                if (cts.IsCancellationRequested)
                    return;
                await Task.Delay(1);
            }
        }

        /// <summary>
        ///等待MCS有下Transfer任務給AGVS取當前Carrier。
        /// </summary>
        /// <param name="cst_id"></param>
        /// <returns></returns>
        private async Task<bool> WaitTransferTaskDownloaded()
        {
            CancellationTokenSource cancelwait = new CancellationTokenSource(TimeSpan.FromSeconds(60));
            while (!CurrentCSTHasTransferTaskFlag)
            {
                if (cancelwait.IsCancellationRequested)
                {
                    Utility.SystemLogger.Warning($"{Properties.PortID} _ Carrier- {WIPINFO_BCR_ID} No body known where to go . No AGV To Transfer....");
                    return false;
                }
                if (NoTransferNotifyFlag)
                {
                    Utility.SystemLogger.Warning($"{Properties.PortID} _ Carrier- {WIPINFO_BCR_ID} MCS NO Transfer Notify. No AGV To Transfer...");
                    NoTransferNotifyFlag = false; //reset flag
                    return false;
                }
                await Task.Delay(1);
            }
            Utility.SystemLogger.Warning($"{Properties.PortID} _ Carrier- {WIPINFO_BCR_ID} AGV Will Transfer this carrier later.");
            CurrentCSTHasTransferTaskFlag = false; //reset flag
            return true;
        }

        /// <summary>
        /// 等待
        /// </summary>
        /// <returns></returns>
        private async Task WaitTransferCompleted(int timeout_sec = 5)
        {
            //確保Wait Out Event Report在 Transfer Completed 之後
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeout_sec));
            while (!Carrier_TransferCompletedFlag)
            {
                if (cts.IsCancellationRequested)
                    break;
                await Task.Delay(1);
            }
            Carrier_TransferCompletedFlag = false;
        }


    }
}
