using GPMCasstteConvertCIM.GPM_SECS;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public class clsPortProperty
        {
            /// <summary>
            /// (Zero-Based)
            /// </summary>
            public int PortNo { get; set; }
            public string PortID { get; set; } = "Port 1";
            internal bool InSerivce { get; set; } = false;

            public string ModbusServer_IP { get; set; } = "127.0.0.1";
            public int ModbusServer_PORT { get; set; } = 1502;

            public bool ModbusServer_Enable = true;

            internal PortUnitType PortType { get; set; }


        }

    }
}
