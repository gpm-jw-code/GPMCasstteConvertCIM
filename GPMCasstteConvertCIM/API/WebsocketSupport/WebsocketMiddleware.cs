using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using WebSocketSharp;
using GPMCasstteConvertCIM.API.WebsocketSupport.GPMWebsocketBehaviors;
using Newtonsoft.Json;
using GPMCasstteConvertCIM.Devices;

namespace GPMCasstteConvertCIM.API.WebsocketSupport
{
    public class WebsocketMiddleware
    {

        public static void ServerBuild()
        {
            Task.Run(() =>
            {
                WebSocketServer server = new WebSocketServer(11441);
                server.AddWebSocketService<EQStatusBehavior>("/eq_status");
                server.AddWebSocketService<UIBehavior>("/ui");
                server.AddWebSocketService<RemoveCarrierDataBehavior>("/ui/remove_carrier_data");
                server.Start();
            });
        }

        public class SimpleReplyViewModel
        {
            public bool confirm { get; set; }
            public string message { get; set; } = string.Empty;

            public SimpleReplyViewModel()
            {

            }

            public SimpleReplyViewModel(bool confirm, string message)
            {
                this.confirm = confirm;
                this.message = message;
            }

            internal string Json
            {
                get
                {
                    return JsonConvert.SerializeObject(this, Formatting.Indented);
                }
            }
        }

        private class RemoveCarrierDataBehavior : WebSocketBehavior
        {
            public class RemoveCarrierIDReqViewModel
            {
                public string PortID { get; set; } = string.Empty;
                public string CarrierID { get; set; } = string.Empty;
            }

            protected override void OnMessage(MessageEventArgs e)
            {
                RemoveCarrierIDReqViewModel req = JsonConvert.DeserializeObject<RemoveCarrierIDReqViewModel>(e.Data);
                var port = DevicesManager.GetPortByPortID(req.PortID);
                if (port != null)
                {

                    port.ReportCarrierRemovedCompToMCS();
                    Send(new SimpleReplyViewModel(true, "").Json);
                }
                else
                {
                    Send(new SimpleReplyViewModel(false, $"NO Exist Port-{req.PortID}").Json);
                }

            }
        }
    }
}
