﻿using AGVSystemCommonNet6.Log;
using CommunityToolkit.HighPerformance.Helpers;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.WebServer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.WebServer
{
    public class Servlet
    {
        public virtual async Task onGetAsync(System.Net.HttpListenerRequest request, System.Net.HttpListenerResponse response) { }
        public virtual async Task onPostAsync(System.Net.HttpListenerRequest request, System.Net.HttpListenerResponse response) { }

        public virtual void onCreate()
        {

        }
    }
    public class MyServlet : Servlet
    {
        private Utilities.LoggerBase logger;
        private string? logFolder;
        public delegate clsResponse EqIOModeChangeDelegate(string eqName, IO_MODE mode);
        public static EqIOModeChangeDelegate OnEqIOModeChangeRequest;

        public delegate clsResponse HotRunModeChangeDelegate(clsHotRunControl control);
        public static HotRunModeChangeDelegate OnHotRunModeChangeRequest;

        public delegate clsResponse PortLDULDStatusChangeDelegate(List<clsEQLDULDSimulationControl> control);
        public static PortLDULDStatusChangeDelegate OnPortLDULDStatusChangeRequest;

        public delegate clsResponse PorTypeChangeDelegate(int tagID, int portType);
        public static PorTypeChangeDelegate OnPortTypeChangeRequest;



        public MyServlet(string? logFolder)
        {
            this.logFolder = logFolder;
        }

        public override void onCreate()
        {
            logger = new Utilities.LoggerBase(null, logFolder, "");
            base.onCreate();
        }

        public override async Task onGetAsync(HttpListenerRequest request, HttpListenerResponse response)
        {
            Log("GET:" + request.Url);
            var _response = GetRequestRoute(request);
            if (_response == null)
            {
                return;
            }
            Log("GET:" + request.Url + $" [Response]:{_response.ToJson()}");
            byte[] buffer = Encoding.UTF8.GetBytes(_response.ToJson());
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public override async Task onPostAsync(HttpListenerRequest request, HttpListenerResponse response)
        {
            string lowerstring = request.RawUrl.ToLower();
            var jsonStr = GetBodyJson(request);
            Log("POST:" + request.Url + $"body:{jsonStr}");
            clsResponse result = new clsResponse(500, "Server Error");
            if (lowerstring.Contains("/api/sethotrun"))
            {
                clsHotRunControl? control = JsonConvert.DeserializeObject<clsHotRunControl>(jsonStr);
                if (OnHotRunModeChangeRequest != null)
                {
                    result = OnHotRunModeChangeRequest(control);
                }

            }
            if (lowerstring.Contains("/api/set_ports_lduld_status"))
            {
                List<clsEQLDULDSimulationControl>? controls = JsonConvert.DeserializeObject<List<clsEQLDULDSimulationControl>>(jsonStr);
                if (OnPortLDULDStatusChangeRequest != null)
                    result = OnPortLDULDStatusChangeRequest(controls);
            }
            if (lowerstring.Contains("/api/porttype_change"))
            {
                int tagID = int.Parse(request.QueryString.GetValues("eqTag").First());
                int portType = int.Parse(request.QueryString.GetValues("portType").First());
                if (OnPortTypeChangeRequest != null)
                    result = OnPortTypeChangeRequest(tagID, portType);
            }

            if (lowerstring.Contains("/api/s2f49/accept"))
            {
                result = new clsResponse(0, "");
            }
            if (lowerstring.Contains("/api/s2f49/reject"))
            {
                string resultCode = request.QueryString["resultCode"].ToString();
                result = new clsResponse(0, "");
            }

            var responseStr = JsonConvert.SerializeObject(result);
            byte[] res = Encoding.UTF8.GetBytes(responseStr);

            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
            response.OutputStream.Write(res, 0, res.Length);
        }

        private static string GetBodyJson(HttpListenerRequest request)
        {
            string json = "";
            using (Stream body = request.InputStream) // 获取请求体
            {
                using (StreamReader reader = new StreamReader(body))
                {
                    json = reader.ReadToEnd(); // 读取JSON内容
                }
            }
            return json;
        }

        private object GetRequestRoute(HttpListenerRequest request)
        {
            try
            {
                string lowerstring = request.RawUrl.ToLower();
                if (lowerstring is "/favicon.ico")
                    return null;
                if (lowerstring.Contains("/api/hotrunning"))
                {
                    return Utilities.Utility.IsHotRunMode;
                }
                if (lowerstring.Contains("/api/port_name_list"))
                {
                    return DevicesManager.GetAllPorts().Select(p => p.PortName).ToList();
                }
                if (lowerstring.Contains("/api/ports_io_mode"))
                {
                    return DevicesManager.GetAllPorts().ToDictionary(p => p.PortName, p => new clsEQLDULDSimulationControl
                    {
                        IOMode = p.IOSignalMode,
                        PortName = p.PortName,
                        Status = p.LDULD_Status_Simulation
                    });
                }
                if (lowerstring.Contains("/api/eq_io_mode"))
                {
                    var eqName = request.QueryString["eqname"];
                    var mode = request.QueryString["mode"];
                    IO_MODE _mode = mode == null ? IO_MODE.Unknown : mode.ToIOMODE();
                    if (eqName == null || mode == null)
                    {
                        return new clsResponse(4, "eqname and mode query option is required");
                    }
                    else
                    {
                        if (_mode == IO_MODE.Unknown)
                            return new clsResponse(4, $"mode only support 0({IO_MODE.FromIOModule}) or 1({IO_MODE.FromCIMSimulation})");
                        Log($"User request change mode of {eqName} to {_mode}({mode})");
                        if (OnEqIOModeChangeRequest != null)
                        {
                            return OnEqIOModeChangeRequest(eqName, _mode);
                        }
                        else
                            return new clsResponse(0);
                    }
                }


                return new clsResponse(0);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void Log(string msg)
        {
            Console.WriteLine(msg);
            logger.Log(msg);
        }
    }

    public class clsResponse
    {
        public int code { get; set; } = 0;
        public string message { get; set; } = "";
        public clsResponse(int return_code, string message = "")
        {
            code = return_code;
            this.message = message;
        }
    }
}
