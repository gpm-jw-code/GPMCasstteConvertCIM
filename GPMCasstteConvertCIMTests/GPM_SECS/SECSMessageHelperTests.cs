using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}