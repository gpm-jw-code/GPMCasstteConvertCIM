using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;


namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsModbusDeviceConfigs
    {
        public string IP_Address { get; set; } = "127.0.0.1";
        public int port { get; set; } = 6000;
    }
}


