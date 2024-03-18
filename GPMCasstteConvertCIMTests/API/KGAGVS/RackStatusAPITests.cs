using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.API.KGAGVS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.KGAGVS.Tests
{
    [TestClass()]
    public class RackStatusAPITests
    {
        [TestMethod()]
        public void AddCSTIDTest()
        {
            APIConfiguration.AGVSHostIP = "127.0.0.1";
            APIConfiguration.AGVSHostPORT = 3000;

            (bool confirm, string response, string errorMsg) result = RackStatusAPI.AddCSTID("Rack_1", 1, "TAU12345").Result;

            Assert.IsTrue(result.confirm);
        }

        [TestMethod()]
        public void DeleteCSTIDTest()
        {
            APIConfiguration.AGVSHostIP = "127.0.0.1";
            APIConfiguration.AGVSHostPORT = 3000;
            (bool confirm, string response, string errorMsg) result = RackStatusAPI.DeleteCSTID("Rack_1", 1, "TAU12345").Result;

            Assert.IsTrue(result.confirm);
        }
    }
}