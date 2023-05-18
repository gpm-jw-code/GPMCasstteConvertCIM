using Microsoft.VisualStudio.TestTools.UnitTesting;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Secs4Net;
using GPMCasstteConvertCIM.CasstteConverter;

namespace GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle.Tests
{
    [TestClass()]
    public class MCSMessageHandlerTests
    {
        [TestMethod()]
        public void S1F3RequestHandleTest()
        {
            SecsMessage? result = MCSMessageHandler.S1F3RequestHandle(new Secs4Net.SecsMessage(1, 3, true)
            {
                SecsItem = Item.L(
                        Item.U2(2005),
                        Item.U2(2007),
                        Item.U2(2009)
                    )
            }).Result;
        }

        [TestMethod()]
        public void PortDataOrderTEst()
        {

            List<clsConverterPort> ports = new List<clsConverterPort>()
            {
                 new clsConverterPort
                 {
                      Properties = new clsConverterPort.clsPortProperty
                      {
                           PortID = "3F_AGVC02_2_6"
                      }
                 },
                 new clsConverterPort
                 {
                      Properties = new clsConverterPort.clsPortProperty
                      {
                           PortID = "3F_AGVC02_2_4"
                      }
                 },
                 new clsConverterPort
                 {
                      Properties = new clsConverterPort.clsPortProperty
                      {
                           PortID = "3F_AGVC02_2_5"
                      }
                 }
            };
            ports = ports.OrderBy(p => p.Properties.PortID).ToList();

            Assert.AreEqual("3F_AGVC02_2_4,3F_AGVC02_2_5,3F_AGVC02_2_6", String.Join(",", ports.Select(p=>p.Properties.PortID)));
        }
    }
}