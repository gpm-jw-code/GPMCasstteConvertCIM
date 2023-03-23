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
            btnTransferMsgSend = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            btnS1F3 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnTransferMsgSend
            // 
            btnTransferMsgSend.Location = new System.Drawing.Point(12, 146);
            btnTransferMsgSend.Name = "btnTransferMsgSend";
            btnTransferMsgSend.Size = new System.Drawing.Size(139, 38);
            btnTransferMsgSend.TabIndex = 0;
            btnTransferMsgSend.Text = "S2F49-Transfer";
            btnTransferMsgSend.UseVisualStyleBackColor = true;
            btnTransferMsgSend.Click += btnTransferMsgSend_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 190);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(139, 38);
            button1.TabIndex = 1;
            button1.Text = "S2F49-NOTransfer";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnS1F3
            // 
            btnS1F3.Location = new System.Drawing.Point(12, 12);
            btnS1F3.Name = "btnS1F3";
            btnS1F3.Size = new System.Drawing.Size(139, 38);
            btnS1F3.TabIndex = 2;
            btnS1F3.Text = "S1F3-Selected Equipment Status Reques";
            btnS1F3.UseVisualStyleBackColor = true;
            btnS1F3.Click += btnS1F3_Click;
            // 
            // FrmGPM_MCS_Simulation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(btnS1F3);
            Controls.Add(button1);
            Controls.Add(btnTransferMsgSend);
            Name = "FrmGPM_MCS_Simulation";
            Text = "FrmGPM_MCS_Simulation";
            Load += FrmGPM_MCS_Simulation_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnTransferMsgSend;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnS1F3;
    }
}