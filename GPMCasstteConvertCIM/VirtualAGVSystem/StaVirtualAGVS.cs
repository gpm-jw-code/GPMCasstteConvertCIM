using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public partial class StaVirtualAGVS
    {
        public static BindingList<clsAGVCState> AGVCList = new BindingList<clsAGVCState>() {
            new()
            {
                 AGV_ID= 1,
                 CarName ="AGV_1"
            },
            new clsAGVCState()
            {
                 AGV_ID= 2,
                 CarName ="AGV_2"

            }
        };

        public static clsDBParam DbParameters = new clsDBParam()
        {
            port = 5501
        };

        private static string DBParamFileName = "configs/AGVS_DB_Param.json";

        public static bool SQLConnected { get; private set; }

        public static List<string> StationList = new List<string>()
        {
            "21","23","25","27","29","31","33","35","37","39","41"
        };

        public static List<string> SlotSetList = new List<string>()
        {
           "RACK_1_3|7|11","RACK_1_4|8|12", "RACK_4_1|3|4","RACK_4_2|4|6","RACK_4_7|8|9"
        };

        public static AGVS_Dispath_Emulator TaskDispatcher = new AGVS_Dispath_Emulator();

        public static frmVirtualAGVS MainUI = new frmVirtualAGVS();

        private static Task AGVCStateSyncTask;
        public async static void Initialize()
        {
            await Task.Delay(1);
            LoadDBParam();

            if (DbParameters.enable)
            {
                AGVCStateFetchTaskRUn();
            }
        }

        private static async void AGVCStateFetchTaskRUn()
        {
            _ = Task.Run(() =>
            {
                while (true)
                {
                    try
                    {

                        FetchAGVCStateFromDatabase();
                    }
                    catch (Exception ex)
                    {
                        Utility.SystemLogger.Error(ex.Message, ex);
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private static void FetchAGVCStateFromDatabase()
        {
            DataBase.MSSQL mSSQL = new DataBase.MSSQL();
            SQLConnected = mSSQL.Connect(DbParameters.database, out string errMsg, DbParameters.server, DbParameters.user, DbParameters.password, DbParameters.port);

            if (!SQLConnected)
            {
                // MainUI.WriteLog($"SQL 連線失敗({DbParameters.server}:{DbParameters.port},{DbParameters.user},{DbParameters.password}) : {errMsg}");
                Utility.SystemLogger.Warning($"SQL 連線失敗({DbParameters.server}:{DbParameters.port},{DbParameters.user},{DbParameters.password}) : {errMsg}");
                AGVCList[0].RunState = clsAGVCState.RUN_STATE.DOWN;
                return;
            }
            string queryString = "SELECT [AGVID],[AGVName],[AGVMainStatus],[AGVSubStatus],[AGVMode],[CurrentPos],[Battery],[AlarmCode],[AlarmDescription],[CSTID] FROM [WebAGVSystem].[dbo].[AGVInfo]";
            bool query_success = mSSQL.TryQuery(queryString, out System.Data.DataSet dataset, out errMsg);
            if (!query_success)
                return;
            else
            {
                foreach (DataRow? row in dataset.Tables[0].Rows)
                {
                    int AGVID = row.Field<int>("AGVID");
                    string CarName = row.Field<string>("AGVName");
                    int AGVMainStatus = row.Field<int>("AGVMainStatus");
                    int AGVSubStatus = row.Field<int>("AGVSubStatus");
                    int AGVMode = row.Field<int>("AGVMode");
                    int CurrentPos = row.Field<int>("CurrentPos");
                    double Battery = row.Field<double>("Battery");
                    int AlarmCode = row.Field<int>("AlarmCode");
                    string AlarmDescription = row.Field<string>("AlarmDescription");
                    string CSTID = row.Field<string>("CSTID");

                    clsAGVCState? AGVC = AGVCList.FirstOrDefault(_agv => _agv.AGV_ID == AGVID);
                    if (AGVC != null)
                    {
                        AGVC.CarName = CarName;
                        AGVC.Battery = Battery;
                        AGVC.TagID = CurrentPos.ToString();
                        AGVC.CSTID = CSTID;

                        try
                        {
                            AGVC.RunState = Enum.GetValues(typeof(clsAGVCState.RUN_STATE)).Cast<clsAGVCState.RUN_STATE>().First(_E => (int)_E == AGVMainStatus);
                        }
                        catch (Exception) { }
                        try
                        {
                            AGVC.OnlineState = Enum.GetValues(typeof(clsAGVCState.ONLINE_STATE)).Cast<clsAGVCState.ONLINE_STATE>().First(_E => (int)_E == AGVMode);
                        }
                        catch (Exception) { }

                    }

                }
            }
            mSSQL.Close();
        }

        private static void LoadDBParam()
        {
            if (File.Exists(DBParamFileName))
            {
                DbParameters = JsonConvert.DeserializeObject<clsDBParam>(File.ReadAllText(DBParamFileName));
            }
            File.WriteAllText(DBParamFileName, JsonConvert.SerializeObject(new clsDBParam(), Formatting.Indented));
        }

        internal static void SetCookie(string connect_sid, string io)
        {
            TaskDispatcher.SetCookie(connect_sid, io);
        }

    }
}
