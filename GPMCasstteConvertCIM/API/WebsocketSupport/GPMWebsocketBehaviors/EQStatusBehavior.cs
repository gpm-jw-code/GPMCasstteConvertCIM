using GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel;
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

                            var viewData = DevicesManager.casstteConverters.Select(eqp => new EQPViewModel()
                            {
                                EqName = eqp.Name,
                                IsDown = eqp.EQPData.EQP_DOWN,
                                IsIdle = eqp.EQPData.EQP_IDLE,
                                IsRun = eqp.EQPData.EQP_RUN,
                                Connected = eqp.Connected,
                                Ports = eqp.EQPData.PortDatas.Select(port => new PortViewModel()
                                {
                                    PortID = port.Properties.PortID,
                                    PortType = port.EPortType,
                                    AutoState = port.EPortAutoStatus,
                                    IsInService = port.PortStatusDown,
                                    DIOSignalsState = new DIOViewModel
                                    {
                                        LoadRequest = port.LoadRequest,
                                        UnloadRequest = port.UnloadRequest,
                                        PortExist = port.PortExist,
                                        PortStatusDown = port.PortStatusDown,
                                        LDUpPose = port.LD_UP_POS,
                                        LDDownPose = port.LD_DOWN_POS,
                                    },
                                    HSSignalsState = new HSSignalViewModel
                                    {
                                        EQ_BUSY = port.EQ_BUSY,
                                        EQ_READY = port.EQ_READY,
                                        L_REQ = port.L_REQ,
                                        U_REQ = port.U_REQ
                                    }
                                }).ToList()
                            });

                            //IEnumerable<CasstteConverter.Data.clsEQPData> eqdatas = DevicesManager.casstteConverters.Select(eq => eq.EQPData);
                            string json = JsonConvert.SerializeObject(viewData);
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
