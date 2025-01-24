using GPMCasstteConvertCIM.Utilities.SysConfigs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Utilities
{
    internal static class AGVController
    {
        internal static List<AGVWrapper> aGVWrappers { get; private set; } = new List<AGVWrapper>();

        internal static async void HandleHostRemoteModeChanged(object? sender, bool isRemoteMode)
        {
            await Task.Delay(1).ContinueWith(async t =>
            {
                await SwitchCSTReader(isRemoteMode);
            });
        }

        internal static void Initialize(List<clsAGVInfo> AGVList)
        {
            aGVWrappers = AGVList.Select(agv => new AGVWrapper(agv)).ToList();
        }

        internal static async Task SwitchCSTReader(bool enable)
        {

            if (!Utility.SysConfigs.SwitchCSTReaderOfAGVWhenRemoteModeChanged)
                return;

            if (!aGVWrappers.Any())
                return;

            string enabledStr = enable ? "ENABLED" : "DISABLED";
            _LOG($"Try Switch ALL AGV CST READER to {(enable ? "ENABLE" : "DISABLED")}");
            (bool confirm, string message)[] results = await Task.WhenAll(aGVWrappers.Select(agv => agv.SwitchCSTReader(enable)));
            if (results.Any(i => !i.confirm))
            {
                string messages = string.Join(",", results.Select(r => r.message));
                _LOG($"SOME AGV CST READER Swtich Fail(Not Confirmed)_messages:{messages}");
            }
            else
            {
                _LOG($"ALL AGV CST READER switch to {enabledStr}");
            }
        }

        private static void _LOG(string message)
        {
            Utility.SystemLogger.Info($"[AGVController] {message}");
        }
    }


    internal class AGVWrapper
    {
        private clsAGVInfo _agv;

        private HttpClient _httpClient;

        public AGVWrapper(clsAGVInfo agv)
        {
            _agv = agv;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri($"http://{_agv.AGVIP}:7025");
        }
        public async Task<(bool confirm, string message)> SwitchCSTReader(bool enable)
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.PostAsync("api/AGV/SwitchCSTReader?enable=" + enable, null);
                var msg = response.EnsureSuccessStatusCode();
                if (!msg.IsSuccessStatusCode)
                    return (false, $"AGV-{_agv.AGVID} CST Reader switch failed");

                string jsonString = await response.Content.ReadAsStringAsync();
                // json deserialize
                var jObject = JObject.Parse(jsonString);
                bool confirm = (bool)jObject["confirm"];
                string message = (string)jObject["message"];
                return (confirm, message);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }

        }
    }
}
