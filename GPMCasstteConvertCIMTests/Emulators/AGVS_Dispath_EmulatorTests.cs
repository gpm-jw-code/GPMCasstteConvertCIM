using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.Emulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPMCasstteConvertCIM.VirtualAGVSystem;

namespace GPMCasstteConvertCIM.Emulators.Tests
{
    [TestClass()]
    public class AGVS_Dispath_EmulatorTests
    {
        [TestMethod()]
        public void MoveTest()
        {
            AGVS_Dispath_Emulator emu = new AGVS_Dispath_Emulator("", "");
            AGVS_Dispath_Emulator.ExcuteResult ret = emu.Move("AGV_1", 1, "35").Result;
        }
    }
}