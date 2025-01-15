using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.Emulators
{
    internal class clsDeviceEmulator : clsCasstteConverter
    {
        internal clsMemoryAddress PortStatusDownAddress => LinkBitMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP && lp.EProperty == PROPERTY.Port_Status_Down);
        internal clsMemoryAddress Interface_ClockAddress => LinkWordMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP && lp.EProperty == PROPERTY.Interface_Clock);
        internal clsMemoryAddress InServiceReportAddress => LinkBitMap.FirstOrDefault(lp => lp.EOwner == clsMemoryAddress.OWNER.EQP && lp.EProperty == PROPERTY.Port_Enabled_Report);

        int[] clock = new int[1] { 100 };

        internal clsDeviceEmulator(ConverterEQPInitialOption eqOptions) : base(eqOptions)
        {
            simulation_mode = true;
        }

        internal override async Task<bool> ActiveAsync(McInterfaceOptions mcInterfaceOptions)
        {
            connectionState = Utilities.Common.CONNECTION_STATE.CONNECTED;
            InitStateSetup();
            return true;
        }

        protected override void CreatePortInstance(clsConverterPort.clsPortProperty portProp)
        {
            PortDatas.Add(new clsConverterPortEmulator(portProp, this));
        }


        protected override async void EQPInterfaceClockMonitor()
        {
            EQPMemOptions.memoryTable.WriteWord(Interface_ClockAddress.Address, ref clock);
        }
        private void InitStateSetup()
        {
            EQPMemOptions.memoryTable.WriteOneBit(PortStatusDownAddress.Address, true);
            EQPMemOptions.memoryTable.WriteOneBit(InServiceReportAddress.Address, true);
            EQPMemOptions.memoryTable.WriteWord(Interface_ClockAddress.Address, ref clock);

        }
        protected override void UpdatePortType(EQ_SCOPE port, clsConverterPort EQPORT)
        {
            base.UpdatePortType(port, EQPORT); //DO NOTHING 因為要在UI上模擬更新
        }
        protected override void UPdateCarrierIDFromMemeoryTable(clsConverterPort EQPORT)
        {
            //base.UPdateCarrierIDFromMemeoryTable(EQPORT); DO NOTHING 因為要在UI上模擬更新
        }
    }
}
