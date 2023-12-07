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
            pnlEqNameEdit = new Panel();
            btnModifyEqNameConfirm = new Button();
            button3 = new Button();
            button5 = new Button();
            button6 = new Button();
            txbEQNameEditInput = new TextBox();
            labPLCConnectState = new Label();
            labPLCMCAddress = new Label();
            btnDown = new Button();
            btnIDLE = new Button();
            btnRun = new Button();
            uscConverterPortStatus2 = new UscConverterPortStatus();
            btnSoftwareEMO = new Button();
            btnAlarmReset = new Button();
            panel1 = new Panel();
            label1 = new Label();
            labInterfaceClock = new Label();
            uscConverterPortStatus1 = new UscConverterPortStatus();
            pnlBanner.SuspendLayout();
            pnlEqNameEdit.SuspendLayout();
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
            labNameDisplay.Dock = DockStyle.Fill;
            labNameDisplay.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labNameDisplay.ForeColor = Color.Snow;
            labNameDisplay.Location = new Point(0, 0);
            labNameDisplay.Margin = new Padding(0);
            labNameDisplay.Name = "labNameDisplay";
            labNameDisplay.Size = new Size(1138, 30);
            labNameDisplay.TabIndex = 26;
            labNameDisplay.Text = "轉換架 # 1";
            labNameDisplay.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlBanner
            // 
            pnlBanner.BackColor = Color.FromArgb(92, 155, 155);
            pnlBanner.BorderStyle = BorderStyle.Fixed3D;
            pnlBanner.Controls.Add(pnlEqNameEdit);
            pnlBanner.Controls.Add(labPLCConnectState);
            pnlBanner.Controls.Add(labPLCMCAddress);
            pnlBanner.Controls.Add(labNameDisplay);
            pnlBanner.Dock = DockStyle.Top;
            pnlBanner.Location = new Point(0, 0);
            pnlBanner.Margin = new Padding(0);
            pnlBanner.Name = "pnlBanner";
            pnlBanner.Size = new Size(1142, 34);
            pnlBanner.TabIndex = 29;
            // 
            // pnlEqNameEdit
            // 
            pnlEqNameEdit.AutoScroll = true;
            pnlEqNameEdit.BorderStyle = BorderStyle.FixedSingle;
            pnlEqNameEdit.Controls.Add(btnModifyEqNameConfirm);
            pnlEqNameEdit.Controls.Add(button3);
            pnlEqNameEdit.Controls.Add(button5);
            pnlEqNameEdit.Controls.Add(button6);
            pnlEqNameEdit.Controls.Add(txbEQNameEditInput);
            pnlEqNameEdit.Dock = DockStyle.Left;
            pnlEqNameEdit.Location = new Point(0, 0);
            pnlEqNameEdit.Margin = new Padding(0);
            pnlEqNameEdit.Name = "pnlEqNameEdit";
            pnlEqNameEdit.Size = new Size(295, 30);
            pnlEqNameEdit.TabIndex = 33;
            pnlEqNameEdit.Visible = false;
            // 
            // btnModifyEqNameConfirm
            // 
            btnModifyEqNameConfirm.BackColor = SystemColors.Control;
            btnModifyEqNameConfirm.Dock = DockStyle.Left;
            btnModifyEqNameConfirm.FlatStyle = FlatStyle.Flat;
            btnModifyEqNameConfirm.ForeColor = Color.Black;
            btnModifyEqNameConfirm.Location = new Point(185, 0);
            btnModifyEqNameConfirm.Name = "btnModifyEqNameConfirm";
            btnModifyEqNameConfirm.Size = new Size(103, 28);
            btnModifyEqNameConfirm.TabIndex = 21;
            btnModifyEqNameConfirm.Text = "修改";
            btnModifyEqNameConfirm.UseVisualStyleBackColor = false;
            btnModifyEqNameConfirm.Click += btnModifyEqNameConfirm_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.Black;
            button3.FlatAppearance.BorderColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(94, 230);
            button3.Name = "button3";
            button3.Size = new Size(103, 28);
            button3.TabIndex = 29;
            button3.Text = "DOWN";
            button3.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.BackColor = Color.Black;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(94, 201);
            button5.Name = "button5";
            button5.Size = new Size(103, 28);
            button5.TabIndex = 28;
            button5.Text = "IDLE";
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.BackColor = Color.Black;
            button6.FlatAppearance.BorderColor = Color.White;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(94, 172);
            button6.Name = "button6";
            button6.Size = new Size(103, 28);
            button6.TabIndex = 27;
            button6.Text = "RUN";
            button6.UseVisualStyleBackColor = false;
            // 
            // txbEQNameEditInput
            // 
            txbEQNameEditInput.AcceptsReturn = true;
            txbEQNameEditInput.AcceptsTab = true;
            txbEQNameEditInput.BackColor = Color.Black;
            txbEQNameEditInput.Dock = DockStyle.Left;
            txbEQNameEditInput.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            txbEQNameEditInput.ForeColor = Color.White;
            txbEQNameEditInput.HideSelection = false;
            txbEQNameEditInput.Location = new Point(0, 0);
            txbEQNameEditInput.Name = "txbEQNameEditInput";
            txbEQNameEditInput.PlaceholderText = "輸入設備名稱";
            txbEQNameEditInput.Size = new Size(185, 28);
            txbEQNameEditInput.TabIndex = 32;
            // 
            // labPLCConnectState
            // 
            labPLCConnectState.BackColor = Color.Transparent;
            labPLCConnectState.BorderStyle = BorderStyle.FixedSingle;
            labPLCConnectState.Dock = DockStyle.Right;
            labPLCConnectState.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labPLCConnectState.ForeColor = Color.Snow;
            labPLCConnectState.Location = new Point(857, 0);
            labPLCConnectState.Margin = new Padding(0);
            labPLCConnectState.Name = "labPLCConnectState";
            labPLCConnectState.Padding = new Padding(0, 4, 0, 0);
            labPLCConnectState.Size = new Size(121, 30);
            labPLCConnectState.TabIndex = 30;
            labPLCConnectState.Text = "DISCONNECT";
            labPLCConnectState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPLCMCAddress
            // 
            labPLCMCAddress.BackColor = Color.Transparent;
            labPLCMCAddress.BorderStyle = BorderStyle.FixedSingle;
            labPLCMCAddress.Dock = DockStyle.Right;
            labPLCMCAddress.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labPLCMCAddress.ForeColor = Color.Wheat;
            labPLCMCAddress.Location = new Point(978, 0);
            labPLCMCAddress.Margin = new Padding(0);
            labPLCMCAddress.Name = "labPLCMCAddress";
            labPLCMCAddress.Padding = new Padding(0, 6, 0, 0);
            labPLCMCAddress.Size = new Size(160, 30);
            labPLCMCAddress.TabIndex = 31;
            labPLCMCAddress.Text = "255.255.255.255:5123";
            labPLCMCAddress.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDown.BackColor = Color.Black;
            btnDown.FlatAppearance.BorderColor = Color.White;
            btnDown.FlatStyle = FlatStyle.Flat;
            btnDown.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDown.ForeColor = Color.White;
            btnDown.Location = new Point(1, 322);
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
            btnIDLE.FlatAppearance.BorderColor = Color.White;
            btnIDLE.FlatStyle = FlatStyle.Flat;
            btnIDLE.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnIDLE.ForeColor = Color.White;
            btnIDLE.Location = new Point(1, 293);
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
            btnRun.FlatAppearance.BorderColor = Color.White;
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRun.ForeColor = Color.White;
            btnRun.Location = new Point(1, 264);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(103, 28);
            btnRun.TabIndex = 27;
            btnRun.Text = "RUN";
            btnRun.UseVisualStyleBackColor = false;
            // 
            // uscConverterPortStatus2
            // 
            uscConverterPortStatus2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uscConverterPortStatus2.AutoScroll = true;
            uscConverterPortStatus2.BackColor = Color.DarkSlateGray;
            uscConverterPortStatus2.BorderStyle = BorderStyle.Fixed3D;
            uscConverterPortStatus2.CstCVPort = null;
            uscConverterPortStatus2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uscConverterPortStatus2.ForeColor = Color.White;
            uscConverterPortStatus2.Location = new Point(497, 39);
            uscConverterPortStatus2.Name = "uscConverterPortStatus2";
            uscConverterPortStatus2.Size = new Size(479, 346);
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
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labInterfaceClock);
            panel1.Controls.Add(btnOpenMemoryTable);
            panel1.Controls.Add(btnAlarmReset);
            panel1.Controls.Add(btnDown);
            panel1.Controls.Add(btnSoftwareEMO);
            panel1.Controls.Add(btnIDLE);
            panel1.Controls.Add(btnRun);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1035, 34);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(107, 356);
            panel1.TabIndex = 32;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(0, 204);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 6, 0, 0);
            label1.Size = new Size(90, 21);
            label1.TabIndex = 33;
            label1.Text = "Interface Clock";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labInterfaceClock
            // 
            labInterfaceClock.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labInterfaceClock.BackColor = Color.Red;
            labInterfaceClock.BorderStyle = BorderStyle.Fixed3D;
            labInterfaceClock.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labInterfaceClock.ForeColor = Color.White;
            labInterfaceClock.Location = new Point(1, 225);
            labInterfaceClock.Name = "labInterfaceClock";
            labInterfaceClock.Size = new Size(103, 29);
            labInterfaceClock.TabIndex = 32;
            labInterfaceClock.Text = "-1";
            labInterfaceClock.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // uscConverterPortStatus1
            // 
            uscConverterPortStatus1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            uscConverterPortStatus1.AutoScroll = true;
            uscConverterPortStatus1.BackColor = Color.DarkSlateGray;
            uscConverterPortStatus1.BorderStyle = BorderStyle.Fixed3D;
            uscConverterPortStatus1.CstCVPort = null;
            uscConverterPortStatus1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uscConverterPortStatus1.ForeColor = Color.White;
            uscConverterPortStatus1.Location = new Point(8, 39);
            uscConverterPortStatus1.Name = "uscConverterPortStatus1";
            uscConverterPortStatus1.Size = new Size(479, 346);
            uscConverterPortStatus1.TabIndex = 27;
            // 
            // UscCasstteConverter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(64, 64, 64);
            Controls.Add(panel1);
            Controls.Add(pnlBanner);
            Controls.Add(uscConverterPortStatus2);
            Controls.Add(uscConverterPortStatus1);
            ForeColor = Color.DarkKhaki;
            Name = "UscCasstteConverter";
            Size = new Size(1142, 390);
            Load += UscCasstteConverter_Load;
            pnlBanner.ResumeLayout(false);
            pnlEqNameEdit.ResumeLayout(false);
            pnlEqNameEdit.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private UscConverterPortStatus uscConverterPortStatus2;
        private Button btnSoftwareEMO;
        private Button btnAlarmReset;
        private Panel panel1;
        private Label labInterfaceClock;
        private TextBox txbEQNameEditInput;
        private Panel pnlEqNameEdit;
        private Button btnModifyEqNameConfirm;
        private Button button3;
        private Button button5;
        private Button button6;
        private Label label1;
        private UscConverterPortStatus uscConverterPortStatus1;
    }
}
