using GPMCasstteConvertCIM.GPM_SECS;
using System.ComponentModel.Design;
using System.DirectoryServices.ActiveDirectory;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public class clsPortProperty
        {
            public Dictionary<string, string> Description { get; set; } = new Dictionary<string, string>()
            {
                { "PortType","0-Input, 1-Output, 2-Input_Output" }
            };
            /// <summary>
            /// (Zero-Based)
            /// </summary>
            public int PortNo { get; set; }
            public string PortID { get; set; } = "Port 1";
            internal bool InSerivce { get; set; } = false;

            public string ModbusServer_IP { get; set; } = "127.0.0.1";
            public int ModbusServer_PORT { get; set; } = 1502;
            public int AGVHandshakeModbus_PORT { get; set; } = 4502;

            public bool ModbusServer_Enable = true;
            public bool AGVHandshakeModbusGatewayActive = false;
            public PortUnitType PortType { get; set; } = PortUnitType.Input;

            public bool CarrierWaitInOutReport_Enable { get; set; } = true;
            public bool LoadUnlloadStateSimulation { get; set; } = false;

            /// <summary>
            /// 是否使用SECS通訊上報狀態或下載請求
            /// </summary>
            public bool SecsReport { get; set; } = true;

            /// <summary>
            /// 在派車系統上設定的Tag編號
            /// </summary>
            public int TagNumberInAGVS { get; set; } = 1;
            public int TagNumberInAGVS_Secondary { get; set; } = 1;

            public string PreviousOnPortID { get; set; } = "";
            public bool IsInstalled { get; set; } = false;

            public DateTime CarrierInstallTime { get; set; } = DateTime.MinValue;

            /// <summary>
            /// 
            /// </summary>
            public bool CarrierWaitInNeedWaitingS2F41OrS2F49 { get; set; } = false;

            /// <summary>
            /// OFFLINE模式下，當與AGV交握結束後自動切換為OUTPUT
            /// </summary>
            public bool AutoChangeToOUTPUTWhenAGVLoadedInOFFLineMode { get; set; } = true;

            /// <summary>
            /// 僅在PORT為OUTPUT時向MCS上報Remove
            /// </summary>
            public bool RemoveCarrierMCSReportOnlyInOUTPUTMODE { get; set; } = false;

            /// <summary>
            /// 不管怎樣都不向MCS上報Carrier Remove事件
            /// </summary>
            public bool NeverReportCarrierRemove { get; set; } = false;

            /// <summary>
            /// 等待接收S2F49 Timeout 時間(秒)(配合 CarrierWaitInNeedWaitingS2F41OrS2F49設定需開啟)
            /// </summary>
            public int WaitS2F49CmdTimeoutSec { get; set; } = 60;

            /// <summary>
            /// 當MCS下任務被AGVS拒絕後須讓轉換架退料
            /// </summary>
            public bool CarrierWaitOutWhenAGVSRefuseMCSMission { get; set; } = false;



            public bool IsConverter { get; set; } = false;

            public bool ModifyAGVSCargoIDWithWebAPI { get; set; } = true;
            public string NameInAGVS { get; set; } = "";

        }

    }
}
