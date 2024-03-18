using GPMCasstteConvertCIM.Cclink_IE_Sturcture;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.GPM_SECS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmChangePortType : Form
    {
        public frmChangePortType()
        {
            InitializeComponent();
            bindingSource1.DataSource = Station;
        }

        private clsStationPort _Station;
        public clsStationPort Station
        {
            get => _Station;
            set
            {
                _Station = value;
                bindingSource1.DataSource = value;
            }
        }

        private void frmChangePortType_Load(object sender, EventArgs e)
        {
            Text = $"Port Type 變更-{Station.PortName}";
            cmbPortTypes.Items.AddRange(Enum.GetValues(typeof(PortUnitType)).Cast<PortUnitType>().Select(en => (object)en).ToArray());
            cmbPortTypes.SelectedItem = Station.EPortType;
            cmbPortTypes.SelectedIndexChanged += cmbPortTypes_SelectedIndexChanged;
        }

        private async void cmbPortTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectType = (PortUnitType)cmbPortTypes.SelectedItem;
            //if (selectType == Station.EPortType)
            //    return;

            if (Station.Properties.IsConverter)
            {
                cmbPortTypes.Enabled = false;
                labConverterPortTypeChangeRequestingNotify.Visible = true;
                bool success = await Station.ModeChangeRequestHandshake(selectType, "User From UI", no_change_if_current_type_is_req: false);
                cmbPortTypes.Enabled = true;
                labConverterPortTypeChangeRequestingNotify.Visible = false;
                if (!success)
                {
                    MessageBox.Show($"{Station.PortName}-Port Type變更失敗!", "PORT TYPE CHANGE FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                Station.Properties.PortType = selectType;
            }
            DevicesManager.SaveDeviceConnectionOpts();
            labCurrentPortType.Text = Station.EPortType.ToString();
            MessageBox.Show($"已變更為-{Station.EPortType}");
        }

    }
}
