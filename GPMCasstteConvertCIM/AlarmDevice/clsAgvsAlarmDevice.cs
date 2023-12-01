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

namespace GPMCasstteConvertCIM.AlarmDevice
{
    internal class clsAgvsAlarmDevice
    {
        clsModbusDeviceConfigs clsModbusDeviceConfigscls = new clsModbusDeviceConfigs();
        ModbusIpMaster modbusMaster;
        bool[] outputs = new bool[8];
        string IPaddress => clsModbusDeviceConfigscls.IP_Address;
        int Port => clsModbusDeviceConfigscls.port;

        internal void Initialize()
        {
            AdamConnect();
        }

        private void AdamConnect()
        {
            var tcp_client = new TcpClient(IPaddress, Port);
            modbusMaster =ModbusIpMaster.CreateIp(tcp_client);
        }

        internal void PlayMusic()
        { 
            //0 1 1 0 0 0 0 0  
            modbusMaster.WriteMultipleCoilsAsync(1, new bool[] { true,true,false});//寫入特定io點位
        }
        internal void GetstopMusic() 
        {
            modbusMaster.ReadInputsAsync(0,8);
        }
    }
}
