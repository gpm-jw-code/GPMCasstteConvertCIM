using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsMemoryAddress : INotifyPropertyChanged
    {
        public enum DATA_TYPE
        {
            BIT, WORD
        }
        public enum OWNER
        {
            CIM, EQP
        }
        public clsMemoryAddress(DATA_TYPE DataType)
        {
            this.DataType = DataType;
            if (DataType == DATA_TYPE.BIT)
            {
                Value = false;
            }
            else
                Value = 0;
        }
        public DATA_TYPE DataType { get; private set; }
        public OWNER EOwner => Owner == "AGVS" ? OWNER.CIM : OWNER.EQP;
        public string Address { get; set; }

        public object _Value = 0;
        public object Value
        {
            get => _Value;
            set
            {
                if (_Value?.ToString() != value.ToString())
                {
                    _Value = value;
                    if (PropertyChanged != null)
                    {
                        try
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
        }
        public string ValueDisplay
        {
            get
            {
                if (DataType == DATA_TYPE.WORD)
                {
                    return Value.ToString();
                }
                else
                {
                    return (bool)Value ? "ON" : "OFF";
                }
            }
        }
        public string DataName { get; set; }
        public string DataFormat { get; set; }
        public string Explanation { get; set; }
        public string Owner { get; set; }
        public int Link_Modbus_Register_Number { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private string _Scope = "";

        public EnumSTATES.EQ_SCOPE EScope { get; private set; } = EnumSTATES.EQ_SCOPE.Unknown;
        public string Scope
        {
            get => _Scope;
            set
            {
                _Scope = value;
                EScope = Enum.GetValues(typeof(EnumSTATES.EQ_SCOPE)).Cast<EnumSTATES.EQ_SCOPE>().FirstOrDefault(s => s.ToString() == _Scope);
            }
        }
        private string _PropertyName = "";
        public EnumSTATES.PROPERTY EProperty { get; private set; } = EnumSTATES.PROPERTY.Unknown;
        public string PropertyName
        {
            get => _PropertyName;
            set
            {
                _PropertyName = value;
                EProperty = Enum.GetValues(typeof(EnumSTATES.PROPERTY)).Cast<EnumSTATES.PROPERTY>().FirstOrDefault(s => s.ToString() == _PropertyName);
            }
        }
    }
}
