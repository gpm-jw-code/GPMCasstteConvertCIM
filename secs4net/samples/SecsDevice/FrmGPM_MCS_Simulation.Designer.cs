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
            btnS2F41PortTypeChange = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnTransferMsgSend
            // 
            btnTransferMsgSend.Location = new System.Drawing.Point(12, 177);
            btnTransferMsgSend.Name = "btnTransferMsgSend";
            btnTransferMsgSend.Size = new System.Drawing.Size(255, 38);
            btnTransferMsgSend.TabIndex = 0;
            btnTransferMsgSend.Text = "S2F49-Transfer";
            btnTransferMsgSend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnTransferMsgSend.UseVisualStyleBackColor = true;
            btnTransferMsgSend.Click += btnTransferMsgSend_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 221);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(255, 38);
            button1.TabIndex = 1;
            button1.Text = "S2F49-NOTransfer";
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnS1F3
            // 
            btnS1F3.Location = new System.Drawing.Point(12, 12);
            btnS1F3.Name = "btnS1F3";
            btnS1F3.Size = new System.Drawing.Size(255, 38);
            btnS1F3.TabIndex = 2;
            btnS1F3.Text = "S1F3-Selected Equipment Status Reques";
            btnS1F3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnS1F3.UseVisualStyleBackColor = true;
            btnS1F3.Click += btnS1F3_Click;
            // 
            // btnS2F41PortTypeChange
            // 
            btnS2F41PortTypeChange.Location = new System.Drawing.Point(12, 97);
            btnS2F41PortTypeChange.Name = "btnS2F41PortTypeChange";
            btnS2F41PortTypeChange.Size = new System.Drawing.Size(255, 38);
            btnS2F41PortTypeChange.TabIndex = 3;
            btnS2F41PortTypeChange.Text = "S2F41-PortTypeChange";
            btnS2F41PortTypeChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnS2F41PortTypeChange.UseVisualStyleBackColor = true;
            btnS2F41PortTypeChange.Click += btnS2F41PortTypeChange_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(282, 177);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(106, 38);
            button3.TabIndex = 4;
            button3.Text = "S2F49-Transfer 高優先度設備";
            button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(394, 177);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(106, 38);
            button4.TabIndex = 5;
            button4.Text = "S2F49-Transfer 低優先度設備";
            button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FrmGPM_MCS_Simulation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(657, 282);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(btnS2F41PortTypeChange);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnS2F41PortTypeChange;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}