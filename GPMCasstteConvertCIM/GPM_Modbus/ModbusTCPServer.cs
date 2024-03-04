using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities;
using Modbus.Data;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using Newtonsoft.Json.Linq;

namespace GPMCasstteConvertCIM.GPM_Modbus
{
    public class ModbusTCPServer
    {
        public int Port { get; set; } = 200;
        internal ModbusClientBase modbus_client_checker = new ModbusClientBase();
        internal ModbusSlave modbusSlave;
        internal clsCasstteConverter linkedCasstteConverter { get; set; }
        internal frmModbusTCPServer UI;
        private LoggerBase logger;

        public async Task StartModbusTcpSlave(string ip, int port)
        {
            byte slaveId = 1;
            IPAddress address = IPAddress.Parse(ip);

            // 創建並啟動 TCP 監聽
            TcpListener listener = new TcpListener(address, port);
            listener.Start();

            // 創建 Modbus TCP slave
            modbusSlave = ModbusTcpSlave.CreateTcp(slaveId, listener);
            modbusSlave.DataStore = DataStoreFactory.CreateDefaultDataStore();
            // 啟動 slave
            modbusSlave.ListenAsync();
        }

        internal async Task Active(string ip, int port, frmModbusTCPServer ui)
        {
            Port = port;
            UI = ui;            
            UI.Port = Port;
            await StartModbusTcpSlave(ip, port);
            UI.ModbusTCPServer = this;
        }

        internal void Close()
        {
            modbusSlave.Dispose();
        }
    }
}
