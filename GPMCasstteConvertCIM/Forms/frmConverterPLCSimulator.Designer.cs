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
            components = new System.ComponentModel.Container();
            uscMemoryTable1 = new UI_UserControls.UscMemoryTable();
            btnWIP_BCR_ID_Write = new Button();
            txbWIP_BCR_ID = new TextBox();
            label1 = new Label();
            btnSendChangeToManModeReq = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ckbIsEQPAlive = new CheckBox();
            EQPInterfaceClockTimer = new System.Windows.Forms.Timer(components);
            ckbMonitor = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // uscMemoryTable1
            // 
            uscMemoryTable1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uscMemoryTable1.BorderStyle = BorderStyle.FixedSingle;
            uscMemoryTable1.Editable = true;
            uscMemoryTable1.Location = new Point(12, 70);
            uscMemoryTable1.Name = "uscMemoryTable1";
            uscMemoryTable1.Size = new Size(1140, 790);
            uscMemoryTable1.TabIndex = 0;
            // 
            // btnWIP_BCR_ID_Write
            // 
            btnWIP_BCR_ID_Write.ForeColor = Color.Black;
            btnWIP_BCR_ID_Write.Location = new Point(258, 12);
            btnWIP_BCR_ID_Write.Name = "btnWIP_BCR_ID_Write";
            btnWIP_BCR_ID_Write.Size = new Size(75, 23);
            btnWIP_BCR_ID_Write.TabIndex = 1;
            btnWIP_BCR_ID_Write.Text = "Write";
            btnWIP_BCR_ID_Write.UseVisualStyleBackColor = true;
            btnWIP_BCR_ID_Write.Click += btnWIP_BCR_ID_Write_Click;
            // 
            // txbWIP_BCR_ID
            // 
            txbWIP_BCR_ID.ForeColor = Color.White;
            txbWIP_BCR_ID.Location = new Point(92, 12);
            txbWIP_BCR_ID.MaxLength = 20;
            txbWIP_BCR_ID.Name = "txbWIP_BCR_ID";
            txbWIP_BCR_ID.Size = new Size(160, 23);
            txbWIP_BCR_ID.TabIndex = 21;
            txbWIP_BCR_ID.Text = "ABCDEFGHIJ1234567890";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(16, 16);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 20;
            label1.Text = "WIP BCR ID";
            // 
            // btnSendChangeToManModeReq
            // 
            btnSendChangeToManModeReq.ForeColor = Color.Black;
            btnSendChangeToManModeReq.Location = new Point(20, 22);
            btnSendChangeToManModeReq.Name = "btnSendChangeToManModeReq";
            btnSendChangeToManModeReq.Size = new Size(160, 26);
            btnSendChangeToManModeReq.TabIndex = 31;
            btnSendChangeToManModeReq.Text = "Send Change Request";
            btnSendChangeToManModeReq.UseVisualStyleBackColor = true;
            btnSendChangeToManModeReq.Click += btnSendChangeToManModeReq_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSendChangeToManModeReq);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(545, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 52);
            groupBox1.TabIndex = 32;
            groupBox1.TabStop = false;
            groupBox1.Text = "Change To Manual Mode ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ckbIsEQPAlive);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(339, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 52);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "EQP Alive Check";
            // 
            // ckbIsEQPAlive
            // 
            ckbIsEQPAlive.AutoSize = true;
            ckbIsEQPAlive.Location = new Point(15, 29);
            ckbIsEQPAlive.Name = "ckbIsEQPAlive";
            ckbIsEQPAlive.Size = new Size(53, 19);
            ckbIsEQPAlive.TabIndex = 32;
            ckbIsEQPAlive.Text = "Alive";
            ckbIsEQPAlive.UseVisualStyleBackColor = true;
            ckbIsEQPAlive.CheckedChanged += ckbIsEQPAlive_CheckedChanged;
            // 
            // EQPInterfaceClockTimer
            // 
            EQPInterfaceClockTimer.Interval = 4000;
            EQPInterfaceClockTimer.Tick += EQPInterfaceClockTimer_Tick;
            // 
            // ckbMonitor
            // 
            ckbMonitor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckbMonitor.Appearance = Appearance.Button;
            ckbMonitor.AutoSize = true;
            ckbMonitor.Checked = true;
            ckbMonitor.CheckState = CheckState.Checked;
            ckbMonitor.FlatAppearance.CheckedBackColor = Color.FromArgb(0, 192, 0);
            ckbMonitor.FlatStyle = FlatStyle.Flat;
            ckbMonitor.Location = new Point(1089, 16);
            ckbMonitor.Name = "ckbMonitor";
            ckbMonitor.Size = new Size(63, 25);
            ckbMonitor.TabIndex = 34;
            ckbMonitor.Text = "Monitor";
            ckbMonitor.UseVisualStyleBackColor = true;
            ckbMonitor.CheckedChanged += ckbMonitor_CheckedChanged;
            // 
            // frmConverterPLCSimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            ClientSize = new Size(1164, 872);
            Controls.Add(ckbMonitor);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(txbWIP_BCR_ID);
            Controls.Add(label1);
            Controls.Add(btnWIP_BCR_ID_Write);
            Controls.Add(uscMemoryTable1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Name = "frmConverterPLCSimulator";
            Text = "轉換架_PLC模擬器";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmConverterPLCSimulator_FormClosing;
            Load += frmConverterPLCSimulator_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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