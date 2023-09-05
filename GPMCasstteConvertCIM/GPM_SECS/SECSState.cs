using Secs4Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_SECS
{
    internal static class SECSState
    {
        internal static bool _IsOnline;
        internal static bool _IsRemote;
        internal static bool IsOnline
        {
            get => _IsOnline;
            set
            {
                if (_IsOnline != value)
                {
                    _IsOnline = value;
                    if (_IsRemote && _IsOnline)
                    {
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
                    _IsRemote = value;
                    if(_IsRemote && _IsOnline)
                    {
                        OnMCSOnlineRemote("",EventArgs.Empty);
                    }
                }
            }
        }

        internal static event EventHandler OnMCSOnlineRemote;
    }
}
