using GPMCasstteConvertCIM.API.KGAGVS;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.DataBase.KGS_AGVs.WebAGVSystemDBBackgroundWorker;
using static GPMCasstteConvertCIM.GPM_SECS.S2F49TransferQueueOperator;

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

        public string MaterialManagementWebUrl { get; set; } = "http://localhost:6600";

        public clsWebServerParam WebService { get; set; } = new clsWebServerParam();
        public clsSECSWatchDogConfig AGVSSecsWatchDog { get; set; } = new clsSECSWatchDogConfig();

        public bool EqMaintainSignalSyncEnabled { get; set; } = false;
        public bool EqPartsReplacementSignalSyncEnabled { get; set; } = false;
        public bool showddosdialog { get; set; } = true;

        /// <summary>
        /// 當遠端模式切換時，是否切換AGV的CST Reader(呼叫AGV車載API)
        /// </summary>
        public bool SwitchCSTReaderOfAGVWhenRemoteModeChanged { get; set; } = false;

        public Int32 ddoschksec { get; set; } = 3;
        public Int32 ddoslimit { get; set; } = 1024;
        public Int32 ddoscountlimit { get; set; } = 20;

        public bool CarrierEventReportNeedInOnlineRemote { get; set; } = false;

        public Configurations S2F49QueuingConfigurations { get; set; } = new Configurations();
        public EQLotIDMonitor.Configrations EQLotIDMonitorConfigrations { get; set; } = new EQLotIDMonitor.Configrations();
        public UIConfiguration UI { get; set; } = new UIConfiguration();
        public CancelChargeTaskFunction CancelChargeTaskAuto { get; set; } = new CancelChargeTaskFunction();
        public clsAutomationConfiguration Automation { get; set; } = new clsAutomationConfiguration();
        public enum PROJECT
        {
            U003, U007, YM_2F_AOI
        }


    }
}
