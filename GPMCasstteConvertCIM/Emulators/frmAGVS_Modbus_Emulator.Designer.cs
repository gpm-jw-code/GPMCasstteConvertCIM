namespace GPMCasstteConvertCIM.Emulators
{
    partial class frmAGVS_Modbus_Emulator
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
            uscagvsModbusClientEmulator1 = new UscAGVSModbusClientEmulator();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // uscagvsModbusClientEmulator1
            // 
            uscagvsModbusClientEmulator1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uscagvsModbusClientEmulator1.AutoScroll = true;
            uscagvsModbusClientEmulator1.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            uscagvsModbusClientEmulator1.Location = new Point(12, 41);
            uscagvsModbusClientEmulator1.Name = "uscagvsModbusClientEmulator1";
            uscagvsModbusClientEmulator1.Size = new Size(1124, 659);
            uscagvsModbusClientEmulator1.TabIndex = 0;
            uscagvsModbusClientEmulator1.Load += uscagvsModbusClientEmulator1_Load;
            // 
            // statusStrip1
            // 
            statusStrip1.Dock = DockStyle.Top;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1150, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(42, 17);
            toolStripStatusLabel1.Text = "Demo";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // frmAGVS_Modbus_Emulator
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1150, 710);
            Controls.Add(statusStrip1);
            Controls.Add(uscagvsModbusClientEmulator1);
            Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "frmAGVS_Modbus_Emulator";
            Text = "frmAGVS_Modbus_Emulator";
            FormClosing += frmAGVS_Modbus_Emulator_FormClosing;
            Load += frmAGVS_Modbus_Emulator_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UscAGVSModbusClientEmulator uscagvsModbusClientEmulator1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}