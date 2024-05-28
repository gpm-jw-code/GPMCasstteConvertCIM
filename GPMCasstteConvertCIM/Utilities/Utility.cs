using AGVSystemCommonNet6.HttpTools;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using GPMCasstteConvertCIM.VirtualAGVSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities
{
    internal class Utility
    {

        public static string configsFolder = "configs";

        public static clsSystemConfigs SysConfigs = new clsSystemConfigs();
        public static clsModbusDeviceConfigs ModbusDeviceConfigs = new clsModbusDeviceConfigs();

        internal static LoggerBase SystemLogger;


        internal static frmModbusTCPServer ModbusTCPServerView = new frmModbusTCPServer();


        internal static frmVirtualAGVS VirtualAGVS = new frmVirtualAGVS();

        internal static bool _IsHotRunMode = false;
        internal static bool IsHotRunMode
        {
            get => _IsHotRunMode;
            set
            {
                if (_IsHotRunMode != value)
                {
                    _IsHotRunMode = value;
                    DevicesManager.SetPortsIOSignalSource(IsHotRunMode ? Enums.IO_MODE.FromCIMSimulation : Enums.IO_MODE.FromIOModule);
                    AGVLDULDNoEntryModeControl(value);
                }
            }
        }

        private static async void AGVLDULDNoEntryModeControl(bool enableHotRun)
        {
            foreach (var _agv in Utility.SysConfigs.AGVList)
            {
                try
                {

                    HttpHelper http = new HttpHelper($"http://{_agv.AGVIP}:7025");
                    int retCode = await http.GetAsync<int>($"/api/VMS/LDULDWithoutEntryControl?actived={enableHotRun}");
                    Utility.SystemLogger.Info($"變更 AGV-{_agv.AGVID}({_agv.AGVIP}) 空取空放模式={enableHotRun},Result Code = {retCode}");
                }
                catch (Exception ex)
                {
                    Utility.SystemLogger.Error($"變更 AGV-{_agv.AGVID}({_agv.AGVIP}) 空取空放模式={enableHotRun} 失敗, Error = {ex.Message}");
                }
            }
        }
        internal static void LoadConfigs()
        {
            LoadSysConfigs();
        }
        internal static void SaveConfigs()
        {
            if (!Directory.Exists(configsFolder))
                Directory.CreateDirectory(configsFolder);
            string SysCofigsFile = Path.Combine(configsFolder, "SystemConfigs.json");
            File.WriteAllText(SysCofigsFile, JsonConvert.SerializeObject(SysConfigs, Formatting.Indented));
            string ModbusDeviceConfig = Path.Combine(configsFolder, "ModbusDeviceConfigs.json");
            File.WriteAllText(ModbusDeviceConfig, JsonConvert.SerializeObject(ModbusDeviceConfigs, Formatting.Indented));
        }
        private static void LoadSysConfigs()
        {

            if (!Directory.Exists(configsFolder))
                Directory.CreateDirectory(configsFolder);

            string SysCofigsFile = Path.Combine(configsFolder, "SystemConfigs.json");
            string ModbusDeviceConfig = Path.Combine(configsFolder, "ModbusDeviceConfigs.json");
            if (File.Exists(SysCofigsFile))
            {
                SysConfigs = JsonConvert.DeserializeObject<clsSystemConfigs>(File.ReadAllText(SysCofigsFile));
                if (SysConfigs.AGVList.Count == 0 && (SysConfigs.Project == clsSystemConfigs.PROJECT.U007 || SysConfigs.Project == clsSystemConfigs.PROJECT.YM_2F_AOI))
                {
                    SysConfigs.AGVList = new List<clsAGVInfo>()
                    {
                         new clsAGVInfo()
                         {
                             AGVID = 1,
                             AGVIP = "10.22.141.218",
                         },
                         new clsAGVInfo()
                         {
                             AGVID = 2,
                             AGVIP = "10.22.141.219",
                         }
                    };
                }
            }
            if (File.Exists(ModbusDeviceConfig))
            { ModbusDeviceConfigs = JsonConvert.DeserializeObject<clsModbusDeviceConfigs>(File.ReadAllText(ModbusDeviceConfig)); }
            SaveConfigs();
        }

    }
}
