using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsSystemConfigs
    {
        public bool Simulation { get; set; } = true;
        public clsLogConfigs Log { get; set; } = new clsLogConfigs();
        public clsSECSConfigs SECS { get; set; } = new clsSECSConfigs();
        public bool EQLoadUnload_RequestSimulation { get; set; } = false;
        public bool PostOrderInfoToAGV { get; set; } = true;

        public string UnknowCargoIDHead { get; set; } = "UN032";

        public int TUNFlowNumberUsed { get; set; } = 1;
        public int DUFlowNumberUsed { get; set; } = 1;

        public bool CIMHandshakingWithAGVWhenAGV_READY_EQ_BUSY_Waiting_interlock { get; set; } = true;

        public bool AGVPingMonitor { get; set; } = true;

        [JsonConverter(typeof(StringEnumConverter))]
        public PROJECT Project { get; set; }
        public string RegionName { get; set; } = "UMTC";

        public List<clsAGVInfo> AGVList { get; set; } = new List<clsAGVInfo>();
        public string MapFilePath { get; set; } = @"C:\CST\ini\Map_UMTC_3F_AOI.json";

        public string KGSDBConnectionString { get; set; } = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";

        public clsWebServerParam WebService { get; set; } = new clsWebServerParam();

        public enum PROJECT
        {
            U003, U007
        }


    }
}
