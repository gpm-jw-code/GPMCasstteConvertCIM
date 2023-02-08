using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class clsMC_TCPCnt
    {
        public enum enuDataType
        {
            ASCIIStr_01 = 1,
            ByteArr_02 = 2
        }

        public enum enErrCode
        {
            NoErr_00 = 0,
            ComErr_10 = 10,
            MsgErr_20 = 20,
            SetErr_90 = 90,
            CodeErr_999 = 999
        }

        private TcpClient loTCPClinet;

        private string varClassName = "MC TCP Client Object";

        private string lstrRemoteIP = "127.0.0.1";

        private int lintRemotePort = 5000;

        private int lintConTimeout = 500;

        private int lintMsgTimeout = 1000;

        private bool lbolIsConnected;

        public enuDataType lenuMsgDataType = enuDataType.ASCIIStr_01;

        public void InitialSet(string RemoteIP, int RemotePort, int ConnectTimeout, int MsgTimeout, enuDataType SetDataType)
        {
            try
            {
                lstrRemoteIP = RemoteIP;
                lintRemotePort = RemotePort;
                lenuMsgDataType = SetDataType;
                lintConTimeout = ConnectTimeout;
                lintMsgTimeout = MsgTimeout;
            }
            catch (Exception ex)
            {
                throw new Exception(varClassName + " [InitialSet]  " + ex.Message);
            }
        }

        public async Task<bool> ConnectOut()
        {
            try
            {
                loTCPClinet = null;
                bool flag = false;
                loTCPClinet = new TcpClient();
                //CancellationTokenSource cts = new CancellationTokenSource(5000);
                //await loTCPClinet.ConnectAsync(lstrRemoteIP, lintRemotePort, cts.Token);
                await loTCPClinet.ConnectAsync(lstrRemoteIP, lintRemotePort);

                lbolIsConnected = true;
                //IAsyncResult asyncResult = loTCPClinet.BeginConnect(lstrRemoteIP, lintRemotePort, null, null);


                //WaitHandle asyncWaitHandle = asyncResult.AsyncWaitHandle;
                //try
                //{
                //    if (!asyncResult.AsyncWaitHandle.WaitOne(lintConTimeout, exitContext: false))
                //    {
                //        flag = true;
                //        Close();
                //    }
                //    loTCPClinet?.EndConnect(asyncResult);
                //}
                //finally
                //{
                //    asyncWaitHandle.Close();
                //}
                //if (!flag)
                //{
                //    lbolIsConnected = true;
                //}
                //else
                //{
                //    lbolIsConnected = false;
                //    loTCPClinet.Dispose();
                //}
                return lbolIsConnected;
            }
            catch (Exception exp)
            {
                lbolIsConnected = false;
                return false;
            }
        }
        public int pindex = 0;
        /// <summary>
        /// Bind 本地指定網卡
        /// </summary>
        /// <returns></returns>g
        public bool ConnectOut(string strLocalIP)
        {
            try
            {
                pindex++;
                loTCPClinet = null;
                bool flag = false;
                IPAddress localIPAddress = IPAddress.Parse(strLocalIP);
                IPEndPoint LocalEndPoint = new IPEndPoint(localIPAddress, 6001 + pindex);
                loTCPClinet = new TcpClient();
                //Bind網卡 by IP
                loTCPClinet.Client.Bind(LocalEndPoint);
                IAsyncResult asyncResult = loTCPClinet.BeginConnect(lstrRemoteIP, lintRemotePort, null, null);
                WaitHandle asyncWaitHandle = asyncResult.AsyncWaitHandle;
                try
                {
                    if (!asyncResult.AsyncWaitHandle.WaitOne(lintConTimeout, exitContext: false))
                    {
                        flag = true;
                        Close();
                    }
                    loTCPClinet.EndConnect(asyncResult);
                }
                finally
                {
                    asyncWaitHandle.Close();
                }
                if (!flag)
                {
                    lbolIsConnected = true;
                }
                else
                {
                    lbolIsConnected = false;
                }
                return lbolIsConnected;
            }
            catch (Exception exp)
            {
                lbolIsConnected = false;
                return false;
            }
        }

        public bool Close()
        {
            try
            {
                try
                {
                    loTCPClinet.Client.Shutdown(SocketShutdown.Both);
                }
                catch (Exception exp)
                {
                }
                try
                {
                    loTCPClinet.Client.Close();
                }
                catch (Exception exp)
                {

                }
                lbolIsConnected = false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void SendDataOut(byte[] cmd)
        {
            try
            {
                if (lbolIsConnected)
                {
                    Stream stream = loTCPClinet.GetStream();
                    if (stream != null)
                    {
                        stream.WriteTimeout = lintMsgTimeout;
                        stream.Write(cmd, 0, cmd.Length);
                    }
                    else
                    {
                        lbolIsConnected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(varClassName + " [SendDataOut]  " + ex.Message);
            }
        }
        public void SendDataOut(string strBuf)
        {
            if (lenuMsgDataType == enuDataType.ByteArr_02)
            {
                try
                {
                    string[] strNewBuf = new string[strBuf.Length / 2];
                    byte[] bytes = new byte[strNewBuf.Length];
                    for (int i = 0; i < strNewBuf.Length; i++)
                    {
                        strNewBuf[i] = strBuf.Substring(i * 2, 2).Trim();
                        bytes[i] = Convert.ToByte(strNewBuf[i], 16);
                    }
                    Stream stream = loTCPClinet.GetStream();
                    if (stream != null)
                    {
                        stream.WriteTimeout = lintMsgTimeout;
                        stream.Write(bytes, 0, bytes.Length);
                    }
                    else
                    {
                        lbolIsConnected = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(varClassName + " [SendDataOut]  " + ex.Message);
                }

            }
            else if (lenuMsgDataType == enuDataType.ASCIIStr_01)
            {
                try
                {
                    if (lbolIsConnected)
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(strBuf);
                        Stream stream = loTCPClinet.GetStream();
                        if (stream != null)
                        {
                            stream.WriteTimeout = lintMsgTimeout;
                            stream.Write(bytes, 0, bytes.Length);
                        }
                        else
                        {
                            lbolIsConnected = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(varClassName + " [SendDataOut]  " + ex.Message);
                }
            }
        }

        public void ReceiveData(ref string strResult)
        {
            try
            {
                RecvTCPSocketData(ref strResult);
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception($"{varClassName} [ReceiveData]  {ex.Message}, debug??建議確認PLC數據格式");
            }
        }
        class SocketState
        {
            public enuDataType lenuMsgDataType = enuDataType.ASCIIStr_01;
            public byte[] buffer = new byte[65535];
            public NetworkStream stream;
            public ManualResetEvent pauseEvent = new ManualResetEvent(false);
            public int receievedDataNum = 0;
            public string revText
            {
                get
                {
                    string text = string.Empty;
                    if (lenuMsgDataType == enuDataType.ASCIIStr_01)
                    {
                        text = Encoding.Default.GetString(buffer, 0, receievedDataNum);
                    }
                    else if (lenuMsgDataType == enuDataType.ByteArr_02)
                    {

                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < receievedDataNum; i++)
                        {
                            sb.Append(((int)buffer[i]).ToString("X2"));
                        }

                        text = sb.ToString();
                    }
                    return text;
                }
            }
        }
        private void RecvTCPSocketData(ref string strResult)
        {
            try
            {

                NetworkStream _stream = loTCPClinet.GetStream();
                SocketState _state = new SocketState()
                {
                    stream = _stream,
                    lenuMsgDataType = lenuMsgDataType
                };
                _stream.BeginRead(_state.buffer, 0, 65535, new AsyncCallback(ReadCallBack), _state);
                _state.pauseEvent.WaitOne();

                strResult = _state.revText;

            }
            catch (Exception ex)
            {
                throw new Exception(varClassName + " [RecvTCPSocketData]  " + ex.Message);
            }
        }

        private void ReadCallBack(IAsyncResult ar)
        {
            SocketState _state = (SocketState)ar.AsyncState;
            try
            {
                int revLen = _state.stream.EndRead(ar);
                _state.receievedDataNum += revLen;

                if (_state.revText.ToUpper().Contains("D00000FFFF0300"))
                    _state.pauseEvent.Set();
                else
                    _state.stream.BeginRead(_state.buffer, revLen, 1024, new AsyncCallback(ReadCallBack), _state);
            }
            catch (Exception ex)
            {
                _state.pauseEvent.Set();

            }
        }

        public bool ClearBuf()
        {
            try
            {
                string empty = string.Empty;
                bool flag = false;
                if (lbolIsConnected)
                {
                    if (loTCPClinet != null)
                    {
                        byte[] array = new byte[loTCPClinet.ReceiveBufferSize];
                        NetworkStream stream = loTCPClinet.GetStream();
                        if (stream != null)
                        {
                            if (stream.CanRead && stream.DataAvailable)
                            {
                                stream.ReadTimeout = lintMsgTimeout;
                                int count = stream.Read(array, 0, loTCPClinet.ReceiveBufferSize);
                                Encoding.Default.GetString(array, 0, count);
                            }
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                }
                else if (!ConnectRetry())
                {
                    flag = true;
                }
                if (!flag)
                {
                    return true;
                }
                return false;
            }

            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                if (ex.Source == "System.Net.Sockets")
                {
                    throw new SocketException();
                }
                else
                    throw new Exception(varClassName + " [ClearBuf]  " + ex.Message);
            }
        }

        public int ConnectMonitor()
        {
            try
            {
                if (loTCPClinet.Connected)
                {
                    return 0;
                }
                lbolIsConnected = false;
                return 10;
            }
            catch (Exception)
            {
                return 999;
            }
        }

        public bool ConnectRetry()
        {
            try
            {
                Close();
                Thread.Sleep(100);
                bool result;
                if (ConnectOut().Result)
                {
                    result = true;
                    Thread.Sleep(10);
                    ClearBuf();
                }
                else
                {
                    result = false;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
