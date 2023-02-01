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
            this.uscagvsModbusClientEmulator1 = new GPMCasstteConvertCIM.Emulators.UscAGVSModbusClientEmulator();
            this.SuspendLayout();
            // 
            // uscagvsModbusClientEmulator1
            // 
            this.uscagvsModbusClientEmulator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uscagvsModbusClientEmulator1.AutoScroll = true;
            this.uscagvsModbusClientEmulator1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uscagvsModbusClientEmulator1.Location = new System.Drawing.Point(12, 12);
            this.uscagvsModbusClientEmulator1.Name = "uscagvsModbusClientEmulator1";
            this.uscagvsModbusClientEmulator1.Size = new System.Drawing.Size(867, 535);
            this.uscagvsModbusClientEmulator1.TabIndex = 0;
            // 
            // frmAGVS_Modbus_Emulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 557);
            this.Controls.Add(this.uscagvsModbusClientEmulator1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "frmAGVS_Modbus_Emulator";
            this.Text = "frmAGVS_Modbus_Emulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAGVS_Modbus_Emulator_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private UscAGVSModbusClientEmulator uscagvsModbusClientEmulator1;
    }
}