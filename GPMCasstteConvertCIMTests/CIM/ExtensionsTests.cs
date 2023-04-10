using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.Devices;

namespace GPMCasstteConvertCIM.CIM.Tests
{
    [TestClass()]
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ToSecsGenOptionsTest()
        {
            var secsopt = new InitialOption()
            {
                IpAddress = "0.tcp.jp.ngrok.io",
            }.ToSecsGenOptions();
        }
    }
}