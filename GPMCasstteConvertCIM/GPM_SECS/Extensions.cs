using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    public static class Extensions
    {
        public static bool TryGetConnectRequestParam(this SecsMessage msg, out string MDLN, out string SOFTREV)
        {
            MDLN = null;
            SOFTREV = null;

            try
            {
                if (msg.S != 1 && msg.F == 13)
                    return false;

                MDLN = msg.SecsItem[0].GetString();
                SOFTREV = msg.SecsItem[1].GetString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TryGetConnectRequestAckResult(this SecsMessage msg, out COMMACK ack, out string MDLN, out string SOFTREV)
        {
            MDLN = null;
            SOFTREV = null;
            ack = COMMACK.Denied_Try_Again;
            try
            {
                if (msg.S != 1 && msg.F != 14)
                    return false;

                byte ackString = msg.SecsItem[0].FirstValue<byte>();
                ack = ackString == 0x00 ? COMMACK.Accepted : COMMACK.Denied_Try_Again;
                MDLN = msg.SecsItem[1].Items[0].GetString();
                SOFTREV = msg.SecsItem[1].Items[1].GetString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static bool TryGetOnlineRequestAckResult(this SecsMessage msg, out ONLACK ack)
        {
            ack = ONLACK.Not_Allowed;
            try
            {
                if (msg.S != 1 && msg.F != 18)
                    return false;

                var ack_byte_val = msg.SecsItem.FirstValue<byte>();
                ack = ack_byte_val.ToONLACK();
                //MDLN = msg.SecsItem[1].Items[0].GetString();
                //SOFTREV = msg.SecsItem[1].Items[1].GetString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool TryGetEventReportAckResult(this SecsMessage msg, out ACKC6 ack)
        {
            ack = ACKC6.System_Error;
            try
            {
                if (msg.S != 6 && msg.F != 12)
                    return false;

                var ack_byte_val = msg.SecsItem.FirstValue<byte>();
                ack = ack_byte_val.ToACKC6();
                //MDLN = msg.SecsItem[1].Items[0].GetString();
                //SOFTREV = msg.SecsItem[1].Items[1].GetString();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool TryGetRCMDAction(this SecsMessage priMsg, byte F, out RCMD cmd, out Item ParameterGroups)
        {
            ParameterGroups = null;
            cmd = RCMD.REMOVE;
            int RCMD_Index = F == 41 ? 0 : F == 49 ? 2 : 0;
            int ParameterGroups_Index = F == 41 ? 1 : F == 49 ? 3 : 0;
            try
            {
                var cmdStr = priMsg.SecsItem[RCMD_Index].GetString();
                cmd = Enum.GetValues(typeof(RCMD)).Cast<RCMD>().FirstOrDefault(f => cmdStr == f.ToString());
                ParameterGroups = priMsg.SecsItem[ParameterGroups_Index];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool TryGetRCMDAction_S2F49(this SecsMessage priMsg, out RCMD cmd, out Item ParameterGroups)
        {
            ParameterGroups = null;
            cmd = RCMD.REMOVE;
            try
            {
                var cmdStr = priMsg.SecsItem[2].GetString();
                cmd = Enum.GetValues(typeof(RCMD)).Cast<RCMD>().FirstOrDefault(f => cmdStr == f.ToString());
                ParameterGroups = priMsg.SecsItem[3];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static ONLACK ToONLACK(this byte val)
        {
            return Enum.GetValues(typeof(ONLACK)).Cast<ONLACK>().FirstOrDefault(f => val == (byte)f);
        }

        public static ACKC6 ToACKC6(this byte val)
        {
            return Enum.GetValues(typeof(ACKC6)).Cast<ACKC6>().FirstOrDefault(f => val == (byte)f);
        }
        internal static bool IsS9F7(this SecsMessage msg)
        {
            return msg.S == 9 && msg.F == 7;
        }
        public static bool IsAGVSOnlineReport(this SecsMessage msg)
        {
            if (msg.S != 6 && msg.F != 11)
                return false;
            try
            {
                var item_check = msg.SecsItem.Items[1];
                var ce_id = item_check.FirstValue<ushort>();
                return ce_id == 2 | ce_id == 3;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsAGVSOfflineReport(this SecsMessage msg)
        {
            if (msg.S != 6 && msg.F != 11)
                return false;
            try
            {
                var item_check = msg.SecsItem.Items[1];
                var ce_id = item_check.FirstValue<ushort>();
                return ce_id == 1;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsAGVSTransferCompletedReport(this SecsMessage msg, out string port_id, out string carrier_id)
        {
            port_id = carrier_id = string.Empty;

            if (msg.S != 6 && msg.F != 11)
                return false;
            try
            {
                var item_check = msg.SecsItem.Items[1];
                var ce_id = item_check.FirstValue<ushort>();
                bool isCEID107 = ce_id == 107;

                if (isCEID107)
                {
                    var paramsItems = msg.SecsItem.Items[2][0][1];
                    carrier_id = paramsItems.Items[1].GetString();
                    port_id = paramsItems.Items[2].GetString();
                }

                return isCEID107;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
