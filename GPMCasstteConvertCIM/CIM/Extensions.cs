using GPMCasstteConvertCIM.CasstteConverter;
using Secs4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CIM.CIMDevices;

namespace GPMCasstteConvertCIM.CIM
{
    internal static class Extensions
    {
        internal static SecsGemOptions ToSecsGenOptions(this InitialOptions gpmInitailOptions)
        {
            return new SecsGemOptions()
            {
                DeviceId = gpmInitailOptions.DeviceId,
                Port = gpmInitailOptions.Port,
                IpAddress = gpmInitailOptions.IpAddress,
                IsActive = gpmInitailOptions.IsActive,
            };

        }

        internal static McInterfaceOptions ToMCIFOptions(this InitialOptions gpmInitailOptions)
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
        internal static Common.CONNECTION_STATE ToCommonConnectionState(this Secs4Net.ConnectionState secs_connectionState)
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
    }
}
