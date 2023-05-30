using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.WebsocketSupport.ViewModel
{
    public class EQPViewModel
    {
        public string EqName { get; set; }
        public bool Connected { get; set; }
        public bool IsRun { get; set; }
        public bool IsDown { get; set; }
        public bool IsIdle { get; set; }

        public int InterfaceClock { get; set; } = 0;
        public List<PortViewModel> Ports { get; set; }
    }
}
