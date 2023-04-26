using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public class clsAlarmDto
    {
        public ALARM_LEVEL Level { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Classify { get; set; } = string.Empty;
        public ALARM_CODES Code { get; set; }
        public double Duration { get; set; }
        public clsAlarmDto(ALARM_CODES code, string classify, string description)
        {
            Code = code;
            Classify = classify;
            Description = description;
        }
        public clsAlarmDto()
        {

        }
    }


    public enum ALARM_CODES
    {
        CONNECTION_ERROR_CONVERT,
        CONNECTION_ERROR_MCS,
        CONNECTION_ERROR_AGVS,
        HANDSHAKE_ERROR_CARRIER_WAIT_IN,
        HANDSHAKE_ERROR_CARRIER_WAIT_OUT,
        HANDSHAKE_ERROR_PORT_TYPE_CHANGE,
    }
}
