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
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ToASCIITest()
        {
            byte[] ref_bs = Encoding.ASCII.GetBytes("ABC123      ");
            List<int> words = new List<int>();
            for (int i = 0; i < ref_bs.Length; i += 2)
            {
                words.Add(BitConverter.ToUInt16(ref_bs, i));
            }
            Assert.AreEqual("ABC123      ", words.ToASCII());
        }

        [TestMethod()]
        public void ToASCIIWordsTest()
        {
            try
            {
                byte[] ref_bs = Encoding.ASCII.GetBytes("ABC123");
                int[] ints = ref_bs.Select(b => Convert.ToInt32(b)).ToArray();
                string ascii = ints.ToASCII();
                var bytes = ascii.ToASCIIWords();
                Assert.AreEqual(string.Join(",", ints), string.Join(",", bytes));
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}