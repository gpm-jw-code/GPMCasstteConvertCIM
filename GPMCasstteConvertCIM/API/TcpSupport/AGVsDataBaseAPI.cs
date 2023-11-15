using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.DataBase;
using GPMCasstteConvertCIM.Database;
using Newtonsoft.Json;

namespace GPMCasstteConvertCIM.API.TcpSupport
{
    internal class AGVsDataBaseAPI : SystemAPI
    {
        public override int Port { get; set; } = 6200;
        public override void ClientRecieveCB(IAsyncResult ar)
        {
            try
            {

                clsSocketState state = (clsSocketState)ar.AsyncState;
                int revLen = state.socket.EndReceive(ar);

                if (revLen > 0)
                {
                    string msg = Encoding.ASCII.GetString(state.buffer, 0, revLen);
                    if (msg.Contains("QueryTaskInfo:"))//QueryTaskInfo:MI1234123
                    {
                        string[] splited = msg.Split(':');
                        if (splited.Length < 2)
                        {
                            state.socket.Send(Encoding.ASCII.GetBytes($"error:TaskName is neccessary"));
                        }
                        string TaskName = splited[1];
                        ExecutingTask task_ = GetTaskInfoFromAGVSDataBase(TaskName, out var ermsg);
                        if (task_ != null)
                        {
                            state.socket.Send(Encoding.ASCII.GetBytes($"{JsonConvert.SerializeObject(task_, Formatting.Indented)}"));
                        }
                        else
                        {
                            state.socket.Send(Encoding.ASCII.GetBytes($"error:{ermsg}"));
                        }
                    }
                }

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        state.socket.BeginReceive(state.buffer, 0, 4096, SocketFlags.None, new AsyncCallback(ClientRecieveCB), state);
                    }
                    catch (Exception ex)
                    {
                        Utility.SystemLogger.Error(ex.Message, ex);
                    }
                });
            }
            catch (Exception ex)
            {
                //
            }
        }

        private ExecutingTask GetTaskInfoFromAGVSDataBase(string taskName, out string errorMsg)
        {
            errorMsg = string.Empty;
            try
            {
                var db = new AGVSDBHelper();
                var task = db.GetTaskByTaskName(taskName);
                return task;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                Utilities.Utility.SystemLogger.Error(ex.Message, ex);
                return null;
            }
        }
    }
}
