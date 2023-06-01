using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel
{
    public class SecsLogViewModel
    {
        public DateTime Time { get; set; }
        public string Direction { get; set; } = string.Empty;
        public string SxFx { get; set; } = string.Empty;
        public string Sml { get; set; } = string.Empty;

    }
}
