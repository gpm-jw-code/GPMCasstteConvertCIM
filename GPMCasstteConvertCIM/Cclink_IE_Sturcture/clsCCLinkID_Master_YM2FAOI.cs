using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.Cclink_IE_Sturcture
{
    internal class clsCCLinkID_Master_YM2FAOI : clsCCLinkIE_Master
    {
        public clsCCLinkID_Master_YM2FAOI(string name, UscEQStatus ui) : base(name, ui)
        {
        }
        protected override string BitMapFileName_CIM { get; set; } = "src\\Map_YM_2F_AOI\\PLC_Bit_Map_CIM.csv";
        protected override string WordMapFileName_CIM { get; set; } = "src\\Map_YM_2F_AOI\\PLC_Word_Map_CIM.csv";
        protected override string BitMapFileName_EQ { get; set; } = "src\\Map_YM_2F_AOI\\PLC_Bit_Map_EQ.csv";
        protected override string WordMapFileName_EQ { get; set; } = "src\\Map_YM_2F_AOI\\PLC_Word_Map_EQ.csv";


    }
}
