﻿using GPMCasstteConvertCIM.GPM_SECS;
using System.ComponentModel.Design;
using System.DirectoryServices.ActiveDirectory;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public class clsPortProperty
        {
            /// <summary>
            /// (Zero-Based)
            /// </summary>
            public int PortNo { get; set; }
            public string PortID { get; set; } = "Port 1";
            internal bool InSerivce { get; set; } = false;

            public string ModbusServer_IP { get; set; } = "127.0.0.1";
            public int ModbusServer_PORT { get; set; } = 1502;

            public bool ModbusServer_Enable = true;

            internal PortUnitType PortType { get; set; }

            public bool CarrierWaitInOutReport_Enable { get; set; } = true;

            public string PreviousOnPortID { get; set; } = "";
            public bool IsInstalledLastTime { get; set; } = false;

            public DateTime CarrierInstallTime { get; set; } = DateTime.MinValue;
            public bool CarrierWaitInNeedWaitingS2F41OrS2F49{ get; set; } = false;

        }

    }
}
