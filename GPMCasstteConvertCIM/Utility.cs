using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.VirtualAGVSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM
{
    internal class Utility
    {

        static string configsFolder = "configs";

        internal static LoggerBase SystemLogger;

        internal static frmAGVS_Modbus_Emulator AGVSModbusEmulator = new frmAGVS_Modbus_Emulator();

        internal static frmModbusTCPServer ModbusTCPServerView = new frmModbusTCPServer();

        internal static DeviceConnectionOptions DevicesConnectionsOpts = new DeviceConnectionOptions();
        internal static frmVirtualAGVS VirtualAGVS = new frmVirtualAGVS();

        internal static void LoadDeviceConnectionOpts()
        {
            Directory.CreateDirectory(configsFolder);

            string deviceConnectionCofigsFile = Path.Combine(configsFolder, "DevicesConnections.json");
            if (File.Exists(deviceConnectionCofigsFile))
            {
                DevicesConnectionsOpts = JsonConvert.DeserializeObject<DeviceConnectionOptions>(File.ReadAllText(deviceConnectionCofigsFile));
            }
            else
            {
                File.WriteAllText(deviceConnectionCofigsFile, JsonConvert.SerializeObject(DevicesConnectionsOpts, Formatting.Indented));
            }
        }

    }
}
