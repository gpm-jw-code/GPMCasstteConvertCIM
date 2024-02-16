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
using GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models;
using GPMCasstteConvertCIM.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;

namespace GPMCasstteConvertCIM.AlarmDevice
{
    public class AlarmDevice
    {
        public  Dictionary<string, IOdeviceinfo> Dict_AlarmModule = new Dictionary<string, IOdeviceinfo>();
        public static string AlarmDeviceConfig = "config\\ModbusDeviceConfig.json";
        public  void LoadAlarmDeviceConfig()
        {
            if (!File.Exists(AlarmDeviceConfig))
            {
                return;
            }
            using (StreamReader SR = new StreamReader(AlarmDeviceConfig))
            {
                Dict_AlarmModule = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, IOdeviceinfo>>(SR.ReadToEnd());
            }
        }
    }
    public class IOdeviceinfo
    {
        public string IP_Address { get; set; }
        public int port { get; set; }
        public int DI_SrartAddress { get; set; }
        public int DI_EndAddress { get; set; }
        public int DO_SrartAddress { get; set; }
        public int DO_EndAddress { get; set; }
    }



    public class ModbusConnectParameters
    {
        public string moduleName = "ADAM6250";
        public string IP = "192.168.1.68";
        public int port = 502;
        public bool type = false;
        public ushort DI_SrartAddress = 0;
        public ushort DI_EndAddress = 0;
        public ushort DO_SrartAddress = 0;
        public ushort DO_EndAddress = 0;
        bool Enable = false;

    }
    /// <summary>
    /// 使用ductionary 方法
    /// </summary>
    public class AdamFunction
    {
        AlarmDevice AlarmConfig = new AlarmDevice();
        ModbusIpMaster AlarmDeviceModbusMaster = null;
       
        public ModbusIpMaster Connect(string ip , int port)
        {
            //AlarmDevice Adam6250config = new AlarmDevice();
            var Tcp_client = new TcpClient(ip, port);
            ModbusIpMaster AlarmDevice_modbusMaster = ModbusIpMaster.CreateIp(Tcp_client);
            return AlarmDevice_modbusMaster;
        }
        public bool[] Read_Adam6250_Status(ModbusIpMaster AlarmDeviceModbusMaster)
        {
            while (true)
            {
                try
                {
                    ushort startAddressDI6250 = 0;
                    ushort numberOfPointsDI6250 = 7;
                    ushort startAddressDO6250 = 17;
                    ushort numberOfPointsDO6250 = 23;
                    bool[] registersDI = AlarmDeviceModbusMaster.ReadInputs(1, startAddressDI6250, numberOfPointsDI6250);
                    bool[] registersDO = AlarmDeviceModbusMaster.ReadInputs(1, startAddressDO6250, numberOfPointsDO6250);
                    bool[] registers6250 = registersDI.Concat(registersDO).ToArray();
                    //MessageBox.Show($"{registers6250.ToString}");
                    return registers6250;
                }
                catch (Exception)
                {

                    Thread.Sleep(2000);
                }
            }
        }

    }

    /// <summary>
    /// 暫時用class
    /// </summary>
    public class AdamIOFunction
    {
        ModbusConnectParameters Adamparam = new ModbusConnectParameters();

