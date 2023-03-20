namespace GPMCasstteConvertCIM.UI_UserControls
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
            labReadyStatusBit = new Label();
            labLoadRequestBit = new Label();
            labUnloadRequestBit = new Label();
            labPortExistBit = new Label();
            labL_REQBit = new Label();
            labU_REQBit = new Label();
            labReadyBit = new Label();
            labLOW_ReadyBit = new Label();
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
            label2 = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(labReadyStatusBit);
            flowLayoutPanel1.Controls.Add(labLoadRequestBit);
            flowLayoutPanel1.Controls.Add(labUnloadRequestBit);
            flowLayoutPanel1.Controls.Add(labPortExistBit);
            flowLayoutPanel1.Controls.Add(labL_REQBit);
            flowLayoutPanel1.Controls.Add(labU_REQBit);
            flowLayoutPanel1.Controls.Add(labReadyBit);
            flowLayoutPanel1.Controls.Add(labLOW_ReadyBit);
            flowLayoutPanel1.Controls.Add(labUpPosition);
            flowLayoutPanel1.Controls.Add(labDownPosition);
            flowLayoutPanel1.Location = new Point(3, 54);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(3);
            flowLayoutPanel1.Size = new Size(380, 136);
            flowLayoutPanel1.TabIndex = 34;
            // 
            // labReadyStatusBit
            // 
            labReadyStatusBit.BackColor = SystemColors.ControlDarkDark;
            labReadyStatusBit.BorderStyle = BorderStyle.FixedSingle;
            labReadyStatusBit.FlatStyle = FlatStyle.Flat;
            labReadyStatusBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labReadyStatusBit.ForeColor = Color.White;
            labReadyStatusBit.Location = new Point(4, 4);
            labReadyStatusBit.Margin = new Padding(1);
            labReadyStatusBit.Name = "labReadyStatusBit";
            labReadyStatusBit.Size = new Size(88, 30);
            labReadyStatusBit.TabIndex = 9;
            labReadyStatusBit.Text = "Ready Status";
            labReadyStatusBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labLoadRequestBit
            // 
            labLoadRequestBit.BackColor = SystemColors.ControlDarkDark;
            labLoadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labLoadRequestBit.FlatStyle = FlatStyle.Flat;
            labLoadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoadRequestBit.ForeColor = Color.White;
            labLoadRequestBit.Location = new Point(94, 4);
            labLoadRequestBit.Margin = new Padding(1);
            labLoadRequestBit.Name = "labLoadRequestBit";
            labLoadRequestBit.Size = new Size(88, 30);
            labLoadRequestBit.TabIndex = 0;
            labLoadRequestBit.Text = "Load Request";
            labLoadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUnloadRequestBit
            // 
            labUnloadRequestBit.BackColor = SystemColors.ControlDarkDark;
            labUnloadRequestBit.BorderStyle = BorderStyle.FixedSingle;
            labUnloadRequestBit.FlatStyle = FlatStyle.Flat;
            labUnloadRequestBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labUnloadRequestBit.ForeColor = Color.White;
            labUnloadRequestBit.Location = new Point(184, 4);
            labUnloadRequestBit.Margin = new Padding(1);
            labUnloadRequestBit.Name = "labUnloadRequestBit";
            labUnloadRequestBit.Size = new Size(88, 30);
            labUnloadRequestBit.TabIndex = 1;
            labUnloadRequestBit.Text = "Unload Request";
            labUnloadRequestBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labPortExistBit
            // 
            labPortExistBit.BackColor = SystemColors.ControlDarkDark;
            labPortExistBit.BorderStyle = BorderStyle.FixedSingle;
            labPortExistBit.FlatStyle = FlatStyle.Flat;
            labPortExistBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labPortExistBit.ForeColor = Color.White;
            labPortExistBit.Location = new Point(274, 4);
            labPortExistBit.Margin = new Padding(1);
            labPortExistBit.Name = "labPortExistBit";
            labPortExistBit.Size = new Size(88, 30);
            labPortExistBit.TabIndex = 2;
            labPortExistBit.Text = "Port Exist";
            labPortExistBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labL_REQBit
            // 
            labL_REQBit.BackColor = SystemColors.ControlDarkDark;
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
            labU_REQBit.BackColor = SystemColors.ControlDarkDark;
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
            // labReadyBit
            // 
            labReadyBit.BackColor = SystemColors.ControlDarkDark;
            labReadyBit.BorderStyle = BorderStyle.FixedSingle;
            labReadyBit.FlatStyle = FlatStyle.Flat;
            labReadyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labReadyBit.ForeColor = Color.White;
            labReadyBit.Location = new Point(184, 36);
            labReadyBit.Margin = new Padding(1);
            labReadyBit.Name = "labReadyBit";
            labReadyBit.Size = new Size(88, 30);
            labReadyBit.TabIndex = 8;
            labReadyBit.Text = "READY";
            labReadyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labLOW_ReadyBit
            // 
            labLOW_ReadyBit.BackColor = SystemColors.ControlDarkDark;
            labLOW_ReadyBit.BorderStyle = BorderStyle.FixedSingle;
            labLOW_ReadyBit.FlatStyle = FlatStyle.Flat;
            labLOW_ReadyBit.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLOW_ReadyBit.ForeColor = Color.White;
            labLOW_ReadyBit.Location = new Point(274, 36);
            labLOW_ReadyBit.Margin = new Padding(1);
            labLOW_ReadyBit.Name = "labLOW_ReadyBit";
            labLOW_ReadyBit.Size = new Size(88, 30);
            labLOW_ReadyBit.TabIndex = 11;
            labLOW_ReadyBit.Text = "LOW_READY";
            labLOW_ReadyBit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labUpPosition
            // 
            labUpPosition.BackColor = SystemColors.ControlDarkDark;
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
            labDownPosition.BackColor = SystemColors.ControlDarkDark;
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
            panel1.Location = new Point(3, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(111, 42);
            panel1.TabIndex = 33;
            // 
            // labCurrentPortMode
            // 
            labCurrentPortMode.BackColor = Color.White;
            labCurrentPortMode.BorderStyle = BorderStyle.FixedSingle;
            labCurrentPortMode.Dock = DockStyle.Fill;
            labCurrentPortMode.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labCurrentPortMode.Location = new Point(0, 18);
            labCurrentPortMode.Margin = new Padding(0);
            labCurrentPortMode.Name = "labCurrentPortMode";
            labCurrentPortMode.Size = new Size(109, 22);
            labCurrentPortMode.TabIndex = 1;
            labCurrentPortMode.Text = "label6";
            labCurrentPortMode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.DarkSlateGray;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Top;
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(109, 18);
            label5.TabIndex = 0;
            label5.Text = "Port Mode";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txbWIP_BCR_ID
            // 
            txbWIP_BCR_ID.BackColor = Color.Black;
            txbWIP_BCR_ID.ForeColor = Color.Yellow;
            txbWIP_BCR_ID.Location = new Point(83, 195);
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
            label1.Location = new Point(7, 199);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 25;
            label1.Text = "WIP BCR ID";
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
            labUnloading.Location = new Point(304, 8);
            labUnloading.Margin = new Padding(1);
            labUnloading.Name = "labUnloading";
            labUnloading.Size = new Size(58, 19);
            labUnloading.TabIndex = 35;
            labUnloading.Text = "Unloading";
            labUnloading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labLoading
            // 
            labLoading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labLoading.BackColor = SystemColors.ControlDarkDark;
            labLoading.BorderStyle = BorderStyle.FixedSingle;
            labLoading.FlatStyle = FlatStyle.Flat;
            labLoading.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            labLoading.ForeColor = Color.White;
            labLoading.Location = new Point(244, 8);
            labLoading.Margin = new Padding(1);
            labLoading.Name = "labLoading";
            labLoading.Size = new Size(58, 19);
            labLoading.TabIndex = 36;
            labLoading.Text = "Loading";
            labLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labAutoStatus
            // 
            labAutoStatus.BackColor = Color.Orange;
            labAutoStatus.BorderStyle = BorderStyle.FixedSingle;
            labAutoStatus.FlatStyle = FlatStyle.Flat;
            labAutoStatus.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labAutoStatus.ForeColor = Color.White;
            labAutoStatus.Location = new Point(118, 8);
            labAutoStatus.Margin = new Padding(1);
            labAutoStatus.Name = "labAutoStatus";
            labAutoStatus.Size = new Size(92, 42);
            labAutoStatus.TabIndex = 37;
            labAutoStatus.Text = "MANUAL";
            labAutoStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = SystemColors.ActiveCaption;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Microsoft JhengHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(244, 31);
            label2.Margin = new Padding(1);
            label2.Name = "label2";
            label2.Size = new Size(118, 19);
            label2.TabIndex = 38;
            label2.Text = "Event Report ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // UscConverterPortStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(labAutoStatus);
            Controls.Add(labLoading);
            Controls.Add(labUnloading);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(txbWIP_BCR_ID);
            Controls.Add(label1);
            Name = "UscConverterPortStatus";
            Size = new Size(371, 222);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label labReadyStatusBit;
        private Label labLoadRequestBit;
        private Label labUnloadRequestBit;
        private Label labPortExistBit;
        private Label labL_REQBit;
        private Label labU_REQBit;
        private Label labReadyBit;
        private Label labLOW_ReadyBit;
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
        private Label label2;
    }
}
