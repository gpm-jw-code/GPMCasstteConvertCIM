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
using GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.GPM_SECS;

namespace GPMCasstteConvertCIM.API.WebsocketSupport
{
    public class WebsocketMiddleware
    {

        public static void ServerBuild()
        {
            Task.Run(() =>
            {
                WebSocketServer server = new WebSocketServer(11441);
                server.AddWebSocketService<SystemStateBehavior>("/system_state");
                server.AddWebSocketService<EQStatusBehavior>("/eq_status");
                server.AddWebSocketService<UIBehavior>("/ui");
                server.AddWebSocketService<RemoveCarrierDataBehavior>("/ui/remove_carrier_data");
                server.AddWebSocketService<SecsLogBehavior>("/secslog");
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
                    bool confirm = port.SecsEventReport(CEID.CarrierRemovedCompletedReport).Result;
                    Send(new SimpleReplyViewModel(true, "Carrier Removed Completed ! \r\n請將載具從 Port 移除").Json);
                }
                else
                {
                    Send(new SimpleReplyViewModel(false, $"NO Exist Port-{req.PortID}").Json);
                }

            }
        }

        private class SystemStateBehavior : WebSocketBehavior
        {
            protected override void OnOpen()
            {

                Task.Run(() =>
                {
                    while (State == WebSocketSharp.WebSocketState.Open)
                    {
                        SystemStateViewModel data = new SystemStateViewModel
                        {
                            IsOnlineMode = frmMain.IsOnline,
                            IsAGVSSecsConnected = DevicesManager.secs_client_for_agvs.connector.State == Secs4Net.ConnectionState.Selected,
                            IsMCSSecsConnected = DevicesManager.secs_host_for_mcs.connector.State == Secs4Net.ConnectionState.Selected,
                            Alarms = AlarmManager.AlarmsList.ToList()
                        };

                        Send(JsonConvert.SerializeObject(data));

                        Thread.Sleep(1000);
                    }
                });

            }
        }

        private class SecsLogBehavior : WebSocketBehavior
        {
            protected override void OnOpen()
            {
                SECSBase.OnPrimaryMsgSendOut += SECSBase_OnPrimaryMsgSendOut;
                //Task.Run(() =>
                //{
                //    while (State == WebSocketSharp.WebSocketState.Open)
                //    {
                //        //
                //        Thread.Sleep(1);
                //    }
                //});
                base.OnOpen();
            }

            private void SECSBase_OnPrimaryMsgSendOut(object? sender, SecsLogViewModel e)
            {
                Send(JsonConvert.SerializeObject(e));
            }

            protected override void OnClose(CloseEventArgs e)
            {
                SECSBase.OnPrimaryMsgSendOut -= SECSBase_OnPrimaryMsgSendOut;
                base.OnClose(e);

            }
        }
    }
}
