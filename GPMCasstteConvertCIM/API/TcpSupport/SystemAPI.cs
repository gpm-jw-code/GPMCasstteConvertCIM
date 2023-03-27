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
        private void CreateTcpServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 23000);
            server.Bind(endPoint);
            server.Listen(1000);

            StertListenAccept(server);
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
            _ = Task.Run(() =>
            {
                while (true)
                {
                    Socket client = server.Accept();
                    clsSocketState state = new clsSocketState(client);
                    client.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                }
            });
        }

        private void ClientRecieveCB(IAsyncResult ar)
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

                state.socket.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
