using GPMCasstteConvertCIM.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.GPMWebsocketBehaviors
{
    internal class EQStatusBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            base.OnMessage(e);
        }

        protected override void OnOpen()
        {
            base.OnOpen();
            SendEQStatusDataWorker();
        }

        private void SendEQStatusDataWorker()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        if (base.State == WebSocketState.Open)
                        {

                            IEnumerable<CasstteConverter.Data.clsEQPData> eqdatas = DevicesManager.casstteConverters.Select(eq => eq.EQPData);
                            string json = JsonConvert.SerializeObject(eqdatas);
                            Send(json);
                        }
                        else if (State == WebSocketState.Closed)
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                    await Task.Delay(1000);
                   
                }

            });
        }

        private void callback(bool obj)
        {
        }
    }
}
