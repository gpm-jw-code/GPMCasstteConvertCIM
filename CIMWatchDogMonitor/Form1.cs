using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIMWatchDogMonitor
{
    public partial class Form1 : Form
    {
        private NotifyIcon trayIcon;

        ModbusWatchDogWorker watchDogWorker = new ModbusWatchDogWorker();
        public Form1()
        {
            InitializeComponent();
            trayIcon = new NotifyIcon()
            {
                Icon = this.Icon,
                Visible = true,
                Text = this.Text
            };
            trayIcon.DoubleClick += TrayIcon_DoubleClick;
            trayIcon.ContextMenu = new ContextMenu();
            trayIcon.ContextMenu.MenuItems.Add(new MenuItem()
            {
                Text = "關閉",
            });
            trayIcon.ContextMenu.MenuItems[0].Click += (sender, e) =>
            {
                Environment.Exit(0);
            };

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModbusWatchDogWorker.ModbusWatchDog.OnDisconeect += ModbusWatchDog_OnDisconeect;
            dataGridView1.DataSource = watchDogWorker.WatchDogsList;
            try
            {
                watchDogWorker.StartWorkerAsync(UtilityTools.LoadModbusConnectionOptionsFromCIM());
                ShowBallonTip("CIM Watch Start Success");
            }
            catch (Exception ex)
            {
                ShowBallonTip(ex.Message, icon: ToolTipIcon.Error);
            }
        }

        private void ModbusWatchDog_OnDisconeect(object sender, string deviceName)
        {
            ShowBallonTip($"與{deviceName} 的Modbus連線中斷!", icon: ToolTipIcon.Warning);
        }

        private void ShowBallonTip(string message, string title = "CIM", ToolTipIcon icon = ToolTipIcon.Info)
        {
            trayIcon?.ShowBalloonTip(1, title, message, icon);

        }
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            // 當用戶雙擊系統托盤圖標時觸發的動作，比如顯示主窗口
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // 當窗口最小化時隱藏窗口
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            trayIcon.Visible = true;  // 確保程序退出時，圖標不留在系統托盤
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Invalidate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.Invalidate();
        }
    }
}
