using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.Utilities.LoggerBase;

namespace GPMCasstteConvertCIM.Utilities.SysConfigs
{
    public class clsLogConfigs
    {
        public string SyslogFolder { get; set; } = @"D:\CIMLOG";
        public LOG_TIME_UNIT LogFileUnit { get; set; } = LOG_TIME_UNIT.ByHour;
    }
}
