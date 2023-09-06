using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.clsCasstteConverter;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class McInterfaceOptions
    {
        //internal string NodeName { get; set; } = "AGVS";
        //internal int NodeNo { get; set; } = 1;
        internal string RemoteIP { get; set; } = "127.0.0.1";
        internal int RemotePort { get; set; } = 5020;
        internal int T_ConnectTimeout { get; set; } = 5000;
        internal int T_MessageTimeout { get; set; } = 3000;
        internal MC_E71_Eth.clsMC_TCPCnt.enuDataType DataType { get; set; } = MC_E71_Eth.clsMC_TCPCnt.enuDataType.ASCIIStr_01;
        public PLC_CONN_INTERFACE PLCInterface { get; set; } = PLC_CONN_INTERFACE.MX;

    }
}
