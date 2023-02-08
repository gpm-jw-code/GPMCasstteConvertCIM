using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using GPMCasstteConvertCIM.VirtualAGVSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities
{
    internal class Utility
    {

        static string configsFolder = "configs";

        internal static clsSystemConfigs SysConfigs = new clsSystemConfigs();

        internal static LoggerBase SystemLogger;

        internal static frmAGVS_Modbus_Emulator AGVSModbusEmulator = new frmAGVS_Modbus_Emulator();

        internal static frmModbusTCPServer ModbusTCPServerView = new frmModbusTCPServer();

        internal static DeviceConnectionOptions DevicesConnectionsOpts = new DeviceConnectionOptions();

        internal static frmVirtualAGVS VirtualAGVS = new frmVirtualAGVS();


        internal static void LoadConfigs()
        {
            LoadSysConfigs();
            LoadDeviceConnectionOpts();
        }

        private static void LoadSysConfigs()
        {
            string SysCofigsFile = Path.Combine(configsFolder, "SystemConfigs.json");
            if (File.Exists(SysCofigsFile))
            {
                SysConfigs = JsonConvert.DeserializeObject<clsSystemConfigs>(File.ReadAllText(SysCofigsFile));
            }
            File.WriteAllText(SysCofigsFile, JsonConvert.SerializeObject(SysConfigs, Formatting.Indented));
        }

        private static void LoadDeviceConnectionOpts()
        {
            Directory.CreateDirectory(configsFolder);

            string deviceConnectionCofigsFile = Path.Combine(configsFolder, "DevicesConnections.json");
            if (File.Exists(deviceConnectionCofigsFile))
            {
                DevicesConnectionsOpts = JsonConvert.DeserializeObject<DeviceConnectionOptions>(File.ReadAllText(deviceConnectionCofigsFile));
            }
            File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));
        }

    }
}