        ModbusIpMaster AlarmDevice_modbusMaster = null;
        public ModbusIpMaster Connect()
        {
            //AlarmDevice Adam6250config = new AlarmDevice();
            var Tcp_client = new TcpClient(Adamparam.IP, Adamparam.port);
            ModbusIpMaster AlarmDevice_modbusMaster = ModbusIpMaster.CreateIp(Tcp_client);
            return AlarmDevice_modbusMaster;
        }
        //public void 
        public void ADAM6256_DOon()
        {
            ushort startAddress = 0;
            //ushort[] data = ADAM6250modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            AlarmDevice_modbusMaster.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
        }
        public bool[] Read_Adam6250_Status()
        {
            while (true)
            {
                try
                {
                    ushort startAddressDI6250 = 0;
                    ushort numberOfPointsDI6250 = 7;
                    ushort startAddressDO6250 = 17;
                    ushort numberOfPointsDO6250 = 23;
                    bool[] registersDI = AlarmDevice_modbusMaster.ReadInputs(1, startAddressDI6250, numberOfPointsDI6250);
                    bool[] registersDO = AlarmDevice_modbusMaster.ReadInputs(1, startAddressDO6250, numberOfPointsDO6250);
                    bool[] registers6250 = registersDI.Concat(registersDO).ToArray();
                    //MessageBox.Show($"{registers6250.ToString}");
                    return registers6250;
                }
                catch (Exception)
                {

                    Thread.Sleep(2000);
                }
            }
        }
        public bool[] Read_Adam6256_Status()
        {
            while (true)
            {
                try
                {
                    ushort startAddress = 16;
                    ushort numberOfPoints = 32;
                    bool[] registers = AlarmDevice_modbusMaster.ReadInputs(1, startAddress, numberOfPoints);
                    return registers;
                    //MessageBox.Show($"{registers6250.ToString}");
                    //return registers6250;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            }
        }
    }
    public class clsAgvsAlarmDevice
    {        
         
        ModbusIpMaster modbusMaster;

        ModbusIpMaster Adam6250_modbusMaster = null;
        ModbusIpMaster Adam6256_modbusMaster = null;
        /// <summary>
        /// 更新adam參數
        /// </summary>
        public ModbusConnectParameters Adam6250 = new ModbusConnectParameters();
        public ModbusConnectParameters Adam6256 = new ModbusConnectParameters();
        
        string Adam_6250 = "ADAM6250";
        string Adam_6250_IP = "192.168.1.68";
        int Adam_6250_port = 502;
        bool Adam_6250_type = false;
        int Adam_6250_DI_SrartAddress = 0;
        int Adam_6250_DI_EndAddress = 7;
        int Adam_6250_DO_SrartAddress = 16;
        int Adam_6250_DO_EndAddress = 22;

        string Adam_6256 = "ADAM6256";
        string Adam_6256_IP = "192.168.1.99";
        int Adam_6256_port = 502;
        bool Adam_6256_type = false;
        int Adam_6256_DI_SrartAddress = 0;
        int Adam_6256_DI_EndAddress = 7;
        int Adam_6256_DO_SrartAddress = 16;
        int Adam_6256_DO_EndAddress = 22;
        /// 
        
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

        bool[] Adamlist;

        public static string ConfigDirectory = "Config";

        string ModbusDeviceConfig = System.IO.Path.Combine(ConfigDirectory, "ModbusDeviceConfig.json");
        //protected virtual string ADAM6250DIO { get; set; } = Path.Combine(Environment.CurrentDirectory, "AlarmDevice\\ADAM_6250.csv");
        //public async void readConfig()
        //{
        //    try
        //    {
        //        if (File.Exists(ModbusDeviceConfig))
        //            using (StreamReader SR = new StreamReader(ModbusDeviceConfig))
        //            {
        //                var ModbusDeviceConfig = SR.ReadToEnd();
        //                Dict_AdamIO = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, IOdeviceinfo>>(SR.ReadToEnd());
        //            }
        //    }
        //    catch { }
        //}


        public void Adam6250Connect()
        {
            //clsAgvsAlarmDevice modbusMaster6250 = new clsAgvsAlarmDevice();
            var Adam6250tcp_client = new TcpClient(Adam_6250_IP, Adam_6250_port);
            Adam6250_modbusMaster = ModbusIpMaster.CreateIp(Adam6250tcp_client);
            return;
        }
        public void Adam6256Connect()
        {
            //clsAgvsAlarmDevice modbusMaster6250 = new clsAgvsAlarmDevice();
            var Adam6256tcp_client = new TcpClient(Adam_6256_IP, Adam_6256_port);
            Adam6256_modbusMaster = ModbusIpMaster.CreateIp(Adam6256tcp_client);
            return;
        }
        public void ADAM6250_DOon()
        {
            //int Adam_6250_DO_SrartAddress ;
            //var ADAM6250modbusMaster = Adam6250Connect();
            ushort startAddress = 0;
            ushort[] data = Adam6250_modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            Adam6250_modbusMaster.WriteMultipleCoils(16, new bool[] { false, true, false, false, false, false, false });
        }
        public void ADAM6256_DOon()
        {
            //int Adam_6250_DO_SrartAddress ;
            //var ADAM6256modbusMaster = Adam6256Connect();
            ushort startAddress = 0;
            //ushort[] data = ADAM6250modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            Adam6256_modbusMaster.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
        }
        public void ADAM6250_DOoff()
        {
            //var ADAM6250modbusMaster = Adam6250Connect();
            ushort startAddress = 0;
            ushort[] data = Adam6250_modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            Adam6250_modbusMaster.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
        }
        public void ADAM6256_DOoff()
        {
            // var ADAM6256modbusMaster = Adam6256Connect();
            ushort startAddress = 0;
            Adam6256_modbusMaster.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
        }
        public bool[] ReadAdam6250()
        {
            while (true)
            {
                try
                {
                    ushort startAddressDI6250 = 0;
                    ushort numberOfPointsDI6250 = 7;
                    ushort startAddressDO6250 = 15;
                    ushort numberOfPointsDO6250 = 21;
                    bool[] registersDI = Adam6250_modbusMaster.ReadInputs(1, startAddressDI6250, numberOfPointsDI6250);
                    bool[] registersDO = Adam6250_modbusMaster.ReadInputs(1, startAddressDO6250, numberOfPointsDO6250);
                    bool[] registers6250 = registersDI.Concat(registersDO).ToArray();
                    //MessageBox.Show($"{registers6250.ToString}");
                    return registers6250;
                }
                catch (Exception)
                {

                    Thread.Sleep(2000);
                }
            }

        }
        public bool[] ReadAdam6256()
        {
            while (true)
            {
                try
                {
                    ushort startAddress = 16;
                    ushort numberOfPoints = 32;
                    bool[] registers = Adam6256_modbusMaster.ReadInputs(1, startAddress, numberOfPoints);
                    return registers;
                    //MessageBox.Show($"{registers6250.ToString}");
                    //return registers6250;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            }
        }
        public bool[] readADAM6250()
        {
            ushort startAddressDI6250 = 0;
            ushort numberOfPointsDI6250 = 7;
            ushort startAddressDO6250 = 17;
            ushort numberOfPointsDO6250 = 23;
            bool[] registersDI = Adam6250_modbusMaster.ReadInputs(1, startAddressDI6250, numberOfPointsDI6250);
            bool[] registersDO = Adam6250_modbusMaster.ReadInputs(1, startAddressDO6250, numberOfPointsDO6250);
            bool[] registers6250 = registersDI.Concat(registersDO).ToArray();
            //MessageBox.Show($"{registers6250.ToString}");
            return registers6250;
        }
        public bool[] readADAM6256()
        {
            ushort startAddress = 16;
            ushort numberOfPoints = 32;
            bool[] registers = Adam6256_modbusMaster.ReadInputs(1, startAddress, numberOfPoints);
            return registers;
        }
        public void Alarm_RejectMission()
        {
            ushort startAddress = 0;
            //ushort[] data = ADAM6250modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            Adam6256_modbusMaster.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
        }
        public void failtask()
        {
            ushort startAddress = 0;
            //ushort[] data = ADAM6250modbusMaster.ReadHoldingRegisters(1, startAddress, 5);
            Adam6256_modbusMaster.WriteMultipleCoils(16, new bool[] { true, false, true, false, true, false, true });
        }

        public void AlwaysRead6256_Do()
        {

            while (true)
            {
                try
                {
                    ushort startAddress = 17;
                    ushort numberOfPoints = 32;
                    bool[] registers = Adam6256_modbusMaster.ReadInputs(1, startAddress, numberOfPoints);
                    ///用委派方法來讓兩個執行緒可以邊執行邊更新UI
                    ///大部分跟UI相關會用委派

                }
                catch (SocketException ex)
                {
                    Console.WriteLine("SocketException: {0}", ex);
                }
                Thread.Sleep(5000);
            }

        }
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
            int disconncount = 0;
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
        public async void AlramStatus()
        {

        }
        public async void RemoteStatus()
        {

        }
        public async void LocalStatus()
        {

        }
        private void Disconnect(ModbusIpMaster modbusMaster)
        {
            modbusMaster.Dispose();
        }
    }
}
