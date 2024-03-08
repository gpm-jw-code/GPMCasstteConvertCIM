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
using System.Collections;
using Modbus.Message;
using static GPMCasstteConvertCIM.GPM_Modbus.ModbusServerBase;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics.Metrics;
using Modbus.Extensions.Enron;

namespace GPMCasstteConvertCIM.AlarmDevice
{
    public class AlarmDeviceFunction
    {
        public Dictionary<string, IOdevice> Dict_AlarmModule = new Dictionary<string, IOdevice>();
        public string AlarmDeviceConfig = @"D:\程式\repos\欣興電\CIM_FOR_MEC\GPMCasstteConvertCIM\GPMCasstteConvertCIM\configs\ModbusDeviceConfigs.json";
        public void LoadAlarmDeviceConfig()
        {
            //string AlarmDeviceConfig = @"D:\程式\repos\欣興電\CIM_FOR_MEC\GPMCasstteConvertCIM\GPMCasstteConvertCIM\configs\ModbusDeviceConfigs.json";
            if (!File.Exists(AlarmDeviceConfig))
            {
                return;
            }
            using (StreamReader SR = new StreamReader(AlarmDeviceConfig))
            {
                Dictionary<string, IOdeviceinfo> Dict_par = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, IOdeviceinfo>>(SR.ReadToEnd());

                foreach (var item in Dict_par)
                {
                    if (!Dict_AlarmModule.Keys.Contains(item.Key))
                    {
                        IOdevice device = new IOdevice();
                        device.info = item.Value;
                        Dict_AlarmModule.Add(item.Key, device);
                    }
                }

                //Dict_AlarmModule = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, IOdeviceinfo>>(SR.ReadToEnd());
            }
        }
        public ModbusIpMaster Connect(string ip, int port)
        {
            //AlarmDevice Adam6250config = new AlarmDevice();
            var Tcp_client = new TcpClient(ip, port);
            ModbusIpMaster AlarmDevice_modbusMaster = ModbusIpMaster.CreateIp(Tcp_client);
            return AlarmDevice_modbusMaster;
        }
        public bool Adam6250ConnectState;
        public bool Adam6256ConnectState;
        public void alladamconnect()
        {
            try
            {
                foreach (var item in Dict_AlarmModule)
                {
                    item.Value.Connect();
                    //var ip = item.Value.info.IP_Address;
                    //int port = item.Value.info.port;
                    //var Tcp_client = new TcpClient(ip, port);
                    ////ModbusIpMaster AlarmDevice_modbusMaster = ModbusIpMaster.CreateIp(Tcp_client);
                    ////AlarmDevice_modbusMaster.re
                    //item.Value.master = ModbusIpMaster.CreateIp(Tcp_client);
                    ////try
                    ////{
                    ////}
                    ////catch (Exception)
                    ////{
                    ////    throw;
                    ////}
                    ////    //Adam6250ConnectState = true;
                    ////    //Adam6256ConnectState = true;
                    ////}
                    //Adam6250ConnectState = true;
                    //Adam6256ConnectState = true;
                    ////Adam6250ConnectState = (Dict_AlarmModule["ADAM6250"].master != null) ? true : false;
                    ////Adam6256ConnectState = (Dict_AlarmModule["ADAM6256"].master != null) ? true : false;

                }
            }
            catch (Exception exp)
            {
                ////連線失敗
                //Adam6250ConnectState = false;
                //Adam6256ConnectState = false;
            }


            //Dict_AlarmModule["ADAM6250"].master.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, false });
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
                    bool[] registersDI = Dict_AlarmModule["ADAM6250"].master.ReadInputs(1, startAddressDI6250, numberOfPointsDI6250);
                    bool[] registersDO = Dict_AlarmModule["ADAM6250"].master.ReadInputs(1, startAddressDO6250, numberOfPointsDO6250);
                    bool[] registers6250 = registersDI.Concat(registersDO).ToArray();
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
                    bool[] registers = Dict_AlarmModule["ADAM6256"].master.ReadInputs(1, startAddress, numberOfPoints);
                    return registers;
                }
                catch (Exception)
                {
                    Thread.Sleep(2000);
                }
            }
        }
        public void ADAM6250_DOon()///對所有6250進行輸出
        {
            ushort startAddress = 0;
            ushort[] data = Dict_AlarmModule["ADAM6250"].master.ReadHoldingRegisters(1, startAddress, 5);
            Dict_AlarmModule["ADAM6250"].master.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
        }
        public void rejectTask()
        {
            // ushort startAddress = 0;
            Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { true, false, true, false, true, false, true });

        }

        public void AllAdamon()
        {
            //var ADAM6250modbusMaster = Adam6250Connect();
            ushort startAddress = 0;
            foreach (var item in Dict_AlarmModule)
            {
                item.Value.master.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
                //ModbusIpMaster AlarmDevice_modbusMaster = ModbusIpMaster.CreateIp(Tcp_client);
                //AlarmDevice_modbusMaster.re
                //item.Value.master = ModbusIpMaster.CreateIp(Tcp_client);

            }

            //  Adam6250_modbusMaster.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
        }
        public void AllAdamOFF()
        {
            //var ADAM6250modbusMaster = Adam6250Connect();
            ushort startAddress = 0;
            foreach (var item in Dict_AlarmModule)
            {
                item.Value.master.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
            }
        }
        public void disconnect()////斷線adama操作
        {
            foreach (var item in Dict_AlarmModule)
            {
                item.Value.master.Dispose();
            }
        }
        public void AGVSTransferFailedReport()
        {
            bool TransferCompeleted = false;
            foreach (var item in Dict_AlarmModule)
            {
                item.Value.master.WriteMultipleCoils(16, new bool[] { true, true, true, true, false, false, false });
            }
        }
        public async void RuturnOnlineRemote()
        {
            bool TransferCompeleted = false;
            try
            {
                Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
                Thread.Sleep(5000);
                //await Task.Delay(5000);
                Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });
            }
            catch (Exception exp)
            {

                throw;
            }


            //for (int i = 0; i <= 1; i++)
            //{
            //    if (i == 0)
            //    { Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true }); }
            //    if (i == 1)
            //    { Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false }); }
            //    Thread.Sleep(5000);
            //}

            //try
            //{
            //    Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { true, true, true, true, true, true, true });
            //    Task.Delay(5000);
            //    Dict_AlarmModule["ADAM6256"].master.WriteMultipleCoils(16, new bool[] { false, false, false, false, false, false, false });

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }


    }
    public class IOdeviceinfo
    {
        public string IP_Address { get; set; } = "127.0.0.1";
        public int port { get; set; } = 502;
        public int DI_SrartAddress { get; set; } = 0;
        public int DI_EndAddress { get; set; } = 7;
        public int DO_SrartAddress { get; set; } = 16;
        public int DO_EndAddress { get; set; } = 22;
    }

    public class IOdevice
    {
        public IOdeviceinfo info;
        public ModbusIpMaster master;

        private bool _ConnectStatus = false;
        public bool ConnectStatus
        {
            get => _ConnectStatus;
        }

        public IOdevice() { }

        public void Connect()
        {
            var Tcp_client = new TcpClient(info.IP_Address, info.port);
            try
            {
                this.master = ModbusIpMaster.CreateIp(Tcp_client);
                _ConnectStatus = true;
            }
            catch (Exception exp)
            {
                _ConnectStatus = false;
            }
        }
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
    /// 暫時用class
    /// </summary>
    public class AdamIOFunction
    {
        AlarmDeviceFunction Adamparam = new AlarmDeviceFunction();

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
        AlarmDeviceFunction adampara = new AlarmDeviceFunction();
        // string static ADAM6250DIO { get; set; } = Path.Combine(Environment.CurrentDirectory, "AlarmDevice\\ADAM_6250.csv");
        // string static ADAM6256DO { get; set; } = Path.Combine(Environment.CurrentDirectory, "AlarmDevice\\ADAM_6256.csv");
        //StreamReader  adam6250file = new StreamReader(File.OpenRead(ADAM6250DIO), Encoding.Default);
        //StreamReader adam6256file = new StreamReader(File.OpenRead(ADAM6256DO), Encoding.Default);

        string Adam_6256 = "ADAM6256";
        string Adam_6256_IP = "192.168.1.99";
        int Adam_6256_port = 502;
        bool Adam_6256_type = false;
        int Adam_6256_DI_SrartAddress = 0;
        int Adam_6256_DI_EndAddress = 7;
        int Adam_6256_DO_SrartAddress = 16;
        int Adam_6256_DO_EndAddress = 22;
        /// 

        bool[] outputs = new bool[7];
        bool[] intputs = new bool[8];
        bool Enable => Utility.ModbusDeviceConfigs.Enable;
        bool Conn = false;

        public static string ConfigDirectory = "Config";

        string ModbusDeviceConfig = System.IO.Path.Combine(ConfigDirectory, "ModbusDeviceConfig.json");



        //public void Connecttest()
        //{
        //    //clsAgvsAlarmDevice modbusMaster6250 = new clsAgvsAlarmDevice();
        //    var Adam6250tcp_client = new TcpClient(adampara.Dict_AlarmModule["6250"].IP_Address, adampara.Dict_AlarmModule["6250"].port);
        //    Adam6250_modbusMaster = ModbusIpMaster.CreateIp(Adam6250tcp_client);
        //    return;
        //}
        public void Adam6250Connect()
        {
            //clsAgvsAlarmDevice modbusMaster6250 = new clsAgvsAlarmDevice();
            var Adam6250tcp_client = new TcpClient(Adam6250.IP, Adam6250.port);
            Adam6250_modbusMaster = ModbusIpMaster.CreateIp(Adam6250tcp_client);
            return;
        }
        public void Adam6256Connect()
        {
            //clsAgvsAlarmDevice modbusMaster6250 = new clsAgvsAlarmDevice();
            var Adam6256tcp_client = new TcpClient(Adam_6256_IP, Adam_6256_port);
            /*Adam6256_modbusMaster =*/
            ModbusIpMaster.CreateIp(Adam6256tcp_client);
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
        public void readAdam(StreamReader adam6250file, StreamReader adam6256file)
        {

            while (!adam6250file.EndOfStream)
            {
                string[] adam6250data = adam6250file.ReadLine().Split(',');
                return;
            }
            while (!adam6256file.EndOfStream)
            {
                string[] adam6256data = adam6256file.ReadLine().Split(',');

            }
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


        public async void MusicStop()
        {
            if (Enable && Conn)
                try
                {
                    //var modbusMaster = AdamConnect();
                    //  await modbusMaster.WriteMultipleCoilsAsync(DO_SrartAddress, new bool[] { false, false, false, false, false, false, false });
                    Disconnect(modbusMaster);
                }
                catch (Exception) { }
        }
        public async void PlayAGV_AlarmMusic()
        {
            if (Enable && Conn)
                try
                {
                    // var modbusMaster = AdamConnect();
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
                    // var modbusMaster = AdamConnect();
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
                    //var modbusMaster = AdamConnect();
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
                        // var modbusMaster = AdamConnect();
                        //await modbusMaster.ReadCoilsAsync(DI_SrartAddress, DI_EndAddress);
                        // intputs = modbusMaster.ReadInputs(DI_SrartAddress, DI_EndAddress);
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
