﻿using Newtonsoft.Json;
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

        [JsonConverter(typeof(StringEnumConverter))]
        public PROJECT Project { get; set; }

        public enum PROJECT
        {
            U003, U007
        }

    }
}
