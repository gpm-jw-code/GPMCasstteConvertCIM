using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Devices
{
    /// <summary>
    /// 具備上下線的能力
    /// </summary>
    internal interface ISECSHandShakeable
    {
        event EventHandler<EventArgs> EQPOnline_Local_OnRequest;
        event EventHandler<EventArgs> EQPOnline_Remote_OnRequest;
        event EventHandler<EventArgs> EQPOffline_OnRequset;

        void ReplyHOSTOfflineRequest();
        void ReplyHostOnlineRequest();
    }



}
