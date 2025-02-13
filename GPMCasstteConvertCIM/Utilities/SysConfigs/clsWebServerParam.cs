using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsWebServerParam
    {
        public string HostUrl { get; set; } = "http://127.0.0.1:5400";

        public string KGS_HOST_IP { get; set; } = "10.22.133.24";
        public int KGS_HOST_PORT { get; set; } = 6600;
    }
}
