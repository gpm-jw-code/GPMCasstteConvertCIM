using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsAGVInfo
    {
        public int AGVID { get; set; }
        public string AGVIP { get; set; } = "192.168.1.101";
        [NonSerialized]
        public string TaskNameExecuting = "";

        [NonSerialized]
        internal CancellationTokenSource PostCancelCTS = new CancellationTokenSource();
        [NonSerialized]
        internal bool PostingFlag = false;

        private bool _PingSuccess = true;
        internal bool PingSuccess
        {
            get => _PingSuccess;
            set
            {
                if (_PingSuccess != value)
                {
                    _PingSuccess = value;
                    if (!_PingSuccess)
                    {
                        AlarmManager.AddWarning(ALARM_CODES.AGV_PING_FAIL, AGVIP, true);
                    }
                }
            }
        }
    }
}
