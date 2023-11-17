using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.AGVsMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.AGVsMiddleware.Tests
{
    [TestClass()]
    public class AGVsOrderInfoTransferTests
    {
        [TestMethod()]
        public void PostOrderInfoToAGVTest()
        {
            var ret = AGVsOrderInfoTransfer.PostOrderInfoToAGV(new Utilities.SysConfigs.clsAGVInfo()
            {
                AGVIP = "192.168.1.101"
            }).Result;
        }
    }
}