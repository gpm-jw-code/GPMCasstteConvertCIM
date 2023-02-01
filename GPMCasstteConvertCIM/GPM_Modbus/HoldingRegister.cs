namespace GPMCasstteConvertCIM.GPM_Modbus
{

    public class HoldingRegister : RegisterBase
    {
        public override int Address =>  Index;
        public string Address_Hex => Address.ToString("X4");
        private short _Value { get; set; }
        public short Value
        {
            get => _Value;
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    PropertyChangedInvoke("Value");
                    PropertyChangedInvoke("Value_Hex");
                }
            }
        }
        public string Value_Hex => string.Format("0x{0}", Value.ToString("X4"));
    }

}
