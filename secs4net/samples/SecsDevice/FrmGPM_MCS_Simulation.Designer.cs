namespace SecsDevice
{
    partial class FrmGPM_MCS_Simulation
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
            this.btnTransferMsgSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTransferMsgSend
            // 
            this.btnTransferMsgSend.Location = new System.Drawing.Point(12, 12);
            this.btnTransferMsgSend.Name = "btnTransferMsgSend";
            this.btnTransferMsgSend.Size = new System.Drawing.Size(139, 38);
            this.btnTransferMsgSend.TabIndex = 0;
            this.btnTransferMsgSend.Text = "S2F49-Transfer";
            this.btnTransferMsgSend.UseVisualStyleBackColor = true;
            this.btnTransferMsgSend.Click += new System.EventHandler(this.btnTransferMsgSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "S2F49-NOTransfer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmGPM_MCS_Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTransferMsgSend);
            this.Name = "FrmGPM_MCS_Simulation";
            this.Text = "FrmGPM_MCS_Simulation";
            this.Load += new System.EventHandler(this.FrmGPM_MCS_Simulation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTransferMsgSend;
        private System.Windows.Forms.Button button1;
    }
}