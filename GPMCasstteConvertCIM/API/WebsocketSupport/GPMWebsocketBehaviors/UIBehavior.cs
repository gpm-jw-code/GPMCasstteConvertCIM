using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.CasstteConverter;
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

                var port = GetPortByID(portID);
                if (port == null)
                {
                    Send("NG");
                    return;
                }

                port.ModeChangeRequestHandshake(portTypeStr == "0" ? GPM_SECS.PortUnitType.Input : GPM_SECS.PortUnitType.Output);
            }

            if (e.Data.Contains("event_report"))
            {
                string portID = e.Data.Split(':')[1];
                clsConverterPort port = GetPortByID(portID);
                if (port == null)
                {
                    Send("NG");
                    return;
                }
                string event_str = e.Data.Split(":")[2];
                EventReportHandle(port, event_str);
            }

            if (e.Data == "clear_alarm")
            {
                AlarmManager.ClearAlarm();
            }
            base.Send("OK");
        }
        private clsConverterPort GetPortByID(string port_id)
        {
            return DevicesManager.GetPortByPortID(port_id);

        }
        private void EventReportHandle(clsConverterPort port, string event_str)
        {
            switch (event_str)
            {
                case "in-service":
                    port.SecsEventReport(GPM_SECS.CEID.PortInServiceReport);
                    break;
                case "out-out-service":
                    port.SecsEventReport(GPM_SECS.CEID.PortOutOfServiceReport);
                    break;
                case "port-type-input":
                    port.SecsEventReport(GPM_SECS.CEID.PortTypeInputReport);
                    break;
                case "port-type-output":
                    port.SecsEventReport(GPM_SECS.CEID.PortTypeOutputReport);
                    break;
                case "carrier-removed-completed":
                    port.SecsEventReport(GPM_SECS.CEID.CarrierRemovedCompletedReport);
                    break;
                case "carrier-wait-in":
                    port.SecsEventReport(GPM_SECS.CEID.CarrierWaitIn);
                    break;
                case "carrier-wait-out":
                    port.SecsEventReport(GPM_SECS.CEID.CarrierWaitOut);
                    break;
            }
        }
    }
}
