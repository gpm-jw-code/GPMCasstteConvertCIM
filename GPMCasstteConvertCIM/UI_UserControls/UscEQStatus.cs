using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscEQStatus : UserControl
    {


        public BindingList<clsConverterPort> BindingPorts;
        /// <summary>
        /// 
        /// </summary>
        public UscEQStatus()
        {
            InitializeComponent();
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            StaUsersManager.OnLogout += StaUsersManager_OnLogout;
            StaUsersManager.OnRD_Login += StaUsersManager_OnRD_Login;
        }

        private void StaUsersManager_OnRD_Login(object? sender, EventArgs e)
        {
            ckbSimulationMode.Visible = true;
        }

        private void StaUsersManager_OnLogout(object? sender, EventArgs e)
        {
            ckbSimulationMode.Visible = false;
        }
        private int StatusbitdataStartIndex = 3;
        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= StatusbitdataStartIndex && e.RowIndex != -1)
            {
                clsConverterPort data = (clsConverterPort)dataGridView1.Rows[e.RowIndex].DataBoundItem;

                bool state_to_change = false;

                if (e.ColumnIndex == StatusbitdataStartIndex)
                    state_to_change = data.LoadRequest;
                if (e.ColumnIndex == StatusbitdataStartIndex + 1)
                    state_to_change = data.UnloadRequest;
                if (e.ColumnIndex == StatusbitdataStartIndex + 2)
                    state_to_change = data.PortExist;
                if (e.ColumnIndex == StatusbitdataStartIndex + 3)
                    state_to_change = data.LD_UP_POS;
                if (e.ColumnIndex == StatusbitdataStartIndex + 4)
                    state_to_change = data.LD_DOWN_POS;
                if (e.ColumnIndex == StatusbitdataStartIndex + 5)
                    state_to_change = data.PortStatusDown;


                if (e.ColumnIndex == StatusbitdataStartIndex + 5)
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = state_to_change ? Color.FromArgb(34, 181, 71) : Color.Red;
                else
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = state_to_change ? Color.FromArgb(34, 181, 71) : Color.WhiteSmoke;

            }
        }

        internal void BindData(List<clsConverterPort> allEqPortList)
        {
            BindingPorts = new BindingList<clsConverterPort>(allEqPortList);
            dataGridView1.DataSource = BindingPorts;
        }

        internal void GUIRefresh()
        {
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 | e.ColumnIndex < StatusbitdataStartIndex)
                return;

            if (!DevicesManager.cclink_master.simulation_mode)
            {
                MessageBox.Show("非模擬模式下不可修改Memory Bit Value", "Forbid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var row = dataGridView1.Rows[e.RowIndex];
            var data = row.DataBoundItem as clsConverterPort;
            bool _state_change_to = false;
            Enums.PROPERTY property = Enums.PROPERTY.Load_Request;
            if (e.ColumnIndex == StatusbitdataStartIndex)
            {
                property = Enums.PROPERTY.Load_Request;
                _state_change_to = !data.LoadRequest;
            }
            else if (e.ColumnIndex == StatusbitdataStartIndex + 1)
            {
                property = Enums.PROPERTY.Unload_Request;
                _state_change_to = !data.UnloadRequest;
            }
            else if (e.ColumnIndex == StatusbitdataStartIndex + 2)
            {
                property = Enums.PROPERTY.Port_Exist;
                _state_change_to = !data.PortExist;
            }
            else if (e.ColumnIndex == StatusbitdataStartIndex + 3)
            {
                property = Enums.PROPERTY.LD_UP_POS;
                _state_change_to = !data.LD_UP_POS;
            }
            else if (e.ColumnIndex == StatusbitdataStartIndex + 4)
            {
                property = Enums.PROPERTY.LD_DOWN_POS;
                _state_change_to = !data.LD_DOWN_POS;
            }
            else if (e.ColumnIndex == StatusbitdataStartIndex + 5)
            {
                property = Enums.PROPERTY.Port_Status_Down;
                _state_change_to = !data.PortStatusDown;
            }
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(data.PortEQBitAddress[property], _state_change_to);
        }

        private void ckbSimulationMode_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.simulation_mode = ckbSimulationMode.Checked;
        }

        private void btnOpenMasterMemTb_Click(object sender, EventArgs e)
        {
            frmConvertPLCMemoryTables frm = new frmConvertPLCMemoryTables()
            {
                CasstteConverter = DevicesManager.cclink_master
            };
            frm.TopLevel = true;
            frm.TopMost = true;
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == StatusbitdataStartIndex + 6)
            {
                frmEQPortInfo frm = new frmEQPortInfo(dataGridView1.Rows[e.RowIndex].DataBoundItem as clsConverterPort);
                frm.Show();
            }
        }

        ///
        //uscAlarmTable1.BindData(AlarmManager.AlarmsList);
        //    AlarmManager.onAlarmAdded += (sender, arg) => { uscAlarmTable1.alarmListBinding.ResetBindings(); };
    }
}
