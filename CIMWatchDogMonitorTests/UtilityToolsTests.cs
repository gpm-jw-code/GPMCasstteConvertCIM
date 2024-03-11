using Microsoft.VisualStudio.TestTools.UnitTesting;
using CIMWatchDogMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMWatchDogMonitor.Tests
{
    [TestClass()]
    public class UtilityToolsTests
    {
        [TestMethod()]
        public void LoadModbusConnectionOptionsFromCIMTest()
        {
            UtilityTools.LoadModbusConnectionOptionsFromCIM();
        }
    }
}