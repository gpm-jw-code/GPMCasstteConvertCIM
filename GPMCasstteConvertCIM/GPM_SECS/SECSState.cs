using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.AlarmDevice;
using GPMCasstteConvertCIM.API.KGAGVS;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal static class SECSState
    {
        internal static bool _IsOnline;
        internal static bool _IsRemote;
        private static clsAgvsAlarmDevice clsAgvsAlarmDevice = new clsAgvsAlarmDevice();

        public static EQLotIDMonitor EqLotIDMonitor { get; internal set; }

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
                        clsAgvsAlarmDevice.Return_Online();
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
                    if (value)
                    {
                        if (EqLotIDMonitor.Config.Enabled)
                            EqLotIDMonitor.InitIDStored();
                    }
                    if (_IsRemote && _IsOnline)
                    {
                        clsAgvsAlarmDevice.Return_Online();
                        OnMCSOnlineRemote("", EventArgs.Empty);
                    }
                }
            }
        }

        internal static event EventHandler OnMCSOnlineRemote;
    }
}
