using GPMCasstteConvertCIM.UI_UserControls;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public partial class AlarmManager
    {
        public static ConcurrentQueue<clsAlarmDto> AlarmsList { get; set; } = new ConcurrentQueue<clsAlarmDto>();

        public static event EventHandler<clsAlarmDto> onAlarmAdded;
        public static event EventHandler onAlarmDBChanged;

        internal static void LoadNewestAlarmsFromDatabase(int count = 30)
        {
            List<clsAlarmDto> alarms = DBhelper.QueryAlarm(1, count);
            foreach (var item in alarms)
            {
                AlarmsList.Enqueue(item);
            }
        }
        public static void AddWarning(ALARM_CODES alarm_code, string EQPName, bool add_new_one_when_exist_same_code = true)
        {
            if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDeffined))
            {
                if (AlarmsList.Count >= 50)
                    AlarmsList.TryDequeue(out var oldest);

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
                    AlarmsList.Enqueue(newAalrm);
                else
                    TryUpdate(newAalrm);

                onAlarmAdded?.Invoke("", newAalrm);
            }
            else
                AddUndefinedAlarm(alarm_code, ALARM_LEVEL.WARNING, EQPName);

            Utility.SystemLogger.Warning($"Warning : {EQPName} - {alarm_code}", false);
        }
        public static void AddAlarm(ALARM_CODES alarm_code, string EQPName, bool add_new_one_when_exist_same_code = true)
        {
            try
            {
                //AlarmList.Add(alarm);
                if (AlarmCodes.TryGetValue(alarm_code, out clsAlarmDto alarmDeffined))
                {
                    if (AlarmsList.Count >= 50)
                        AlarmsList.TryDequeue(out var oldest);
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
                        AlarmsList.Enqueue(newAalrm);
                    else
                        TryUpdate(newAalrm);

                    onAlarmAdded?.Invoke("", newAalrm);
                    if (onAlarmDBChanged != null)
                        onAlarmDBChanged("", EventArgs.Empty);
                }
                else
                    AddUndefinedAlarm(alarm_code, ALARM_LEVEL.ALARM, EQPName);
                Utility.SystemLogger.Error($"Alarm : {EQPName} - {alarm_code}", null, true);
            }
            catch (Exception ex)
            {
                Utility.SystemLogger.Error($"[AlarmManager] Add Alarm : {EQPName} - {alarm_code} FAIL:{ex.Message}", ex, true);
            }


        }
        private static void TryUpdate(clsAlarmDto alarmDto)
        {
            var alarmExist = AlarmsList.FirstOrDefault(alarm => alarm.Level == alarmDto.Level && alarm.Code.ToString() == alarmDto.Code.ToString() && alarm.EQPName == alarmDto.EQPName);
            if (alarmExist == null)
                AlarmsList.Enqueue(alarmDto);
            else
            {
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
            AlarmsList.Enqueue(alarm);
            onAlarmAdded?.Invoke("", alarm);
        }

        internal static void ClearAlarm()
        {
            AlarmsList.Clear();
            onAlarmAdded?.Invoke("", null);

        }

        internal static void TryRemoveAlarm(ALARM_CODES alarmCode, string EQPName)
        {
            var alarms = AlarmsList.ToList().FindAll(alarm => alarm.Code == alarmCode && alarm.EQPName == EQPName);
            foreach (var alarm in alarms)
            {
                AlarmsList.TakeWhile(a => a == alarm);
            }
        }
    }
}
