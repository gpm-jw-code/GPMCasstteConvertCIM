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
            this.labNameDisplay = new System.Windows.Forms.Label();
            this.pnlBanner = new System.Windows.Forms.Panel();
            this.labPLCConnectState = new System.Windows.Forms.Label();
            this.labPLCMCAddress = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnIDLE = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.uscConverterPortStatus1 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
            this.uscConverterPortStatus2 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
            this.btnSoftwareEMO = new System.Windows.Forms.Button();
            this.btnAlarmReset = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labInterfaceClock = new System.Windows.Forms.Label();
            this.pnlBanner.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // btnOpenMemoryTable
            // 
            this.btnOpenMemoryTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMemoryTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMemoryTable.Location = new System.Drawing.Point(1, 1);
            this.btnOpenMemoryTable.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenMemoryTable.Name = "btnOpenMemoryTable";
            this.btnOpenMemoryTable.Size = new System.Drawing.Size(132, 34);
            this.btnOpenMemoryTable.TabIndex = 21;
            this.btnOpenMemoryTable.Text = "Memory Table";
            this.btnOpenMemoryTable.UseVisualStyleBackColor = true;
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
            this.labNameDisplay.Size = new System.Drawing.Size(134, 29);
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
            this.pnlBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBanner.Location = new System.Drawing.Point(0, 0);
            this.pnlBanner.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBanner.Name = "pnlBanner";
            this.pnlBanner.Size = new System.Drawing.Size(1162, 33);
            this.pnlBanner.TabIndex = 29;
            // 
            // labPLCConnectState
            // 
            this.labPLCConnectState.AutoSize = true;
            this.labPLCConnectState.BackColor = System.Drawing.Color.Transparent;
            this.labPLCConnectState.Dock = System.Windows.Forms.DockStyle.Right;
            this.labPLCConnectState.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labPLCConnectState.ForeColor = System.Drawing.Color.Snow;
            this.labPLCConnectState.Location = new System.Drawing.Point(868, 0);
            this.labPLCConnectState.Margin = new System.Windows.Forms.Padding(0);
            this.labPLCConnectState.Name = "labPLCConnectState";
            this.labPLCConnectState.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labPLCConnectState.Size = new System.Drawing.Size(121, 27);
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
            this.labPLCMCAddress.Location = new System.Drawing.Point(989, 0);
            this.labPLCMCAddress.Margin = new System.Windows.Forms.Padding(0);
            this.labPLCMCAddress.Name = "labPLCMCAddress";
            this.labPLCMCAddress.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.labPLCMCAddress.Size = new System.Drawing.Size(169, 27);
            this.labPLCMCAddress.TabIndex = 31;
            this.labPLCMCAddress.Text = "255.255.255.255:5123";
            this.labPLCMCAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnDown.Location = new System.Drawing.Point(1, 377);
            this.btnDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(132, 35);
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
            this.btnIDLE.Location = new System.Drawing.Point(1, 340);
            this.btnIDLE.Margin = new System.Windows.Forms.Padding(4);
            this.btnIDLE.Name = "btnIDLE";
            this.btnIDLE.Size = new System.Drawing.Size(132, 35);
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
            this.btnRun.Location = new System.Drawing.Point(1, 303);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(132, 35);
            this.btnRun.TabIndex = 27;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = false;
            // 
            // uscConverterPortStatus1
            // 
            this.uscConverterPortStatus1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.uscConverterPortStatus1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscConverterPortStatus1.CstCVPort = null;
            this.uscConverterPortStatus1.Location = new System.Drawing.Point(4, 37);
            this.uscConverterPortStatus1.Margin = new System.Windows.Forms.Padding(5);
            this.uscConverterPortStatus1.Name = "uscConverterPortStatus1";
            this.uscConverterPortStatus1.Size = new System.Drawing.Size(503, 407);
            this.uscConverterPortStatus1.TabIndex = 27;
            // 
            // uscConverterPortStatus2
            // 
            this.uscConverterPortStatus2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.uscConverterPortStatus2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscConverterPortStatus2.CstCVPort = null;
            this.uscConverterPortStatus2.Location = new System.Drawing.Point(516, 37);
            this.uscConverterPortStatus2.Margin = new System.Windows.Forms.Padding(5);
            this.uscConverterPortStatus2.Name = "uscConverterPortStatus2";
            this.uscConverterPortStatus2.Size = new System.Drawing.Size(503, 407);
            this.uscConverterPortStatus2.TabIndex = 28;
            // 
            // btnSoftwareEMO
            // 
            this.btnSoftwareEMO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoftwareEMO.BackColor = System.Drawing.Color.Red;
            this.btnSoftwareEMO.ForeColor = System.Drawing.Color.White;
            this.btnSoftwareEMO.Location = new System.Drawing.Point(-123, 43);
            this.btnSoftwareEMO.Margin = new System.Windows.Forms.Padding(4);
            this.btnSoftwareEMO.Name = "btnSoftwareEMO";
            this.btnSoftwareEMO.Size = new System.Drawing.Size(140, 43);
            this.btnSoftwareEMO.TabIndex = 30;
            this.btnSoftwareEMO.Text = "EMO";
            this.btnSoftwareEMO.UseVisualStyleBackColor = false;
            this.btnSoftwareEMO.Visible = false;
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlarmReset.BackColor = System.Drawing.SystemColors.Control;
            this.btnAlarmReset.ForeColor = System.Drawing.Color.Black;
            this.btnAlarmReset.Location = new System.Drawing.Point(-123, 85);
            this.btnAlarmReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.Size = new System.Drawing.Size(140, 43);
            this.btnAlarmReset.TabIndex = 31;
            this.btnAlarmReset.Text = "異常Reset";
            this.btnAlarmReset.UseVisualStyleBackColor = false;
            this.btnAlarmReset.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labInterfaceClock);
            this.panel1.Controls.Add(this.btnOpenMemoryTable);
            this.panel1.Controls.Add(this.btnAlarmReset);
            this.panel1.Controls.Add(this.btnDown);
            this.panel1.Controls.Add(this.btnSoftwareEMO);
            this.panel1.Controls.Add(this.btnIDLE);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1025, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 419);
            this.panel1.TabIndex = 32;
            // 
            // labInterfaceClock
            // 
            this.labInterfaceClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labInterfaceClock.BackColor = System.Drawing.Color.Red;
            this.labInterfaceClock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labInterfaceClock.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labInterfaceClock.ForeColor = System.Drawing.Color.White;
            this.labInterfaceClock.Location = new System.Drawing.Point(1, 254);
            this.labInterfaceClock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labInterfaceClock.Name = "labInterfaceClock";
            this.labInterfaceClock.Size = new System.Drawing.Size(132, 37);
            this.labInterfaceClock.TabIndex = 32;
            this.labInterfaceClock.Text = "-1";
            this.labInterfaceClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UscCasstteConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBanner);
            this.Controls.Add(this.uscConverterPortStatus2);
            this.Controls.Add(this.uscConverterPortStatus1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UscCasstteConverter";
            this.Size = new System.Drawing.Size(1162, 452);
            this.pnlBanner.ResumeLayout(false);
            this.pnlBanner.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private Panel panel1;
        private Label labInterfaceClock;
    }
}
