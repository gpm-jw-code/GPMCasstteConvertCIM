using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    public partial class TaskDispatchDialog : Form
    {
        private readonly clsAGVCState agvc;
        AGVS_Dispath_Emulator.ACTION selected_action
        {
            get
            {
                return (AGVS_Dispath_Emulator.ACTION)cmbACTION.SelectedItem;
            }
        }
        public TaskDispatchDialog(clsAGVCState agvc)
        {
            InitializeComponent();
            this.agvc = agvc;
            Text = $"任務-{agvc.CarName}";

            cmbACTION.DataSource = new List<AGVS_Dispath_Emulator.ACTION> { AGVS_Dispath_Emulator.ACTION.Move, AGVS_Dispath_Emulator.ACTION.Parking };
            cmbACTION.SelectedItem = null;
            cmbStations.SelectedItem = null;
        }

        private void cmbACTION_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbACTION.SelectedItem == null)
                return;

            AGVS_Dispath_Emulator.ACTION selected_action = (AGVS_Dispath_Emulator.ACTION)cmbACTION.SelectedItem;

            if (selected_action == AGVS_Dispath_Emulator.ACTION.Move)
            {
                cmbStations.DataSource = StaVirtualAGVS.StationList;
                label3.Visible = cmbSlots.Visible = false;
            }
            else if (selected_action == AGVS_Dispath_Emulator.ACTION.Parking)
            {
                cmbStations.DataSource = StaVirtualAGVS.SlotSetList;
                label3.Visible = cmbSlots.Visible = true;
                cmbSlots.SelectedItem = null;
            }

        }

        private void cmbSlots_DropDown(object sender, EventArgs e)
        {
            //"rack_4_7|8|9"
            string stationName = cmbStations.SelectedItem.ToString();
            string[] splited = stationName.Split('|');
            List<string> slotList = new List<string>();
            foreach (string s in splited)
            {
                var sploted_ul = s.Split('_');
                slotList.Add(sploted_ul[sploted_ul.Length - 1]);
            }
            cmbSlots.DataSource = slotList;
        }

        private void cmbStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSlots.SelectedItem = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cmbACTION.SelectedItem == null)
            {
                btnSendDispatchTask.Enabled = false;
                return;
            }

            if (cmbACTION.SelectedItem.ToString() == AGVS_Dispath_Emulator.ACTION.Move.ToString())
            {
                btnSendDispatchTask.Enabled = cmbStations.SelectedItem != null;
            }
            else if (cmbACTION.SelectedText == AGVS_Dispath_Emulator.ACTION.Parking.ToString())
            {
                btnSendDispatchTask.Enabled = cmbStations.SelectedItem != null && cmbSlots.SelectedItem != null;
            }
        }

        private void cmbSlots_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbACTION.Focus();
        }

        private async void btnSendDispatchTask_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            string station = cmbStations.SelectedItem.ToString();
            string slot = cmbSlots.SelectedItem?.ToString();
            btnSendDispatchTask.Enabled = false;
            var _selected_action = selected_action;
            _ = Task.Factory.StartNew(async () =>
            {
                AGVS_Dispath_Emulator.ExcuteResult ret;
                if (_selected_action == AGVS_Dispath_Emulator.ACTION.Move)
                {
                    ret = await StaVirtualAGVS.TaskDispatcher.Move(agvc.CarName, agvc.AGV_ID, station);
                }

                if (_selected_action == AGVS_Dispath_Emulator.ACTION.Parking)
                {
                    ret = await StaVirtualAGVS.TaskDispatcher.Park(agvc.CarName, agvc.AGV_ID, station, slot);
                }
                Invoke(new Action(() =>
                {
                    timer1.Enabled = btnSendDispatchTask.Enabled = true;
                }));
            });
        }
    }
}
