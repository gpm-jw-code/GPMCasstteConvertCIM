namespace GPMCasstteConvertCIM.CasstteConverter
{
    public partial class clsConverterPort
    {
        public class HandShakeResult
        {
            public bool Finish;
            public string Message;
            public bool Timeout;

            public void Reset()
            {
                Finish = Timeout = false;
                Message = "";
            }
        }

    }
}
