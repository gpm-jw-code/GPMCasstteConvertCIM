namespace GPMCasstteConvertCIM.Forms
{
    partial class frmConverterPLCSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.uscMemoryTable1 = new GPMCasstteConvertCIM.UI_UserControls.UscMemoryTable();
            this.btnWIP_BCR_ID_Write = new System.Windows.Forms.Button();
            this.txbWIP_BCR_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendChangeToManModeReq = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbIsEQPAlive = new System.Windows.Forms.CheckBox();
            this.EQPInterfaceClockTimer = new System.Windows.Forms.Timer(this.components);
            this.ckbMonitor = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uscMemoryTable1
            // 
            this.uscMemoryTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uscMemoryTable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscMemoryTable1.Location = new System.Drawing.Point(12, 70);
            this.uscMemoryTable1.Name = "uscMemoryTable1";
            this.uscMemoryTable1.Size = new System.Drawing.Size(1309, 462);
            this.uscMemoryTable1.TabIndex = 0;
            // 
            // btnWIP_BCR_ID_Write
            // 
            this.btnWIP_BCR_ID_Write.Location = new System.Drawing.Point(258, 12);
            this.btnWIP_BCR_ID_Write.Name = "btnWIP_BCR_ID_Write";
            this.btnWIP_BCR_ID_Write.Size = new System.Drawing.Size(75, 23);
            this.btnWIP_BCR_ID_Write.TabIndex = 1;
            this.btnWIP_BCR_ID_Write.Text = "Write";
            this.btnWIP_BCR_ID_Write.UseVisualStyleBackColor = true;
            this.btnWIP_BCR_ID_Write.Click += new System.EventHandler(this.btnWIP_BCR_ID_Write_Click);
            // 
            // txbWIP_BCR_ID
            // 
            this.txbWIP_BCR_ID.Location = new System.Drawing.Point(92, 12);
            this.txbWIP_BCR_ID.MaxLength = 20;
            this.txbWIP_BCR_ID.Name = "txbWIP_BCR_ID";
            this.txbWIP_BCR_ID.Size = new System.Drawing.Size(160, 23);
            this.txbWIP_BCR_ID.TabIndex = 21;
            this.txbWIP_BCR_ID.Text = "ABCDEFGHIJ1234567890";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "WIP BCR ID";
            // 
            // btnSendChangeToManModeReq
            // 
            this.btnSendChangeToManModeReq.Location = new System.Drawing.Point(20, 22);
            this.btnSendChangeToManModeReq.Name = "btnSendChangeToManModeReq";
            this.btnSendChangeToManModeReq.Size = new System.Drawing.Size(160, 26);
            this.btnSendChangeToManModeReq.TabIndex = 31;
            this.btnSendChangeToManModeReq.Text = "Send Change Request";
            this.btnSendChangeToManModeReq.UseVisualStyleBackColor = true;
            this.btnSendChangeToManModeReq.Click += new System.EventHandler(this.btnSendChangeToManModeReq_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSendChangeToManModeReq);
            this.groupBox1.Location = new System.Drawing.Point(545, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change To Manual Mode ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbIsEQPAlive);
            this.groupBox2.Location = new System.Drawing.Point(339, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 52);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "EQP Alive Check";
            // 
            // ckbIsEQPAlive
            // 
            this.ckbIsEQPAlive.AutoSize = true;
            this.ckbIsEQPAlive.Location = new System.Drawing.Point(15, 29);
            this.ckbIsEQPAlive.Name = "ckbIsEQPAlive";
            this.ckbIsEQPAlive.Size = new System.Drawing.Size(53, 19);
            this.ckbIsEQPAlive.TabIndex = 32;
            this.ckbIsEQPAlive.Text = "Alive";
            this.ckbIsEQPAlive.UseVisualStyleBackColor = true;
            this.ckbIsEQPAlive.CheckedChanged += new System.EventHandler(this.ckbIsEQPAlive_CheckedChanged);
            // 
            // EQPInterfaceClockTimer
            // 
            this.EQPInterfaceClockTimer.Interval = 4000;
            this.EQPInterfaceClockTimer.Tick += new System.EventHandler(this.EQPInterfaceClockTimer_Tick);
            // 
            // ckbMonitor
            // 
            this.ckbMonitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbMonitor.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbMonitor.AutoSize = true;
            this.ckbMonitor.Checked = true;
            this.ckbMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMonitor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbMonitor.Location = new System.Drawing.Point(1258, 16);
            this.ckbMonitor.Name = "ckbMonitor";
            this.ckbMonitor.Size = new System.Drawing.Size(63, 25);
            this.ckbMonitor.TabIndex = 34;
            this.ckbMonitor.Text = "Monitor";
            this.ckbMonitor.UseVisualStyleBackColor = true;
            this.ckbMonitor.CheckedChanged += new System.EventHandler(this.ckbMonitor_CheckedChanged);
            // 
            // frmConverterPLCSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 544);
            this.Controls.Add(this.ckbMonitor);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txbWIP_BCR_ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWIP_BCR_ID_Write);
            this.Controls.Add(this.uscMemoryTable1);
            this.DoubleBuffered = true;
            this.Name = "frmConverterPLCSimulator";
            this.Text = "轉換架_PLC模擬器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConverterPLCSimulator_FormClosing);
            this.Load += new System.EventHandler(this.frmConverterPLCSimulator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI_UserControls.UscMemoryTable uscMemoryTable1;
        private Button btnWIP_BCR_ID_Write;
        private TextBox txbWIP_BCR_ID;
        private Label label1;
        private Button btnSendChangeToManModeReq;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private CheckBox ckbIsEQPAlive;
        private System.Windows.Forms.Timer EQPInterfaceClockTimer;
        private CheckBox ckbMonitor;
    }
}