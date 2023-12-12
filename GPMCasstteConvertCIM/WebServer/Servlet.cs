using AGVSystemCommonNet6.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            byte[] buffer = Encoding.UTF8.GetBytes("OK");
            var id = request.QueryString["id"];
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
            //listener.Stop();
        }

        public override void onPost(HttpListenerRequest request, HttpListenerResponse response)
        {
            Log("POST:" + request.Url);
            byte[] res = Encoding.UTF8.GetBytes("OK");
            response.OutputStream.Write(res, 0, res.Length);
        }

        private void Log(string msg)
        {
            Console.WriteLine(msg);
            logger.Log(new LogItem(msg));
        }
    }
}
