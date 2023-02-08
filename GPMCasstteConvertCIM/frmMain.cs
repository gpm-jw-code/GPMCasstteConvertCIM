using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Devices.Options;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.Emulator;
using GPMCasstteConvertCIM.Utilities;
using Secs4Net;
using Secs4Net.Sml;
using System.Windows.Forms;
using static Secs4Net.Item;
namespace GPMCasstteConvertCIM
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
            DevicesManager.LoadDeviceConnectionOpts();

            LoggerBase.logTimeUnit = Utility.SysConfigs.Log.LogFileUnit;


            Utility.SystemLogger = new LoggerBase(rtbSystemLogShow, Path.Combine(Utility.SysConfigs.Log.SyslogFolder, "Sys Log"));
            Utility.SystemLogger.Info("GPM CIM System Start");

            uscConnectionStates1.InitializeConnectionState();

            //EmulatorManager.Start();

            DevicesManager.DevicesConnectionsOpts.SECS_HOST.logRichTextBox = rtbSecsHostLog;
            DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable = dgvMsgFromAGVS;
            DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable = dgvActiveMsgToAGVS;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox = rtbSecsClientLog;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable = dgvMsgFromMCS;
            DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable = dgvActiveMsgToMCS;


            foreach (Devices.Options.ConverterEQPInitialOption item in DevicesManager.DevicesConnectionsOpts.PLCEQS)
            {
                item.logRichTextBox = rtbCasstteConvertLog;
                UI_UserControls.UscCasstteConverter mainUI = new UI_UserControls.UscCasstteConverter();
                item.mainUI = mainUI;
                tlpConverterContainer.Controls.Add(mainUI);
                mainUI.Dock = DockStyle.Fill;

                ToolStripMenuItem agvs_modbus_emu_selBtn = new ToolStripMenuItem()
                {
                    Text = $"Âà´«¬[-{item.DeviceId}({item.ConverterType})",
                    Tag = item //ConverterEQPInitialOption
                };

                agvs_modbus_emu_selBtn.Click += Agvs_modbus_emu_selBtn_Click;
                AGVS_modbus_sim_ToolStripMenuItem.DropDownItems.Add(agvs_modbus_emu_selBtn);

            }


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



            //dgvMsgFromAGVS.DataSource = CIMDevices.secs_host.recvBuffer;
            //dgvActiveMsgToAGVS.DataSource = CIMDevices.secs_host.sendBuffer;
            //dgvMsgFromMCS.DataSource = CIMDevices.secs_client.recvBuffer;
            //dgvActiveMsgToMCS.DataSource = CIMDevices.secs_client.sendBuffer;

        }

        private void Agvs_modbus_emu_selBtn_Click(object? sender, EventArgs e)
        {
            ToolStripMenuItem agvs_modbus_emu_selBtn = (ToolStripMenuItem)sender;
            ConverterEQPInitialOption opt = (ConverterEQPInitialOption)agvs_modbus_emu_selBtn.Tag;

            clsCasstteConverter? linkedCasstteCV = DevicesManager.casstteConverters.FirstOrDefault(c => c.index == opt.DeviceId);
            frmAGVS_Modbus_Emulator emu = new frmAGVS_Modbus_Emulator(linkedCasstteCV);
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
                    break;
                case DevicesManager.CIM_DEVICE_TYPES.SECS_CLIENT:
                    uscConnectionStates1.SECS_TO_MCS_ConnectionChange(e.Connection_State);
                    break;
                case DevicesManager.CIM_DEVICE_TYPES.CASSTTE_CONVERTER:
                    uscConnectionStates1.Converter_ConnectionChange(e.Connection_State);
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
                SecsMessage? se = await DevicesManager.secs_host?.SendAsync(new SecsMessage(1, 3)
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

        private void aGVS¬£¨®¼ÒÀÀ¾¹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VirtualAGVSystem.StaVirtualAGVS.MainUI.Show();
        }
    }
}