using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.clsConverterPort;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.WebServer.Models
{
    public class clsEQLDULDSimulationControl
    {
        public string PortName { get; set; } = "";
        public int TagNumber { get; set; }

        public IO_MODE IOMode { get; set; }
        public LDULD_STATUS Status { get; set; }
    }
}
