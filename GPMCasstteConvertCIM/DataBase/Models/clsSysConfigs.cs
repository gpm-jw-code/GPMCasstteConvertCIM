using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Database
{
    public class clsSysConfigs
    {
        public string MapFile { get; set; } = "C:\\CST\\ini\\Map_UMTC_AOI.json";
        public string AGVSHost { get; set; } = "http://127.0.0.1:6600";
        public string DBConnection { get; set; } = "Server=127.0.0.1;Database=WebAGVSystem;User Id=sa;Password=12345678;Encrypt=False";
        public string HotRunScriptStoredFile { get; set; } = "HotRunScripts.json";
        internal string AGVSIP
        {
            get
            {
                return AGVSHost.Replace("http://", "").Split(':')[0];
            }
        }
        internal int AGVSPort
        {
            get
            {
                if (int.TryParse(AGVSHost.Replace("http://", "").Split(':')[1], out int _port))
                    return _port;
                return 6600;
            }
        }
        /// <summary>
        /// 派送任務後是否需要等待任務結束
        /// </summary>
        public bool WaitTaskDoneDispatchMode { get; set; } = false;
        /// <summary>
        /// 腳本執行過程中如有充電任務是否要取消
        /// </summary>
        public bool CancelChargeTaskWhenHotRun { get; set; } = false;
    }
}
