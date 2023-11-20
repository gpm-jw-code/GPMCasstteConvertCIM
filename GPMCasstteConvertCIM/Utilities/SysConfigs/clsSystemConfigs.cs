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

        public string UnknowCargoIDHead { get; set; } = "UN032";

        public int TUNFlowNumberUsed { get; set; } = 1;
        public int DUFlowNumberUsed { get; set; } = 1;

        [JsonConverter(typeof(StringEnumConverter))]
        public PROJECT Project { get; set; }

        public List<clsAGVInfo> AGVList { get; set; } = new List<clsAGVInfo>();
        public string MapFilePath { get; set; } = @"C:\CST\ini\Map_UMTC_3F_MEC.json";

        public enum PROJECT
        {
            U003, U007
        }


    }
}
