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
using GPMCasstteConvertCIM.Utilities;


namespace GPMCasstteConvertCIM.AlarmDevice
{
    public class clsAgvsAlarmDevice
    {
        
        ModbusIpMaster modbusMaster;
        string IPaddress => Utility.ModbusDeviceConfigs.IP_Address;
        int Port => Utility.ModbusDeviceConfigs.port;
        ushort DI_SrartAddress => Utility.ModbusDeviceConfigs.DI_SrartAddress;
        ushort DI_EndAddress => Utility.ModbusDeviceConfigs.DI_EndAddress;
        ushort DO_SrartAddress => Utility.ModbusDeviceConfigs.DO_SrartAddress;
        ushort DO_EndAddress => Utility.ModbusDeviceConfigs.DO_EndAddress;
        bool[] outputs = new bool[7];
        bool[] intputs = new bool[8];
        bool Enable => Utility.ModbusDeviceConfigs.Enable;
        bool Conn = false;

        private ModbusIpMaster AdamConnect()
        {
            var tcp_client = new TcpClient(IPaddress, Port);
            ModbusIpMaster modbusMaster = ModbusIpMaster.CreateIp(tcp_client);
            return modbusMaster;
        }

        public async void MusicStop()
        {
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await modbusMaster.WriteMultipleCoilsAsync(DO_SrartAddress, new bool[] { false, false, false, false, false, false, false });
                    Disconnect(modbusMaster);
                }
                catch (Exception) { }
        }
        public async void PlayAGV_AlarmMusic()
        {
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    //0 1 1 0 0 0 0 0  
                    await modbusMaster.WriteMultipleCoilsAsync(18, new bool[] { true });//寫入特定io點位
                    Disconnect(modbusMaster);
                    //modbusMaster.WriteSingleCoil(17, true);//寫入特定io點位
                    //var di_inputs = modbusMaster.ReadInputs(0, 8);
                }
                catch (Exception) { }
        }
        public async void offline()
        {
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await modbusMaster.WriteSingleCoilAsync(16, true);
                    Disconnect(modbusMaster);
                }
                catch (Exception) { }
        }
        public async void Return_Online()
        {
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await Task.Delay(10);
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { true });
                    await Task.Delay(1000);
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { false });
                    Disconnect(modbusMaster);
                }
                catch (Exception)
                {

                }
        }
        public async void GetstopMusic()
        {
            int disconncount =0;
            if (Enable)
                while (true)
                {
                    try
                    {
                        if (disconncount >= 5)
                        {
                            MusicStop();
                        }
                        var modbusMaster = AdamConnect();
                        await modbusMaster.ReadCoilsAsync(DI_SrartAddress, DI_EndAddress);
                        intputs = modbusMaster.ReadInputs(DI_SrartAddress, DI_EndAddress);
                        for (int i = 0; i < intputs.Length; i++)
                        {
                            Console.WriteLine($"DI {0 + i}: {intputs[i]}");
                        }
                        Disconnect(modbusMaster);
                        if (intputs[0])
                        {
                            MusicStop();
                        }
                        Console.Write(Conn = true);
                    }
                    catch
                    {
                        Utility.SystemLogger.Info($"SE MP3 Alarm DIO is disconnect");
                        disconncount += 1;
                        Console.Write(Conn = false);
                        continue;
                    }
                    Thread.Sleep(100);
                }

        }
        private void Disconnect(ModbusIpMaster modbusMaster)
        {
            modbusMaster.Dispose();
        }
    }
}
