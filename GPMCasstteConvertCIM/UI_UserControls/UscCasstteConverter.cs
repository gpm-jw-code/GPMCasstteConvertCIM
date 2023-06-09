﻿using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Forms;
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

                uscConverterPortStatus1.CstCVPort = _casstteConverter.EQPData.PortDatas[0];
                if (_casstteConverter.EQPData.PortDatas.Count == 2)
                    uscConverterPortStatus2.CstCVPort = _casstteConverter.EQPData.PortDatas[1];

                if (_casstteConverter.converterType == Enums.CONVERTER_TYPE.IN_SYS)
                {
                    uscConverterPortStatus2.Visible = false;
                    labNameDisplay.Text = "單一轉換架";
                }
                else
                {
                    labNameDisplay.Text = "平對平組";
                }


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
    }
}
