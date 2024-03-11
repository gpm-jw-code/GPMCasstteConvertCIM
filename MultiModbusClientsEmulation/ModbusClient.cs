using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Modbus;
using Modbus.Device;
namespace MultiModbusClientsEmulation
{
    internal class ModbusClient
    {
        private readonly string host;
        private readonly int port;
        private IModbusMaster modbusMaster;
        private bool X10State = false;
        private bool X11State = true;
        private bool X12State = true;
        private bool X13State = false;
        public ModbusClient(int port, string host = "127.0.0.1")
        {
            this.host = host;
            this.port = port;
        }

        public async Task RunAsync()
        {
            await Task.Delay(10);
            // 創建 TCP 客戶端
            var client = new TcpClient(this.host, this.port);
            // 使用 TCP 客戶端創建 Modbus TCP 客戶端
            modbusMaster = ModbusIpMaster.CreateIp(client);
            Console.WriteLine($"Connect to :{host}:{port}");

            System.Threading.Timer timer = new System.Threading.Timer(new TimerCallback(WriteTimerCallback), null, 1000, 5000);

            bool[] previousInputs = new bool[16];
            while (true)
            {
                var inputs = modbusMaster.ReadInputs(1, 0, 16);

                if (!previousInputs.SequenceEqual(inputs))
                {
                    string currentInputsStr = string.Join(",", inputs.Select(b => b ? "1" : "0"));
                    Console.WriteLine($"Port_{port} Inputs Changed to {currentInputsStr}");
                }
                previousInputs = inputs;
                await Task.Delay(10);
            }
        }

        private void WriteTimerCallback(object? state)
        {
            modbusMaster.WriteSingleCoil(1, 16, X10State);
            modbusMaster.WriteSingleCoil(1, 17, X11State);
            modbusMaster.WriteSingleCoil(1, 18, X12State);
            modbusMaster.WriteSingleCoil(1, 19, X13State);
            X10State = !X10State;
            X11State = !X11State;
            X12State = !X12State;
            X13State = !X13State;
        }
    }
}
