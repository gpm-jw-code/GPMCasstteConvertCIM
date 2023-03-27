using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using GPMCasstteConvertCIM.API.WebsocketSupport.GPMWebsocketBehaviors;

namespace GPMCasstteConvertCIM.API.WebsocketSupport
{
    public class WebsocketMiddleware
    {

        public static void ServerBuild()
        {
            Task.Run(() =>
            {
                WebSocketServer server = new WebSocketServer(25231);
                server.AddWebSocketService<EQStatusBehavior>("/eq_status");
                server.Start();
            });
        }
    }
}
