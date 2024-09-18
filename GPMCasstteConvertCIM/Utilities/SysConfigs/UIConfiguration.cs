using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class UIConfiguration
    {
        public StatusBar statusBar { get; set; } = new StatusBar();
        public class StatusBar
        {
            public bool SystemTimeDisplay { get; set; } = true;
            public bool SECSEncodingDisplay { get; set; } = false;
            public bool WebServerDisplay { get; set; } = false;
            public bool S2F49TransferDisplay { get; set; } = false;
        }
    }
}
