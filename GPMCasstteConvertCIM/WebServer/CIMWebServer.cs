using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.WebServer
{
    internal class CIMWebServer
    {
        static HttpListener httpListenner;
        static string? _logFolder;
        internal static string _url = "";
        internal static bool Servering = false;
        internal static void StartService(string url = "http://localhost:9900", string logFolder = null)
        {
            try
            {
                _url = url;
                _logFolder = logFolder;
                httpListenner = new HttpListener();
                httpListenner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                httpListenner.Prefixes.Add($"{url}/");
                httpListenner.Start();

                new Thread(new ThreadStart(delegate
                {
                    try
                    {
                        loop(httpListenner);
                    }
                    catch (Exception)
                    {
                        httpListenner.Stop();
                    }
                })).Start();
                Servering = true;
            }
            catch (Exception ex)
            {
                Servering = false;
                AlarmManager.AddAlarm(ALARM_CODES.WebServer_Build_Fail, "SYSTEM", true);
            }

        }
        private static void loop(HttpListener httpListenner)
        {
            while (true)
            {
                HttpListenerContext context = httpListenner.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                Servlet servlet = new MyServlet(_logFolder);
                servlet.onCreate();
                if (request.HttpMethod == "POST")
                {
                    //servlet.onPost(request, response);
                }
                else if (request.HttpMethod == "GET")
                {
                    servlet.onGet(request, response);
                }
                response.Close();
            }
        }
    }
}
