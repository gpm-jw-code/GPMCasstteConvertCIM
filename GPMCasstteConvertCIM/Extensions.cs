using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.Devices.DevicesManager;

namespace GPMCasstteConvertCIM
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, Formatting.Indented);

            }
            catch (Exception)
            {
                return "";
            }
        }
        public static SecsGemOptions ToSecsGenOptions(this InitialOption gpmInitailOptions)
        {
            var secs_config = Utility.SysConfigs.SECS;
            return new SecsGemOptions()
            {
                DeviceId = gpmInitailOptions.DeviceId,
                Port = gpmInitailOptions.Port,
                IpAddress = gpmInitailOptions.IpAddress,
                IsActive = gpmInitailOptions.IsActive,
                T3 = secs_config.T3,
                T5 = secs_config.T5,
                T6 = secs_config.T6,
                T7 = secs_config.T7,
                T8 = secs_config.T8,
                SocketReceiveBufferSize = secs_config.SocketRecieveBufferSize,
                EncodeBufferInitialSize = 32768,
            };

        }

        internal static McInterfaceOptions ToMCIFOptions(this InitialOption gpmInitailOptions)
        {
            return new McInterfaceOptions
            {
                DataType = MC_E71_Eth.clsMC_TCPCnt.enuDataType.ASCIIStr_01,
                RemoteIP = gpmInitailOptions.IpAddress,
                RemotePort = gpmInitailOptions.Port,
                T_ConnectTimeout = 5000,
                T_MessageTimeout = 4000
            };

        }
        internal static Common.CONNECTION_STATE ToCommonConnectionState(this ConnectionState secs_connectionState)
        {
            switch (secs_connectionState)
            {
                case ConnectionState.Connecting:
                    return Common.CONNECTION_STATE.CONNECTING;
                case ConnectionState.Connected:
                    return Common.CONNECTION_STATE.CONNECTED;
                case ConnectionState.Selected:
                    return Common.CONNECTION_STATE.CONNECTED;
                case ConnectionState.Retry:
                    return Common.CONNECTION_STATE.DISCONNECTED;
                default:
                    return Common.CONNECTION_STATE.DISCONNECTED;
            }
        }

        internal static void GetClassNameAndLine(this Exception ex, out string className, out int lineNumber)
        {
            className = "";
            lineNumber = -1;
            var stackTrace = new StackTrace(ex, true);
            var frame = stackTrace.GetFrame(0); // 獲取堆棧中的第一個幀

            if (frame != null)
            {
                string fileName = frame.GetFileName(); // 獲取發生異常的文件名
                lineNumber = frame.GetFileLineNumber(); // 獲取發生異常的行號
                MethodBase method = frame.GetMethod();
                if (method != null)
                {
                    Type declaringType = method.DeclaringType;
                    if (declaringType != null)
                    {
                        className = declaringType.FullName; // 獲取完整的類名（包括命名空間）
                    }
                }
            }
        }
    }
}
