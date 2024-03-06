using GPMCasstteConvertCIM.Alarm;
using SQLite;
using System.Drawing.Printing;
using System.Security.Claims;

namespace GPMCasstteConvertCIM
{
    public class DBhelper
    {
        private static SQLiteConnection db;
        public static string DBFileName { get; private set; } = "";
        public static void Initialize(string dbName = "GPM_AGVS_CIM_Alarms")
        {
            try
            {
                var databasePath = Path.Combine(Environment.CurrentDirectory, $"{dbName}.db");
                db = new SQLiteConnection(databasePath);
                db.CreateTable<clsAlarmDto>();
                db.CreateTable<clsExceptionDto>();
                DBFileName = databasePath;
            }
            catch (System.Exception ex)
            {
                //LOG.Critical($"初始化資料庫時發生錯誤＿{ex.Message}");
            }
        }

        public static void InsertAlarm(clsAlarmDto alarm)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    db?.Insert(alarm);
                }
                catch (Exception)
                {
                }
            });
        }


        public static int AlarmsTotalNum(string alarm_type = "All")
        {
            if (alarm_type.ToLower() == "all")
                return db.Table<clsAlarmDto>().Count();
            else if (alarm_type.ToLower() == "alarm")
                return db.Table<clsAlarmDto>().Where(al => al.Level == ALARM_LEVEL.ALARM).Count();
            else
                return db.Table<clsAlarmDto>().Where(al => al.Level == ALARM_LEVEL.WARNING).Count();
        }

        public static int ClearAllAlarm()
        {
            try
            {
                return db.Table<clsAlarmDto>().Delete(a => a.Time != null);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<clsAlarmDto> QueryAlarm(int page, int page_size = 16, string alarm_type = "All")
        {
            try
            {
                TableQuery<clsAlarmDto> query = null;
                if (alarm_type.ToLower() == "all")
                {
                    query = db.Table<clsAlarmDto>().OrderByDescending(f => f.Time).Skip(page_size * (page - 1)).Take(page_size);
                }
                else
                {
                    var filterLevel = alarm_type.ToLower() == "alarm" ? ALARM_LEVEL.ALARM : ALARM_LEVEL.WARNING;
                    query = db.Table<clsAlarmDto>().OrderByDescending(f => f.Time).Where(al => al.Level == filterLevel).Skip(page_size * (page - 1)).Take(page_size);
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void AddExceptionRecord(clsExceptionDto exceptionDto)
        {
            try
            {
                db.Insert(exceptionDto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
