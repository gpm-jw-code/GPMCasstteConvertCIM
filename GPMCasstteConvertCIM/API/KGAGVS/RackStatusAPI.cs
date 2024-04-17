using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public class RackStatusAPI
    {
        internal static LoggerBase Logger;
        public string LastZone3CarrierID
        {
            get => AGVSiniRead.lastCarrierID; 
        }
        public static async Task<(bool confirm, string response, string errorMsg)> AddCSTID(string EQPName, int slot, string CarrierID)
        {
            Log($"Request to KGS AGVSYSTEM: Try Add CSTID={CarrierID} of {EQPName} ");
            (bool success, UserAuthAPI.clsCookie cookie, string response, string errorMsg) login_result = await UserAuthAPI.LoginToAGVSWebSite();

            if (!login_result.success)
            {
                return (false, "", login_result.errorMsg);
            }
            string apiResponse = await CallRackStatusAPI(login_result.cookie, EQPName, slot, CarrierID, "Add");
            return (true, apiResponse, "");
        }
        public static async Task<(bool confirm, string response, string errorMsg)> DeleteCSTID(string EQPName, int slot, string CarrierID)
        {
            Log($"Request to KGS AGVSYSTEM: Try Delete CSTID={CarrierID} of {EQPName} ");

            (bool success, UserAuthAPI.clsCookie cookie, string response, string errorMsg) login_result = await UserAuthAPI.LoginToAGVSWebSite();
            if (!login_result.success)
            {
                return (false, "", login_result.errorMsg);
            }

            string apiResponse = await CallRackStatusAPI(login_result.cookie, EQPName, slot, CarrierID, "Delete");
            return (true, apiResponse, "");
        }

        public static async Task<(bool confirm, string response, string errorMsg)> ModifyCSTID(string EQPName, int slot, string OldCarrierID, string CarrierID)
        {
            Log($"Request to KGS AGVSYSTEM: Try Modify CSTID From {OldCarrierID} To {CarrierID} of {EQPName} ");

            (bool success, UserAuthAPI.clsCookie cookie, string response, string errorMsg) login_result = await UserAuthAPI.LoginToAGVSWebSite();
            if (!login_result.success)
            {
                return (false, "", login_result.errorMsg);
            }

            string apiResponse = await CallRackStatusAPI(login_result.cookie, EQPName, slot, CarrierID, "Modify", OldCarrierID);
            return (true, apiResponse, "");
        }

        /// <summary>
        /// 建帳：http://10.22.133.24:6600/umtcstatus/modify?EQPName=Rack_1&Slot=1&OldCarrierID=&CarrierID=TA25E23371&Action=Add
        //  刪帳：http://10.22.133.24:6600/umtcstatus/modify?EQPName=Rack_1&Slot=1&OldCarrierID=&CarrierID=TA25E23371&Action=Delete
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>

        private static async Task<string> CallRackStatusAPI(UserAuthAPI.clsCookie cookie, string EQPName, int slot, string CarrierID, string action, string OldCarrierID = "")
        {
            var responseString = "";
            var baseAddress = new Uri($"http://{APIConfiguration.AGVSHostIP}:{APIConfiguration.AGVSHostPORT}");

            var cookieContainer = new CookieContainer();
            cookieContainer.Add(baseAddress, new Cookie("connect.sid", cookie.Cookies_Connect_SID));
            cookieContainer.Add(baseAddress, new Cookie("io", cookie.Cookies_io));

            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Accept.ParseAdd("*/*");
                client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate");
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                client.DefaultRequestHeaders.Referrer = new Uri($"{baseAddress.ToString()}/umtcstatus");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");

                var response = await client.GetAsync($"/umtcstatus/modify?EQPName={EQPName}&Slot={slot}&OldCarrierID={OldCarrierID}&CarrierID={CarrierID}&Action={action}");

                responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseString);
            }
            return responseString;
        }
        private static void Log(string msg)
        {
            Console.WriteLine(msg);
            if (Logger != null)
            {
                Logger.Info(msg);
            }
        }
    }
}
