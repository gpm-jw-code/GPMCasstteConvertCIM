using AGVSystemCommonNet6.Log;
using CommunityToolkit.HighPerformance.Helpers;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using Newtonsoft.Json;
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
        public virtual void onGet(System.Net.HttpListenerRequest request, System.Net.HttpListenerResponse response) { }
        public virtual void onPost(System.Net.HttpListenerRequest request, System.Net.HttpListenerResponse response) { }

        public virtual void onCreate()
        {

        }
    }
    public class MyServlet : Servlet
    {
        private LogBase logger;
        private string? logFolder;
        public delegate clsResponse EqIOModeChangeDelegate(string eqName, IO_MODE mode);
        public static EqIOModeChangeDelegate OnEqIOModeChangeRequest;
        public MyServlet(string? logFolder)
        {
            this.logFolder = logFolder;
        }

        public override void onCreate()
        {
            logger = new LogBase(logFolder);
            base.onCreate();
        }

        public override void onGet(HttpListenerRequest request, HttpListenerResponse response)
        {
            Log("GET:" + request.Url);
            var _response = GetRequestRoute(request);
            byte[] buffer = Encoding.UTF8.GetBytes(_response.ToJson());
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public override void onPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            Log("POST:" + request.Url);
            byte[] res = Encoding.UTF8.GetBytes("OK");
            response.OutputStream.Write(res, 0, res.Length);
        }
        private object GetRequestRoute(HttpListenerRequest request)
        {
            try
            {
                string lowerstring = request.RawUrl.ToLower();
                if (lowerstring is "/favicon.ico")
                    return new clsResponse(0);
                if (lowerstring.Contains("/api/port_name_list"))
                {
                    return DevicesManager.GetAllPorts().Select(p => p.PortName).ToList();
                }
                if (lowerstring.Contains("/api/ports_io_mode"))
                {
                    return DevicesManager.GetAllPorts().ToDictionary(p => p.PortName, p => p.IOSignalMode);
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
            logger.Log(new LogItem(msg));
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
