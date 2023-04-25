using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Alarm
{
    public class AlarmManager
    {
        public static Dictionary<ALARM_CODES, clsAlarmDto> AlarmCodes = new Dictionary<ALARM_CODES, clsAlarmDto>() {

             {  ALARM_CODES.CONNECTION_ERROR_CONVERT , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_CONVERT,"通訊異常","轉換架通訊異常") },
             {  ALARM_CODES.CONNECTION_ERROR_MCS , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_MCS,"通訊異常","MES通訊異常") },
             {  ALARM_CODES.CONNECTION_ERROR_AGVS , new clsAlarmDto( ALARM_CODES.CONNECTION_ERROR_AGVS,"通訊異常","AGVS通訊異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_IN , new clsAlarmDto( ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_IN,"CIM/EQP HS","Carrier WAIT_IN 交握異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_OUT , new clsAlarmDto( ALARM_CODES.HANDSHAKE_ERROR_CARRIER_WAIT_OUT,"CIM/EQP HS","Carrier WAIT_OUT 交握異常") },
             {  ALARM_CODES.HANDSHAKE_ERROR_PORT_TYPE_CHANGE , new clsAlarmDto( ALARM_CODES.HANDSHAKE_ERROR_PORT_TYPE_CHANGE,"CIM/EQP HS","Port Type Change 交握異常") },
             {  ALARM_CODES.ALIVE_CLOCK_EQP_DOWN , new clsAlarmDto( ALARM_CODES.ALIVE_CLOCK_EQP_DOWN,"CLOCK CHECK","設備ALIVE CLOCK CHECK 異常") },
             {  ALARM_CODES.MCS_PORT_IN_SERVICE_REPORT_FAIL , new clsAlarmDto( ALARM_CODES.MCS_PORT_IN_SERVICE_REPORT_FAIL,"REPORT TO MCS","上報PORT IN-SERVICE的過程中發生異常") },
             {  ALARM_CODES.MCS_PORT_OUT_SERVICE_REPORT_FAIL , new clsAlarmDto( ALARM_CODES.MCS_PORT_OUT_SERVICE_REPORT_FAIL,"REPORT TO MCS","上報PORT OUT-SERVICE的過程中發生異常") },
             {  ALARM_CODES.MCS_CARRIER_WAITIN_REPORT_FAIL , new clsAlarmDto( ALARM_CODES.MCS_CARRIER_WAITIN_REPORT_FAIL,"REPORT TO MCS","上報Carrier Wait-In 的過程中發生異常") },
             {  ALARM_CODES.MCS_CARRIER_WAITOUT_REPORT_FAIL , new clsAlarmDto( ALARM_CODES.MCS_CARRIER_WAITIN_REPORT_FAIL,"REPORT TO MCS","上報Carrier Wait-Out 的過程中發生異常") },
             {  ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL , new clsAlarmDto( ALARM_CODES.MCS_CARRIER_REMOVED_COMPLETED_REPORT_FAIL,"REPORT TO MCS","CarrierRemovedCompleted Report(CE-152) 的過程中發生異常") },
             {  ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_DISCONNECT, new clsAlarmDto( ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_DISCONNECT,"CARRIER WAIT_IN","Carrier Wait-In 失敗-與MCS的連線已中斷") },
             {  ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_REJECT, new clsAlarmDto( ALARM_CODES.CARRIER_WAIT_IN_BUT_MCS_REJECT,"CARRIER WAIT_IN","Carrier Wait-In 失敗-MCS REJECT") },
             {  ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout, new clsAlarmDto( ALARM_CODES.CarrierWaitIn_HS_EQ_Timeout,"CIM/EQP HS","Carrier Wait-In 交握過程中發生EQ TIMEOUT") },
             {  ALARM_CODES.CarrierWaitOut_HS_EQ_Timeout, new clsAlarmDto( ALARM_CODES.CarrierWaitOut_HS_EQ_Timeout,"CIM/EQP HS","Carrier Wait-Out 交握過程中發生EQ TIMEOUT") },
             {  ALARM_CODES.CarrierRemovedCompolete_HS_EQ_Timeout, new clsAlarmDto( ALARM_CODES.CarrierRemovedCompolete_HS_EQ_Timeout,"CIM/EQP HS","Carrier Removed Completed 交握過程中發生EQ TIMEOUT") },
             {  ALARM_CODES.TRANSFER_MCS_MSG_TO_AGVS_BUT_AGVS_NO_REPLY, new clsAlarmDto( ALARM_CODES.TRANSFER_MCS_MSG_TO_AGVS_BUT_AGVS_NO_REPLY,"MCS MSG TRANSFER","轉送MCS SECS訊息但AGVS沒有回覆") },
             {  ALARM_CODES.AGVS_REPLY_MCS_MSG_BUT_ERROR_WHEN_REPLY_TO_MCS, new clsAlarmDto( ALARM_CODES.AGVS_REPLY_MCS_MSG_BUT_ERROR_WHEN_REPLY_TO_MCS,"MCS MSG TRANSFER","轉送AGVS訊息至MCS時失敗") },
             {  ALARM_CODES.CODE_EXCEPTION_WHEN_TRANSFER_MSG_TO_AGVS, new clsAlarmDto( ALARM_CODES.CODE_EXCEPTION_WHEN_TRANSFER_MSG_TO_AGVS,"MCS MSG TRANSFER","轉送MCS SECS訊息至AGVS的過程中發生程式例外") },
             {  ALARM_CODES.EVENT_REPORT_COMPLETED_BUT_ACK_IS_SYSTEM_ERROR_65, new clsAlarmDto( ALARM_CODES.EVENT_REPORT_COMPLETED_BUT_ACK_IS_SYSTEM_ERROR_65,"SECS_EVENT_REPORT","Event Report MCS回傳System_Error(ACKC6 = 65)") },
        };
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
