using GPMCasstteConvertCIM.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.TcpSupport
{
    internal class EQDIODataAPI : SystemAPI
    {
        public class clsDIO_STATUS
        {
            public bool Load_Request { get; set; } = false;
            public bool Unload_Request { get; set; } = false;
            public bool PortExist { get; set; } = false;
            public bool Up_Pose { get; set; } = false;
            public bool Down_Pose { get; set; } = false;
            public bool EQ_Status_Run { get; set; } = false;
        }

        public override int Port { get; set; } = 6100;
        public override void ClientRecieveCB(IAsyncResult ar)
        {
            try
            {
                clsSocketState state = (clsSocketState)ar.AsyncState;
                int revLen = state.socket.EndReceive(ar);
                if (revLen > 0)
                {
                    string msg = Encoding.ASCII.GetString(state.buffer, 0, revLen).ToUpper();
                    if (msg.Contains("GETDIOSTATUS"))
                    {
                        Dictionary<int, clsDIO_STATUS> data = DevicesManager.GetAllPorts().ToDictionary(p => p.Properties.TagNumberInAGVS, p => new clsDIO_STATUS
                        {
                            Load_Request = p.LoadRequest,
                            Unload_Request = p.UnloadRequest,
                            PortExist = p.PortExist,
                            Up_Pose = p.LD_UP_POS,
                            Down_Pose = p.LD_DOWN_POS,
                            EQ_Status_Run = p.PortStatusDown
                        });

                        var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                        state.socket.Send(Encoding.ASCII.GetBytes(json));
                    }
                }

                state.socket.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
            }
            catch (Exception ex)
            {
                //
            }

        }
    }
}
