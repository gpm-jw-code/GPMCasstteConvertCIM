using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.GPM_Modbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_Modbus.Tests
{
    [TestClass()]
    public class ModbusTCPServerTests
    {
        [TestMethod()]
        public void WriteDITest()
        {
            ModbusTCPServer ser = new ModbusTCPServer();
        }
    }
}