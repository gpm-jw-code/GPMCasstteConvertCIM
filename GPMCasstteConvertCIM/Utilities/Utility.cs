using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.Forms;
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

        public static string configsFolder = "configs";

        public static clsSystemConfigs SysConfigs = new clsSystemConfigs();

        internal static LoggerBase SystemLogger;


        internal static frmModbusTCPServer ModbusTCPServerView = new frmModbusTCPServer();


        internal static frmVirtualAGVS VirtualAGVS = new frmVirtualAGVS();


        internal static void LoadConfigs()
        {
            LoadSysConfigs();
        }

        private static void LoadSysConfigs()
        {

            if(!Directory.Exists(configsFolder))
                Directory.CreateDirectory(configsFolder);

            string SysCofigsFile = Path.Combine(configsFolder, "SystemConfigs.json");
            if (File.Exists(SysCofigsFile))
            {
                SysConfigs = JsonConvert.DeserializeObject<clsSystemConfigs>(File.ReadAllText(SysCofigsFile));
            }
            File.WriteAllText(SysCofigsFile, JsonConvert.SerializeObject(SysConfigs, Formatting.Indented));
        }

    }
}
