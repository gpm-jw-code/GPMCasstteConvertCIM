using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.GPMWebsocketBehaviors
{
    internal class UIBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
            base.Send("OK");
        }
    }
}
