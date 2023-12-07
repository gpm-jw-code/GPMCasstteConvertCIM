using GPMCasstteConvertCIM.GPM_Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using Modbus.Data;
using System.Net.Sockets;
using System.Net;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using GPMCasstteConvertCIM;


namespace GPMCasstteConvertCIM.AlarmDevice
{
    public class clsAgvsAlarmDevice
    {
        clsModbusDeviceConfigs clsModbusDeviceConfigscls = new clsModbusDeviceConfigs();
        ModbusIpMaster modbusMaster;
        string IPaddress => clsModbusDeviceConfigscls.IP_Address;
        int Port => clsModbusDeviceConfigscls.port;
        bool IsDioCon;
        bool[] outputs = new bool[7];
        bool[] intputs = new bool[8];



        internal void Initialize()
        {
            AdamConnect();
        }

        private void AdamConnect()
        {
            var tcp_client = new TcpClient(IPaddress, Port);
            modbusMaster =ModbusIpMaster.CreateIp(tcp_client);
        }

        public async void MusicStop()
        {
            AdamConnect();
            await modbusMaster.WriteMultipleCoilsAsync(16, new bool[] { false, false, false, false, false, false, false });
            Disconnect();
        }
        public async void PlayAGV_AlarmMusic()
        {
            AdamConnect();
            //0 1 1 0 0 0 0 0  
            await modbusMaster.WriteMultipleCoilsAsync(18, new bool[] { true });//寫入特定io點位
            Disconnect();
            //modbusMaster.WriteSingleCoil(17, true);//寫入特定io點位
            //var di_inputs = modbusMaster.ReadInputs(0, 8);
        }
        public async void offline()
        {
                AdamConnect();
                await modbusMaster.WriteSingleCoilAsync(16, true);
            Disconnect();
        }
        public async void Return_Online()
        {
            AdamConnect();
            await Task.Delay(10);
            await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { true });
            await Task.Delay(1000);
            await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { false });
            Disconnect();
        }
        public void GetstopMusic()
        {
            AdamConnect();
            modbusMaster.ReadCoilsAsync(0, 8);
            bool[] inputStatus = modbusMaster.ReadInputs(0, 8);
            for (int i = 0; i < intputs.Length; i++)
            {
                Console.WriteLine($"DI {0 + i}: {inputStatus[i]}");
            }
            Disconnect();
        }
        internal async void Conn()
        {
            
            while (true) 
            {
                using (TcpClient client = new TcpClient())
                {
                    try
                    {
                        client.Connect(IPaddress, Port);

                        if (client.Connected)
                        {
                            IsDioCon = true;
                        }
                        else
                        {
                            IsDioCon = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        IsDioCon = false;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine(IsDioCon);
                }
            }
            
        }
        private void Disconnect()
        {
            modbusMaster.Dispose();
        }
    }
}
