using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public partial class AlarmManager
    {
        public static List<clsAlarmDto> AlarmsList { get; set; } = new List<clsAlarmDto>();

        public static event EventHandler<clsAlarmDto> onAlarmAdded;



        public static void AddWarning(ALARM_CODES alarm_code, string EQPName, bool add_new_one_when_exist_same_code = true)
        {
            lock (AlarmsList)
            {
                if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDeffined))
                {
                    var newAalrm = new clsAlarmDto()
                    {
                        Classify = alarmDeffined.Classify,
                        Description = alarmDeffined.Description,
                        Code = alarmDeffined.Code,
                    };
                    newAalrm.Time = DateTime.Now;
                    newAalrm.Level = ALARM_LEVEL.WARNING;
                    newAalrm.EQPName = EQPName;
                    if (add_new_one_when_exist_same_code)
                        AlarmsList.Insert(0, newAalrm);
                    else
                        TryUpdate(newAalrm);
                    onAlarmAdded?.Invoke("", newAalrm);
                }
                else
                    AddUndefinedAlarm(alarm_code, ALARM_LEVEL.WARNING, EQPName);
            }
        }
        public static void AddAlarm(ALARM_CODES alarm_code, string EQPName, bool add_new_one_when_exist_same_code = true)
        {
            //AlarmList.Add(alarm);
            lock (AlarmsList)
            {
                if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDeffined))
                {
                    var newAalrm = new clsAlarmDto()
                    {
                        Classify = alarmDeffined.Classify,
                        Description = alarmDeffined.Description,
                        Code = alarmDeffined.Code,
                    };
                    newAalrm.Time = DateTime.Now;
                    newAalrm.Level = ALARM_LEVEL.ALARM;
                    newAalrm.EQPName = EQPName;

                    if (add_new_one_when_exist_same_code)
                        AlarmsList.Insert(0, newAalrm);
                    else
                        TryUpdate(newAalrm);

                    onAlarmAdded?.Invoke("", newAalrm);
                }
                else
                    AddUndefinedAlarm(alarm_code, ALARM_LEVEL.ALARM, EQPName);

            }

        }
        private static void TryUpdate(clsAlarmDto alarmDto)
        {
            var alarmExist = AlarmsList.FirstOrDefault(alarm => alarm.Level == alarmDto.Level && alarm.Code.ToString() == alarmDto.Code.ToString() && alarm.EQPName == alarmDto.EQPName);
            if (alarmExist == null)
                AlarmsList.Insert(0, alarmDto);
            else
            {
                alarmExist.Duration += (DateTime.Now - alarmExist.Time).TotalSeconds;
                alarmExist.Time = alarmDto.Time;
            }

        }


        private static void AddUndefinedAlarm(ALARM_CODES alarmCode, ALARM_LEVEL level = ALARM_LEVEL.WARNING, string eQPName = "")
        {
            clsAlarmDto alarm = new clsAlarmDto();
            alarm.Time = DateTime.Now;
            alarm.Level = level;
            alarm.Code = alarmCode;
            alarm.Classify = "Unknown";
            alarm.Description = alarmCode.ToString();
            alarm.EQPName = eQPName;
            AlarmsList.Add(alarm);
            onAlarmAdded?.Invoke("", alarm);
        }

        internal static void ClearAlarm()
        {
            AlarmsList.Clear();
            onAlarmAdded?.Invoke("", null);

        }


        internal static void TryRemoveAlarm(ALARM_CODES alarmCode, string EQPName)
        {
            var alarms = AlarmsList.FindAll(alarm => alarm.Code == alarmCode && alarm.EQPName == EQPName);
            foreach (var alarm in alarms)
            {
                AlarmsList.Remove(alarm);
            }
        }
    }
}
