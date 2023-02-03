using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.CasstteConverter.Data
{
    public class clsAGVSData
    {

        public clsAGVSData()
        {

        }

        /// <summary>
        /// Load/Unload 交握訊號
        /// </summary>
        public clsHS_Status_Signals[] Signals = new clsHS_Status_Signals[2] {
          new clsHS_Status_Signals(),
          new clsHS_Status_Signals(),
        };

        public int InterfaceClock { get; set; }
        public int MessageIndex { get; set; }
        public int TriggerEquiment { get; set; }
        public int BuzzerFlag { get; set; }
        public int ClockUpdatingIndex { get; set; }
        public int TimeSync_Year { get; set; }
        public int TimeSync_Month { get; set; }
        public int TimeSync_Day { get; set; }
        public int TimeSync_Hour { get; set; }
        public int TimeSync_Minutes { get; set; }
        public int TimeSync_Second { get; set; }



        public class clsHS_Status_Signals
        {

            public event EventHandler OnValidSignalActive;

            private bool _VALID;
            public bool VALID
            {
                get => _VALID;
                set
                {
                    if (_VALID != value)
                    {
                        _VALID = value;
                        if (_VALID)
                            OnValidSignalActive?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            public bool TR_REQ { get; set; }
            public bool BUSY { get; set; }
            public bool COMPT { get; set; }
            public bool AGV_READY { get; set; }

            public bool To_EQ_Up { get; set; }
            public bool To_EQ_Low { get; set; }
            public bool CMD_Reserve_Up { get; set; }
            public bool CMD_Reserve_Low { get; set; }

            internal bool AnySignalON()
            {
                return VALID | TR_REQ | BUSY | COMPT | AGV_READY;
            }
        }

    }
}
