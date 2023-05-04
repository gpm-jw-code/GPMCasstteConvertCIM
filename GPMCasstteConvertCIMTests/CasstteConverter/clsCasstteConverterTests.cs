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
    public class clsCasstteConverterTests
    {
        [TestMethod()]
        public void LoadPLCMapDataTest()
        {
            clsCasstteConverter cv = new clsCasstteConverter();
            cv.LoadPLCMapData();
        }
    }
}