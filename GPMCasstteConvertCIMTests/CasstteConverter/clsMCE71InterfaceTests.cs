using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.CasstteConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GPMCasstteConvertCIM.CasstteConverter.Tests
{
    [TestClass()]
    public class clsMCE71InterfaceTests
    {
        static string ip = "192.168.1.133";
        static int port = 5123;
        [TestMethod()]
        public void HwdSendTest()
        {
            clsMCE71Interface mc = new clsMCE71Interface();
            mc.Open(ip, port, 1111, 1111, false, clsMC_TCPCnt.enuDataType.ByteArr_02);
            List<byte> cmd = mc.GenWriteDataBinaryCmdData("W", "0", "0002", true);
            mc.loMCTcpCtrl.SendDataOut(cmd.ToArray());
            string hexStr = string.Join(" ", cmd.Select(e => e.ToString("X2")));
        }

        [TestMethod()]
        public void ReadBitTest()
        {
            clsMCE71Interface mc = new clsMCE71Interface();
            mc.Open(ip, port, 1111, 1111, false, clsMC_TCPCnt.enuDataType.ByteArr_02);
            List<byte> cmd = mc.GenReadDataBinaryCmdData("B", "1", 16, true);
            mc.loMCTcpCtrl.SendDataOut(cmd.ToArray());
            string resultTxt = "";
            mc.loMCTcpCtrl.ReceiveData(ref resultTxt);

            string lenb1 = resultTxt.Substring(16, 2);
            string lenb2 = resultTxt.Substring(14, 2);

            int len = int.Parse(lenb1 + lenb2, System.Globalization.NumberStyles.HexNumber);
            string dataText = resultTxt.Substring(18, len * 2);

            string hexData = "";
            for (int i = 0; i < dataText.Length; i += 4)
            {
                var hex = dataText.Substring(i + 2, 2) + dataText.Substring(i, 2);
                hexData += hex;
            }
            bool[] bools = Convert.ToString(Convert.ToInt64(hexData, 16), 2).Select(c => c == '1').Reverse().ToArray();

            mc.Close();
        }
    }
}