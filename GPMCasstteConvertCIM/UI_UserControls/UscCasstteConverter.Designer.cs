namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscCasstteConverter
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            btnOpenMemoryTable = new Button();
            labNameDisplay = new Label();
            pnlBanner = new Panel();
            labPLCConnectState = new Label();
            labPLCMCAddress = new Label();
            labOpenModbusServerFom = new Label();
            btnDown = new Button();
            btnIDLE = new Button();
            btnRun = new Button();
            uscConverterPortStatus1 = new UscConverterPortStatus();
            uscConverterPortStatus2 = new UscConverterPortStatus();
            btnSoftwareEMO = new Button();
            btnAlarmReset = new Button();
            panel1 = new Panel();
            labInterfaceClock = new Label();
            pnlBanner.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // btnOpenMemoryTable
            // 
            btnOpenMemoryTable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpenMemoryTable.FlatStyle = FlatStyle.Flat;
            btnOpenMemoryTable.Location = new Point(1, 1);
            btnOpenMemoryTable.Name = "btnOpenMemoryTable";
            btnOpenMemoryTable.Size = new Size(103, 27);
            btnOpenMemoryTable.TabIndex = 21;
            btnOpenMemoryTable.Text = "Memory Table";
            btnOpenMemoryTable.UseVisualStyleBackColor = true;
            btnOpenMemoryTable.Click += btnOpenMemoryTable_Click;
            // 
            // labNameDisplay
            // 
            labNameDisplay.BackColor = Color.DarkSlateGray;
            labNameDisplay.BorderStyle = BorderStyle.FixedSingle;
            labNameDisplay.Dock = DockStyle.Left;
            labNameDisplay.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labNameDisplay.ForeColor = Color.Snow;
            labNameDisplay.Location = new Point(0, 0);
            labNameDisplay.Margin = new Padding(0);
            labNameDisplay.Name = "labNameDisplay";
            labNameDisplay.Size = new Size(105, 23);
            labNameDisplay.TabIndex = 26;
            labNameDisplay.Text = "轉換架 # 1";
            labNameDisplay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBanner
            // 
            pnlBanner.BackColor = Color.FromArgb(92, 155, 155);
            pnlBanner.BorderStyle = BorderStyle.Fixed3D;
            pnlBanner.Controls.Add(labPLCConnectState);
            pnlBanner.Controls.Add(labNameDisplay);
            pnlBanner.Controls.Add(labPLCMCAddress);
            pnlBanner.Controls.Add(labOpenModbusServerFom);
            pnlBanner.Dock = DockStyle.Top;
            pnlBanner.Location = new Point(0, 0);
            pnlBanner.Margin = new Padding(0);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(904, 27);
            pnlBanner.TabIndex = 29;
            // 
            // labPLCConnectState
            // 
            labPLCConnectState.AutoSize = true;
            labPLCConnectState.BackColor = Color.Transparent;
            labPLCConnectState.Dock = DockStyle.Right;
            labPLCConnectState.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labPLCConnectState.ForeColor = Color.Snow;
            labPLCConnectState.Location = new Point(571, 0);
            labPLCConnectState.Margin = new Padding(0);
            labPLCConnectState.Name = "labPLCConnectState";
            labPLCConnectState.Padding = new Padding(0, 4, 0, 0);
            labPLCConnectState.Size = new Size(100, 22);
            labPLCConnectState.TabIndex = 30;
            labPLCConnectState.Text = "DISCONNECT";
            labPLCConnectState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labPLCMCAddress
            // 
            labPLCMCAddress.AutoSize = true;
            labPLCMCAddress.BackColor = Color.Transparent;
            labPLCMCAddress.Dock = DockStyle.Right;
            labPLCMCAddress.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labPLCMCAddress.ForeColor = Color.Wheat;
            labPLCMCAddress.Location = new Point(671, 0);
            labPLCMCAddress.Margin = new Padding(0);
            labPLCMCAddress.Name = "labPLCMCAddress";
            labPLCMCAddress.Padding = new Padding(0, 6, 0, 0);
            labPLCMCAddress.Size = new Size(131, 21);
            labPLCMCAddress.TabIndex = 31;
            labPLCMCAddress.Text = "255.255.255.255:5123";
            labPLCMCAddress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labOpenModbusServerFom
            // 
            labOpenModbusServerFom.AutoSize = true;
            labOpenModbusServerFom.BackColor = Color.Transparent;
            labOpenModbusServerFom.Dock = DockStyle.Right;
            labOpenModbusServerFom.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labOpenModbusServerFom.ForeColor = Color.Black;
            labOpenModbusServerFom.Location = new Point(802, 0);
            labOpenModbusServerFom.Margin = new Padding(0);
            labOpenModbusServerFom.Name = "labOpenModbusServerFom";
            labOpenModbusServerFom.Padding = new Padding(0, 6, 0, 0);
            labOpenModbusServerFom.Size = new Size(98, 21);
            labOpenModbusServerFom.TabIndex = 32;
            labOpenModbusServerFom.Text = "Modbus Server";
            labOpenModbusServerFom.TextAlign = ContentAlignment.MiddleLeft;
            labOpenModbusServerFom.Click += labOpenModbusServerFom_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDown.BackColor = Color.Black;
            btnDown.FlatAppearance.BorderColor = Color.Black;
            btnDown.FlatAppearance.BorderSize = 2;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDown.ForeColor = Color.White;
            btnDown.Location = new Point(1, 296);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(103, 28);
            btnDown.TabIndex = 29;
            btnDown.Text = "DOWN";
            btnDown.UseVisualStyleBackColor = false;
            // 
            // btnIDLE
            // 
            btnIDLE.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIDLE.BackColor = Color.Black;
            btnIDLE.FlatAppearance.BorderColor = Color.Black;
            btnIDLE.FlatAppearance.BorderSize = 2;
            btnIDLE.FlatStyle = FlatStyle.Flat;
            btnIDLE.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnIDLE.ForeColor = Color.White;
            btnIDLE.Location = new Point(1, 267);
            btnIDLE.Name = "btnIDLE";
            btnIDLE.Size = new Size(103, 28);
            btnIDLE.TabIndex = 28;
            btnIDLE.Text = "IDLE";
            btnIDLE.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRun.BackColor = Color.Black;
            btnRun.FlatAppearance.BorderColor = Color.Black;
            btnRun.FlatAppearance.BorderSize = 2;
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRun.ForeColor = Color.White;
            btnRun.Location = new Point(1, 238);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(103, 28);
            btnRun.TabIndex = 27;
            btnRun.Text = "RUN";
            btnRun.UseVisualStyleBackColor = false;
            // 
            // uscConverterPortStatus1
            // 
            uscConverterPortStatus1.BackColor = SystemColors.InactiveCaption;
            uscConverterPortStatus1.BorderStyle = BorderStyle.FixedSingle;
            uscConverterPortStatus1.Location = new Point(3, 29);
            uscConverterPortStatus1.Name = "uscConverterPortStatus1";
            uscConverterPortStatus1.portData = null;
            uscConverterPortStatus1.Size = new Size(392, 322);
            uscConverterPortStatus1.TabIndex = 27;
            // 
            // uscConverterPortStatus2
            // 
            uscConverterPortStatus2.BackColor = SystemColors.InactiveCaption;
            uscConverterPortStatus2.BorderStyle = BorderStyle.FixedSingle;
            uscConverterPortStatus2.Location = new Point(401, 29);
            uscConverterPortStatus2.Name = "uscConverterPortStatus2";
            uscConverterPortStatus2.portData = null;
            uscConverterPortStatus2.Size = new Size(392, 322);
            uscConverterPortStatus2.TabIndex = 28;
            // 
            // btnSoftwareEMO
            // 
            btnSoftwareEMO.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSoftwareEMO.BackColor = Color.Red;
            btnSoftwareEMO.ForeColor = Color.White;
            btnSoftwareEMO.Location = new Point(-1, 34);
            btnSoftwareEMO.Name = "btnSoftwareEMO";
            btnSoftwareEMO.Size = new Size(109, 34);
            btnSoftwareEMO.TabIndex = 30;
            btnSoftwareEMO.Text = "EMO";
            btnSoftwareEMO.UseVisualStyleBackColor = false;
            btnSoftwareEMO.Visible = false;
            btnSoftwareEMO.Click += btnSoftwareEMO_Click;
            // 
            // btnAlarmReset
            // 
            btnAlarmReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAlarmReset.BackColor = SystemColors.Control;
            btnAlarmReset.ForeColor = Color.Black;
            btnAlarmReset.Location = new Point(-1, 67);
            btnAlarmReset.Name = "btnAlarmReset";
            btnAlarmReset.Size = new Size(109, 34);
            btnAlarmReset.TabIndex = 31;
            btnAlarmReset.Text = "異常Reset";
            btnAlarmReset.UseVisualStyleBackColor = false;
            btnAlarmReset.Visible = false;
            btnAlarmReset.Click += btnAlarmReset_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labInterfaceClock);
            panel1.Controls.Add(btnOpenMemoryTable);
            panel1.Controls.Add(btnAlarmReset);
            panel1.Controls.Add(btnDown);
            panel1.Controls.Add(btnSoftwareEMO);
            panel1.Controls.Add(btnIDLE);
            panel1.Controls.Add(btnRun);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(797, 27);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(107, 330);
            panel1.TabIndex = 32;
            // 
            // labInterfaceClock
            // 
            labInterfaceClock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labInterfaceClock.BackColor = Color.Red;
            labInterfaceClock.BorderStyle = BorderStyle.Fixed3D;
            labInterfaceClock.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labInterfaceClock.ForeColor = Color.White;
            labInterfaceClock.Location = new Point(1, 199);
            labInterfaceClock.Name = "labInterfaceClock";
            labInterfaceClock.Size = new Size(103, 29);
            labInterfaceClock.TabIndex = 32;
            labInterfaceClock.Text = "-1";
            labInterfaceClock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UscCasstteConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Controls.Add(pnlBanner);
            Controls.Add(uscConverterPortStatus2);
            Controls.Add(uscConverterPortStatus1);
            Name = "UscCasstteConverter";
            Size = new Size(904, 357);
            Load += UscCasstteConverter_Load;
            pnlBanner.ResumeLayout(false);
            pnlBanner.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenMemoryTable;
        private Label labNameDisplay;
        private Panel pnlBanner;
        private Button btnDown;
        private Button btnIDLE;
        private Button btnRun;
        private Label labPLCConnectState;
        private Label labPLCMCAddress;
        private UscConverterPortStatus uscConverterPortStatus1;
        private UscConverterPortStatus uscConverterPortStatus2;
        private Button btnSoftwareEMO;
        private Button btnAlarmReset;
        private Label labOpenModbusServerFom;
        private Panel panel1;
        private Label labInterfaceClock;
    }
}
