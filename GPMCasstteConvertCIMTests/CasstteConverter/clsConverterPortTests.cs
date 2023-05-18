using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.CasstteConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter.Tests
{
    [TestClass()]
    public class clsConverterPortTests
    {
        [TestMethod()]
        public void clsConverterPortTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void clsConverterPortTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ModbusServerActiveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuildModbusTCPServerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SyncRegisterDataTest()
        {
            string id = "DCG      ";
            id = id.Replace(" ", "");
            Assert.AreEqual("DCG",id);
        }
    }
}