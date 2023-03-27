using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.API.WebsocketSupport;

namespace GPMCasstteConvertCIM.API.Tests
{
    [TestClass()]
    public class WebsocketMiddlewareTests
    {
        [TestMethod()]
        public void ServerBuildTest()
        {
            WebsocketMiddleware.ServerBuild();
            while (true)
            {
                Thread.Sleep(1);
            }
        }
    }
}