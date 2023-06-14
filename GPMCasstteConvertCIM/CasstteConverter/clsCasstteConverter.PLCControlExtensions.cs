using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsCasstteConverter
    {
        internal clsMemoryGroupOptions ExetenMEM = new clsMemoryGroupOptions("X0000", "X00FF", "W0000", "W001F", true, true);

        private bool ReadXBit(int address)
        {
            mcInterface?.ReadBit(ref ExetenMEM.memoryTable, "X", "0", ExetenMEM.bitSize);
            return ExetenMEM.memoryTable.ReadOneBit($"X{address}");
        }
        private void WriteXBit(int address, bool value)
        {
            try
            {
                ExetenMEM.memoryTable.WriteOneBit($"X{address}", value);
                mcInterface?.WriteBit(ref ExetenMEM.memoryTable, "X", "0", ExetenMEM.bitSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Set X{address} Fail, {ex.Message}");
            }
        }

        internal bool X30
        {
            get
            {
                return ReadXBit(30);
            }
            set
            {
                WriteXBit(30, value);
            }
        }

        internal bool X33_OnlineMode
        {
            get
            {
                return ReadXBit(33);
            }
            set
            {
                WriteXBit(33, value);
            }
        }

    }
}
