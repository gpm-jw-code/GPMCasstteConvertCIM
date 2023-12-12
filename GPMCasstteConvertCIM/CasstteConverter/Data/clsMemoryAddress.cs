using GPMCasstteConvertCIM.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GPMCasstteConvertCIM.CasstteConverter.Enums;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsMemoryAddress : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                ControlValue = Value = false;
            }
            else
                ControlValue = Value = 0;
        }
        public DATA_TYPE DataType { get; private set; }
        public OWNER EOwner => Owner == "AGVS" ? OWNER.CIM : OWNER.EQP;

        internal bool IsCIMUse => EOwner == OWNER.CIM;
        internal bool IsEQUse => EOwner == OWNER.EQP;
        internal bool firstUse = true;
        public string Address { get; set; }

        public object _Value = 0;
        public object Value
        {
            get => _Value;
            set
            {
                if (_Value + "" != value + "")
                {
                    _Value = value;
                    OnPropertyChanged(nameof(Value));
                    firstUse = false;
                }
            }
        }

        public object ControlValue { get; set; } = 0;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            Task.Factory.StartNew(() =>
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
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
        public EQ_NAMES EQ_Name { get; set; }

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

        private string _Scope = "";

        public Enums.EQ_SCOPE EScope { get; private set; } = Enums.EQ_SCOPE.Unknown;
        public string Scope
        {
            get => _Scope;
            set
            {
                _Scope = value;
                if (value == "EQ")
                {

                }
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

        internal clsMemoryAddress Copy()
        {
            return JsonConvert.DeserializeObject<clsMemoryAddress>(JsonConvert.SerializeObject(this));
        }
    }
}
