using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.KGAGVS
{
    public class UserAuthAPI
    {
        public static async Task<(bool success, clsCookie cookie, string response, string errorMsg)> LoginToAGVSWebSite()
        {
            try
            {

                clsCookie cookie = new clsCookie();
                cookie.Cookies_Connect_SID = await GetwebsiteSID(CancellationToken.None);
                cookie.Cookies_io = $"2BPc0hLL{DateTime.Now.ToString("yyMMddHHmmss")}";
                var response = await Login(cookie.Cookies_Connect_SID, cookie.Cookies_io);
                return (true, cookie, response, "");
            }
            catch (Exception ex)
            {
                return (false, new clsCookie(), "", ex.Message);
            }
        }


        private static async Task<string> Login(string sid, string io)
        {
            var baseAddress = new Uri($"http://{APIConfiguration.AGVSHostIP}:{APIConfiguration.AGVSHostPORT}");
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(baseAddress, new Cookie("connect.sid", sid));
            cookieContainer.Add(baseAddress, new Cookie("io", io));
            var responseString = "";
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json, text/javascript, */*; q=0.01");
                client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate");
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                client.DefaultRequestHeaders.Referrer = new Uri($"{baseAddress.ToString()}/login");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("Origin", baseAddress.ToString());

                var content = new StringContent("[{\"name\":\"UserName\",\"value\":\"paul\"},{\"name\":\"Password\",\"value\":\"1\"}]", System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/user/login", content);

                responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseString);
            }
            return responseString;
        }

        public class clsCookie
        {
            public string Cookies_Connect_SID = "s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18uI";
            public string Cookies_io = "TPrw6Q8Aol3EBu1YAAAP";

        }
        public static async Task<string> GetwebsiteSID(CancellationToken cancelToken)
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = await client.GetAsync($"http://{APIConfiguration.AGVSHostIP}:{APIConfiguration.AGVSHostPORT}/Index", cancelToken);
                var cookieHeader = response.Headers.GetValues("Set-Cookie");
                //connect.sid=s%3AKGQ-tYUAMeZVvwaq8TL5JbCB5bO5j_9q.8kdLcGJz%2FqrKdpv3wzEL%2B4m%2BgY9aZ7OiRDuT5yqDi6w; Path=/; Expires=Tue, 18 Jul 2023 05:28:04 GMT; HttpOnly
                return cookieHeader.First().Split('=')[1].Split(';')[0];
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
