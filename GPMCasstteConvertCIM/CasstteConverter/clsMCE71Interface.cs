using CIMComponent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public class clsMCE71Interface
    {
        public enum enErrCode
        {
            NoErr_00 = 0,
            ComErr_10 = 10,
            MsgErr_20 = 20,
            SetErr_90 = 90,
            CodeErr_999 = 999
        }

        public clsMC_TCPCnt loMCTcpCtrl;

        private clsFormatTool oFormat = new clsFormatTool();

        private MemoryTable cls_STable;

        private MemoryTable cls_RTable;

        private string strClassName = "clsMC_EthIF";

        private string lstrRemoteIP;

        private int lintRemotePort;

        private int lintMCComErrCode;

        private bool lbolIsOneBitType;

        public clsMCE71Interface()
        {
            SetDefault();
        }

        private void SetDefault()
        {
            try
            {
                lstrRemoteIP = "1.1.1.1";
                lintRemotePort = 5001;
            }
            catch (Exception ex)
            {
                throw new Exception(strClassName + " [SetDefault]  " + ex.Message);
            }
        }

        public int Open(string RemoteIP, int RemotePort, int ConnTimeout, int MsgTimeout, clsMC_TCPCnt.enuDataType enuDataType)
        {
            try
            {
                lstrRemoteIP = RemoteIP;
                lintRemotePort = RemotePort;
                loMCTcpCtrl = new clsMC_TCPCnt();
                loMCTcpCtrl.InitialSet(lstrRemoteIP, lintRemotePort, ConnTimeout, MsgTimeout, enuDataType);
                if (loMCTcpCtrl.ConnectOut().Result)
                {
                    return 0;
                }
                return 10;
            }
            catch (Exception)
            {
                return 999;
            }
        }

        /// <summary>
        /// 可綁定網卡之Open方法
        /// </summary>
        /// <param name="LocalIP">指定的網卡Local IP</param>
        /// <param name="RemoteIP"></param>
        /// <param name="RemotePort"></param>
        /// <param name="ConnTimeout"></param>
        /// <param name="MsgTimeout"></param>
        /// <returns></returns>
        public int Open(string LocalIP, string RemoteIP, int RemotePort, int ConnTimeout, int MsgTimeout, clsMC_TCPCnt.enuDataType enuDataType)
        {
            try
            {
                lstrRemoteIP = RemoteIP;
                lintRemotePort = RemotePort;
                loMCTcpCtrl = new clsMC_TCPCnt();
                loMCTcpCtrl.InitialSet(lstrRemoteIP, lintRemotePort, ConnTimeout, MsgTimeout, enuDataType);
                if (loMCTcpCtrl.ConnectOut(LocalIP))
                {
                    return 0;
                }
                return 10;
            }
            catch (Exception)
            {
                return 999;
            }
        }
        public int Open(string RemoteIP, int RemotePort, int ConnTimeout, int MsgTimeout, bool IsOneBitType, clsMC_TCPCnt.enuDataType enuDataType)
        {
            try
            {
                lstrRemoteIP = RemoteIP;
                lintRemotePort = RemotePort;
                lbolIsOneBitType = IsOneBitType;
                loMCTcpCtrl = new clsMC_TCPCnt();
                loMCTcpCtrl.InitialSet(lstrRemoteIP, lintRemotePort, ConnTimeout, MsgTimeout, enuDataType);
                if (loMCTcpCtrl.ConnectOut().Result)
                {
                    return 0;
                }
                return 10;
            }
            catch (Exception)
            {
                return 999;
            }
        }


        public int Close()
        {
            try
            {
                if (loMCTcpCtrl != null)
                {
                    if (loMCTcpCtrl.Close())
                    {
                        return 0;
                    }
                    return 10;
                }
                return 0;
            }
            catch (Exception)
            {
                return 999;
            }
        }

        /// <summary>
        /// 3E Method
        /// </summary>
        /// <param name="lHeadName"></param>
        /// <param name="lStartAddress"></param>
        /// <param name="Value"></param>
        /// <param name="bWriteFlag"></param>
        /// <param name="dSize"></param>
        /// <param name="IsBitType"></param>
        public void HwdSend(string lHeadName, string lStartAddress, string Value, bool bWriteFlag, int dSize, bool IsBitType)
        {
            try
            {
                if (lHeadName.Trim().Length == 0)
                {
                    throw new Exception(strClassName + " [HwdSend]  Set the Start Memory HeadName Error(" + lHeadName + ")");
                }

                if (lStartAddress.Trim().Length > 6)
                {
                    throw new Exception(strClassName + " [HwdSend]  Set the Start Memory StartAddress Error(" + lStartAddress + ")");
                }
                if (lStartAddress.Trim().Length < 6)
                {
                    lStartAddress = lStartAddress.Trim();
                    int length = lStartAddress.Length;
                    for (int i = length; i < 6; i++)
                    {
                        lStartAddress = "0" + lStartAddress;
                    }
                }
                if (loMCTcpCtrl.lenuMsgDataType == clsMC_TCPCnt.enuDataType.ByteArr_02)
                {
                    List<byte> cmdList = new List<byte>();
                    if (bWriteFlag)
                        cmdList = GenWriteDataBinaryCmdData(lHeadName, lStartAddress, Value, IsBitType);
                    else
                        cmdList = GenReadDataBinaryCmdData(lHeadName, lStartAddress, dSize, IsBitType);
                    loMCTcpCtrl.SendDataOut(cmdList.ToArray());
                }
                else if (loMCTcpCtrl.lenuMsgDataType == clsMC_TCPCnt.enuDataType.ASCIIStr_01)
                {
                    string str = String.Empty;
                    if (lHeadName.Trim().Length == 1)
                    {
                        lHeadName = lHeadName.Trim();
                        lHeadName += "*";
                    }
                    str = (IsBitType && lbolIsOneBitType) ? ((!bWriteFlag) ? "500000FF03FF00LLLL000104010001" : "500000FF03FF00LLLL000114010001") : ((!bWriteFlag) ? "500000FF03FF00LLLL000104010000" : "500000FF03FF00LLLL000114010000");
                    str = str + lHeadName + lStartAddress;
                    str += dSize.ToString("X4");
                    str += Value;
                    int num = str.Length - 18;
                    str = str.Remove(14, 4);
                    str = str.Insert(14, num.ToString("X4"));
                    loMCTcpCtrl.SendDataOut(str);
                }
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {
                throw new Exception(strClassName + " [HwdSend]  " + ex.Message);
            }
        }

        public List<byte> GenWriteDataBinaryCmdData(string region, string address, string data, bool IsWriteBit)
        {
            //起始Address 
            var _region = region.Replace("*", "").ToUpper();
            bool IsHexNumber = _region == "X" | _region == "Y" | _region == "B" | _region == "W";
            int intStartAddress = int.Parse(address, IsHexNumber ? System.Globalization.NumberStyles.HexNumber : System.Globalization.NumberStyles.Number);
            byte[] bytesStartAddress = BitConverter.GetBytes(intStartAddress);

            List<byte> dataBytesList = new List<byte>();
            for (int i = 0; i < data.Length; i += 4)
            {

                var bytes = BitConverter.GetBytes(int.Parse(data.Substring(i, 4), System.Globalization.NumberStyles.HexNumber));
                dataBytesList.Add(bytes[0]);
                dataBytesList.Add(bytes[1]);
            }

            var deviceNumBytes = BitConverter.GetBytes(dataBytesList.Count / 2);

            List<byte> cmdList = new List<byte>() {
                0x50,
                0x00,
                0x00,
                0xFF,
                0xFF,
                0x03,
                0x00,
                0x0E,//長度
                0x00,//長度
                0x10,//監視定時器
                0x00,//監視定時器
                0x01,//指令
                0x14,//指令
                0x00,//子指令
                0x00,//子指令
                bytesStartAddress[0],
                bytesStartAddress[1],
                bytesStartAddress[2],
                GetDeviceCodeByte(region),
                deviceNumBytes[0],
                deviceNumBytes[1],

            };

            cmdList.AddRange(dataBytesList);

            var dataLen = cmdList.Count - 9;
            byte[] dataLenBytes = BitConverter.GetBytes(dataLen);

            cmdList[7] = dataLenBytes[0];
            cmdList[8] = dataLenBytes[1];
            return cmdList;
        }


        public List<byte> GenReadDataBinaryCmdData(string region, string address, int number, bool IsBitFlag)
        {
            //起始Address 
            var _region = region.Replace("*", "").ToUpper();
            bool IsHexNumber = _region == "X" | _region == "Y" | _region == "B" | _region == "W";
            int intStartAddress = int.Parse(address, IsHexNumber ? System.Globalization.NumberStyles.HexNumber : System.Globalization.NumberStyles.Number);
            byte[] bytesStartAddress = BitConverter.GetBytes(intStartAddress);

            var deviceNumBytes = BitConverter.GetBytes(number);

            List<byte> cmdList = new List<byte>() {
                0x50,
                0x00,
                0x00,
                0xFF,
                0xFF,
                0x03,
                0x00,
                0x0E,//長度
                0x00,//長度
                0x10,//監視定時器
                0x00,//監視定時器
                0x01,//指令
                0x04,//指令
                0x00,//子指令
                0x00,//子指令
                bytesStartAddress[0],
                bytesStartAddress[1],
                bytesStartAddress[2],
                GetDeviceCodeByte(region),
                deviceNumBytes[0],
                deviceNumBytes[1],

            };
            var dataLen = cmdList.Count - 9;
            byte[] dataLenBytes = BitConverter.GetBytes(dataLen);

            cmdList[7] = dataLenBytes[0];
            cmdList[8] = dataLenBytes[1];
            return cmdList;
        }
        private byte GetDeviceCodeByte(string lHeadName)
        {
            switch (lHeadName.ToUpper())
            {
                case "X":
                    return 0x9C;
                case "Y":
                    return 0x9D;
                case "M":
                    return 0x90;
                case "L":
                    return 0x92;
                case "F":
                    return 0x93;
                case "V":
                    return 0x94;
                case "B":
                    return 0xA0;
                case "D":
                    return 0xA8;
                case "W":
                    return 0xB4;
                default:
                    return 0x00;
            }
        }
        private void HwdRecive(ref string strResultData)
        {
            try
            {
                loMCTcpCtrl.ReceiveData(ref strResultData);
            }
            catch (SocketException ex)
            {

            }
            catch (Exception ex)
            {
                throw new Exception(strClassName + " [HwdRecive]  " + ex.Message);
            }
        }

        private bool HwdClearBuf()
        {
            try
            {
                if (loMCTcpCtrl != null)
                {
                    if (loMCTcpCtrl.ClearBuf())
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(strClassName + " [HwdClearBuf]  " + ex.Message);
            }
        }

        public int MCErrMonitor()
        {
            try
            {
                if (lintMCComErrCode != 0)
                {
                    return lintMCComErrCode;
                }
                return loMCTcpCtrl.ConnectMonitor();
            }
            catch (Exception)
            {
                return 999;
            }
        }

        public int WriteWord(ref MemoryTable PC_STable, string lWordName, string lStartWordAddress, int lMemorySize)
        {
            try
            {
                int[] lValue = null;
                int num = 0;
                string strResultData = null;
                cls_STable = PC_STable;
                enErrCode enErrCode;
                if (HwdClearBuf())
                {
                    string text = "";
                    string lMemoryName = (!(lWordName.Trim() == "ZR")) ? (lWordName + lStartWordAddress) : (lWordName + lStartWordAddress);
                    cls_STable.ReadWord(lMemoryName, lMemorySize, ref lValue);
                    for (int i = 0; i < lValue.Length; i++)
                    {
                        text += lValue[i].ToString("X4");
                    }
                    if (lWordName.Trim() == "ZR")
                    {
                        string lStartAddress = Convert.ToInt16(lStartWordAddress, 10).ToString("X6");
                        HwdSend(lWordName, lStartAddress, text, true, lMemorySize, false);
                    }
                    else
                    {
                        HwdSend(lWordName, lStartWordAddress, text, true, lMemorySize, false);
                    }
                    HwdRecive(ref strResultData);
                    if (strResultData != null)
                    {
                        string a = strResultData.Substring(0, 4);
                        if (a == "D000")
                        {
                            string text2 = strResultData.Substring(18, 4);
                            if (text2 == "0000")
                            {
                                enErrCode = enErrCode.NoErr_00;
                            }
                            else
                            {
                                num = Convert.ToUInt16(text2, 16);
                                enErrCode = enErrCode.MsgErr_20;
                            }
                        }
                        else
                        {
                            enErrCode = enErrCode.MsgErr_20;
                        }
                    }
                    else
                    {
                        enErrCode = enErrCode.MsgErr_20;
                    }
                }
                else
                {
                    enErrCode = enErrCode.ComErr_10;
                }
                lintMCComErrCode = (int)enErrCode;
                if (enErrCode == enErrCode.MsgErr_20 && num != 0)
                {
                    return num;
                }
                return (int)enErrCode;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                lintMCComErrCode = 999;
                throw new Exception(strClassName + " [WriteWord]  " + ex.Message);
            }
        }

        public int ReadWord(ref MemoryTable PC_RTable, string lWordName, string lStartWordAddress, int lMemorySize)
        {
            try
            {
                int[] lValue = new int[lMemorySize];
                int num = 0;
                string strResultData = null;
                cls_RTable = PC_RTable;
                enErrCode enErrCode;
                if (HwdClearBuf())
                {
                    string lMemoryName = lWordName + lStartWordAddress;
                    string value = "";
                    if (lWordName.Trim() == "ZR")
                    {
                        string lStartAddress = Convert.ToInt16(lStartWordAddress, 10).ToString("X6");
                        HwdSend(lWordName, lStartAddress, value, false, lMemorySize, false);
                    }
                    else
                    {
                        HwdSend(lWordName, lStartWordAddress, value, false, lMemorySize, false);
                    }
                    HwdRecive(ref strResultData);
                    if (strResultData != null)
                    {
                        //             D0 00          00        FF         FF 03             00            0400            00 00      
                        // (3EFrameresponse-2bytes)(NerNo-1)(PCNo-1)(Req.Dest.I/ONo.-2)(Req.Stat.No.-1)(Req.DataLength-2)(EndCode-2)<== 11 bytes
                        // 00 00 00 00 00 00 00
                        // 

                        string a = strResultData.Substring(0, 4);
                        if (a == "D000")
                        {
                            string text = strResultData.Substring(18, 4);
                            if (text == "0000")
                            {
                                enErrCode = enErrCode.NoErr_00;
                            }
                            else
                            {
                                num = Convert.ToUInt16(text, 16);
                                enErrCode = enErrCode.MsgErr_20;
                            }
                        }
                        else
                        {
                            enErrCode = enErrCode.MsgErr_20;
                        }
                    }
                    else
                    {
                        enErrCode = enErrCode.ComErr_10;
                    }
                    if (num == 0)
                    {
                        if (loMCTcpCtrl.lenuMsgDataType == clsMC_TCPCnt.enuDataType.ASCIIStr_01)
                        {
                            string text2 = strResultData.Substring(22, lMemorySize * 4);
                            for (int i = 0; i < lMemorySize; i++)
                            {
                                string value2 = text2.Substring(i * 4, 4);
                                lValue[i] = Convert.ToUInt16(value2, 16);
                            }
                        }
                        else if (loMCTcpCtrl.lenuMsgDataType == clsMC_TCPCnt.enuDataType.ByteArr_02)
                        {
                            string text2 = strResultData.Substring(22, lMemorySize * 4);
                            for (int i = 0; i < lMemorySize; i++)
                            {
                                string value2 = text2.Substring(i * 4, 4);
                                string value3 = value2.Substring(2, 2) + value2.Substring(0, 2);
                                lValue[i] = Int32.Parse(value3, System.Globalization.NumberStyles.HexNumber);
                            }
                        }
                        cls_RTable.WriteWord(lMemoryName, ref lValue);
                    }
                }
                else
                {
                    enErrCode = enErrCode.ComErr_10;
                }
                lintMCComErrCode = (int)enErrCode;
                if (enErrCode == enErrCode.MsgErr_20 && num != 0)
                {
                    return num;
                }
                return (int)enErrCode;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                lintMCComErrCode = 999;
                throw new Exception(strClassName + " [ReadWord]  " + ex.Message);
            }
        }

        public int ReadBit(ref MemoryTable PC_RTable, string lBitName, string lStartBitAddress, int lMemorySize)
        {
            try
            {
                bool[] lValue = new bool[lMemorySize];
                int num = 0;
                string text = null;
                int num2 = 0;
                string strResultData = null;
                if (!lbolIsOneBitType)
                {
                    if (lMemorySize % 16 != 0)
                    {
                        throw new ArgumentOutOfRangeException("1", "Bit Memory Size must be 16 times");
                    }
                    num = lMemorySize / 16;
                }
                cls_RTable = PC_RTable;
                string value = "";
                enErrCode enErrCode;
                if (HwdClearBuf())
                {
                    if (!lbolIsOneBitType)
                    {
                        HwdSend(lBitName, lStartBitAddress, value, false, num, true);
                    }
                    else
                    {
                        HwdSend(lBitName, lStartBitAddress, value, false, lMemorySize, true);
                    }
                    HwdRecive(ref strResultData);
                    if (strResultData != null)
                    {
                        string a = strResultData.Substring(0, 4);
                        if (a == "D000")
                        {
                            string text2 = strResultData.Substring(18, 4);
                            if (text2 == "0000")
                            {
                                enErrCode = enErrCode.NoErr_00;
                            }
                            else
                            {
                                num2 = Convert.ToUInt16(text2, 16);
                                enErrCode = enErrCode.MsgErr_20;
                            }
                        }
                        else
                        {
                            enErrCode = enErrCode.MsgErr_20;
                        }
                    }
                    else
                    {
                        enErrCode = enErrCode.MsgErr_20;
                    }
                    if (num2 == 0)
                    {
                        if (!lbolIsOneBitType)
                        {

                            if (loMCTcpCtrl.lenuMsgDataType == clsMC_TCPCnt.enuDataType.ByteArr_02)
                            {

                                string lenb1 = strResultData.Substring(16, 2);
                                string lenb2 = strResultData.Substring(14, 2);

                                int len = int.Parse(lenb1 + lenb2, System.Globalization.NumberStyles.HexNumber);
                                string dataText = strResultData.Substring(18, len * 2);

                                string hexData = "";
                                List<bool> bitList = new List<bool>();
                                for (int i = 4; i < dataText.Length; i += 4)
                                {
                                    var hex = dataText.Substring(i + 2, 2) + dataText.Substring(i, 2);
                                    hexData += hex;
                                    var _int16 = Int16.Parse(hex, NumberStyles.HexNumber);
                                    var bitArray = new BitArray(BitConverter.GetBytes(_int16));
                                    bitList.AddRange(bitArray.Cast<bool>());
                                }

                                lValue = bitList.ToArray();
                            }
                            else
                            {

                                int[] array = new int[num];
                                string text3 = strResultData.Substring(18, num * 4);
                                for (int i = 0; i < num; i++)
                                {
                                    string value2 = text3.Substring(i * 4, 4);
                                    array[i] = Convert.ToUInt16(value2, 16);
                                }
                                for (int j = 0; j < array.Length; j++)
                                {
                                    text = oFormat.Get_Dec2BinString(array[j], 16) + text;
                                }
                                for (int k = 0; k < text.Length; k++)
                                {
                                    string a2 = text.Substring(text.Length - k - 1, 1);
                                    if (a2 == "1")
                                    {
                                        lValue[k] = true;
                                    }
                                    else
                                    {
                                        lValue[k] = false;
                                    }
                                }
                            }

                        }
                        else
                        {
                            string text3 = strResultData.Substring(22, lMemorySize);
                            for (int l = 0; l < lMemorySize; l++)
                            {
                                string a2 = text3.Substring(l, 1);
                                if (a2.Trim() == "1")
                                {
                                    lValue[l] = true;
                                }
                                else
                                {
                                    lValue[l] = false;
                                }
                            }
                        }
                        cls_RTable.WriteBit(lBitName + lStartBitAddress, ref lValue);
                    }
                }
                else
                {
                    enErrCode = enErrCode.ComErr_10;
                }
                lintMCComErrCode = (int)enErrCode;
                if (enErrCode == enErrCode.MsgErr_20 && num2 != 0)
                {
                    return num2;
                }
                return (int)enErrCode;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                lintMCComErrCode = 999;
                throw new Exception(strClassName + " [ReadBit]  " + ex.Message + "|_|_|_|" + ex.StackTrace);
            }
        }

        public int WriteBit(ref MemoryTable PC_STable, string lBitName, string lStartBitAddress, int lMemorySize)
        {
            try
            {
                bool[] lValue = new bool[lMemorySize];
                int num = 0;
                string strResultData = null;
                int num2 = 0;
                if (!lbolIsOneBitType)
                {
                    if (lMemorySize % 16 != 0)
                    {
                        throw new ArgumentOutOfRangeException("1", "Bit Memory Size must be 16 times");
                    }
                    num = lMemorySize / 16;
                }
                cls_STable = PC_STable;
                cls_STable.ReadBit(lBitName + lStartBitAddress, lMemorySize, ref lValue);
                enErrCode enErrCode;
                if (HwdClearBuf())
                {
                    string text = "";
                    if (!lbolIsOneBitType)
                    {
                        int[] array = new int[num];
                        for (int i = 0; i < num; i++)
                        {
                            int num3 = 1;
                            for (int j = 0; j < 16; j++)
                            {
                                if (lValue[i * 16 + j])
                                {
                                    array[i] += num3;
                                }
                                num3 *= 2;
                            }
                        }
                        for (int k = 0; k < num; k++)
                        {
                            text += array[k].ToString("X4");
                        }
                    }
                    else
                    {
                        for (int l = 0; l < lMemorySize; l++)
                        {
                            text = ((!lValue[l]) ? (text + "0") : (text + "1"));
                        }
                    }
                    if (!lbolIsOneBitType)
                    {
                        HwdSend(lBitName, lStartBitAddress, text, true, num, true);
                    }
                    else
                    {
                        HwdSend(lBitName, lStartBitAddress, text, true, lMemorySize, true);
                    }
                    HwdRecive(ref strResultData);
                    if (strResultData != null)
                    {
                        string a = strResultData.Substring(0, 4);
                        if (a == "D000")
                        {
                            string text2 = strResultData.Substring(18, 4);
                            if (text2 == "0000")
                            {
                                enErrCode = enErrCode.NoErr_00;
                            }
                            else
                            {
                                num2 = Convert.ToUInt16(text2, 16);
                                enErrCode = enErrCode.MsgErr_20;
                            }
                        }
                        else
                        {
                            enErrCode = enErrCode.MsgErr_20;
                        }
                    }
                    else
                    {
                        enErrCode = enErrCode.MsgErr_20;
                    }
                }
                else
                {
                    enErrCode = enErrCode.ComErr_10;
                }
                lintMCComErrCode = (int)enErrCode;
                if (enErrCode == enErrCode.MsgErr_20 && num2 != 0)
                {
                    return num2;
                }
                return (int)enErrCode;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                lintMCComErrCode = 999;
                throw new Exception(strClassName + " [WriteBit]  " + ex.Message);
            }
        }
    }
}
