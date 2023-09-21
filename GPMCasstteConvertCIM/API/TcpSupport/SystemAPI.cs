using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.TcpSupport
{
    public class SystemAPI
    {
        public SystemAPI() { }

        public async Task Start()
        {
            CreateTcpServer();
        }
        public virtual int Port { get; set; } = 23000;
        private void CreateTcpServer()
        {
            try
            {

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, Port);
                server.Bind(endPoint);
                server.Listen(1000);
                StertListenAccept(server);
                Utility.SystemLogger.Info($"TCP/IP Server{endPoint.ToString()} Created !");

            }
            catch (Exception ex)
            {

            }
        }
        public class clsSocketState
        {
            public Socket socket { get; }
            public byte[] buffer = new byte[4096];

            public clsSocketState(Socket socket)
            {
                this.socket = socket;
            }
        }
        private async void StertListenAccept(Socket server)
        {
            await Task.Delay(1);
            _ = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    await Task.Delay(1);
                    Socket client = server.Accept();
                    clsSocketState state = new clsSocketState(client);
                    try
                    {
                        client.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
        }

        public virtual void ClientRecieveCB(IAsyncResult ar)
        {
            try
            {

                clsSocketState state = (clsSocketState)ar.AsyncState;
                int revLen = state.socket.EndReceive(ar);

                if (revLen > 0)
                {
                    string msg = Encoding.ASCII.GetString(state.buffer, 0, revLen);

                    if (msg.Contains("CLOSE_APP"))
                    {
                        Environment.Exit(0);
                    }
                }

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        state.socket.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                    }
                    catch (Exception ex)
                    {
                        Utility.SystemLogger.Error(ex.Message, ex);
                    }
                });
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
