using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public class AGVS_Dispath_Emulator
    {

        public class POWERSHELL_HELPER
        {

            public static string Run(string powershellFile)
            {
                try
                {

                    var filePath = powershellFile;
                    var process = new Process();
                    process.StartInfo.FileName = "powershell.exe";
                    process.StartInfo.Arguments = $"-File {powershellFile}";
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return output;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
        }



        public class TaskObj
        {
            public string CarName { get; set; }
            public int AGVID { get; set; } = 1;
            public string Action { get; set; }

            public string FromStation { get; set; }
            public string FromSlot { get; set; }
            public string ToStation { get; set; }
            public string ToSlot { get; set; }

            public int Priority { get; set; } = 5;
            public int RepeatTime { get; set; } = 1;
            public string CSTID { get; set; } = "";

            public string ToQueryString()
            {
                return $"CarName={CarName}&AGVID={AGVID}&Action={Action}&FromStation={FromStation}&FromSlot={FromSlot}&ToStation={ToStation}&ToSlot={ToSlot}&Priority={Priority}&RepeatTime={RepeatTime}&CSTID={CSTID}";
            }

        }
        public enum ACTION
        {
            Move,
            Parking,
            Unload,
            Load
        }

        string url = "http://127.0.0.1:6600/mission/request?";

        public class clsCookie
        {
            public string Cookies_Connect_SID = "s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI";
            public string Cookies_io = "TPrw6Q8Aol3EBu1YAAAP";

        }
        public clsCookie Cookies = new clsCookie();

        public AGVS_Dispath_Emulator()
        {
            LoadCookies();
        }
        private string cookies_json_file = "cookie.json";
        private void LoadCookies()
        {
            if (File.Exists(cookies_json_file))
            {
                Cookies = JsonConvert.DeserializeObject<clsCookie>(File.ReadAllText(cookies_json_file));
            }
            else
            {
                SaveCookies();
            }
        }

        private void SaveCookies()
        {
            File.WriteAllText(cookies_json_file, JsonConvert.SerializeObject(Cookies, Formatting.Indented));
        }

        public AGVS_Dispath_Emulator(string cookie_connect_sid, string cookie_io)
        {
            this.Cookies.Cookies_Connect_SID = cookie_connect_sid;
            this.Cookies.Cookies_io = cookie_io;
        }


        public async Task<ExcuteResult> Move(string CarName, int AGV_ID, string Station)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Move, CarName, AGV_ID + "", Station);
            var output = POWERSHELL_HELPER.Run(psFile);
            File.Delete(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Park(string CarName, int AGV_ID, string Station, string slot)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Parking, CarName, AGV_ID + "", Station, slot);
            var output = POWERSHELL_HELPER.Run(psFile);
            File.Delete(psFile);

            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<ExcuteResult> Load(string CarName, int AGV_ID, string Station, string slot)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Load, CarName, AGV_ID + "", Station, slot);
            var output = POWERSHELL_HELPER.Run(psFile);
            if (!Debugger.IsAttached)
                File.Delete(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }
        public async Task<ExcuteResult> Unload(string CarName, int AGV_ID, string Station, string slot)
        {
            var psFile = CreateTaskCmdPSFile(ACTION.Unload, CarName, AGV_ID + "", Station, slot);
            var output = POWERSHELL_HELPER.Run(psFile);
            if (!Debugger.IsAttached)
                File.Delete(psFile);
            return new ExcuteResult
            {
                ErrorMsg = "",
                ResponseMsg = output,
                fileName = psFile,
            };
        }

        public async Task<string> TryGetConnectionCookies()
        {
            string cookies_str = "";
            using (HttpClient _client = new HttpClient())
            {
                var ret = await _client.GetAsync("http://127.0.0.1:6600/index");
                IEnumerable<string> cookies = ret.Headers.GetValues("Set-Cookie");
                cookies_str = string.Join(",", cookies);
            }

            return cookies_str;
        }


        public class ExcuteResult
        {
            public bool Success
            {
                get
                {
                    return ResponseMsg.Contains("403");
                }
            }
            public string ResponseMsg { get; set; }
            public string ErrorMsg { get; set; }
            public string url { get; internal set; }
            public string fileName { get; internal set; }
            public string Json()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }


        private string CreateTaskCmdPSFile(ACTION action, string CarName, string AGV_ID, string station_no, string slot_id = "1")
        {
            if (station_no.Contains("|"))
            {
                station_no = station_no.Replace("|", "%7C");
            }

            string content = GetDispatchCmdTemplatePSContent();

            content = content.Replace("s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI", $"{Cookies.Cookies_Connect_SID}");
            content = content.Replace("TPrw6Q8Aol3EBu1YAAAP", $"{Cookies.Cookies_io}");
            content = content.Replace("Action=Move", $"Action={action.ToString()}");
            content = content.Replace("CarName=AGV_1", $"CarName={CarName}");
            content = content.Replace("AGVID=1", $"AGVID={AGV_ID}");
            content = content.Replace("FromStation=35", $"FromStation={station_no}");
            content = content.Replace("FromSlot=1", $"FromSlot={slot_id}");
            Directory.CreateDirectory("temp");
            string psFileName = $"temp/{CarName}_Move_{station_no}_{slot_id}_{DateTime.Now.Ticks}.ps1";
            File.WriteAllText(psFileName, content);
            return psFileName;
        }
        private string GetDispatchCmdTemplatePSContent()
        {
            return File.ReadAllText("src/agv_task_cmd_template.ps1");
        }

        internal void SetCookie(string connect_sid, string io)
        {
            Cookies.Cookies_Connect_SID = connect_sid;
            Cookies.Cookies_io = io;
            SaveCookies();

        }
    }
}
