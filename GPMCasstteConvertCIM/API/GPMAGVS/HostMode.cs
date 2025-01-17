using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.GPMAGVS
{
    internal static class HostMode
    {

        const string agvsHost = "http://127.0.0.1:5216";

        internal static async Task<(bool isOnline, bool isRemote)> GetCurrentHostMode()
        {
            bool isOnline = false;
            bool isRemote = false;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{agvsHost}/api/system/OperationStates");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<JObject>(responseBody);

                //host_online_mode = SystemModes.HostConnMode,
                //host_remote_mode = SystemModes.HostOperMode,

                int onlineMode = int.Parse(json["host_online_mode"].ToString());
                int remoteMode = int.Parse(json["host_remote_mode"].ToString());
                isOnline = onlineMode == 1;
                isRemote = remoteMode == 1;
            }
            return (isOnline, isRemote);
        }
    }
}
