using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    /// <summary>
    /// 在 TimeWindow 設定秒數內流量超過 MsgSizeLimit Byte=> DDOS!
    /// </summary>
    public class clsSECSWatchDogConfig
    {
        /// <summary>
        /// Unit : Second
        /// </summary>
        public int TimeWindow { get; set; } = 3;

        /// <summary>
        /// Unit : byte
        /// </summary>
        public long MsgSizeLimit { get; set; } = 8192;
        public int CountLimit { get; set; } = 20;
    }
}
