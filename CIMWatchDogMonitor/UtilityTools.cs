using CIMWatchDogMonitor.CIM_Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMWatchDogMonitor
{
    public class UtilityTools
    {
        public static ConnectionOptionsConfig LoadModbusConnectionOptionsFromCIM()
        {
            string jsonFilePath = APPConfiguration.Instance.DevicesConnectionsJsonFilePath;
            string json = File.ReadAllText(jsonFilePath);
            ConnectionOptionsConfig RawConfigObject = JsonConvert.DeserializeObject<ConnectionOptionsConfig>(json);
            return RawConfigObject;
        }
    }
}
