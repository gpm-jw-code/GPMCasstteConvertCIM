using GPMCasstteConvertCIM.VirtualAGVSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.Emulators.UscAGVSModbusClientEmulator;

namespace GPMCasstteConvertCIM.Emulators
{
    public partial class frmDemo : Form
    {
        public class TaskItem
        {
            public AGVS_Dispath_Emulator.ACTION Action;
            public string Tag { get; set; } = "";
            public string Slot { get; set; } = "";

            public string Station { get; set; } = "";
        }

        private readonly UscAGVSModbusClientEmulator agvs_modbus_emu;

        string CarName;
        int AGV_ID;

        TaskItem BeforeLoad_Action = new TaskItem
        {
            Action = AGVS_Dispath_Emulator.ACTION.Unload,
        };

        TaskItem AfterUnload_Action = new TaskItem
        {
            Action = AGVS_Dispath_Emulator.ACTION.Load,
            Tag = "39"
        };


        TaskItem AGV_In_Action = new TaskItem()
        {
            Action = AGVS_Dispath_Emulator.ACTION.Parking,
            Slot = "7",
            Tag = "38",
            Station = "RACK_4_7|8|9"
        };
        TaskItem AGV_Out_Action = new TaskItem()
        {
            Action = AGVS_Dispath_Emulator.ACTION.Move,
            Tag = "37"
        };
        public frmDemo(UscAGVSModbusClientEmulator agvs_modbus_emu)
        {
            InitializeComponent();
            this.agvs_modbus_emu = agvs_modbus_emu;
        }

        private void cmbDemoAGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox_LoadDemo.Enabled = groupBox_UnloadDemo.Enabled = true;
            CarName = cmbDemoAGV.SelectedItem.ToString();
            AGV_ID = int.Parse(CarName.Split('_')[1]);
        }
        private void btnRunUnloadDemo_Click(object sender, EventArgs e)
        {
            if (!agvs_modbus_emu.STATE_IO_Port_Exist.State)
            {
                MessageBox.Show("轉換架上無貨物，禁止進行 UNLOAD!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            groupBox_LoadDemo.Enabled = groupBox_UnloadDemo.Enabled = false;
            UnloadDemoFlow();
        }
        private async void btnRunLoadDemo_Click(object sender, EventArgs e)
        {
            if (agvs_modbus_emu.STATE_IO_Port_Exist.State)
            {
                MessageBox.Show("轉換架上有貨物，禁止進行 LOAD!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            groupBox_LoadDemo.Enabled = groupBox_UnloadDemo.Enabled = false;
            LoadDemoFlow();
        }

        private void LoadDemoFlow()
        {
            clsAGVCState agvc = StaVirtualAGVS.AGVCList.FirstOrDefault(_agv => _agv.CarName == CarName);
            if (agvc == null)
            {
                MessageBox.Show($"{CarName} not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Task.Factory.StartNew(async () =>
            {
                //放貨前動作先派去取貨
                //await StaVirtualAGVS.TaskDispatcher.Move(CarName, AGV_ID, BeforeLoad_Action.Tag);
                bool success = await GO_TO_LD_ULD(agvc, LDULD_STATE.LOAD);

                Invoke(new Action(() =>
                {
                    groupBox_LoadDemo.Enabled = groupBox_UnloadDemo.Enabled = true;
                }));
            });
        }
        private void UnloadDemoFlow()
        {
            clsAGVCState agvc = StaVirtualAGVS.AGVCList.FirstOrDefault(_agv => _agv.CarName == CarName);
            if (agvc == null)
            {
                MessageBox.Show($"{CarName} not exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Task.Factory.StartNew(async () =>
            {

                bool success = await GO_TO_LD_ULD(agvc, LDULD_STATE.UNLOAD);
                //if (success)
                //    //取貨後動作
                //    await StaVirtualAGVS.TaskDispatcher.Move(CarName, AGV_ID, AfterUnload_Action.Tag);

                Invoke(new Action(() =>
                {
                    groupBox_LoadDemo.Enabled = groupBox_UnloadDemo.Enabled = true;
                }));

            });
        }


        private async Task<bool> GO_TO_LD_ULD(clsAGVCState agvc, LDULD_STATE ld_uld_action)
        {
            agvs_modbus_emu.LDULDHSCancel = new CancellationTokenSource();

            //派到到轉換架前
            await StaVirtualAGVS.TaskDispatcher.Move(CarName, AGV_ID, "37");
            await Wait_AGV_Arrival_Station(agvc, "37"); //等待AGV抵達二次定位點

            _ = Task.Factory.StartNew(() => agvs_modbus_emu.LoadUnloadHSSimulation(ld_uld_action));

            Utility.SystemLogger.Info("等待EQ READY");
            await EQ_READY();
            Utility.SystemLogger.Info("EQ READY");

            if (agvs_modbus_emu.LDULDHSCancel.IsCancellationRequested)
                return false;


            Utility.SystemLogger.Info("派送停車任務");
            await StaVirtualAGVS.TaskDispatcher.Park(CarName, AGV_ID, AGV_In_Action.Station, AGV_In_Action.Slot);
            await Wait_AGV_Arrival_Station(agvc, AGV_In_Action.Tag); //等待AGV侵入設備完成 //TODO 確認在Slot裡面的Tag
            agvs_modbus_emu.HS_IO_AGV_BUSY.State = false;

            Utility.SystemLogger.Info("等待 AGV_Ready_OFF");
            await AGV_Ready_OFF();
            Utility.SystemLogger.Info("等待 AGV_Ready_OFF");

            if (agvs_modbus_emu.LDULDHSCancel.IsCancellationRequested)
                return false;

            await Task.Delay(TimeSpan.FromSeconds(3));
            //退出設備
            await StaVirtualAGVS.TaskDispatcher.Move(CarName, AGV_ID, "37");
            await Wait_AGV_Arrival_Station(agvc, "37"); //等待AGV侵入設備完成
            agvs_modbus_emu.HS_IO_AGV_BUSY.State = false;

            return true;
        }

        private async Task AGV_Ready_OFF()
        {
            while (agvs_modbus_emu.HS_IO_AGV_AGV_READY.State)
            {
                try
                {
                    await Task.Delay(1, agvs_modbus_emu.LDULDHSCancel.Token);
                }
                catch (TaskCanceledException ex)
                {
                    return;
                }
            }
        }

        private async Task EQ_READY()
        {
            while (!agvs_modbus_emu.HS_IO_EQ_EQ_READY.State)
            {
                try
                {
                    await Task.Delay(1, agvs_modbus_emu.LDULDHSCancel.Token);
                }
                catch (TaskCanceledException ex)
                {
                    return;
                }
            }
        }

        private async Task Wait_AGV_Arrival_Station(clsAGVCState agvc, string stationName = "37")
        {
            Utility.SystemLogger.Info($"等待AGV抵達 {stationName}");

            while (agvc.RunState != clsAGVCState.RUN_STATE.IDLE | agvc.TagID != stationName)
            {
                Thread.Sleep(1);
                if (agvs_modbus_emu.LDULDHSCancel.IsCancellationRequested)
                {
                    return;
                }
            }
            Utility.SystemLogger.Info($"AGV抵達 {stationName}");

        }

        private void frmDemo_Load(object sender, EventArgs e)
        {

        }
    }
}
