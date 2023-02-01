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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labPLCConnectState = new System.Windows.Forms.Label();
            this.labPLCMCAddress = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnIDLE = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.uscConverterPortStatus1 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
            this.uscConverterPortStatus2 = new GPMCasstteConvertCIM.UI_UserControls.UscConverterPortStatus();
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
            this.btnOpenMemoryTable.Location = new System.Drawing.Point(773, 33);
            this.btnOpenMemoryTable.Name = "btnOpenMemoryTable";
            this.btnOpenMemoryTable.Size = new System.Drawing.Size(103, 32);
            this.btnOpenMemoryTable.TabIndex = 21;
            this.btnOpenMemoryTable.Text = "Memory Table";
            this.btnOpenMemoryTable.UseVisualStyleBackColor = true;
            this.btnOpenMemoryTable.Click += new System.EventHandler(this.btnOpenMemoryTable_Click);
            // 
            // btnOpenConvertPLCSimulator
            // 
            this.btnOpenConvertPLCSimulator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenConvertPLCSimulator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenConvertPLCSimulator.Location = new System.Drawing.Point(773, 71);
            this.btnOpenConvertPLCSimulator.Name = "btnOpenConvertPLCSimulator";
            this.btnOpenConvertPLCSimulator.Size = new System.Drawing.Size(103, 34);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labPLCConnectState);
            this.panel1.Controls.Add(this.labNameDisplay);
            this.panel1.Controls.Add(this.labPLCMCAddress);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 27);
            this.panel1.TabIndex = 29;
            // 
            // labPLCConnectState
            // 
            this.labPLCConnectState.AutoSize = true;
            this.labPLCConnectState.BackColor = System.Drawing.Color.Transparent;
            this.labPLCConnectState.Dock = System.Windows.Forms.DockStyle.Right;
            this.labPLCConnectState.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labPLCConnectState.ForeColor = System.Drawing.Color.Snow;
            this.labPLCConnectState.Location = new System.Drawing.Point(645, 0);
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
            this.labPLCMCAddress.Location = new System.Drawing.Point(745, 0);
            this.labPLCMCAddress.Margin = new System.Windows.Forms.Padding(0);
            this.labPLCMCAddress.Name = "labPLCMCAddress";
            this.labPLCMCAddress.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labPLCMCAddress.Size = new System.Drawing.Size(131, 21);
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
            this.btnDown.Location = new System.Drawing.Point(772, 223);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(103, 33);
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
            this.btnIDLE.Location = new System.Drawing.Point(772, 189);
            this.btnIDLE.Name = "btnIDLE";
            this.btnIDLE.Size = new System.Drawing.Size(103, 33);
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
            this.btnRun.Location = new System.Drawing.Point(772, 155);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(103, 33);
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
            // UscCasstteConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.uscConverterPortStatus2);
            this.Controls.Add(this.btnIDLE);
            this.Controls.Add(this.uscConverterPortStatus1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnOpenConvertPLCSimulator);
            this.Controls.Add(this.btnOpenMemoryTable);
            this.Name = "UscCasstteConverter";
            this.Size = new System.Drawing.Size(880, 259);
            this.Load += new System.EventHandler(this.UscCasstteConverter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenMemoryTable;
        private Button btnOpenConvertPLCSimulator;
        private Label labNameDisplay;
        private Panel panel1;
        private Button btnDown;
        private Button btnIDLE;
        private Button btnRun;
        private Label labPLCConnectState;
        private Label labPLCMCAddress;
        private UscConverterPortStatus uscConverterPortStatus1;
        private UscConverterPortStatus uscConverterPortStatus2;
    }
}
