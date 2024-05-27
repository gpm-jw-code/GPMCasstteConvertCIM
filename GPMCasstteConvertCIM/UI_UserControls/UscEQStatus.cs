using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Cclink_IE_Sturcture;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Forms;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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

        private void UscEQStatus_Load(object sender, EventArgs e)
        {
            var timer = new System.Windows.Forms.Timer()
            {
                Interval = 1000,
            };
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
        }
        private bool _ShowMaintainAndPartsReplaceSignalColumn = false;
        public bool ShowMaintainAndPartsReplaceSignalColumn
        {
            get => _ShowMaintainAndPartsReplaceSignalColumn;
            set
            {
                _ShowMaintainAndPartsReplaceSignalColumn = value;
                MaintainingCloumn.Visible = PartsReplacingColumn.Visible = value;
            }
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (DevicesManager.cclink_master != null)
            {
                var sTATE = DevicesManager.cclink_master.connectionState;
                labConnectionState.Visible = sTATE != Common.CONNECTION_STATE.CONNECTED;
                pnlHeader.BackColor = sTATE == Common.CONNECTION_STATE.CONNECTED ? Color.Teal : sTATE == Common.CONNECTION_STATE.CONNECTING ? Color.Orange : Color.Red;
                labConnectionState.Text = sTATE == Common.CONNECTION_STATE.CONNECTING ? "CCLINK-嘗試重新連線中" : "CCLINK-已斷線";

            }
        }



        private void StaUsersManager_OnRD_Login(object? sender, EventArgs e)
        {
            ChangeToAdminMode();
        }

        private void StaUsersManager_OnLogout(object? sender, EventArgs e)
        {
            ChangeToVisitorMode();
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
                if (e.ColumnIndex == StatusbitdataStartIndex + 6)
                    state_to_change = data.To_EQ_UP;
                if (e.ColumnIndex == StatusbitdataStartIndex + 7)
                    state_to_change = data.To_EQ_Low;
                if (e.ColumnIndex == StatusbitdataStartIndex + 8)
                    state_to_change = data.CMD_Reserve_Up;
                if (e.ColumnIndex == StatusbitdataStartIndex + 9)
                    state_to_change = data.CMD_Reserve_Low;

                var oriColor = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;

                if (e.ColumnIndex == StatusbitdataStartIndex + 5)
                {
                    var color = state_to_change ? Color.FromArgb(34, 181, 71) : Color.FromArgb(255, 92, 97);
                    if (oriColor == color)
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                }
                else
                {
                    var actived_color = e.ColumnIndex > StatusbitdataStartIndex + 5 ? Color.FromArgb(51, 211, 255) : Color.FromArgb(31, 255, 116);
                    actived_color = data.IsIOSimulating ? Color.FromArgb(31, 152, 230) : actived_color;
                    var color = state_to_change ? actived_color : Color.WhiteSmoke;
                    if (oriColor == color)
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                }

            }
        }

        internal void BindData(List<clsConverterPort> allEqPortList)
        {
            BindingPorts = new BindingList<clsConverterPort>(allEqPortList);
            string firstEQName = DevicesManager.casstteConverters.Select(eq => eq.Name).FirstOrDefault();
            if (firstEQName != null)
            {
                dataGridView1.DataSource = new BindingList<clsConverterPort>(BindingPorts.ToList().Where(port => port.EqName == firstEQName).ToList());
                eqCombobox1.DisplayText = firstEQName;
            }
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

            DataGridViewColumn columnClicked = dataGridView1.Columns[e.ColumnIndex];

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

            if (columnClicked == MaintainingCloumn)
            {
                property = Enums.PROPERTY.EQP_Maintaining;
                _state_change_to = !data.Maintaining;
            }
            if (columnClicked == PartsReplacingColumn)
            {
                property = Enums.PROPERTY.EQP_Parts_Replacement;
                _state_change_to = !data.PartsReplacing;
            }
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(data.PortEQBitAddress[property], _state_change_to);
        }

        private void ckbSimulationMode_CheckedChanged(object sender, EventArgs e)
        {
            DevicesManager.cclink_master.simulation_mode = ckbSimulationMode.Checked;
        }
        frmConvertPLCMemoryTables frmmemory = null;
        private void btnOpenMasterMemTb_Click(object sender, EventArgs e)
        {
            if (frmmemory == null)
            {
                frmmemory = new frmConvertPLCMemoryTables()
                {
                    CasstteConverter = DevicesManager.cclink_master
                };
            }
            frmmemory.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (e.RowIndex != -1 && columnName == colSettings.Name)
            {
                frmEQPortInfo frm = new frmEQPortInfo(dataGridView1.Rows[e.RowIndex].DataBoundItem as clsConverterPort);
                frm.Show();
            }
            if (e.RowIndex != -1 && columnName == colModbus.Name)
            {
                var station = (dataGridView1.Rows[e.RowIndex].DataBoundItem as clsConverterPort);
                station.modbus_server.UI.Text = station.PortName;
                station.modbus_server.UI.Show();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (e.RowIndex != -1 && columnName == colIOSim.Name)
            {
                var station = (dataGridView1.Rows[e.RowIndex].DataBoundItem as clsConverterPort);
                frmPortStatusIOSimulation form = new frmPortStatusIOSimulation();
                form.ShowDialog(station);
            }
        }
        private void eqCombobox1_OnEQSelectChanged(object sender, string eq_name)
        {

            dataGridView1.DataSource = null;

            if (eq_name.ToUpper() == "ALL")
            {
                dataGridView1.DataSource = BindingPorts;
                return;
            }

            IEnumerable<clsConverterPort> filtered_ports = BindingPorts.Where(port => port.EqName == eq_name);
            var _BindingPorts = new BindingList<clsConverterPort>(filtered_ports.ToList());
            dataGridView1.DataSource = _BindingPorts;
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {

            dataGridView1.ResumeLayout();
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            dataGridView1.SuspendLayout();
        }

        private void btnOpenModbusServer_Click(object sender, EventArgs e)
        {

        }

        internal void ChangeToVisitorMode()
        {
            dataGridView1.SuspendLayout();
            ckbSimulationMode.Visible = colModbus.Visible = colSettings.Visible = colIOSim.Visible = false;
            dataGridView1.ResumeLayout();
        }

        internal void ChangeToAdminMode()
        {
            dataGridView1.SuspendLayout();
            ckbSimulationMode.Visible = colModbus.Visible = colSettings.Visible = colIOSim.Visible = true;
            dataGridView1.ResumeLayout();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && IsClickPortTypeCell(e, out var row))
            {
                clsStationPort station = (clsStationPort)row.DataBoundItem;
                portTypeContextMenuStrip.Items[0].Tag = station;
                portTypeContextMenuStrip.Items[1].Tag = station;
                dataGridView1.ContextMenuStrip = portTypeContextMenuStrip;

            }
            else
            {
                dataGridView1.ContextMenuStrip = null;
            }


            bool IsClickPortTypeCell(DataGridViewCellMouseEventArgs e, out DataGridViewRow row)
            {
                row = null;
                if (e.ColumnIndex == -1 || e.RowIndex == -1)
                    return false;
                bool isPortTypeCell = dataGridView1.Columns[e.ColumnIndex].Name == EPortType.Name;
                row = isPortTypeCell ? dataGridView1.Rows[e.RowIndex] : null;
                return isPortTypeCell;
            }
        }

        private void changePortTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            clsStationPort station = (clsStationPort)toolStripMenuItem.Tag;
            using frmChangePortType form = new frmChangePortType()
            {
                StartPosition = FormStartPosition.CenterScreen,
                Station = station
            };
            form.ShowDialog();
        }

        int debug = 1;
        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            clsStationPort station = (clsStationPort)toolStripMenuItem.Tag;
            debug = debug + 1;
            station.CIMMemoryTable.WriteBinary("WW0259", debug);
        }

        ///
        //uscAlarmTable1.BindData(AlarmManager.AlarmsList);
        //    AlarmManager.onAlarmAdded += (sender, arg) => { uscAlarmTable1.alarmListBinding.ResetBindings(); };
    }
}
