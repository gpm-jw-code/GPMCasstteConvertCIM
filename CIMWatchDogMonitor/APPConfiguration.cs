using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMWatchDogMonitor
{
    public class APPConfiguration
    {
        public static APPConfiguration Instance { get; private set; } = new APPConfiguration();
        public static void LoadConfigure()
        {
            string _configFilePath = Path.Combine(Environment.CurrentDirectory, "AppConfigs.json");
            if (File.Exists(_configFilePath))
            {
                Instance = JsonConvert.DeserializeObject<APPConfiguration>(File.ReadAllText(_configFilePath));
            }

            File.WriteAllText(_configFilePath, JsonConvert.SerializeObject(Instance, Formatting.Indented));
        }
        public string DevicesConnectionsJsonFilePath { get; set; } = @"C:\GPM Worksapce\AGV_Project\Codes\GPMCasstteConvertCIM\GPMCasstteConvertCIM\bin\x86\Debug\net6.0-windows\configs\DevicesConnections-U007.json";


    }
}
