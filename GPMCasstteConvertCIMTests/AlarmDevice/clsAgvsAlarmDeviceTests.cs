using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.AlarmDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.AlarmDevice.Tests
{
    [TestClass()]
    public class clsAgvsAlarmDeviceTests
    {
        [TestMethod()]
        public void offlineTest()
        {
            clsAgvsAlarmDevice agv_buzzer = new clsAgvsAlarmDevice();
            agv_buzzer.offline();
            Thread.Sleep(1000);
            agv_buzzer.Return_Online();
            Thread.Sleep(1000);
            agv_buzzer.GetstopMusic();
            Thread.Sleep(1000);
        }
    }
}