using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.API.TcpSupport;
using GPMCasstteConvertCIM.API.WebsocketSupport;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Devices.Options;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.Emulators.SecsEmu;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System.Windows.Forms;
using static Secs4Net.Item;
namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmMain : Form
    {
        CasstteConverter.clsCasstteConverter casstteConverter_1;
        CasstteConverter.clsCasstteConverter casstteConverter_2;
        public frmMain()
        {
            InitializeComponent();
            Application.ThreadException += Application_ThreadException; ;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            toolStripComboBox_Emulators.Visible = false;

        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Invoke(new Action(() =>
            {
                richTextBox3.SelectionColor = Color.Black;
                richTextBox3.AppendText($"{e.Exception.Message}\n");
            }));
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            Invoke(new Action(() =>
            {
                richTextBox3.SelectionColor = Color.Black;
                richTextBox3.AppendText($"{(e.ExceptionObject as Exception).InnerException?.Message}\n");
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Utility.LoadConfigs();
            DevicesManager.LoadDeviceConnectionOpts(out bool config_error, out bool eqplc_config_error, out string errMsg);

            if (config_error | eqplc_config_error)
            {
                MessageBox.Show($"{errMsg}，請確認參數設定", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            LoggerBase.logTimeUnit = Utility.SysConfigs.Log.LogFileUnit;


            Utility.SystemLogger = new LoggerBase(rtbSystemLogShow, Path.Combine(Utility.SysConfigs.Log.SyslogFolder, "Sys Log"));


            Utility.SystemLogger.Info("GPM CIM System Start");

            uscConnectionStates1.InitializeConnectionState();

            //SECSEmulatorManager.Start();

            DevicesManager.DevicesConnectionsOpts.SECS_HOST.logRichTextBox = rtbSecsHostLog;
            DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable = dgvMsgFromAGVS;
            DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable = dgvActiveMsgToAGVS;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox = rtbSecsClientLog;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable = dgvMsgFromMCS;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable = dgvActiveMsgToMCS;

            tlpConverterContainer.SuspendLayout();
            foreach (Devices.Options.ConverterEQPInitialOption item in DevicesManager.DevicesConnectionsOpts.PLCEQS)
            {
                item.logRichTextBox = rtbCasstteConvertLog;
                UI_UserControls.UscCasstteConverter mainUI = new UI_UserControls.UscCasstteConverter();
                item.mainUI = mainUI;
                tlpConverterContainer.Controls.Add(mainUI);
                mainUI.Dock = DockStyle.Fill;

                foreach (clsConverterPort.clsPortProperty port in item.Ports.Values)
                {

                    ToolStripMenuItem agvs_modbus_emu_selBtn = new ToolStripMenuItem()
                    {
                        Text = $"轉換架-{item.DeviceId}({item.ConverterType})-Port{port.PortNo}",
                        Tag = port //ConverterEQPInitialOption
                    };

                    agvs_modbus_emu_selBtn.Click += Agvs_modbus_emu_selBtn_Click;
                    AGVS_modbus_sim_ToolStripMenuItem.DropDownItems.Add(agvs_modbus_emu_selBtn);
                }


            }
            tlpConverterContainer.ResumeLayout();


            foreach (var item in DevicesManager.DevicesConnectionsOpts.Modbus_Servers)
            {
                item.mainUI = new frmModbusTCPServer();
                item.logRichTextBox = rtbModbusTcpServerLog;
            }


            DevicesManager.DeviceConnectionStateOnChanged += CIMDevices_DeviceConnectionStateOnChanged;

            DevicesManager.Connect();


            //DevicesManager.Connect(DevicesManager.DevicesConnectionsOpts.SECS_HOST, DevicesManager.DevicesConnectionsOpts.SECS_CLIENT,
            //    DevicesManager.DevicesConnectionsOpts.PLCEQ1, DevicesManager.DevicesConnectionsOpts.PLCEQ2, DevicesManager.DevicesConnectionsOpts.Modbus_Server);

            VirtualAGVSystem.StaVirtualAGVS.Initialize();

            SystemAPI systemAPI = new SystemAPI();
            systemAPI.Start();
            WebsocketMiddleware.ServerBuild();
            uscAlarmTable1.BindData(AlarmManager.AlarmsList);
            AlarmManager.onAlarmAdded += (sender, arg) => { uscAlarmTable1.alarmListBinding.ResetBindings(); };
            //dgvMsgFromAGVS.DataSource = CIMDevices.secs_host.recvBuffer;
            //dgvActiveMsgToAGVS.DataSource = CIMDevices.secs_host.sendBuffer;
            //dgvMsgFromMCS.DataSource = CIMDevices.secs_client.recvBuffer;
            //dgvActiveMsgToMCS.DataSource = CIMDevices.secs_client.sendBuffer;

        }


        private void Agvs_modbus_emu_selBtn_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem agvs_modbus_emu_selBtn = (ToolStripMenuItem)sender;
            clsConverterPort.clsPortProperty opt = (clsConverterPort.clsPortProperty)agvs_modbus_emu_selBtn.Tag;

            clsConverterPort? port = DevicesManager.GetAllPorts().FirstOrDefault(c => c.Properties.PortID == opt.PortID);
            frmAGVS_Modbus_Emulator emu = new frmAGVS_Modbus_Emulator(port)
            {
                Text = $"AGV交握模擬-{port.Properties.ModbusServer_IP}:{port.Properties.ModbusServer_PORT}({port.PortNameWithEQName})"
            };
            emu.Show();
        }

        private void Secs_client_MsgRecvBufferOnAdded(object? sender, EventArgs e)
        {
            dgvMsgFromMCS.Invalidate();
        }

        private void Secs_client_MsgSendBufferOnAdded(object? sender, EventArgs e)
        {
            dgvActiveMsgToMCS.Invalidate();
        }

        private void Secs_host_MsgRecvBufferOnAdded(object? sender, EventArgs e)
        {
            dgvMsgFromAGVS.Invalidate();
        }

        private void Secs_host_MsgSendBufferOnAdded(object? sender, EventArgs e)
        {
            dgvActiveMsgToAGVS.Invalidate();
        }

        private void CIMDevices_DeviceConnectionStateOnChanged(object? sender, DevicesManager.ConnectionStateChangeArgs e)
        {
            switch (e.Device_Type)
            {
                case DevicesManager.CIM_DEVICE_TYPES.SECS_HOST:
                    uscConnectionStates1.SECS_TO_AGVS_ConnectionChange(e.Connection_State);
                    if (e.Connection_State == Common.CONNECTION_STATE.DISCONNECTED)
                        AlarmManager.AddAlarm(ALARM_CODES.CONNECTION_ERROR_AGVS, "AGVS", false);
                    break;
                case DevicesManager.CIM_DEVICE_TYPES.SECS_CLIENT:
                    uscConnectionStates1.SECS_TO_MCS_ConnectionChange(e.Connection_State);
                    if (e.Connection_State == Common.CONNECTION_STATE.DISCONNECTED)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.CONNECTION_ERROR_MCS, "MCS", false);
                    }
                    break;
                case DevicesManager.CIM_DEVICE_TYPES.CASSTTE_CONVERTER:
                    uscConnectionStates1.Converter_ConnectionChange(e.Connection_State);
                    if (e.Connection_State == Common.CONNECTION_STATE.DISCONNECTED)
                    {
                        AlarmManager.AddAlarm(ALARM_CODES.CONNECTION_ERROR_CONVERT, ((clsCasstteConverter)sender).Name, false);
                    }
                    break;
                default:
                    break;
            }
        }

        private void EQPData_ModeChangeOnRequest(object? sender, EventArgs e)
        {
            //clsEQPData eqpData = (clsEQPData)sender;
            //MessageBox.Show($"Mode Change Request, Port Mode :{eqpData.EPortModeRequest}, Rack Mode :{eqpData.ERackModeRequest}");
        }

        private async void btnSecsHostSendMsgTest_Click(object sender, EventArgs e)
        {
            try
            {
                SecsMessage? se = await DevicesManager.secs_host_for_mcs?.SendAsync(new SecsMessage(1, 3)
                {
                    Name = "S1F3",
                    SecsItem = L(
                        A("HI"),
                        Boolean(false, false, true))
                });
            }
            catch (Exception ex)
            {
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

        }

        private void btnOpenConvertPLCSimulator_Click(object sender, EventArgs e)
        {
            frmConverterPLCSimulator fm = new frmConverterPLCSimulator();
            fm.CasstteConverter = casstteConverter_1;
            fm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOpenMCSSimulatorForm_Click(object sender, EventArgs e)
        {
            SECSEmulatorManager.StartMCSSecsEmu();
            frmMCSSimulator fm = new frmMCSSimulator();
            fm.Show();
        }

        private void toolStripMenuItem_OpenConvert_1_Simulator_Click(object sender, EventArgs e)
        {
            DevicesManager.casstteConverters[0].OpenSimulatorUI();
        }

        private void toolStripMenuItem_OpenConvert_2_Simulator_Click(object sender, EventArgs e)
        {
            DevicesManager.casstteConverters[1].OpenSimulatorUI();

        }

        private void modbusTCPServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.ModbusTCPServerView.Show();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("確定要關閉CIM程式", "Exit APP Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }


            foreach (var item in DevicesManager.casstteConverters)
            {
                item.mcInterface?.Close();
            }

            Environment.Exit(0);
        }

        private void SysTimer_Tick(object sender, EventArgs e)
        {
            labSysTime.Text = DateTime.Now.ToString();
        }

        private void aGVS派車模擬器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirtualAGVSystem.StaVirtualAGVS.MainUI.Show();
        }

        private void btnOpenLoginFOrm_Click(object sender, EventArgs e)
        {

            if (StaUsersManager.CurrentUser.Group != StaUsersManager.USER_GROUP.VISITOR)
            {
                var logout_confirm_result = MessageBox.Show("確定要登出?", "Logout Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (logout_confirm_result == DialogResult.OK)
                {
                    StaUsersManager.Logout();
                    btnOpenLoginFOrm.Text = "Login";
                    label6.Text = "VISITOR";
                    toolStripComboBox_Emulators.Visible = false;
                }
                return;
            }

            frmUserLogin loginForm = new frmUserLogin();
            var result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                btnOpenLoginFOrm.Text = "登出";
                label6.Text = $"{StaUsersManager.CurrentUser.Name}\r\n({StaUsersManager.CurrentUser.Group})";

                SuspendLayout();
                if (StaUsersManager.CurrentUser.Group == StaUsersManager.USER_GROUP.GPM_ENG | StaUsersManager.CurrentUser.Group == StaUsersManager.USER_GROUP.GPM_RD)
                {
                    uscAlarmShow1.showAlarmResetBtn = toolStripComboBox_Emulators.Visible = true;
                }
                else
                    uscAlarmShow1.showAlarmResetBtn = toolStripComboBox_Emulators.Visible = false;
                ResumeLayout();
            }

        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                uscAlarmTable1.alarmListBinding.ResetBindings();
            }
        }

        private void GPMRDMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void uscConnectionStates1_Load(object sender, EventArgs e)
        {

        }

        private void uscConnectionStates1_Click(object sender, EventArgs e)
        {
            Utility.SystemLogger.SecsTransferLog("Log Test");
        }

        private void pnlSideLeft_Click(object sender, EventArgs e)
        {
            Utility.SystemLogger.SecsTransferLog("Log Test");

        }
    }
}