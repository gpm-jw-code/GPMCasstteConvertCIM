namespace GPMCasstteConvertCIM
{
    partial class frmMCSSimulator
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
            this.btnEQOnlineRequest = new System.Windows.Forms.Button();
            this.btnEQOfflineRequest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbPortTypeSelector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPortID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendPortTypeChangeMsg = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTransferTask = new System.Windows.Forms.Button();
            this.btnCarrierWaitInReject = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEQOnlineRequest
            // 
            this.btnEQOnlineRequest.Location = new System.Drawing.Point(18, 22);
            this.btnEQOnlineRequest.Name = "btnEQOnlineRequest";
            this.btnEQOnlineRequest.Size = new System.Drawing.Size(120, 41);
            this.btnEQOnlineRequest.TabIndex = 0;
            this.btnEQOnlineRequest.Text = "Online By Host";
            this.btnEQOnlineRequest.UseVisualStyleBackColor = true;
            this.btnEQOnlineRequest.Click += new System.EventHandler(this.btnEQOnlineRequest_Click);
            // 
            // btnEQOfflineRequest
            // 
            this.btnEQOfflineRequest.Location = new System.Drawing.Point(18, 69);
            this.btnEQOfflineRequest.Name = "btnEQOfflineRequest";
            this.btnEQOfflineRequest.Size = new System.Drawing.Size(120, 41);
            this.btnEQOfflineRequest.TabIndex = 1;
            this.btnEQOfflineRequest.Text = "Offline By Host";
            this.btnEQOfflineRequest.UseVisualStyleBackColor = true;
            this.btnEQOfflineRequest.Click += new System.EventHandler(this.btnEQOfflineRequest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEQOnlineRequest);
            this.groupBox1.Controls.Add(this.btnEQOfflineRequest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "On/Off Line";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbPortTypeSelector);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txbPortID);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSendPortTypeChangeMsg);
            this.groupBox2.Location = new System.Drawing.Point(209, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PORT TYPE CHANGE";
            // 
            // cmbPortTypeSelector
            // 
            this.cmbPortTypeSelector.FormattingEnabled = true;
            this.cmbPortTypeSelector.Location = new System.Drawing.Point(101, 50);
            this.cmbPortTypeSelector.Name = "cmbPortTypeSelector";
            this.cmbPortTypeSelector.Size = new System.Drawing.Size(100, 23);
            this.cmbPortTypeSelector.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port Type";
            // 
            // txbPortID
            // 
            this.txbPortID.Location = new System.Drawing.Point(101, 22);
            this.txbPortID.Name = "txbPortID";
            this.txbPortID.Size = new System.Drawing.Size(100, 23);
            this.txbPortID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port ID";
            // 
            // btnSendPortTypeChangeMsg
            // 
            this.btnSendPortTypeChangeMsg.Location = new System.Drawing.Point(26, 79);
            this.btnSendPortTypeChangeMsg.Name = "btnSendPortTypeChangeMsg";
            this.btnSendPortTypeChangeMsg.Size = new System.Drawing.Size(175, 41);
            this.btnSendPortTypeChangeMsg.TabIndex = 0;
            this.btnSendPortTypeChangeMsg.Text = "Port Change";
            this.btnSendPortTypeChangeMsg.UseVisualStyleBackColor = true;
            this.btnSendPortTypeChangeMsg.Click += new System.EventHandler(this.btnSendPortTypeChangeMsg_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.btnTransferTask);
            this.groupBox3.Location = new System.Drawing.Point(432, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(217, 126);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TRANSFER (派工)";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port Type";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port ID";
            // 
            // btnTransferTask
            // 
            this.btnTransferTask.Location = new System.Drawing.Point(26, 79);
            this.btnTransferTask.Name = "btnTransferTask";
            this.btnTransferTask.Size = new System.Drawing.Size(175, 41);
            this.btnTransferTask.TabIndex = 0;
            this.btnTransferTask.Text = "派車任務";
            this.btnTransferTask.UseVisualStyleBackColor = true;
            this.btnTransferTask.Click += new System.EventHandler(this.btnTransferTask_Click);
            // 
            // btnCarrierWaitInReject
            // 
            this.btnCarrierWaitInReject.Location = new System.Drawing.Point(458, 144);
            this.btnCarrierWaitInReject.Name = "btnCarrierWaitInReject";
            this.btnCarrierWaitInReject.Size = new System.Drawing.Size(175, 41);
            this.btnCarrierWaitInReject.TabIndex = 5;
            this.btnCarrierWaitInReject.Text = "Carrier Wait In Reject";
            this.btnCarrierWaitInReject.UseVisualStyleBackColor = true;
            // 
            // frmMCSSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 331);
            this.Controls.Add(this.btnCarrierWaitInReject);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMCSSimulator";
            this.Text = "frmMCSSimulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMCSSimulator_FormClosing);
            this.Load += new System.EventHandler(this.frmMCSSimulator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnEQOnlineRequest;
        private Button btnEQOfflineRequest;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnSendPortTypeChangeMsg;
        private ComboBox cmbPortTypeSelector;
        private Label label2;
        private TextBox txbPortID;
        private Label label1;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Button btnTransferTask;
        private Button btnCarrierWaitInReject;
    }
}