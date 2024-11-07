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
    public class EQLotIDMonitorTests
    {
        [TestMethod()]
        public void StartMonitorTest()
        {
            EQLotIDMonitor monitor = new EQLotIDMonitor(new EQLotIDMonitor.Configrations
            {
                Enabled = true,
                STATUS_INI_FILE_PATH = "C://CST//ini//Status.ini",
                Monitor_Lot_Table = new Dictionary<string, string>()
                {
                    {"Rack1_1","Z1"}
                }
            });
            monitor.StartMonitor();

            while (true)
            {
                Thread.Sleep(1);
            }

            Assert.Fail();
        }
    }
}