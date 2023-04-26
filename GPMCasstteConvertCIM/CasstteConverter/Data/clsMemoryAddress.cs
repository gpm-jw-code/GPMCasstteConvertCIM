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
        public string Link_Modbus_Address_Hex
        {
            get
            {
                if (Link_Modbus_Register_Number == -1)
                    return "";
                string hex = Link_Modbus_Register_Number.ToString("X4");
                return (EOwner == OWNER.EQP ? "Y" : "X") + hex;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private string _Scope = "";

        public Enums.EQ_SCOPE EScope { get; private set; } = Enums.EQ_SCOPE.Unknown;
        public string Scope
        {
            get => _Scope;
            set
            {
                _Scope = value;
                EScope = Enum.GetValues(typeof(Enums.EQ_SCOPE)).Cast<Enums.EQ_SCOPE>().FirstOrDefault(s => s.ToString() == _Scope);
            }
        }
        private string _PropertyName = "";
        public Enums.PROPERTY EProperty { get; private set; } = Enums.PROPERTY.Unknown;
        public string ToggleBtnText { get; set; } = "Toggle";
        public string PropertyName
        {
            get => _PropertyName;
            set
            {
                _PropertyName = value;
                EProperty = Enum.GetValues(typeof(Enums.PROPERTY)).Cast<Enums.PROPERTY>().FirstOrDefault(s => s.ToString() == _PropertyName);
            }
        }
    }
}
