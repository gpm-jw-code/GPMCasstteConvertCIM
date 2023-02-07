using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public class clsAGVCState : INotifyPropertyChanged
    {

        public enum ONLINE_STATE
        {
            OFFLINE = 0,
            ONLINE,
        }
        public enum AUTO_STATE
        {
            AUTO,
            MANUAL
        }

        public enum RUN_STATE
        {
            IDLE = 1,
            RUN,
            DOWN,
            Charging

        }

        private RUN_STATE _RunState = RUN_STATE.IDLE;
        private ONLINE_STATE _OnlineState = ONLINE_STATE.OFFLINE;
        private AUTO_STATE _AutoState = AUTO_STATE.MANUAL;
        private string _TagID = "";

        public event PropertyChangedEventHandler? PropertyChanged;
        public string CarName { get; set; } = "AGV_1";
        public int AGV_ID { get; set; } = 1;
        public string TagID
        {
            get => _TagID;
            set
            {
                if (value != _TagID)
                {
                    _TagID = value;
                    PropertyChangedInvoke(nameof(value));
                }
            }
        }
        public double Battery { get; set; }

        public string CSTID { get; set; } = "";


        public RUN_STATE RunState
        {
            get => _RunState;
            set
            {
                if (value != _RunState)
                {
                    _RunState = value;
                    PropertyChangedInvoke(nameof(value));
                }
            }
        }
        public ONLINE_STATE OnlineState
        {
            get => _OnlineState;
            set
            {
                if (value != _OnlineState)
                {
                    _OnlineState = value;
                    PropertyChangedInvoke(nameof(value));
                }
            }
        }
        public AUTO_STATE AutoState
        {
            get => _AutoState;
            set
            {
                if (value != _AutoState)
                {
                    _AutoState = value;
                    PropertyChangedInvoke(nameof(value));
                }
            }
        }

        private void PropertyChangedInvoke(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
