using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommMsgHelper = GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper.COMMUNICATION;
using OnOffLineMsgHelper = GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper.ONOFFLINE;
using EVENTRPMsgHelper = GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper.EVENT_REPORT;
using Secs4Net;

namespace GPMCasstteConvertCIM.GPM_SECS.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void TryGetConnectRequestParamTest()
        {
            string mdln = "test_mdln";
            string softrev = "test_softrev";
            var connectMsg = CommMsgHelper.EstablishCommunicationRequestMessage(mdln, softrev);

            connectMsg.TryGetConnectRequestParam(out string _mdln, out string _softrev);

            Assert.AreEqual(mdln, _mdln);
            Assert.AreEqual(softrev, _softrev);
        }

        [TestMethod()]
        public void TryGetConnectRequestAckResultTest()
        {
            SECSMessageHelper.COMMACK ack = SECSMessageHelper.COMMACK.Denied_Try_Again;
            string mdln = "test_mdln";
            string softrev = "test_softrev";
            var ackMsg = CommMsgHelper.EstablishCommunicationRequestAcknowledgeMessage(ack, mdln, softrev);
            ackMsg.TryGetConnectRequestAckResult(out SECSMessageHelper.COMMACK _ack, out string _mdln, out string _softrev);

            Assert.AreEqual(ack, _ack);
            Assert.AreEqual(mdln, _mdln);
            Assert.AreEqual(softrev, _softrev);
        }

        [TestMethod()]
        public void TryGetOnlineRequestAckResultTest()
        {
            var msg = OnOffLineMsgHelper.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Already_Online);
            msg.TryGetOnlineRequestAckResult(out SECSMessageHelper.ONLACK _ack);
            Assert.AreEqual(SECSMessageHelper.ONLACK.Already_Online, _ack);

            msg = OnOffLineMsgHelper.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Accepted);
            msg.TryGetOnlineRequestAckResult(out _ack);
            Assert.AreEqual(SECSMessageHelper.ONLACK.Accepted, _ack);

            msg = OnOffLineMsgHelper.OnLineRequestAcknowledgeMessage(SECSMessageHelper.ONLACK.Not_Allowed);
            msg.TryGetOnlineRequestAckResult(out _ack);
            Assert.AreEqual(SECSMessageHelper.ONLACK.Not_Allowed, _ack);
        }

        [TestMethod()]
        public void TryGetEventReportAckResultTest()
        {
            var ackMsg = EVENTRPMsgHelper.EventReportAcknowledgeMessage(SECSMessageHelper.ACKC6.Accpeted);
            ackMsg.TryGetEventReportAckResult(out SECSMessageHelper.ACKC6 _ack);
            Assert.AreEqual(SECSMessageHelper.ACKC6.Accpeted, _ack);

            ackMsg = EVENTRPMsgHelper.EventReportAcknowledgeMessage(SECSMessageHelper.ACKC6.System_Error);
            ackMsg.TryGetEventReportAckResult(out _ack);
            Assert.AreEqual(SECSMessageHelper.ACKC6.System_Error, _ack);
        }

        [TestMethod()]
        public void IsAGVSOnlineReportTest()
        {
            SecsMessage msg = new SecsMessage(6, 11)
            {
                SecsItem = Item.L(
                        Item.U4()

                     )
            };
        }
    }
}