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
            var ret = AGVsOrderInfoTransfer.PostOrderInfoToAGV(new DataBase.KGS_AGVs.AGVSDBHelper.clsNewTaskObj
            {
                AGVID = 1,
                AGVIP = "127.0.0.1",
                OrderInfo = new DataBase.KGS_AGVs.Models.ExecutingTask
                {
                    ActionType = ""
                }
            }).Result;
        }
    }
}