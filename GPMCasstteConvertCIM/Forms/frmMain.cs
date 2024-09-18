//#define logTest
using GPMCasstteConvertCIM.AGVsMiddleware;
using GPMCasstteConvertCIM.Alarm;
using GPMCasstteConvertCIM.API.TcpSupport;
using GPMCasstteConvertCIM.API.WebsocketSupport;
using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.DataBase.KGS_AGVs;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Devices.Options;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.Emulators.SecsEmu;
using GPMCasstteConvertCIM.GPM_SECS;
using GPMCasstteConvertCIM.GPM_SECS.SecsMessageHandle;
using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.WebServer;
using Secs4Net;
using Secs4Net.Sml;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static GPMCasstteConvertCIM.Utilities.StaUsersManager;
using static Secs4Net.Item;
using GPMCasstteConvertCIM.AlarmDevice;
using GPMCasstteConvertCIM.WebServer.Models;
using AGVSystemCommonNet6.HttpTools;
using GPMCasstteConvertCIM.API.KGAGVS;
namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmMain : Form
    {
        CasstteConverter.clsCasstteConverter casstteConverter_1;
        CasstteConverter.clsCasstteConverter casstteConverter_2;
        private static clsAgvsAlarmDevice clsAgvsAlarmDevice = new clsAgvsAlarmDevice();

        public frmMain()
        {
            InitializeComponent();
            if (!Environment.Is64BitProcess)
            {
                this.Icon = new Icon(Path.Combine(Environment.CurrentDirectory, "cimico_x86.ico"));
            }
            toolStripComboBox_Emulators.Visible = false;
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var exception = e.Exception;
                Utility.SystemLogger.Error(exception.Message, exception, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{e.Exception.Message + "\r\n" + e.Exception.StackTrace}");
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (e.ExceptionObject as Exception).InnerException;
            Utility.SystemLogger.Error(exception.Message, exception, false);
        }
        private frmAGVsDatabaseBroswer AGVsDatabaseForm;
        private void Form1_Load(object sender, EventArgs e)
        {
            pnlLoading.BringToFront();

            DBhelper.Initialize();
            Utility.LoadConfigs();

            API.KGAGVS.APIConfiguration.AGVSHostIP = Utility.SysConfigs.WebService.KGS_HOST_IP;
            API.KGAGVS.APIConfiguration.AGVSHostPORT = Utility.SysConfigs.WebService.KGS_HOST_PORT;


            Text = $"GPM AGVS CIM-V{Assembly.GetExecutingAssembly().GetName().Version.ToString()} {(Environment.Is64BitProcess ? "" : "(x86)")}-{Utility.SysConfigs.Project}";
            警報器IO狀態ToolStripMenuItem.Visible = Utility.ModbusDeviceConfigs.Enable;

            Task.Run(async () =>
            {
                await Task.Delay(500);
                Invoke(new Action(() =>
                {
                    Secs4Net.EncodingSetting.ASCIIEncoding = Utility.SysConfigs.SECS.SECESAEncoding; //設定編碼
                    if (Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.U007 || Utility.SysConfigs.Project == Utilities.SysConfigs.clsSystemConfigs.PROJECT.YM_2F_AOI)
                    {
                        tabControl1.TabPages.RemoveAt(1);//把原本的HOME PAGE移除
                        splitContainer1.Panel2.Controls.Add(pnlSyslogRtbContainer);//Move container of  LOG to the Main View(Home) of Project.U007
                    }
                    else
                        tabControl1.TabPages.RemoveAt(0);

                    DevicesManager.LoadDeviceConnectionOpts(out bool config_error, out bool eqplc_config_error, out string errMsg);

                    if (config_error | eqplc_config_error)
                    {
                        MessageBox.Show($"{errMsg}，請確認參數設定", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }

                    LoggerBase.logTimeUnit = Utility.SysConfigs.Log.LogFileUnit;

                    Utility.SystemLogger = new LoggerBase(rtbSystemLogShow, Utility.SysConfigs.Log.SyslogFolder, "Sys Log");
                    Utility.SystemLogger.Info("GPM CIM System Start");
                    S2F49TransferQueueOperator.logger = new LoggerBase(null, Utility.SysConfigs.Log.SyslogFolder, "S2F49TransferQueue");
                    uscConnectionStates1.InitializeConnectionState();

                    DevicesManager.DevicesConnectionsOpts.SECS_HOST.logRichTextBox = rtbSecsHostLog;
                    DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvRevBufferTable = dgvMsgFromAGVS;
                    DevicesManager.DevicesConnectionsOpts.SECS_HOST.dgvSendBufferTable = dgvActiveMsgToAGVS;
                    DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.logRichTextBox = rtbSecsClientLog;
                    DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvRevBufferTable = dgvMsgFromMCS;
                    DevicesManager.DevicesConnectionsOpts.SECS_CLIENT.dgvSendBufferTable = dgvActiveMsgToMCS;


                    CVUIRender();

                    foreach (var item in DevicesManager.DevicesConnectionsOpts.Modbus_Servers)
                    {
                        item.mainUI = new frmModbusTCPServer();
                        item.logRichTextBox = rtbModbusTcpServerLog;
                    }
                    clsConverterPort.OnWaitInReqRaiseButStatusError += ClsConverterPort_OnWaitInReqRaiseButStatusError;
                    DevicesManager.DeviceConnectionStateOnChanged += CIMDevices_DeviceConnectionStateOnChanged;
                    DevicesManager.EqStatusUI = usceqStatus1;
                    DevicesManager.Connect();

                    VirtualAGVSystem.StaVirtualAGVS.Initialize();

                    SystemAPI systemAPI = new SystemAPI();
                    EQDIODataAPI EqDIOAPIService = new EQDIODataAPI();
                    AGVsDataBaseAPI AgvsDBAPIService = new AGVsDataBaseAPI();
                    systemAPI.Start();
                    EqDIOAPIService.Start();
                    AgvsDBAPIService.Start();
                    if (Utility.SysConfigs.AGVPingMonitor)
                        AGVMonitor.Start();
                    WebsocketMiddleware.ServerBuild();
                    uscAlarmTable1.BindData(AlarmManager.AlarmsList.ToList());

                    AlarmManager.onAlarmAdded += (sender, alarm) =>
                    {
                        Invoke(new Action(() =>
                        {
                            DBhelper.InsertAlarm(alarm);
                            CopyAlarmDBFileToLogFolderToday(DBhelper.DBFileName);
                            uscAlarmTable1.BindData(AlarmManager.AlarmsList.ToList());
                            uscAlarmTable1.alarmListBinding.ResetBindings();
                        }));
                    };
                    AlarmManager.onUnHandleExceptionOccur += (sender, alarm) =>
                    {
                        UnHandleExpLabelAnimation();
                    };

                    AlarmManager.onUnHandleExceptionAllClear += (sender, alarm) =>
                    {
                        UnHandleExpLabelAnimationStop();
                    };

                    SetCurrentEncodingName();

                    if (!Utility.SysConfigs.PostOrderInfoToAGV)
                    {
                        tabControl1.TabPages.Remove(tabAGVSInfos);
                    }
                    else
                    {
                        Thread initTheard = new Thread(KGSAGVSHelperInitWorker);
                        initTheard.Start();
                    }
                    CreateCVSimulatorItemButtons();
                    labRegionName.Text = Utility.SysConfigs.RegionName;
                    pnlLoading.SendToBack();

                    MyServlet.OnEqIOModeChangeRequest += DevicesManager.EqIOModeChangeHandle;
                    MyServlet.OnPortLDULDStatusChangeRequest += DevicesManager.PortLDULDStatusChangeHandle;
                    MyServlet.OnPortTypeChangeRequest += DevicesManager.PortTypeChangeHandler;
                    MyServlet.OnHotRunModeChangeRequest += HotRunRemoteControlHandle;
                    GPM_SECS.SecsMessageHandle.AGVSMessageHandler.OnAGVSDDOSAttacking += AGVSMessageHandler_OnAGVSDDOSAttacking;

                    CIMWebServer.StartService(Utility.SysConfigs.WebService.HostUrl, Path.Combine(Utility.SysConfigs.Log.SyslogFolder, "WebServerLog"));
                    Task.Run(async () =>
                    {
                        clsAgvsAlarmDevice.GetAlarmReset();
                    });
                    API.KGAGVS.RackStatusAPI.Logger = Utility.SystemLogger;
                    API.KGAGVS.UserAuthAPI.Logger = Utility.SystemLogger;
                    Utility.SystemLogger.Info($"KGS Web Service = {API.KGAGVS.APIConfiguration.AGVSHostIP}:{API.KGAGVS.APIConfiguration.AGVSHostPORT}");
                    MCSMessageHandler.MCSUseLogger.Info("Logger instance create test");
                    MCSMessageHandler.MCSUseLogger.MessageOut(new SecsMessage(6, 9) { Name = "GPM TEST" }, 0);
                    MCSMessageHandler.MCSUseLogger.MessageIn(new SecsMessage(6, 9) { Name = "GPM TEST" }, 0);

                    btnDisableS2F49TransgerQueue.CheckState = Utility.SysConfigs.S2F49QueuingConfigurations.Enable ? CheckState.Unchecked : CheckState.Checked;
                    btnEnableS2F49TransgerQueue.CheckState = !Utility.SysConfigs.S2F49QueuingConfigurations.Enable ? CheckState.Unchecked : CheckState.Checked;

                    EQLotIDMonitor eQLotIDMonitor = new EQLotIDMonitor();
                    eQLotIDMonitor.OnUnknownIDInstalled += EQLotIDMonitor_OnUnknownIDInstalled;
                    eQLotIDMonitor.StartMonitor();

                    SECSState.EqLotIDMonitor = eQLotIDMonitor;

#if logTest
                    for (int i = 0; i < 20; i++)
                    {
                        var _threadID = i + "";
                        Thread th = new Thread((_object) =>
                        {
                            while (true)
                            {
                                Thread.Sleep(1);
                                Utility.SystemLogger.Info($"Thread-{_object},Log Test-{DateTime.Now.Ticks}", true);
                            }
                        });
                        th.IsBackground = true;
                        th.Start(_threadID);
                    }
#endif
                }));
            });

        }

        private void AGVSMessageHandler_OnAGVSDDOSAttacking(object? sender, Queue<(DateTime Timestamp, int Size, SecsMessage message)> _trafficData)
        {
            string msgSmls = string.Join("\r\n", _trafficData.Select(item => item.message.ToSml()));
            Utility.SystemLogger.Info($"DDOS!\n{msgSmls}");
            AlarmManager.AddAlarm(ALARM_CODES.AGVS_DDOS, "SECS");
            ShowDDOSNotifyDialog();
        }

        private static void ShowDDOSNotifyDialog()
        {
            if (Utility.SysConfigs.showddosdialog)
            {
                AGVSDDOSDialog dialog = new AGVSDDOSDialog()
                {
                    TopMost = true,
                    TopLevel = true,
                    Text = "AGVS DDOS !!!!"
                };
                dialog.FormClosing += AGVSMessageHandler_OnAGVSDDOSReconvery;
                AGVSMessageHandler.OnAGVSDDOSReconvery += AGVSMessageHandler_OnAGVSDDOSReconvery;

                dialog.Show();
                void AGVSMessageHandler_OnAGVSDDOSReconvery(object? sender, EventArgs e)
                {
                    dialog.Dispose();
                    AGVSMessageHandler.OnAGVSDDOSReconvery -= AGVSMessageHandler_OnAGVSDDOSReconvery;
                }
            }
        }


        private void EQLotIDMonitor_OnUnknownIDInstalled(object? sender, EQLotIDMonitor.CarrierIDState e)
        {

            if (!SECSState.IsRemote && !Debugger.IsAttached)
                return;

            UnknownIDNotifyDialog notifyDialog = new UnknownIDNotifyDialog()
            {
                TopLevel = true,
                TopMost = true,
            };
            notifyDialog.ShowDialog(e, Utility.SysConfigs.MaterialManagementWebUrl);
        }

        private void UnHandleExpLabelAnimationStop()
        {
            if (UnHandleExpLabelAnumationTimer == null)
                return;
            UnHandleExpLabelAnumationTimer.Enabled = false;
            labUnHandleExceptions.Visible = false;
        }

        System.Windows.Forms.Timer UnHandleExpLabelAnumationTimer;
        private void UnHandleExpLabelAnimation()
        {
            labUnHandleExceptions.Visible = true;
            if (UnHandleExpLabelAnumationTimer == null)
            {
                Color bgColor1 = Color.White;
                Color bgColor2 = Color.Red;

                Color foreColor1 = Color.Red;
                Color foreColor2 = Color.White;

                UnHandleExpLabelAnumationTimer = new System.Windows.Forms.Timer()
                {
                    Interval = 1000,
                };
                UnHandleExpLabelAnumationTimer.Tick += (sender, e) =>
                {
                    labUnHandleExceptions.BackColor = labUnHandleExceptions.BackColor == bgColor1 ? bgColor2 : bgColor1;
                    labUnHandleExceptions.ForeColor = labUnHandleExceptions.ForeColor == foreColor1 ? foreColor2 : foreColor1;
                };
            }

            UnHandleExpLabelAnumationTimer.Enabled = true;

        }

        private clsResponse HotRunRemoteControlHandle(clsHotRunControl control)
        {
            ckbHotRunMode.CheckedChanged -= ckbHotRunMode_CheckedChanged;
            ckbHotRunMode.Checked = Utility.IsHotRunMode = control.enableHotRun;
            ckbHotRunMode.CheckedChanged += ckbHotRunMode_CheckedChanged;
            Utility.SystemLogger.Info($"Hot run mode set as {control.enableHotRun} via api.");
            return new clsResponse(0);
        }



        private void CopyAlarmDBFileToLogFolderToday(string dBFilePath)
        {
            try
            {
                string fileName = Path.GetFileName(dBFilePath);
                string destineFolder = Utility.SystemLogger.currentLogFolder;
                string destineFilePath = Path.Combine(destineFolder, fileName);
                File.Copy(dBFilePath, destineFilePath, true);
            }
            catch (Exception)
            {
            }
        }

        private void AlarmManager_onAlarmUpdated(object? sender, EventArgs e)
        {

        }

        private void CVUIRender()
        {
            var single_cvs = DevicesManager.DevicesConnectionsOpts.PLCEQS.Where(p => p.ConverterType == Enums.CONVERTER_TYPE.IN_SYS);
            bool isTwoSingleEQ = single_cvs.Count() == DevicesManager.DevicesConnectionsOpts.PLCEQS.Length;
            tlpSingleConvertsContainer.Visible = false;

            //if (!isTwoSingleEQ)
            //{
            //    tlpSingleConvertsContainer.ColumnCount = single_cvs.Count();
            //    tlpSingleConvertsContainer.ColumnStyles.Clear();
            //    for (int i = 0; i < single_cvs.Count(); i++)
            //    {
            //        tlpSingleConvertsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / single_cvs.Count()));
            //    }
            //}
            tlpConverterContainer.SuspendLayout();
            foreach (Devices.Options.ConverterEQPInitialOption item in DevicesManager.DevicesConnectionsOpts.PLCEQS)
            {
                UI_UserControls.UscCasstteConverter mainUI = new UI_UserControls.UscCasstteConverter();
                item.mainUI = mainUI;
                //if (!isTwoSingleEQ && item.ConverterType == Enums.CONVERTER_TYPE.IN_SYS)
                //{
                //    tlpSingleConvertsContainer.Controls.Add(mainUI);
                //}
                //else
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
        }

        private void CreateCVSimulatorItemButtons()
        {
            CVSimulatorsToolStripMenuItem.DropDownItems.Clear();
            int shortCutKeyNum = 3;
            foreach (clsCasstteConverter _cv in DevicesManager.casstteConverters)
            {
                Keys shortCutKey = Enum.GetValues(typeof(Keys)).Cast<Keys>().FirstOrDefault(ke => ke.ToString() == $"F{shortCutKeyNum}");
                ToolStripMenuItem cv_emu_selBtn = new ToolStripMenuItem()
                {
                    Text = $"{_cv.Name}",
                    Tag = _cv,
                    ShortcutKeys = shortCutKey
                };
                cv_emu_selBtn.Click += (sender, e) => { _cv.OpenSimulatorUI(); };
                CVSimulatorsToolStripMenuItem.DropDownItems.Add(cv_emu_selBtn);
                shortCutKeyNum += 1;

            }
        }

        private void ClsConverterPort_OnWaitInReqRaiseButStatusError(object? sender, clsConverterPort port)
        {
            Task.Run(() =>
            {
                CarrierWaitInOutRefuseDialog dialog = new CarrierWaitInOutRefuseDialog();
                dialog.ShowDialog(port);
            });
        }

        private async void KGSAGVSHelperInitWorker()
        {
            await Task.Delay(1000);
            Utility.SystemLogger.Info("Init AGVs");
            AGVsOrderInfoTransfer.Initialize(Utility.SystemLogger);
            AGVSDBHelper.OnError += (sender, msg) =>
            {
                Utility.SystemLogger.Error(msg);
            };
            DBInitWorker();
        }

        private async void DBInitWorker()
        {
            await Task.Delay(1000);
            if (!AGVSDBHelper.Init(Utility.SystemLogger, out var erMsg, EnsureCreated: true, Utility.SysConfigs.KGSDBConnectionString))
            {
                Utility.SystemLogger.Error(erMsg);

                Thread initTheard = new Thread(DBInitWorker);
                initTheard.Start();
            }
            else
            {
                Utility.SystemLogger.Info($"Init AGVs Database:{AGVSDBHelper.DBConnection} SUCCESS!!");
            }
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
        private void OpenAllModbusSimulators()
        {
            List<clsConverterPort> ports = DevicesManager.GetAllPorts();
            foreach (var port in ports)
            {
                frmAGVS_Modbus_Emulator emu = new frmAGVS_Modbus_Emulator(port)
                {
                    Text = $"AGV交握模擬-{port.Properties.ModbusServer_IP}:{port.Properties.ModbusServer_PORT}({port.PortNameWithEQName})"
                };
                emu.Show();
            }
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


        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            AppCloseConfirmDialog dialog = new AppCloseConfirmDialog();
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            Utility.SystemLogger.Info($"User {CurrentUser.Name} closed CIM APP", true);
            Thread.Sleep(1000);
            foreach (var item in DevicesManager.casstteConverters)
            {
                item.mcInterface?.Close();
            }

            Environment.Exit(0);
        }

        private void SysTimer_Tick(object sender, EventArgs e)
        {
            labSysTime.Text = DateTime.Now.ToString();
            labWebServerUrl.Text = CIMWebServer._url;
            labWebServerUrl.BackColor = CIMWebServer.Servering ? Color.White : Color.Red;
            ckbRemoteModeIndi.Checked = SECSState.IsRemote;
            cknOnlineModeIndi.Checked = SECSState.IsOnline;
            if (SECSState.IsRemote || SECSState.IsOnline == false)
            { clsAgvsAlarmDevice.AGVSLocal(); }
            labHotRun.Visible = Utility.IsHotRunMode;
            labS2F49QueueTimer.Text = S2F49TransferQueueOperator._timer.Elapsed.ToString() + $"(Queueing:{S2F49TransferQueueOperator.InQueueCount})";
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
                    ckbHotRunMode.Visible = toolStripComboBox_Emulators.Visible = toolStripMenuItem_AGVs_DB.Visible = false;
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
                    ckbHotRunMode.Visible = uscAlarmShow1.showAlarmResetBtn = toolStripComboBox_Emulators.Visible = toolStripMenuItem_AGVs_DB.Visible = true;
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

        private void ckbRemoteModeIndi_Click(object sender, EventArgs e)
        {
            if (Debugger.IsAttached)
            {
                SECSState.IsRemote = !SECSState.IsRemote;
            }
        }

        private void cknOnlineModeIndi_Click(object sender, EventArgs e)
        {
            DevicesManager.secs_host_for_mcs.SendMsg(new SecsMessage(2, 52)
            {
                SecsItem = Item.L(
                        Item.A("中文測試1_(AGV_中文)AHGBBBB")
                    )
            });
            if (Debugger.IsAttached)
            {
                SECSState.IsOnline = !SECSState.IsOnline;
            }
        }

        private void labCurrentEncodingName_Click(object sender, EventArgs e)
        {
            EncodingSettingDialog dialog = new EncodingSettingDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SetCurrentEncodingName();
            }

        }
        private void SetCurrentEncodingName()
        {
            labCurrentEncodingName.Text = $"{Utility.SysConfigs.SECS.ASCIIEncoding}({Utility.SysConfigs.SECS.SECESAEncoding.EncodingName})";

        }

        private void btnEditRegionName_Click(object sender, EventArgs e)
        {
            if (StaUsersManager.CurrentUser.Group == USER_GROUP.VISITOR)
                return;

            txbRegionNameEditInput.Visible = btnRegionNameEditedConfirm.Visible = btnCancelRegionNameEdit.Visible = true;
            labRegionName.Visible = false;
            txbRegionNameEditInput.Text = labRegionName.Text;
        }

        private void btnRegionNameEditedConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                txbRegionNameEditInput.Visible = btnRegionNameEditedConfirm.Visible = btnCancelRegionNameEdit.Visible = false;
                labRegionName.Visible = true;
                Utility.SysConfigs.RegionName = labRegionName.Text = txbRegionNameEditInput.Text;
                Utility.SaveConfigs();

                Utility.SystemLogger.Info($"User-{StaUsersManager.CurrentUser.Name} Change Region Name to [{Utility.SysConfigs.RegionName}]");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancelRegionNameEdit_Click(object sender, EventArgs e)
        {

            txbRegionNameEditInput.Visible = btnRegionNameEditedConfirm.Visible = btnCancelRegionNameEdit.Visible = false;
            labRegionName.Visible = true;
        }

        private void 警報器DIOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem_AGVs_DB_Click(object sender, EventArgs e)
        {
            if (AGVsDatabaseForm == null)
                AGVsDatabaseForm = new frmAGVsDatabaseBroswer();
            AGVsDatabaseForm.Show();
        }

        private void WebServerExceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CIMWebServer._simulateExceptionHappend = true;
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            try
            {

                var _WindowState = this.WindowState;
                Utility.SystemLogger.UIWindowState = _WindowState;
            }
            catch (Exception)
            {
            }
        }

        private void openAllModbusEmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAllModbusSimulators();
        }

        private async void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                throw new Exception("例外捕捉測試");
            });
        }

        private void labUnHandleExceptions_Click(object sender, EventArgs e)
        {
            frmUnHandleExceptionViewer exceptionViewer = new frmUnHandleExceptionViewer()
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            exceptionViewer.Show();
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            AlarmManager.AddAlarm(ALARM_CODES.AGVS_DDOS, "SECS");
            ShowDDOSNotifyDialog();
        }

        private void toolStripStatusLabel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                AGVSMessageHandler.DDOSRestoreInvoke();
            }
        }

        private void btnDisableS2F49TransgerQueue_Click(object sender, EventArgs e)
        {
            btnDisableS2F49TransgerQueue.CheckState = CheckState.Checked;
            btnEnableS2F49TransgerQueue.CheckState = CheckState.Unchecked;
            Utility.SysConfigs.S2F49QueuingConfigurations.Enable = false;
            Utility.SaveConfigs();

            S2F49TransferQueueOperator.logger.Info("使用者關閉S2F49 Transfer佇列功能");
        }

        private void btnEnableS2F49TransgerQueue_Click(object sender, EventArgs e)
        {
            btnDisableS2F49TransgerQueue.CheckState = CheckState.Unchecked;
            btnEnableS2F49TransgerQueue.CheckState = CheckState.Checked;
            Utility.SysConfigs.S2F49QueuingConfigurations.Enable = true;
            Utility.SaveConfigs();
            S2F49TransferQueueOperator.logger.Info("使用者啟用S2F49 Transfer佇列功能");
        }

        private void btnClearS2F49TransferQueueing_Click(object sender, EventArgs e)
        {
            S2F49TransferQueueOperator.ClearQueue();
            S2F49TransferQueueOperator.logger.Info("使用者操作[清空]S2F49 Transfer佇列訊息");
        }

        private void btnSendS2F49InQueueInstanly_Click(object sender, EventArgs e)
        {
            S2F49TransferQueueOperator.SendMessageInstanly();
            S2F49TransferQueueOperator.logger.Info("使用者操作[立即傳送]S2F49 Transfer佇列訊息");
        }

        private void btnSettingS2F49QueueingTimeWindow_Click(object sender, EventArgs e)
        {
            S2F49QueueTimeWindowSetupDialog dialog = new S2F49QueueTimeWindowSetupDialog();
            dialog.ShowDialog();
        }

        private void transferCommandListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransferCommandsViewer viewr = new frmTransferCommandsViewer();
            viewr.Show();
        }

        private void tlpSingleConvertsContainer_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}