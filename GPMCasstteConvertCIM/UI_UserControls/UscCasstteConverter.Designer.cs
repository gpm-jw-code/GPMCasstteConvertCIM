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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnOpenMemoryTable = new System.Windows.Forms.Button();
            this.btnOpenConvertPLCSimulator = new System.Windows.Forms.Button();
            this.labNameDisplay = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.labPLCConnectState = new System.Windows.Forms.Label();
            this.labPLCMCAddress = new System.Windows.Forms.Label();
            this.labOpenModbusServerFom = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnIDLE = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.uscConverterPortStatus1 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
            this.uscConverterPortStatus2 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
            this.btnSoftwareEMO = new System.Windows.Forms.Button();
            this.btnAlarmReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlBanner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnOpenMemoryTable
            // 
            this.btnOpenMemoryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMemoryTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMemoryTable.Location = new System.Drawing.Point(1, 1);
            this.btnOpenMemoryTable.Name = "btnOpenMemoryTable";
            this.btnOpenMemoryTable.Size = new System.Drawing.Size(103, 27);
            this.btnOpenMemoryTable.TabIndex = 21;
            this.btnOpenMemoryTable.Text = "Memory Table";
            this.btnOpenMemoryTable.UseVisualStyleBackColor = true;
            this.btnOpenMemoryTable.Click += new System.EventHandler(this.btnOpenMemoryTable_Click);
            // 
            // btnOpenConvertPLCSimulator
            // 
            this.btnOpenConvertPLCSimulator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenConvertPLCSimulator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenConvertPLCSimulator.Location = new System.Drawing.Point(1, 29);
            this.btnOpenConvertPLCSimulator.Name = "btnOpenConvertPLCSimulator";
            this.btnOpenConvertPLCSimulator.Size = new System.Drawing.Size(103, 29);
            this.btnOpenConvertPLCSimulator.TabIndex = 22;
            this.btnOpenConvertPLCSimulator.Text = "轉換架模擬器";
            this.btnOpenConvertPLCSimulator.UseVisualStyleBackColor = true;
            this.btnOpenConvertPLCSimulator.Click += new System.EventHandler(this.btnOpenConvertPLCSimulator_Click);
            // 
            // labNameDisplay
            // 
            this.labNameDisplay.BackColor = System.Drawing.Color.DarkSlateGray;
            this.labNameDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labNameDisplay.Dock = System.Windows.Forms.DockStyle.Left;
            this.labNameDisplay.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labNameDisplay.ForeColor = System.Drawing.Color.Snow;
            this.labNameDisplay.Location = new System.Drawing.Point(0, 0);
            this.labNameDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.labNameDisplay.Name = "labNameDisplay";
            this.labNameDisplay.Size = new System.Drawing.Size(105, 23);
            this.labNameDisplay.TabIndex = 26;
            this.labNameDisplay.Text = "轉換架 # 1";
            this.labNameDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBanner
            // 
            this.pnlBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.pnlBanner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBanner.Controls.Add(this.labPLCConnectState);
            this.pnlBanner.Controls.Add(this.labNameDisplay);
            this.pnlBanner.Controls.Add(this.labPLCMCAddress);
            this.pnlBanner.Controls.Add(this.labOpenModbusServerFom);
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(880, 27);
            this.pnlBanner.TabIndex = 29;
            // 
            // labPLCConnectState
            // 
            this.labPLCConnectState.AutoSize = true;
            this.labPLCConnectState.BackColor = System.Drawing.Color.Transparent;
            this.labPLCConnectState.Dock = System.Windows.Forms.DockStyle.Right;
            this.labPLCConnectState.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labPLCConnectState.ForeColor = System.Drawing.Color.Snow;
            this.labPLCConnectState.Location = new System.Drawing.Point(547, 0);
            this.labPLCConnectState.Margin = new System.Windows.Forms.Padding(0);
            this.labPLCConnectState.Name = "labPLCConnectState";
            this.labPLCConnectState.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labPLCConnectState.Size = new System.Drawing.Size(100, 22);
            this.labPLCConnectState.TabIndex = 30;
            this.labPLCConnectState.Text = "DISCONNECT";
            this.labPLCConnectState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labPLCMCAddress
            // 
            this.labPLCMCAddress.AutoSize = true;
            this.labPLCMCAddress.BackColor = System.Drawing.Color.Transparent;
            this.labPLCMCAddress.Dock = System.Windows.Forms.DockStyle.Right;
            this.labPLCMCAddress.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labPLCMCAddress.ForeColor = System.Drawing.Color.Wheat;
            this.labPLCMCAddress.Location = new System.Drawing.Point(647, 0);
            this.labPLCMCAddress.Margin = new System.Windows.Forms.Padding(0);
            this.labPLCMCAddress.Name = "labPLCMCAddress";
            this.labPLCMCAddress.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labPLCMCAddress.Size = new System.Drawing.Size(131, 21);
            this.labPLCMCAddress.TabIndex = 31;
            this.labPLCMCAddress.Text = "255.255.255.255:5123";
            this.labPLCMCAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labOpenModbusServerFom
            // 
            this.labOpenModbusServerFom.AutoSize = true;
            this.labOpenModbusServerFom.BackColor = System.Drawing.Color.Transparent;
            this.labOpenModbusServerFom.Dock = System.Windows.Forms.DockStyle.Right;
            this.labOpenModbusServerFom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labOpenModbusServerFom.ForeColor = System.Drawing.Color.Black;
            this.labOpenModbusServerFom.Location = new System.Drawing.Point(778, 0);
            this.labOpenModbusServerFom.Margin = new System.Windows.Forms.Padding(0);
            this.labOpenModbusServerFom.Name = "labOpenModbusServerFom";
            this.labOpenModbusServerFom.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labOpenModbusServerFom.Size = new System.Drawing.Size(98, 21);
            this.labOpenModbusServerFom.TabIndex = 32;
            this.labOpenModbusServerFom.Text = "Modbus Server";
            this.labOpenModbusServerFom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labOpenModbusServerFom.Click += new System.EventHandler(this.labOpenModbusServerFom_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDown.BackColor = System.Drawing.Color.Black;
            this.btnDown.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDown.FlatAppearance.BorderSize = 2;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(1, 198);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(103, 28);
            this.btnDown.TabIndex = 29;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // btnIDLE
            // 
            this.btnIDLE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIDLE.BackColor = System.Drawing.Color.Black;
            this.btnIDLE.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnIDLE.FlatAppearance.BorderSize = 2;
            this.btnIDLE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIDLE.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnIDLE.ForeColor = System.Drawing.Color.White;
            this.btnIDLE.Location = new System.Drawing.Point(1, 169);
            this.btnIDLE.Name = "btnIDLE";
            this.btnIDLE.Size = new System.Drawing.Size(103, 28);
            this.btnIDLE.TabIndex = 28;
            this.btnIDLE.Text = "IDLE";
            this.btnIDLE.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.BackColor = System.Drawing.Color.Black;
            this.btnRun.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRun.FlatAppearance.BorderSize = 2;
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(1, 140);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(103, 28);
            this.btnRun.TabIndex = 27;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // uscConverterPortStatus1
            // 
            this.uscConverterPortStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uscConverterPortStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscConverterPortStatus1.Location = new System.Drawing.Point(3, 32);
            this.uscConverterPortStatus1.Name = "uscConverterPortStatus1";
            this.uscConverterPortStatus1.portData = null;
            this.uscConverterPortStatus1.Size = new System.Drawing.Size(379, 224);
            this.uscConverterPortStatus1.TabIndex = 27;
            // 
            // uscConverterPortStatus2
            // 
            this.uscConverterPortStatus2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.uscConverterPortStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscConverterPortStatus2.Location = new System.Drawing.Point(388, 32);
            this.uscConverterPortStatus2.Name = "uscConverterPortStatus2";
            this.uscConverterPortStatus2.portData = null;
            this.uscConverterPortStatus2.Size = new System.Drawing.Size(379, 224);
            this.uscConverterPortStatus2.TabIndex = 28;
            // 
            // btnSoftwareEMO
            // 
            this.btnSoftwareEMO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoftwareEMO.BackColor = System.Drawing.Color.Red;
            this.btnSoftwareEMO.ForeColor = System.Drawing.Color.White;
            this.btnSoftwareEMO.Location = new System.Drawing.Point(-3, 58);
            this.btnSoftwareEMO.Name = "btnSoftwareEMO";
            this.btnSoftwareEMO.Size = new System.Drawing.Size(103, 34);
            this.btnSoftwareEMO.TabIndex = 30;
            this.btnSoftwareEMO.Text = "EMO";
            this.btnSoftwareEMO.UseVisualStyleBackColor = false;
            this.btnSoftwareEMO.Visible = false;
            this.btnSoftwareEMO.Click += new System.EventHandler(this.btnSoftwareEMO_Click);
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlarmReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnAlarmReset.ForeColor = System.Drawing.Color.Black;
            this.btnAlarmReset.Location = new System.Drawing.Point(-3, 91);
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.Size = new System.Drawing.Size(103, 34);
            this.btnAlarmReset.TabIndex = 31;
            this.btnAlarmReset.Text = "異常Reset";
            this.btnAlarmReset.UseVisualStyleBackColor = false;
            this.btnAlarmReset.Visible = false;
            this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnOpenMemoryTable);
            this.panel1.Controls.Add(this.btnAlarmReset);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnOpenConvertPLCSimulator);
            this.panel1.Controls.Add(this.btnSoftwareEMO);
            this.panel1.Controls.Add(this.btnIDLE);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(773, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 232);
            this.panel1.TabIndex = 32;
            // 
            // UscCasstteConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.uscConverterPortStatus2);
            this.Controls.Add(this.uscConverterPortStatus1);
            this.Name = "UscCasstteConverter";
            this.Size = new System.Drawing.Size(880, 259);
            this.Load += new System.EventHandler(this.UscCasstteConverter_Load);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenMemoryTable;
        private Button btnOpenConvertPLCSimulator;
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
    }
}
