using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secs4Net;

namespace GPMCasstteConvertCIM.GPM_SECS.Tests
{
    [TestClass()]
    public class SECSMessageHelperTests
    {
        [TestMethod()]
        public void ChangeOfflineEventReportMessageTest()
        {
            Secs4Net.SecsMessage msg = SECSMessageHelper.EVENT_REPORT.ChangeOfflineModeEventReportMessage(0, "SV-GPM-EQP-ID-213");
        }



        [TestMethod()]
        public void CreateCarrierWaitInMsgTest()
        {
            string Carrier_ID = "ID_123";
            string Carrier_Loc = "LOC_123";
            string Carrier_ZoneNameCarrier_ID = "ZoneName_123";
            SecsMessage msg = SECSMessageHelper.EVENT_REPORT.CarrierWaitInReportMessage(Carrier_ID, Carrier_Loc, Carrier_ZoneNameCarrier_ID);
            Assert.AreEqual(3, msg.SecsItem.Count);
            Assert.AreEqual(158, msg.SecsItem[1].FirstValue<short>());
            Assert.AreEqual(5, msg.SecsItem[2][0][0].FirstValue<short>());

            Assert.AreEqual(Carrier_ID, msg.SecsItem[2][0][1][0].GetString());
            Assert.AreEqual(Carrier_Loc, msg.SecsItem[2][0][1][1].GetString());
            Assert.AreEqual(Carrier_ZoneNameCarrier_ID, msg.SecsItem[2][0][1][2].GetString());
        }
        [TestMethod()]
        public void MsgBuildTest()
        {

        }
    }
}