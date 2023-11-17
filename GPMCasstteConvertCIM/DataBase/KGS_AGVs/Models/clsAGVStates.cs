using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.DataBase.KGS_AGVs.Models
{
    public class clsAGVStates
    {
        public ONLINE_STATE OnlineStatus { get; set; }
        public RUN_STATE RunStatus { get; set; }
        public AUTO_STATE AutoStatus { get; set; }
    }
}
