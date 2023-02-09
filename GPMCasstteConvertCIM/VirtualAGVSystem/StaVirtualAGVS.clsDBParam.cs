namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public partial class StaVirtualAGVS
    {
        public class clsDBParam
        {
            public bool enable { get; set; } = false;
            public string user { get; set; } = "sa";
            public string password { get; set; } = "12345678";
            public string server { get; set; } = "127.0.0.1";
            public string database { get; set; } = "WebAGVSystem";
            public int port { get; set; } = 1433;
        }

    }
}
