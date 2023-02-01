using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscConnectionStates : UserControl
    {
        public UscConnectionStates()
        {
            InitializeComponent();
        }

        internal void SECS_TO_AGVS_ConnectionChange(Common.CONNECTION_STATE state)
        {
            labSECS_AGVS.ConnectionStateChange(state);
        }

        internal void SECS_TO_MCS_ConnectionChange(Common.CONNECTION_STATE state)
        {
            labSECS_MCS.ConnectionStateChange(state);
        }

        internal void Converter_ConnectionChange(Common.CONNECTION_STATE state)
        {
            labConverter.ConnectionStateChange(state);
        }

        internal void AGVC_ConnectionChange(Common.CONNECTION_STATE state)
        {
            labAGVC.ConnectionStateChange(state);
        }

        internal void InitializeConnectionState(Common.CONNECTION_STATE init_state = Common.CONNECTION_STATE.DISCONNECTED)
        {
            labSECS_AGVS.ConnectionStateChange(init_state);
            labSECS_MCS.ConnectionStateChange(init_state);
            labConverter.ConnectionStateChange(init_state);
            labAGVC.ConnectionStateChange(init_state);
        }

    }
}
