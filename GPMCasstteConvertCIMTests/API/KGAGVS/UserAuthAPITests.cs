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
    public class UserAuthAPITests
    {
        [TestMethod()]
        public void LoginToAGVSWebSiteTest()
        {
            APIConfiguration.AGVSHostIP = "127.0.0.1";
            APIConfiguration.AGVSHostPORT = 3000;
            var result = KGAGVS.UserAuthAPI.LoginToAGVSWebSite().Result;
            Console.WriteLine(result);
            Assert.Fail();
        }

        [TestMethod()]
        public void GetWebSiteSIDTest()
        {
            APIConfiguration.AGVSHostIP = "127.0.0.1";
            APIConfiguration.AGVSHostPORT = 3000;
            var result = KGAGVS.UserAuthAPI.GetwebsiteSID(CancellationToken.None).Result;
            Assert.Fail();
        }
    }
}