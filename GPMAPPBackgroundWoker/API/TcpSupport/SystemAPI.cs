using GPMAPPBackgroundWoker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.TcpSupport
{
    public class SystemAPI
    {
        private readonly clsConfig config;

        public SystemAPI(GPMAPPBackgroundWoker.clsConfig config)
        {

            this.config = config;
        }

        public async Task Start()
        {
            CreateTcpServer();
        }
        private void CreateTcpServer()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 33838);
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
                    try
                    {
                        client.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                    }
                    catch (Exception)
                    {
                    }
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
                    string msg = Encoding.ASCII.GetString(state.buffer, 0, revLen).ToUpper();
                    if (msg.Contains("CLOSECIM"))
                    {
                        CloseProcess(config.CIMAPP_FilePath);
                        state.socket.Send(new byte[1] { 0x10});
                    }
                    if (msg.Contains("STARTCIM"))
                    {
                        OpenProcess(config.CIMAPP_FilePath);
                        state.socket.Send(new byte[1] { 0x20 });
                    }
                }
                Task.Factory.StartNew(() =>
                {
                    state.socket.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                });
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void CloseProcess(string fileName)
        {
            Process.Start("taskkill", $"/F /im \"{Path.GetFileName(fileName)}\"");
        }

        private void OpenProcess(string fileName)
        {
            if (File.Exists(fileName))
            {

                string workFolder = Path.GetDirectoryName(fileName);
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    WorkingDirectory = workFolder,
                    FileName = fileName,
                };
                Process.Start(startInfo);
                Console.WriteLine($"{fileName} Start");
            }
            else
                Console.WriteLine($"{fileName} isn't exist.");
        }
    }
}
