using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.GPM_Modbus
{

    public class RegisterBase : INotifyPropertyChanged
    {
        public int Index { get; set; } = 0;

        public virtual int Address { get; }

        public string Description { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void PropertyChangedInvoke(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public string LinkPLCAddress { get; set; } = "";
    }

    public class DigitalIORegister : RegisterBase
    {
        public override int Address
        {
            get
            {
                return 00000 + Index;
            }
        }

        private bool _State = false;
        public bool State
        {
            get => _State;
            set
            {
                if (_State != value)
                {
                    _State = value;
                    PropertyChangedInvoke("State");
                }
            }
        }
    }
}
