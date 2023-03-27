using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.API.TcpSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.API.TcpSupport.Tests
{
    [TestClass()]
    public class SystemAPITests
    {
        [TestMethod()]
        public void StartTest()
        {

            SystemAPI sysapi = new SystemAPI();
            sysapi.Start();

            while (true)
            {
                Thread.Sleep(1);
            }
        }
    }
}