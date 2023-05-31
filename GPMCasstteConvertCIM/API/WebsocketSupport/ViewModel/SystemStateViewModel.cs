using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel
{
    public class SystemStateViewModel
    {
        public bool IsOnlineMode { get; set; }
        public bool IsMCSSecsConnected { get; set; }
        public bool IsAGVSSecsConnected { get; set; }

        public List<clsAlarmDto> Alarms { get; set; }

    }
}
