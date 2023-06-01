using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.Devices;
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
        protected override void OnOpen()
        {
            base.OnOpen();
        }

        protected override void OnClose(CloseEventArgs e)
        {
            base.OnClose(e);
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            if (e.Data.Contains("port_type_change"))
            {
                string portID = e.Data.Split(':')[1];
                string portTypeStr = e.Data.Split(":")[2];

                var port = DevicesManager.GetPortByPortID(portID);
                if (port == null)
                {
                    Send("NG");
                    return;
                }

                port.ModeChangeRequestHandshake(portTypeStr == "0" ? GPM_SECS.PortUnitType.Input : GPM_SECS.PortUnitType.Output);
            }

            if (e.Data == "clear_alarm")
            {
                AlarmManager.ClearAlarm();
            }
            base.Send("OK");
        }
    }
}
