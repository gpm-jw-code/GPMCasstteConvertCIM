﻿namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscConverterPortStatus
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
            components = new System.ComponentModel.Container();
            flowLayoutPanel1 = new FlowLayoutPanel();
            labLoadRequestBit = new Label();
            labUnloadRequestBit = new Label();
            labPortExistBit = new Label();
            labPortStatusDown = new Label();
            labL_REQBit = new Label();
            labU_REQBit = new Label();
            labEQReadyBit = new Label();
            labBusyBit = new Label();
            labUpPosition = new Label();
            labDownPosition = new Label();
            panel1 = new Panel();
            labCurrentPortMode = new Label();
            label5 = new Label();
            txbWIP_BCR_ID = new TextBox();
            label1 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labUnloading = new Label();
            labLoading = new Label();
            labAutoStatus = new Label();
            labPortEventRepShow = new Label();
            panel2 = new Panel();
            labPortID = new Label();
            label4 = new Label();
            labServiceStatusText = new Label();
            label3 = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labLoadRequestBit);
            flowLayoutPanel1.Controls.Add(labUnloadRequestBit);
            flowLayoutPanel1.Controls.Add(labPortExistBit);
            flowLayoutPanel1.Controls.Add(labPortStatusDown);
            flowLayoutPanel1.Controls.Add(labL_REQBit);
            flowLayoutPanel1.Controls.Add(labU_REQBit);
            flowLayoutPanel1.Controls.Add(labEQReadyBit);
            flowLayoutPanel1.Controls.Add(labBusyBit);
            flowLayoutPanel1.Controls.Add(labUpPosition);
            flowLayoutPanel1.Controls.Add(labDownPosition);
            flowLayoutPanel1.Location = new Point(3, 103);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(3);
            flowLayoutPanel1.Size = new Size(391, 107);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // labLoadRequestBit
            // 
            labLoadRequestBit.BackColor = SystemColors.AppWorkspace;
            labLoadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labLoadRequestBit.FlatStyle = FlatStyle.Flat;
            labLoadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoadRequestBit.ForeColor = Color.White;
            labLoadRequestBit.Location = new Point(4, 4);
            labLoadRequestBit.Margin = new Padding(1);
            labLoadRequestBit.Name = "labLoadRequestBit";
            labLoadRequestBit.Size = new Size(88, 30);
            labLoadRequestBit.TabIndex = 0;
            labLoadRequestBit.Text = "Load Request";
            labLoadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUnloadRequestBit
            // 
            labUnloadRequestBit.BackColor = SystemColors.AppWorkspace;
            labUnloadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labUnloadRequestBit.FlatStyle = FlatStyle.Flat;
            labUnloadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUnloadRequestBit.ForeColor = Color.White;
            labUnloadRequestBit.Location = new Point(94, 4);
            labUnloadRequestBit.Margin = new Padding(1);
            labUnloadRequestBit.Name = "labUnloadRequestBit";
            labUnloadRequestBit.Size = new Size(88, 30);
            labUnloadRequestBit.TabIndex = 1;
            labUnloadRequestBit.Text = "Unload Request";
            labUnloadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPortExistBit
            // 
            labPortExistBit.BackColor = SystemColors.AppWorkspace;
            labPortExistBit.BorderStyle = BorderStyle.FixedSingle;
            labPortExistBit.FlatStyle = FlatStyle.Flat;
            labPortExistBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortExistBit.ForeColor = Color.White;
            labPortExistBit.Location = new Point(184, 4);
            labPortExistBit.Margin = new Padding(1);
            labPortExistBit.Name = "labPortExistBit";
            labPortExistBit.Size = new Size(88, 30);
            labPortExistBit.TabIndex = 2;
            labPortExistBit.Text = "Port Exist";
            labPortExistBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPortStatusDown
            // 
            labPortStatusDown.BackColor = SystemColors.AppWorkspace;
            labPortStatusDown.BorderStyle = BorderStyle.FixedSingle;
            labPortStatusDown.FlatStyle = FlatStyle.Flat;
            labPortStatusDown.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortStatusDown.ForeColor = Color.White;
            labPortStatusDown.Location = new Point(274, 4);
            labPortStatusDown.Margin = new Padding(1);
            labPortStatusDown.Name = "labPortStatusDown";
            labPortStatusDown.Size = new Size(88, 30);
            labPortStatusDown.TabIndex = 23;
            labPortStatusDown.Text = "PORT_STATUS_DOWN";
            labPortStatusDown.TextAlign = ContentAlignment.MiddleCenter;
            labPortStatusDown.DoubleClick += labPortStatusDown_DoubleClick;
            // 
            // labL_REQBit
            // 
            labL_REQBit.BackColor = SystemColors.AppWorkspace;
            labL_REQBit.BorderStyle = BorderStyle.FixedSingle;
            labL_REQBit.FlatStyle = FlatStyle.Flat;
            labL_REQBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labL_REQBit.ForeColor = Color.White;
            labL_REQBit.Location = new Point(4, 36);
            labL_REQBit.Margin = new Padding(1);
            labL_REQBit.Name = "labL_REQBit";
            labL_REQBit.Size = new Size(88, 30);
            labL_REQBit.TabIndex = 6;
            labL_REQBit.Text = "L_REQ";
            labL_REQBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labU_REQBit
            // 
            labU_REQBit.BackColor = SystemColors.AppWorkspace;
            labU_REQBit.BorderStyle = BorderStyle.FixedSingle;
            labU_REQBit.FlatStyle = FlatStyle.Flat;
            labU_REQBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labU_REQBit.ForeColor = Color.White;
            labU_REQBit.Location = new Point(94, 36);
            labU_REQBit.Margin = new Padding(1);
            labU_REQBit.Name = "labU_REQBit";
            labU_REQBit.Size = new Size(88, 30);
            labU_REQBit.TabIndex = 7;
            labU_REQBit.Text = "U_REQ";
            labU_REQBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labEQReadyBit
            // 
            labEQReadyBit.BackColor = SystemColors.AppWorkspace;
            labEQReadyBit.BorderStyle = BorderStyle.FixedSingle;
            labEQReadyBit.FlatStyle = FlatStyle.Flat;
            labEQReadyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labEQReadyBit.ForeColor = Color.White;
            labEQReadyBit.Location = new Point(184, 36);
            labEQReadyBit.Margin = new Padding(1);
            labEQReadyBit.Name = "labEQReadyBit";
            labEQReadyBit.Size = new Size(88, 30);
            labEQReadyBit.TabIndex = 8;
            labEQReadyBit.Text = "READY";
            labEQReadyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labBusyBit
            // 
            labBusyBit.BackColor = SystemColors.AppWorkspace;
            labBusyBit.BorderStyle = BorderStyle.FixedSingle;
            labBusyBit.FlatStyle = FlatStyle.Flat;
            labBusyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labBusyBit.ForeColor = Color.White;
            labBusyBit.Location = new Point(274, 36);
            labBusyBit.Margin = new Padding(1);
            labBusyBit.Name = "labBusyBit";
            labBusyBit.Size = new Size(88, 30);
            labBusyBit.TabIndex = 11;
            labBusyBit.Text = "BUSY";
            labBusyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUpPosition
            // 
            labUpPosition.BackColor = SystemColors.AppWorkspace;
            labUpPosition.BorderStyle = BorderStyle.FixedSingle;
            labUpPosition.FlatStyle = FlatStyle.Flat;
            labUpPosition.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUpPosition.ForeColor = Color.White;
            labUpPosition.Location = new Point(4, 68);
            labUpPosition.Margin = new Padding(1);
            labUpPosition.Name = "labUpPosition";
            labUpPosition.Size = new Size(88, 30);
            labUpPosition.TabIndex = 21;
            labUpPosition.Text = "LD_UP_POS";
            labUpPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDownPosition
            // 
            labDownPosition.BackColor = SystemColors.AppWorkspace;
            labDownPosition.BorderStyle = BorderStyle.FixedSingle;
            labDownPosition.FlatStyle = FlatStyle.Flat;
            labDownPosition.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labDownPosition.ForeColor = Color.White;
            labDownPosition.Location = new Point(94, 68);
            labDownPosition.Margin = new Padding(1);
            labDownPosition.Name = "labDownPosition";
            labDownPosition.Size = new Size(88, 30);
            labDownPosition.TabIndex = 22;
            labDownPosition.Text = "LD_DOWN_POS";
            labDownPosition.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labCurrentPortMode);
            panel1.Controls.Add(label5);
            panel1.Location = new Point(8, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(167, 46);
            panel1.TabIndex = 33;
            // 
            // labCurrentPortMode
            // 
            labCurrentPortMode.BackColor = Color.Black;
            labCurrentPortMode.BorderStyle = BorderStyle.FixedSingle;
            labCurrentPortMode.Dock = DockStyle.Fill;
            labCurrentPortMode.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labCurrentPortMode.ForeColor = Color.White;
            labCurrentPortMode.Location = new Point(0, 18);
            labCurrentPortMode.Margin = new Padding(0);
            labCurrentPortMode.Name = "labCurrentPortMode";
            labCurrentPortMode.Size = new Size(165, 26);
            labCurrentPortMode.TabIndex = 1;
            labCurrentPortMode.Text = "label6";
            labCurrentPortMode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(0, 57, 155);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Top;
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(165, 18);
            label5.TabIndex = 0;
            label5.Text = "PORT TYPE";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbWIP_BCR_ID
            // 
            txbWIP_BCR_ID.BackColor = Color.Black;
            txbWIP_BCR_ID.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            txbWIP_BCR_ID.ForeColor = Color.Yellow;
            txbWIP_BCR_ID.Location = new Point(83, 216);
            txbWIP_BCR_ID.Name = "txbWIP_BCR_ID";
            txbWIP_BCR_ID.ReadOnly = true;
            txbWIP_BCR_ID.Size = new Size(282, 23);
            txbWIP_BCR_ID.TabIndex = 26;
            txbWIP_BCR_ID.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(7, 219);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 25;
            label1.Text = "Carrier ID";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // labUnloading
            // 
            labUnloading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labUnloading.BackColor = SystemColors.ControlDarkDark;
            labUnloading.BorderStyle = BorderStyle.FixedSingle;
            labUnloading.FlatStyle = FlatStyle.Flat;
            labUnloading.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUnloading.ForeColor = Color.White;
            labUnloading.Location = new Point(422, 199);
            labUnloading.Margin = new Padding(1);
            labUnloading.Name = "labUnloading";
            labUnloading.Size = new Size(58, 19);
            labUnloading.TabIndex = 35;
            labUnloading.Text = "Unloading";
            labUnloading.TextAlign = ContentAlignment.MiddleCenter;
            labUnloading.Visible = false;
            // 
            // labLoading
            // 
            labLoading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labLoading.BackColor = SystemColors.ControlDarkDark;
            labLoading.BorderStyle = BorderStyle.FixedSingle;
            labLoading.FlatStyle = FlatStyle.Flat;
            labLoading.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoading.ForeColor = Color.White;
            labLoading.Location = new Point(422, 220);
            labLoading.Margin = new Padding(1);
            labLoading.Name = "labLoading";
            labLoading.Size = new Size(58, 19);
            labLoading.TabIndex = 36;
            labLoading.Text = "Loading";
            labLoading.TextAlign = ContentAlignment.MiddleCenter;
            labLoading.Visible = false;
            // 
            // labAutoStatus
            // 
            labAutoStatus.BackColor = Color.Orange;
            labAutoStatus.BorderStyle = BorderStyle.FixedSingle;
            labAutoStatus.FlatStyle = FlatStyle.Flat;
            labAutoStatus.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labAutoStatus.ForeColor = Color.White;
            labAutoStatus.Location = new Point(184, 6);
            labAutoStatus.Margin = new Padding(1);
            labAutoStatus.Name = "labAutoStatus";
            labAutoStatus.Size = new Size(101, 42);
            labAutoStatus.TabIndex = 37;
            labAutoStatus.Text = "MANUAL";
            labAutoStatus.TextAlign = ContentAlignment.MiddleCenter;
            labAutoStatus.DoubleClick += labAutoStatus_DoubleClick;
            // 
            // labPortEventRepShow
            // 
            labPortEventRepShow.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labPortEventRepShow.BackColor = SystemColors.ActiveCaption;
            labPortEventRepShow.BorderStyle = BorderStyle.FixedSingle;
            labPortEventRepShow.FlatStyle = FlatStyle.Flat;
            labPortEventRepShow.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortEventRepShow.ForeColor = Color.White;
            labPortEventRepShow.Location = new Point(385, 251);
            labPortEventRepShow.Margin = new Padding(1);
            labPortEventRepShow.Name = "labPortEventRepShow";
            labPortEventRepShow.Size = new Size(95, 39);
            labPortEventRepShow.TabIndex = 38;
            labPortEventRepShow.Text = "Event Report ";
            labPortEventRepShow.TextAlign = ContentAlignment.MiddleCenter;
            labPortEventRepShow.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(labPortID);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(7, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(169, 46);
            panel2.TabIndex = 39;
            // 
            // labPortID
            // 
            labPortID.BackColor = Color.Black;
            labPortID.BorderStyle = BorderStyle.FixedSingle;
            labPortID.Dock = DockStyle.Fill;
            labPortID.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labPortID.ForeColor = Color.White;
            labPortID.Location = new Point(0, 18);
            labPortID.Margin = new Padding(0);
            labPortID.Name = "labPortID";
            labPortID.Padding = new Padding(1);
            labPortID.Size = new Size(167, 26);
            labPortID.TabIndex = 1;
            labPortID.Text = "3F_AGVC02_PORT_2_1";
            labPortID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(0, 57, 155);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Top;
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(167, 18);
            label4.TabIndex = 0;
            label4.Text = "PORT ID";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labServiceStatusText
            // 
            labServiceStatusText.AutoSize = true;
            labServiceStatusText.Font = new Font("Microsoft JhengHei UI", 23F, FontStyle.Bold, GraphicsUnit.Point);
            labServiceStatusText.ForeColor = Color.Red;
            labServiceStatusText.Location = new Point(3, 255);
            labServiceStatusText.Name = "labServiceStatusText";
            labServiceStatusText.Size = new Size(233, 40);
            labServiceStatusText.TabIndex = 40;
            labServiceStatusText.Text = "Out Of Service";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(428, 6);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 41;
            label3.Text = "IO LINK";
            label3.Click += label3_Click;
            // 
            // UscConverterPortStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(label3);
            Controls.Add(labServiceStatusText);
            Controls.Add(panel2);
            Controls.Add(labPortEventRepShow);
            Controls.Add(labAutoStatus);
            Controls.Add(labLoading);
            Controls.Add(labUnloading);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(txbWIP_BCR_ID);
            Controls.Add(label1);
            Name = "UscConverterPortStatus";
            Size = new Size(489, 295);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label labLoadRequestBit;
        private Label labUnloadRequestBit;
        private Label labPortExistBit;
        private Label labL_REQBit;
        private Label labU_REQBit;
        private Label labReadyBit;
        private Label labBusyBit;
        private Panel panel1;
        private Label labCurrentPortMode;
        private Label label5;
        private TextBox txbWIP_BCR_ID;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label labUpPosition;
        private Label labDownPosition;
        private Label labUnloading;
        private Label labLoading;
        private Label labAutoStatus;
        private Label labPortEventRepShow;
        private Panel panel2;
        private Label labPortID;
        private Label label4;
        private Label labServiceStatusText;
        private Label label3;
        private Label labPortStatusDown;
        private Label labEQReadyBit;
    }
}
