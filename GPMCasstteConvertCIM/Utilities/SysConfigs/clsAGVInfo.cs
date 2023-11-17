using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsAGVInfo
    {
        public int AGVID { get; set; }
        public string AGVIP { get; set; } = "192.168.1.101";
        [NonSerialized]
        public string TaskNameExecuting = "";
    }
}
