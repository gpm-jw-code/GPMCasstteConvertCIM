using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.AlarmDevice;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal static class SECSState
    {
        internal static bool _IsOnline;
        internal static bool _IsRemote;
        private static clsAgvsAlarmDevice clsAgvsAlarmDevice = new clsAgvsAlarmDevice();
        public  static AlarmDeviceFunction AdamAlarmDevice = new AlarmDeviceFunction();
        internal static bool IsOnline
        {
            get => _IsOnline;
            set
            {
                if (_IsOnline != value)
                {
                    
                    Utility.SystemLogger.Info($"AGVS/MCS Online Mode Changed to {(value ? "Online" : "Offline")}");
                    _IsOnline = value;
                    if (_IsRemote && _IsOnline)
                    {
                        clsAgvsAlarmDevice.Return_Online();//offline轉online
                        AdamAlarmDevice.RuturnOnlineRemote(); ;//offline轉online
                        OnMCSOnlineRemote("", EventArgs.Empty);
                    } 
                }
            }
        }
        internal static bool IsRemote
        {
            get => _IsRemote;
            set
            {
                if (_IsRemote != value)
                {
                    Utility.SystemLogger.Info($"AGVS/MCS Operation Mode Changed to {(value ? "Remote" : "Local")}");
                    _IsRemote = value;
                    if (_IsRemote && _IsOnline)
                    {
                        clsAgvsAlarmDevice.Return_Online(); ///local轉remote
                        AdamAlarmDevice.RuturnOnlineRemote();///local轉remote
                        OnMCSOnlineRemote("", EventArgs.Empty);
                    }
                }
            }
        }

        internal static event EventHandler OnMCSOnlineRemote;
    }
}
