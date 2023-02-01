using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsAGVSData
    {
        public bool VALID { get; set; }
        public bool TR_REQ { get; set; }
        public bool BUSY { get; set; }
        public bool COMPT { get; set; }
        public bool ManualLoadCompleteReply { get; set; }
        public bool ManualUnloadCompleteReply { get; set; }
        public bool ModeChangeAccept { get; set; }
        public bool ModeChangeRefuse { get; set; }
        public bool Proceed_Request { get; set; }
        public bool Release_Request { get; set; }

        public int InterfaceClock { get; set; }
        public int MessageIndex { get; set; }
        public int TriggerEquiment { get; set; }
        public int BuzzerFlag { get; set; }
        public int ClockUpdatingIndex { get; set; }
        public int TimeSync_Year { get; set; }
        public int TimeSync_Month { get; set; }
        public int TimeSync_Day { get; set; }
        public int TimeSync_Hour { get; set; }
        public int TimeSync_Minutes { get; set; }
        public int TimeSync_Second { get; set; }

      
    }
}
