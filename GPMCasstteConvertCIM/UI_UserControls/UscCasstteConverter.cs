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
using static GPMCasstteConvertCIM.Utilities.Common;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscCasstteConverter : UserControl
    {
        frmConvertPLCMemoryTables MemoryTable = new frmConvertPLCMemoryTables()
        {
        };
        frmConverterPLCSimulator PLCSimulator = new frmConverterPLCSimulator();

        private clsCasstteConverter _casstteConverter;
        internal clsCasstteConverter casstteConverter
        {
            get => _casstteConverter;
            set
            {
                PLCSimulator.CasstteConverter = MemoryTable.CasstteConverter = _casstteConverter = value;

                uscConverterPortStatus1.CstCVPort = _casstteConverter.PortDatas[0];
                if (_casstteConverter.PortDatas.Count == 2)
                    uscConverterPortStatus2.CstCVPort = _casstteConverter.PortDatas[1];
                uscConverterPortStatus2.Visible = _casstteConverter.converterType != Enums.CONVERTER_TYPE.IN_SYS;
                labNameDisplay.Text = value.Name == "" ? "設備-Unknown" : value.Name;

            }
        }
        public string NameDisplay
        {
            get => labNameDisplay.Text;
            set => labNameDisplay.Text = value;
        }
        public UscCasstteConverter()
        {
            InitializeComponent();
        }

        private void UscCasstteConverter_Load(object sender, EventArgs e)
        {
            StaUsersManager.OnRD_Login += StaUsersManager_OnRD_Login;
            StaUsersManager.OnLogout += StaUsersManager_OnLogout;
        }

        private void StaUsersManager_OnLogout(object? sender, EventArgs e)
        {
            SwitchToViewMode();
        }

        private void StaUsersManager_OnRD_Login(object? sender, EventArgs e)
        {
            SwitchToEditMode();
        }
        private void SwitchToEditMode()
        {
            txbEQNameEditInput.Text = labNameDisplay.Text;
            pnlEqNameEdit.Visible = true;
            labNameDisplay.Visible = false;
        }
        private void SwitchToViewMode()
        {
            labNameDisplay.Visible = true;
            pnlEqNameEdit.Visible = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (casstteConverter == null)
                return;

            try
            {
                labPLCMCAddress.Text = string.Format("{0}:{1}", _casstteConverter.mcInterfaceOptions.RemoteIP, _casstteConverter.mcInterfaceOptions.RemotePort);

                var eqpData = casstteConverter.EQPData;
                var btnRun_BackColor = eqpData.EQP_RUN ? Color.SeaGreen : Color.Black;
                var btnIdle_BackColor = eqpData.EQP_IDLE ? Color.Yellow : Color.Black;
                var btnDown_BackColor = eqpData.EQP_DOWN ? Color.Red : Color.Black;

                if (btnRun.BackColor != btnRun_BackColor)
                    btnRun.BackColor = btnRun_BackColor;

                if (btnIDLE.BackColor != btnIdle_BackColor)
                {
                    btnIDLE.BackColor = btnIdle_BackColor;
                    btnIDLE.ForeColor = btnIdle_BackColor == Color.Yellow ? Color.Black : Color.White;
                }

                if (btnDown.BackColor != btnDown_BackColor)
                    btnDown.BackColor = btnDown_BackColor;


                pnlBanner.BackColor = _casstteConverter.connectionState == CONNECTION_STATE.CONNECTED ? Color.FromArgb(0, 57, 155) :
                    _casstteConverter.connectionState == CONNECTION_STATE.CONNECTING ? Color.FromArgb(255, 126, 0) : Color.Red;
                labPLCConnectState.ForeColor = _casstteConverter.connectionState == CONNECTION_STATE.CONNECTING ? Color.Black : Color.White;
                labPLCConnectState.Text = _casstteConverter.connectionState.ToString();


                InterfaceClockUIRender();

            }
            catch (Exception ex)
            {
            }
        }

        private void InterfaceClockUIRender()
        {
            labInterfaceClock.Text = _casstteConverter.EQPData.InterfaceClock.ToString();
            labInterfaceClock.BackColor = _casstteConverter.PLCInterfaceClockDown ? Color.Red : Color.Green;
        }

        private void btnOpenMemoryTable_Click(object sender, EventArgs e)
        {
            MemoryTable.Show();
        }

        private void btnOpenConvertPLCSimulator_Click(object sender, EventArgs e)
        {
            OpenConvertPLCSumulator();
        }

        public void OpenConvertPLCSumulator()
        {

            PLCSimulator.Show();

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void btnIDLE_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {

        }

        private void btnSoftwareEMO_Click(object sender, EventArgs e)
        {
            casstteConverter.CIMinputMemOptions.memoryTable.WriteOneBit("X100", true);
        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            casstteConverter.AlarmResetFlag = true;
        }

        private void labOpenModbusServerFom_Click(object sender, EventArgs e)
        {
            casstteConverter.modbusServerGUI?.Show();
        }

        private void btnModifyEqNameConfirm_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show($"確定要將設備名稱由[{labNameDisplay.Text}] 修改為 [{txbEQNameEditInput.Text}]?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Cancel)
                return;
            var newName = txbEQNameEditInput.Text;
            labNameDisplay.Text = newName;
            casstteConverter.Name = newName;

            bool success = DevicesManager.TryModifyEQName(casstteConverter, newName, out string errMsg);
            if (success)
            {
                MessageBox.Show($"修改成功!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"修改失敗-{errMsg}", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
