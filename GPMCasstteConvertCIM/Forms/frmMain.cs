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
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static GPMCasstteConvertCIM.Utilities.StaUsersManager;
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
                rtbSystemLogShow.SelectionColor = Color.Black;
                rtbSystemLogShow.AppendText($"{e.Exception.Message}\n");
            }));
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            Invoke(new Action(() =>
            {
                rtbSystemLogShow.SelectionColor = Color.Black;
                rtbSystemLogShow.AppendText($"{(e.ExceptionObject as Exception).InnerException?.Message}\n");
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Utility.LoadConfigs();
            Secs4Net.EncodingSetting.ASCIIEncoding = Utility.SysConfigs.SECS.SECESAEncoding; //設定編碼
            if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007)
                tabControl1.TabPages.RemoveAt(1);//把原本的HOME PAGE移除
            else
                tabControl1.TabPages.RemoveAt(0);

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
                UI_UserControls.UscCasstteConverter mainUI = new UI_UserControls.UscCasstteConverter();
                item.mainUI = mainUI;
                tlpConverterContainer.Controls.Add(mainUI);
                mainUI.Dock = DockStyle.Fill;

                foreach (clsConverterPort.clsPortProperty port in item.Ports.Values)
                {
                    ToolStripMenuItem agvs_modbus_emu_selBtn = new ToolStripMenuItem()
                    {
                        Text = $"{item.Eq_Name}-{port.PortID}",
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
            DevicesManager.EqStatusUI = usceqStatus1;
            DevicesManager.Connect();


            //DevicesManager.Connect(DevicesManager.DevicesConnectionsOpts.SECS_HOST, DevicesManager.DevicesConnectionsOpts.SECS_CLIENT,
            //    DevicesManager.DevicesConnectionsOpts.PLCEQ1, DevicesManager.DevicesConnectionsOpts.PLCEQ2, DevicesManager.DevicesConnectionsOpts.Modbus_Server);

            VirtualAGVSystem.StaVirtualAGVS.Initialize();

            SystemAPI systemAPI = new SystemAPI();
            systemAPI.Start();

            WebsocketMiddleware.ServerBuild();
            uscAlarmTable1.BindData(AlarmManager.AlarmsList.ToList());
            AlarmManager.onAlarmAdded += (sender, arg) =>
            {
                Invoke(new Action(() =>
                {
                    uscAlarmTable1.BindData(AlarmManager.AlarmsList.ToList());
                    uscAlarmTable1.alarmListBinding.ResetBindings();
                }));
            };
            //dgvMsgFromAGVS.DataSource = CIMDevices.secs_host.recvBuffer;
            //dgvActiveMsgToAGVS.DataSource = CIMDevices.secs_host.sendBuffer;
            //dgvMsgFromMCS.DataSource = CIMDevices.secs_client.recvBuffer;
            //dgvActiveMsgToMCS.DataSource = CIMDevices.secs_client.sendBuffer;


        }


        private void Agvs_modbus_emu_selBtn_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem agvs_modbus_emu_selBtn = (ToolStripMenuItem)sender;
            clsConverterPort.clsPortProperty opt = (clsConverterPort.clsPortProperty)agvs_modbus_emu_selBtn.Tag;
            if (opt == null)
                return;
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
                SecsMessage? se = await DevicesManager.secs_host_for_mcs?.SendMsg(new SecsMessage(1, 3)
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
            ckbRemoteModeIndi.Checked = SECSState.IsRemote;
            cknOnlineModeIndi.Checked = SECSState.IsOnline;
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
                    ckbHotRunMode.Visible = toolStripComboBox_Emulators.Visible = false;
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
                    ckbHotRunMode.Visible = uscAlarmShow1.showAlarmResetBtn = toolStripComboBox_Emulators.Visible = true;
                }
                else
                    ckbHotRunMode.Visible = uscAlarmShow1.showAlarmResetBtn = toolStripComboBox_Emulators.Visible = false;
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

        private void ckbRemoteModeIndi_CheckedChanged(object sender, EventArgs e)
        {
            ckbRemoteModeIndi.Text = ckbRemoteModeIndi.Checked ? "REMOTE" : "LOCAL";
        }

        private void btnClearInfoLog_Click(object sender, EventArgs e)
        {
            rtbSystemLogShow.Clear();
        }

        private void cknOnlineModeIndi_CheckedChanged(object sender, EventArgs e)
        {
            cknOnlineModeIndi.Text = cknOnlineModeIndi.Checked ? "ONLINE" : "OFFLINE";
            string ch = "中文測試";
            var bytes = Encoding.ASCII.GetBytes(ch);

            var big5ch = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
            var big5Bytes = Encoding.BigEndianUnicode.GetBytes(big5ch);
            //
            DevicesManager.secs_host_for_mcs.SendMsg(new SecsMessage(5, 9)
            {
                SecsItem = A(ch)
            });

        }

        private void ckbHotRunMode_CheckedChanged(object sender, EventArgs e)
        {
            Utility.IsHotRunMode = ckbHotRunMode.Checked;
            if (Utility.IsHotRunMode)
            {
                if (SECSState.IsOnline && SECSState.IsRemote)
                {
                    ckbHotRunMode.Checked = false;
                    MessageBox.Show($"SECS ONLINE/REMOTE 的狀態下不可切換為Hot Run模式", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Utility.SystemLogger.Info($"User Enable Hot Run Mode");
                MessageBox.Show($"Hot Run模式已啟動\r\n - 轉換架 Wait Out請求將會被接受，但PortType(方向)強制切換為[INPUT]", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Utility.SystemLogger.Info($"User Disable Hot Run Mode");
            }
        }

        private void labSysTime_Click(object sender, EventArgs e)
        {
            bool success = StaUsersManager.TryLogin("gpm", "33838628", out User user);
        }
    }
}