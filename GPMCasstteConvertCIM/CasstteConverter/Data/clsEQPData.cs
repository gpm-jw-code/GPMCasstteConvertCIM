using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;
using static GPMCasstteConvertCIM.GPM_SECS.SECSMessageHelper;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsEQPData : INotifyPropertyChanged
    {
        internal event EventHandler OnEQPRunStatusChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _InterfaceClock = -1;

        public clsEQPData(int portNum)
        {
            for (int i = 0; i < portNum; i++)
            {
                PortDatas.Add(new clsPortData(i + 1));
            }
        }

        public int InterfaceClock
        {
            get => _InterfaceClock;
            set
            {
                if (_InterfaceClock != value)
                {
                    _InterfaceClock = value;
                    PropertyChangedInnoke(nameof(InterfaceClock));
                }
            }
        }

        private void PropertyChangedInnoke(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public List<clsPortData> PortDatas { get; set; } = new List<clsPortData>();

        public bool EQP_RUN { get; internal set; }
        public bool EQP_IDLE { get; internal set; }
        public bool EQP_DOWN { get; internal set; }


        private int _Warning_Report_Index = -1;
        public int Warning_Report_Index
        {
            get => _Warning_Report_Index;
            set
            {
                if (_Warning_Report_Index != value)
                {
                    _Warning_Report_Index = value;
                }
            }
        }
        public int Warning_Code_1_16 { get; internal set; }
        public int Warning_Code_17_32 { get; internal set; }
        public int Warning_Code_33_48 { get; internal set; }
        public int Alarm_Report_Index { get; internal set; }
        public int Alarm_Code_1_16 { get; internal set; }
        public int Alarm_Code_17_32 { get; internal set; }
        public int Alarm_Code_33_48 { get; internal set; }
        public int EQP_ON_OFFLine_Mode_Status { get; internal set; }
    }


}
