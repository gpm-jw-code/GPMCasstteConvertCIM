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
        public string IP_Address { get; set; } = "192.168.1.100";
        public int port { get; set; } = 502;
        public ushort DI_SrartAddress { get; set; } = 0;
        public ushort DI_EndAddress { get; set; } = 7;

        public ushort DO_SrartAddress { get; set; } =16 ;
        public ushort DO_EndAddress { get; set; } = 22;
        public bool Enable = false;
    }
}


