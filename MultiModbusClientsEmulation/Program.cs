// See https://aka.ms/new-console-template for more information
using MultiModbusClientsEmulation;
using System.Runtime.CompilerServices;

Console.Title = "Modbus Master 模擬器-[Connect to CIM]";

int portStart = 1501;
for (int i = 0; i < 24; i++)
{
    var _port = portStart + i;
    ModbusClient client = new ModbusClient(_port);
    _ = client.RunAsync();
}


while (true)
{
    Thread.Sleep(1);
}