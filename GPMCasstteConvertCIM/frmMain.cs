using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.CIM;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.Emulator;
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
            Utility.SystemLogger = new LoggerBase(rtbSystemLogShow);
            Utility.LoadDeviceConnectionOpts();
            uscConnectionStates1.InitializeConnectionState();
            EmulatorManager.Start();

            Utility.DevicesConnectionsOpts.SECS_HOST.logRichTextBox = rtbSecsHostLog;
            Utility.DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable = dgvMsgFromAGVS;
            Utility.DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable = dgvActiveMsgToAGVS;

            Utility.DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox = rtbSecsClientLog;
            Utility.DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable = dgvMsgFromMCS;
            Utility.DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable = dgvActiveMsgToMCS;


            Utility.DevicesConnectionsOpts.PLCEQ1.logRichTextBox = rtbCasstteConvertLog;
            Utility.DevicesConnectionsOpts.PLCEQ1.mainUI = uscCasstteConverterUI_1;
            Utility.DevicesConnectionsOpts.PLCEQ2.logRichTextBox = rtbCasstteConvertLog;
            Utility.DevicesConnectionsOpts.PLCEQ2.mainUI = uscCasstteConverterUI_2;

            Utility.DevicesConnectionsOpts.Modbus_Server.mainUI = Utility.ModbusTCPServerView;
            Utility.DevicesConnectionsOpts.Modbus_Server.logRichTextBox = rtbModbusTcpServerLog;


            CIMDevices.DeviceConnectionStateOnChanged += CIMDevices_DeviceConnectionStateOnChanged;


            CIMDevices.Connect(Utility.DevicesConnectionsOpts.SECS_HOST, Utility.DevicesConnectionsOpts.SECS_CLIENT,
                Utility.DevicesConnectionsOpts.PLCEQ1, Utility.DevicesConnectionsOpts.PLCEQ2, Utility.DevicesConnectionsOpts.Modbus_Server);

            VirtualAGVSystem.StaVirtualAGVS.Initialize();
         
            //dgvMsgFromAGVS.DataSource = CIMDevices.secs_host.recvBuffer;
            //dgvActiveMsgToAGVS.DataSource = CIMDevices.secs_host.sendBuffer;
            //dgvMsgFromMCS.DataSource = CIMDevices.secs_client.recvBuffer;
            //dgvActiveMsgToMCS.DataSource = CIMDevices.secs_client.sendBuffer;

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

        private void CIMDevices_DeviceConnectionStateOnChanged(object? sender, CIMDevices.ConnectionStateChangeArgs e)
        {
            switch (e.Device_Type)
            {
                case CIMDevices.CIM_DEVICE_TYPES.SECS_HOST:
                    uscConnectionStates1.SECS_TO_AGVS_ConnectionChange(e.Connection_State);
                    break;
                case CIMDevices.CIM_DEVICE_TYPES.SECS_CLIENT:
                    uscConnectionStates1.SECS_TO_MCS_ConnectionChange(e.Connection_State);
                    break;
                case CIMDevices.CIM_DEVICE_TYPES.CASSTTE_CONVERTER:
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
                SecsMessage? se = await CIMDevices.secs_host?.SendAsync(new SecsMessage(1, 3)
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
            CIMDevices.casstteConverter_1.OpenSimulatorUI();
        }

        private void toolStripMenuItem_OpenConvert_2_Simulator_Click(object sender, EventArgs e)
        {
            CIMDevices.casstteConverter_2.OpenSimulatorUI();

        }

        private void modbusTCPServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utility.ModbusTCPServerView.Show();
        }

        private void aGVS¼ÒÀÀ¾¹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAGVS_Modbus_Emulator AGVSModbusEmulator = new frmAGVS_Modbus_Emulator();
            AGVSModbusEmulator.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CIMDevices.casstteConverter_1.mcInterface?.Close();
            CIMDevices.casstteConverter_2.mcInterface?.Close();

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