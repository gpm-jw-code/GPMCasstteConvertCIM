using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmConverterPLCSimulator : Form
    {
        internal clsCasstteConverter CasstteConverter { get; set; }

        public frmConverterPLCSimulator()
        {
            InitializeComponent();
            uscMemoryTable1.bitValueOnChanged += UscMemoryTable1_bitValueOnChanged;
            uscMemoryTable1.wordValueOnChanged += UscMemoryTable1_wordValueOnChanged; ;
        }

        private void UscMemoryTable1_wordValueOnChanged(object? sender, clsMemoryAddress e)
        {
            CasstteConverter.EQPMemOptions.memoryTable.WriteBinary(e.Address, (int)e.Value);
        }

        private void UscMemoryTable1_bitValueOnChanged(object? sender, clsMemoryAddress e)
        {
            CasstteConverter.EQPMemOptions.memoryTable.WriteOneBit(e.Address, (bool)e.Value);
        }

        private void frmConverterPLCSimulator_Load(object sender, EventArgs e)
        {
            uscMemoryTable1.bitMemoryAddressList = CasstteConverter?.LinkBitMap;
            uscMemoryTable1.wordMemoryAddressList = CasstteConverter?.LinkWordMap;
        }

        private void btnWIP_BCR_ID_Write_Click(object sender, EventArgs e)
        {
            List<int> toWriteBinarys = ConvertToBinaryValues(ref txbWIP_BCR_ID);

            var addresses = CasstteConverter.WIP_Port1_BCR_ID_Addresses;
            for (int i = 0; i < addresses.Count; i++)
            {
                var address = addresses[i].Address;
                var value = toWriteBinarys[i];
                CasstteConverter.EQPMemOptions.memoryTable.WriteBinary(address, value);
            }
            uscMemoryTable1.Invalidate();
        }

        private List<int> ConvertToBinaryValues(ref TextBox txb)
        {
            string ascii_str = txb.Text;
            int empty_com = 20 - ascii_str.Length;//要補空格的數量
            for (int i = 0; i < empty_com; i++)
            {
                ascii_str += " ";
            }
            byte[] ascii_bytes = Encoding.ASCII.GetBytes(ascii_str);
            List<int> toWriteBinarys = new List<int>();
            for (int i = 0; i < ascii_bytes.Length; i += 2)
            {
                var _int = BitConverter.ToInt16(ascii_bytes, i);
                toWriteBinarys.Add(_int);
            }

            return toWriteBinarys;
        }

        private void btnSendChangeToManModeReq_Click(object sender, EventArgs e)
        {
            var RackModeRequestAddress = CasstteConverter.LinkWordMap.FirstOrDefault(m => m.PropertyName == "RackModeRequest").Address;
            var PortModeRequestAddress = CasstteConverter.LinkWordMap.FirstOrDefault(m => m.PropertyName == "PortModeRequest").Address;
            var ModeRequestFlagAddress = CasstteConverter.LinkBitMap.FirstOrDefault(m => m.PropertyName == "Mode_Change_Request").Address;


            CasstteConverter.EQPMemOptions.memoryTable.WriteBinary(RackModeRequestAddress, (int)AUTO_MANUAL_MODE.MANUAL);
            CasstteConverter.EQPMemOptions.memoryTable.WriteBinary(PortModeRequestAddress, (int)PortUnitType.Input);
            CasstteConverter.EQPMemOptions.memoryTable.WriteOneBit(ModeRequestFlagAddress, true);

            uscMemoryTable1.Invalidate();
        }

        private void ckbIsEQPAlive_CheckedChanged(object sender, EventArgs e)
        {
            EQPInterfaceClockTimer.Enabled = ckbIsEQPAlive.Checked;
        }

        private void EQPInterfaceClockTimer_Tick(object sender, EventArgs e)
        {
            string address = CasstteConverter.EQPInterfaceClockAddress.Address;
            int _clock = CasstteConverter.EQPMemOptions.memoryTable.ReadBinary(address);
            CasstteConverter.EQPMemOptions.memoryTable.WriteBinary(address, _clock += 1);
        }

        private void frmConverterPLCSimulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void ckbMonitor_CheckedChanged(object sender, EventArgs e)
        {
            CasstteConverter.monitor= ckbMonitor.Checked;
        }
    }
}
