using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;

namespace GPMCasstteConvertCIM.GPM_Modbus
{

    public class RegisterBase : INotifyPropertyChanged
    {
        public int Index { get; set; } = 0;

        public virtual int Address { get; }
        public virtual string AddressHex { get; }

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
        public enum IO_TYPE
        {
            INPUT,
            OUTPUT
        }
        public IO_TYPE IOType { get; }
        public DigitalIORegister(IO_TYPE IOType)
        {
            this.IOType = IOType;
        }
        public override string AddressHex
        {

            get
            {
                string hex = IOType == IO_TYPE.OUTPUT ? (Address - 1).ToString("X4") : Address.ToString("X4");
                return (IOType == IO_TYPE.OUTPUT ? "Y" : "X") + hex;
            }
        }
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
