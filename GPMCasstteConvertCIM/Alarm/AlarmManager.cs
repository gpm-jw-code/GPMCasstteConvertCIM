using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public class AlarmManager
    {
        public static Dictionary<ALARM_CODES, clsAlarmDto> AlarmCodes = new Dictionary<ALARM_CODES, clsAlarmDto>() {

             {  ALARM_CODES.CONNECTION_ERROR_CONVERT , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"通訊異常","轉換架通訊異常") },
             {  ALARM_CODES.CONNECTION_ERROR_MCS , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"通訊異常","MES通訊異常") },
             {  ALARM_CODES.CONNECTION_ERROR_AGVS , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"通訊異常","AGVS通訊異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_IN , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"轉換架交握","Carrier WAIT_IN 交握異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_OUT , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"轉換架交握","Carrier WAIT_OUT 交握異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_PORT_TYPE_CHANGE , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"轉換架交握","Port Type Change 交握異常") }
        };
        public static List<clsAlarmDto> AlarmList { get; set; } = new List<clsAlarmDto>();
        public static void Add(clsAlarmDto alarm)
        {
            AlarmList.Add(alarm);
        }

        public static void AddWarning(ALARM_CODES alarm_code)
        {
            if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDto))
            {
                alarmDto.Time = DateTime.Now;
                alarmDto.Level = ALARM_LEVEL.WARNING;
                AddToList(alarmDto);
            }
            else
                AddUndefinedAlarm(alarm_code, ALARM_LEVEL.WARNING);
        }
        public static void AddAlarm(ALARM_CODES alarm_code)
        {
            //AlarmList.Add(alarm);

            if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDto))
            {
                alarmDto.Time = DateTime.Now;
                alarmDto.Level = ALARM_LEVEL.ALARM;
                AddToList(alarmDto);
            }
            else
                AddUndefinedAlarm(alarm_code, ALARM_LEVEL.ALARM);
        }
        private static void AddToList(clsAlarmDto alarmDto)
        {
            var alarmExist = AlarmList.FirstOrDefault(alarm => alarm.Code == alarmDto.Code);
            if (alarmExist == null)
                AlarmList.Add(alarmDto);
            else
            {
                alarmExist.Duration += (DateTime.Now - alarmExist.Time).TotalSeconds;
                alarmExist.Time = alarmDto.Time;
            }

        }
        private static void AddUndefinedAlarm(ALARM_CODES alarmCode, ALARM_LEVEL level = ALARM_LEVEL.WARNING)
        {
            clsAlarmDto alarm = new clsAlarmDto();
            alarm.Time = DateTime.Now;
            alarm.Level = level;
            alarm.Code = alarmCode;
            alarm.Classify = "Unknown";
            alarm.Description = alarmCode.ToString();
            AlarmList.Add(alarm);
        }

        internal static void ClearAlarm()
        {
            AlarmList.Clear();
        }


    }
}
