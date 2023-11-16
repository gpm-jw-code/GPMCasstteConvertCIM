namespace SecsDevice
{
    partial class Form1
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
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.Button btnSendPrimary;
            System.Windows.Forms.Button btnReplySecondary;
            System.Windows.Forms.Button btnReplyS9F1;
            cmbEncodingSelector = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            numBufferSize = new System.Windows.Forms.NumericUpDown();
            numDeviceId = new System.Windows.Forms.NumericUpDown();
            lbStatus = new System.Windows.Forms.Label();
            btnDisable = new System.Windows.Forms.Button();
            btnEnable = new System.Windows.Forms.Button();
            numPort = new System.Windows.Forms.NumericUpDown();
            txtAddress = new System.Windows.Forms.TextBox();
            radioPassiveMode = new System.Windows.Forms.RadioButton();
            radioActiveMode = new System.Windows.Forms.RadioButton();
            txtRecvSecondary = new System.Windows.Forms.TextBox();
            txtSendPrimary = new System.Windows.Forms.TextBox();
            txtReplySeconary = new System.Windows.Forms.TextBox();
            txtRecvPrimary = new System.Windows.Forms.TextBox();
            lstUnreplyMsg = new System.Windows.Forms.ListBox();
            recvMessageBindingSource = new System.Windows.Forms.BindingSource(components);
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            splitContainer2 = new System.Windows.Forms.SplitContainer();
            richTextBox1 = new System.Windows.Forms.RichTextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            btnSendPrimary = new System.Windows.Forms.Button();
            btnReplySecondary = new System.Windows.Forms.Button();
            btnReplyS9F1 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBufferSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDeviceId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPort).BeginInit();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)recvMessageBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbEncodingSelector);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numBufferSize);
            groupBox1.Controls.Add(numDeviceId);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lbStatus);
            groupBox1.Controls.Add(btnDisable);
            groupBox1.Controls.Add(btnEnable);
            groupBox1.Controls.Add(numPort);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(radioPassiveMode);
            groupBox1.Controls.Add(radioActiveMode);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox1.Size = new System.Drawing.Size(1416, 138);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Config";
            // 
            // cmbEncodingSelector
            // 
            cmbEncodingSelector.FormattingEnabled = true;
            cmbEncodingSelector.Location = new System.Drawing.Point(147, 62);
            cmbEncodingSelector.Name = "cmbEncodingSelector";
            cmbEncodingSelector.Size = new System.Drawing.Size(232, 23);
            cmbEncodingSelector.TabIndex = 15;
            cmbEncodingSelector.SelectedIndexChanged += cmbEncodingSelector_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(88, 60);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(55, 15);
            label5.TabIndex = 14;
            label5.Text = "編碼模式";
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            button1.Location = new System.Drawing.Point(1317, 30);
            button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(87, 28);
            button1.TabIndex = 13;
            button1.Text = "GPM";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(542, 31);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(66, 15);
            label4.TabIndex = 12;
            label4.Text = "Buffer Size";
            // 
            // numBufferSize
            // 
            numBufferSize.Location = new System.Drawing.Point(617, 26);
            numBufferSize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numBufferSize.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numBufferSize.Name = "numBufferSize";
            numBufferSize.Size = new System.Drawing.Size(90, 23);
            numBufferSize.TabIndex = 11;
            numBufferSize.Value = new decimal(new int[] { 65535, 0, 0, 0 });
            // 
            // numDeviceId
            // 
            numDeviceId.Location = new System.Drawing.Point(466, 26);
            numDeviceId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numDeviceId.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numDeviceId.Name = "numDeviceId";
            numDeviceId.Size = new System.Drawing.Size(50, 23);
            numDeviceId.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(401, 31);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 9;
            label3.Text = "Device Id";
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lbStatus.Location = new System.Drawing.Point(952, 22);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new System.Drawing.Size(93, 32);
            lbStatus.TabIndex = 8;
            lbStatus.Text = "Status";
            // 
            // btnDisable
            // 
            btnDisable.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnDisable.Enabled = false;
            btnDisable.Location = new System.Drawing.Point(859, 26);
            btnDisable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnDisable.Name = "btnDisable";
            btnDisable.Size = new System.Drawing.Size(87, 28);
            btnDisable.TabIndex = 7;
            btnDisable.Text = "Disable";
            btnDisable.UseVisualStyleBackColor = true;
            btnDisable.Click += btnDisable_Click;
            // 
            // btnEnable
            // 
            btnEnable.Location = new System.Drawing.Point(765, 26);
            btnEnable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnEnable.Name = "btnEnable";
            btnEnable.Size = new System.Drawing.Size(87, 28);
            btnEnable.TabIndex = 6;
            btnEnable.Text = "Enable";
            btnEnable.UseVisualStyleBackColor = true;
            btnEnable.Click += btnEnable_Click;
            // 
            // numPort
            // 
            numPort.Location = new System.Drawing.Point(320, 26);
            numPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numPort.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numPort.Minimum = new decimal(new int[] { 5000, 0, 0, 0 });
            numPort.Name = "numPort";
            numPort.Size = new System.Drawing.Size(61, 23);
            numPort.TabIndex = 5;
            numPort.Value = new decimal(new int[] { 9500, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(285, 31);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 15);
            label2.TabIndex = 4;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(88, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 15);
            label1.TabIndex = 3;
            label1.Text = "IP";
            // 
            // txtAddress
            // 
            txtAddress.Location = new System.Drawing.Point(111, 26);
            txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(166, 23);
            txtAddress.TabIndex = 2;
            txtAddress.Text = "127.0.0.1";
            // 
            // radioPassiveMode
            // 
            radioPassiveMode.AutoSize = true;
            radioPassiveMode.Location = new System.Drawing.Point(14, 52);
            radioPassiveMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radioPassiveMode.Name = "radioPassiveMode";
            radioPassiveMode.Size = new System.Drawing.Size(65, 19);
            radioPassiveMode.TabIndex = 1;
            radioPassiveMode.Text = "Passive";
            radioPassiveMode.UseVisualStyleBackColor = true;
            // 
            // radioActiveMode
            // 
            radioActiveMode.AutoSize = true;
            radioActiveMode.Checked = true;
            radioActiveMode.Location = new System.Drawing.Point(14, 25);
            radioActiveMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            radioActiveMode.Name = "radioActiveMode";
            radioActiveMode.Size = new System.Drawing.Size(59, 19);
            radioActiveMode.TabIndex = 0;
            radioActiveMode.TabStop = true;
            radioActiveMode.Text = "Active";
            radioActiveMode.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtRecvSecondary);
            groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox4.Location = new System.Drawing.Point(0, 375);
            groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox4.Size = new System.Drawing.Size(522, 295);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Received Secondary Message";
            // 
            // txtRecvSecondary
            // 
            txtRecvSecondary.Dock = System.Windows.Forms.DockStyle.Fill;
            txtRecvSecondary.Location = new System.Drawing.Point(3, 20);
            txtRecvSecondary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRecvSecondary.Multiline = true;
            txtRecvSecondary.Name = "txtRecvSecondary";
            txtRecvSecondary.ReadOnly = true;
            txtRecvSecondary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtRecvSecondary.Size = new System.Drawing.Size(516, 271);
            txtRecvSecondary.TabIndex = 0;
            txtRecvSecondary.WordWrap = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSendPrimary);
            groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox2.Location = new System.Drawing.Point(0, 0);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Size = new System.Drawing.Size(522, 347);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Send Primary Message";
            // 
            // txtSendPrimary
            // 
            txtSendPrimary.AcceptsReturn = true;
            txtSendPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            txtSendPrimary.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtSendPrimary.Location = new System.Drawing.Point(3, 20);
            txtSendPrimary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtSendPrimary.Multiline = true;
            txtSendPrimary.Name = "txtSendPrimary";
            txtSendPrimary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtSendPrimary.Size = new System.Drawing.Size(516, 323);
            txtSendPrimary.TabIndex = 1;
            txtSendPrimary.Text = resources.GetString("txtSendPrimary.Text");
            txtSendPrimary.WordWrap = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtReplySeconary);
            groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox5.Location = new System.Drawing.Point(0, 375);
            groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox5.Size = new System.Drawing.Size(574, 267);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Reply Secondary Message";
            // 
            // txtReplySeconary
            // 
            txtReplySeconary.AcceptsReturn = true;
            txtReplySeconary.Dock = System.Windows.Forms.DockStyle.Fill;
            txtReplySeconary.ImeMode = System.Windows.Forms.ImeMode.Disable;
            txtReplySeconary.Location = new System.Drawing.Point(3, 20);
            txtReplySeconary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtReplySeconary.Multiline = true;
            txtReplySeconary.Name = "txtReplySeconary";
            txtReplySeconary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtReplySeconary.Size = new System.Drawing.Size(568, 243);
            txtReplySeconary.TabIndex = 0;
            txtReplySeconary.WordWrap = false;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtRecvPrimary);
            groupBox3.Controls.Add(lstUnreplyMsg);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox3.Location = new System.Drawing.Point(0, 0);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Size = new System.Drawing.Size(574, 375);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Received Primary Message";
            // 
            // txtRecvPrimary
            // 
            txtRecvPrimary.Dock = System.Windows.Forms.DockStyle.Fill;
            txtRecvPrimary.Location = new System.Drawing.Point(242, 20);
            txtRecvPrimary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            txtRecvPrimary.Multiline = true;
            txtRecvPrimary.Name = "txtRecvPrimary";
            txtRecvPrimary.ReadOnly = true;
            txtRecvPrimary.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtRecvPrimary.Size = new System.Drawing.Size(329, 351);
            txtRecvPrimary.TabIndex = 1;
            txtRecvPrimary.WordWrap = false;
            // 
            // lstUnreplyMsg
            // 
            lstUnreplyMsg.DataSource = recvMessageBindingSource;
            lstUnreplyMsg.DisplayMember = "Message";
            lstUnreplyMsg.Dock = System.Windows.Forms.DockStyle.Left;
            lstUnreplyMsg.FormattingEnabled = true;
            lstUnreplyMsg.ItemHeight = 15;
            lstUnreplyMsg.Location = new System.Drawing.Point(3, 20);
            lstUnreplyMsg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            lstUnreplyMsg.Name = "lstUnreplyMsg";
            lstUnreplyMsg.Size = new System.Drawing.Size(239, 351);
            lstUnreplyMsg.TabIndex = 0;
            lstUnreplyMsg.SelectedIndexChanged += lstUnreplyMsg_SelectedIndexChanged;
            // 
            // recvMessageBindingSource
            // 
            recvMessageBindingSource.DataSource = typeof(Secs4Net.PrimaryMessageWrapper);
            // 
            // btnSendPrimary
            // 
            btnSendPrimary.Dock = System.Windows.Forms.DockStyle.Top;
            btnSendPrimary.Location = new System.Drawing.Point(0, 347);
            btnSendPrimary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSendPrimary.Name = "btnSendPrimary";
            btnSendPrimary.Size = new System.Drawing.Size(522, 28);
            btnSendPrimary.TabIndex = 4;
            btnSendPrimary.Text = "Send";
            btnSendPrimary.UseVisualStyleBackColor = true;
            btnSendPrimary.Click += btnSendPrimary_Click;
            // 
            // btnReplySecondary
            // 
            btnReplySecondary.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnReplySecondary.Location = new System.Drawing.Point(0, 642);
            btnReplySecondary.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnReplySecondary.Name = "btnReplySecondary";
            btnReplySecondary.Size = new System.Drawing.Size(574, 28);
            btnReplySecondary.TabIndex = 1;
            btnReplySecondary.Text = "Reply";
            btnReplySecondary.UseVisualStyleBackColor = true;
            btnReplySecondary.Click += btnReplySecondary_Click;
            // 
            // btnReplyS9F1
            // 
            btnReplyS9F1.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnReplyS9F1.Location = new System.Drawing.Point(0, 614);
            btnReplyS9F1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnReplyS9F1.Name = "btnReplyS9F1";
            btnReplyS9F1.Size = new System.Drawing.Size(574, 28);
            btnReplyS9F1.TabIndex = 3;
            btnReplyS9F1.Text = "Reply S9F7";
            btnReplyS9F1.UseVisualStyleBackColor = true;
            btnReplyS9F1.Click += btnReplyS9F7_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox4);
            splitContainer1.Panel1.Controls.Add(btnSendPrimary);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnReplyS9F1);
            splitContainer1.Panel2.Controls.Add(groupBox5);
            splitContainer1.Panel2.Controls.Add(btnReplySecondary);
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Size = new System.Drawing.Size(1101, 670);
            splitContainer1.SplitterDistance = 522;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 3;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 138);
            splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(richTextBox1);
            splitContainer2.Size = new System.Drawing.Size(1416, 670);
            splitContainer2.SplitterDistance = 1101;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 11;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            richTextBox1.Location = new System.Drawing.Point(0, 0);
            richTextBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new System.Drawing.Size(310, 670);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.WordWrap = false;
            // 
            // Form1
            // 
            AcceptButton = btnEnable;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = btnDisable;
            ClientSize = new System.Drawing.Size(1416, 808);
            Controls.Add(splitContainer2);
            Controls.Add(groupBox1);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "SECS Device";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBufferSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDeviceId).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPort).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)recvMessageBindingSource).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RadioButton radioPassiveMode;
        private System.Windows.Forms.RadioButton radioActiveMode;
        private System.Windows.Forms.Button btnDisable;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSendPrimary;
        private System.Windows.Forms.TextBox txtRecvSecondary;
        private System.Windows.Forms.TextBox txtRecvPrimary;
        private System.Windows.Forms.ListBox lstUnreplyMsg;
        private System.Windows.Forms.TextBox txtReplySeconary;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.NumericUpDown numDeviceId;
        private System.Windows.Forms.BindingSource recvMessageBindingSource;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numBufferSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbEncodingSelector;
        private System.Windows.Forms.Label label5;
    }
}

