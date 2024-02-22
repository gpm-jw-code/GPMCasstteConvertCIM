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
using System.Security.Permissions;

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

        string STK_IPaddress => Utility.ModbusDeviceConfigs.STK_IP_Address;
        int STK_Port => Utility.ModbusDeviceConfigs.STK_port;
        bool[] outputs = new bool[7];
        bool[] intputs = new bool[8];
        bool Enable => Utility.ModbusDeviceConfigs.Enable;
        bool Conn = false;

        private ModbusIpMaster AdamConnect()
        {
            // modbus 建立連線
            var tcp_client = new TcpClient(IPaddress, Port);
            ModbusIpMaster modbusMaster = ModbusIpMaster.CreateIp(tcp_client);
            return modbusMaster;
        }
        private void Disconnect(ModbusIpMaster modbusMaster)
        {
            modbusMaster.Dispose();
        }
        private ModbusIpMaster STK_AdamConnect()
        {
            // modbus 建立連線
            var tcp_client = new TcpClient(STK_IPaddress, STK_Port);
            ModbusIpMaster STK_Conn = ModbusIpMaster.CreateIp(tcp_client);
            return STK_Conn;
        }
        private void STK_Disconnect(ModbusIpMaster STK_Conn)
        {
            STK_Conn.Dispose();
        }

        public async void MusicStop()
        {
            //蜂鳴器關閉
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await modbusMaster.WriteMultipleCoilsAsync(DO_SrartAddress, new bool[] { false, false, false, false, false, false, false });
                    Disconnect(modbusMaster);
                }
                catch (Exception) { }
        }
        public async void AlarmReset()
        {
            //異常清除
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
            //AGV異常時發警報
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
        public async void AGVSLocal()
        {
            //AGVS Local
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await modbusMaster.WriteSingleCoilAsync(16, false);//將Remote燈關閉
                    await modbusMaster.WriteSingleCoilAsync(16, true);//將Local燈開啟
                    Disconnect(modbusMaster);
                }
                catch (Exception) { }
        }
        public async void Return_Online()
        {
            //AGVS重新與上層建立連線
            if (Enable && Conn)
                try
                {
                    var modbusMaster = AdamConnect();
                    await Task.Delay(10);
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { true });
                    await Task.Delay(1000);
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { false });
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { true }); //將Local燈關閉
                    await modbusMaster.WriteMultipleCoilsAsync(17, new bool[] { true }); //將Remote燈開啟
                    Disconnect(modbusMaster);
                }
                catch (Exception)
                {

                }
        }
        public async void SE_Task_Can_Go()
        {
            //STK可執行任務亮藍燈
            if (Enable && Conn)
            {
                //while (true)
                //{
                //    if (SeCanDoTask)
                //    {
                //        try
                //        {
                //            var STK_Conn = STK_AdamConnect();
                //            await STK_Conn.ReadCoilsAsync(DI_SrartAddress, DI_EndAddress);
                //            intputs = modbusMaster.ReadInputs(DI_SrartAddress, DI_EndAddress);
                //            for (int i = 0; i < intputs.Length; i++)
                //            {
                //                Console.WriteLine($"DI {0 + i}: {intputs[i]}");
                //            }
                //            if (intputs[0] || intputs[1])//判斷LD、ULD
                //            {
                //                if (!intputs[3])//判斷在席訊號
                //                {
                //                    var modbusMaster = AdamConnect();
                //                    await modbusMaster.WriteMultipleCoilsAsync(19, new bool[] { true });
                //                    Disconnect(modbusMaster);
                //                }
                //            }
                //            STK_Disconnect(STK_Conn);
                //        }
                //        catch (Exception EX)
                //        {
                //            Utility.SystemLogger.Info($"STK DIO Is DISConnect");
                //            Utility.SystemLogger.Info(EX.Message);
                //            continue;
                //        }
                //    }
                //    Thread.Sleep(100);
                //}
            }
        }
        public async void GetAlarmReset()
        {
            //與DIO連線判斷，並偵測按鈕觸發
            int disconncount = 0;
            if (Enable)
                while (true)
                {
                    Thread.Sleep(100);
                    try
                    {
                        if (disconncount >= 5)
                        {
                            AlarmReset();
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
                            AlarmReset();
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
                }

        }

    }
}
