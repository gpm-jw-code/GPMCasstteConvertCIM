﻿using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.Utilities;
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
        private static bool _Servering = false;
        internal static bool Servering
        {
            get => _Servering;
            set
            {
                if (_Servering != value)
                {
                    _Servering = value;
                    if (_Servering)
                    {

                        Utility.SystemLogger.Info($"Web Server Serving.({_url})");
                    }
                    else
                    {

                        Utility.SystemLogger.Error($"Web Server end serve...({_url})");
                    }
                }
            }
        }
        internal static bool _simulateExceptionHappend = false;
        internal static void StartService(string url = "http://localhost:9900", string logFolder = null)
        {
            try
            {
                _url = url;
                _logFolder = logFolder;
                httpListenner = new HttpListener();
                httpListenner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                httpListenner.Prefixes.Add($"{url}/");
                httpListenner.IgnoreWriteExceptions = true;
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

        private static void RestartServerProcess()
        {
            Utility.SystemLogger.Warning("Web Server Restarting...");
            httpListenner?.Stop();
            StartService(_url, _logFolder);
        }
        private static void loop(HttpListener httpListenner)
        {
            while (true)
            {
                Thread.Sleep(1);
                try
                {
                    HttpListenerContext context = httpListenner.GetContext();
                    if (_simulateExceptionHappend)
                    {
                        _simulateExceptionHappend = false;
                        throw new Exception("Test exception happen");
                    }
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    Servlet servlet = new MyServlet(_logFolder);
                    servlet.onCreate();
                    if (request.HttpMethod == "POST")
                    {
                        servlet.onPost(request, response);
                    }
                    else if (request.HttpMethod == "GET")
                    {
                        servlet.onGet(request, response);
                    }
                    response.Close();
                }
                catch (Exception ex)
                {
                    AlarmManager.AddAlarm(ALARM_CODES.WebServer_Exception_Happend_When_Handling_Request, "SYSTEM", true);
                    break;
                }
            }
            Servering = false;
            Task.Run(async () =>
            {
                await Task.Delay(3000);
                RestartServerProcess();
            });
        }

    }
}
