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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labReadyStatusBit = new System.Windows.Forms.Label();
            this.labLoadRequestBit = new System.Windows.Forms.Label();
            this.labUnloadRequestBit = new System.Windows.Forms.Label();
            this.labPortExistBit = new System.Windows.Forms.Label();
            this.labL_REQBit = new System.Windows.Forms.Label();
            this.labU_REQBit = new System.Windows.Forms.Label();
            this.labReadyBit = new System.Windows.Forms.Label();
            this.labLOW_ReadyBit = new System.Windows.Forms.Label();
            this.labUpPosition = new System.Windows.Forms.Label();
            this.labDownPosition = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labCurrentPortMode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbWIP_BCR_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labUnloading = new System.Windows.Forms.Label();
            this.labLoading = new System.Windows.Forms.Label();
            this.labAutoStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labReadyStatusBit);
            this.flowLayoutPanel1.Controls.Add(this.labLoadRequestBit);
            this.flowLayoutPanel1.Controls.Add(this.labUnloadRequestBit);
            this.flowLayoutPanel1.Controls.Add(this.labPortExistBit);
            this.flowLayoutPanel1.Controls.Add(this.labL_REQBit);
            this.flowLayoutPanel1.Controls.Add(this.labU_REQBit);
            this.flowLayoutPanel1.Controls.Add(this.labReadyBit);
            this.flowLayoutPanel1.Controls.Add(this.labLOW_ReadyBit);
            this.flowLayoutPanel1.Controls.Add(this.labUpPosition);
            this.flowLayoutPanel1.Controls.Add(this.labDownPosition);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 136);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // labReadyStatusBit
            // 
            this.labReadyStatusBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labReadyStatusBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labReadyStatusBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labReadyStatusBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labReadyStatusBit.ForeColor = System.Drawing.Color.White;
            this.labReadyStatusBit.Location = new System.Drawing.Point(4, 4);
            this.labReadyStatusBit.Margin = new System.Windows.Forms.Padding(1);
            this.labReadyStatusBit.Name = "labReadyStatusBit";
            this.labReadyStatusBit.Size = new System.Drawing.Size(88, 30);
            this.labReadyStatusBit.TabIndex = 9;
            this.labReadyStatusBit.Text = "Ready Status";
            this.labReadyStatusBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLoadRequestBit
            // 
            this.labLoadRequestBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labLoadRequestBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labLoadRequestBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labLoadRequestBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labLoadRequestBit.ForeColor = System.Drawing.Color.White;
            this.labLoadRequestBit.Location = new System.Drawing.Point(94, 4);
            this.labLoadRequestBit.Margin = new System.Windows.Forms.Padding(1);
            this.labLoadRequestBit.Name = "labLoadRequestBit";
            this.labLoadRequestBit.Size = new System.Drawing.Size(88, 30);
            this.labLoadRequestBit.TabIndex = 0;
            this.labLoadRequestBit.Text = "Load Request";
            this.labLoadRequestBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUnloadRequestBit
            // 
            this.labUnloadRequestBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labUnloadRequestBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUnloadRequestBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labUnloadRequestBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labUnloadRequestBit.ForeColor = System.Drawing.Color.White;
            this.labUnloadRequestBit.Location = new System.Drawing.Point(184, 4);
            this.labUnloadRequestBit.Margin = new System.Windows.Forms.Padding(1);
            this.labUnloadRequestBit.Name = "labUnloadRequestBit";
            this.labUnloadRequestBit.Size = new System.Drawing.Size(88, 30);
            this.labUnloadRequestBit.TabIndex = 1;
            this.labUnloadRequestBit.Text = "Unload Request";
            this.labUnloadRequestBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labPortExistBit
            // 
            this.labPortExistBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labPortExistBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labPortExistBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labPortExistBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labPortExistBit.ForeColor = System.Drawing.Color.White;
            this.labPortExistBit.Location = new System.Drawing.Point(274, 4);
            this.labPortExistBit.Margin = new System.Windows.Forms.Padding(1);
            this.labPortExistBit.Name = "labPortExistBit";
            this.labPortExistBit.Size = new System.Drawing.Size(88, 30);
            this.labPortExistBit.TabIndex = 2;
            this.labPortExistBit.Text = "Port Exist";
            this.labPortExistBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labL_REQBit
            // 
            this.labL_REQBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labL_REQBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labL_REQBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labL_REQBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labL_REQBit.ForeColor = System.Drawing.Color.White;
            this.labL_REQBit.Location = new System.Drawing.Point(4, 36);
            this.labL_REQBit.Margin = new System.Windows.Forms.Padding(1);
            this.labL_REQBit.Name = "labL_REQBit";
            this.labL_REQBit.Size = new System.Drawing.Size(88, 30);
            this.labL_REQBit.TabIndex = 6;
            this.labL_REQBit.Text = "L_REQ";
            this.labL_REQBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labU_REQBit
            // 
            this.labU_REQBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labU_REQBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labU_REQBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labU_REQBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labU_REQBit.ForeColor = System.Drawing.Color.White;
            this.labU_REQBit.Location = new System.Drawing.Point(94, 36);
            this.labU_REQBit.Margin = new System.Windows.Forms.Padding(1);
            this.labU_REQBit.Name = "labU_REQBit";
            this.labU_REQBit.Size = new System.Drawing.Size(88, 30);
            this.labU_REQBit.TabIndex = 7;
            this.labU_REQBit.Text = "U_REQ";
            this.labU_REQBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labReadyBit
            // 
            this.labReadyBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labReadyBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labReadyBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labReadyBit.ForeColor = System.Drawing.Color.White;
            this.labReadyBit.Location = new System.Drawing.Point(184, 36);
            this.labReadyBit.Margin = new System.Windows.Forms.Padding(1);
            this.labReadyBit.Name = "labReadyBit";
            this.labReadyBit.Size = new System.Drawing.Size(88, 30);
            this.labReadyBit.TabIndex = 8;
            this.labReadyBit.Text = "READY";
            this.labReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLOW_ReadyBit
            // 
            this.labLOW_ReadyBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labLOW_ReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labLOW_ReadyBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labLOW_ReadyBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labLOW_ReadyBit.ForeColor = System.Drawing.Color.White;
            this.labLOW_ReadyBit.Location = new System.Drawing.Point(274, 36);
            this.labLOW_ReadyBit.Margin = new System.Windows.Forms.Padding(1);
            this.labLOW_ReadyBit.Name = "labLOW_ReadyBit";
            this.labLOW_ReadyBit.Size = new System.Drawing.Size(88, 30);
            this.labLOW_ReadyBit.TabIndex = 11;
            this.labLOW_ReadyBit.Text = "LOW_READY";
            this.labLOW_ReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUpPosition
            // 
            this.labUpPosition.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labUpPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUpPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labUpPosition.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labUpPosition.ForeColor = System.Drawing.Color.White;
            this.labUpPosition.Location = new System.Drawing.Point(4, 68);
            this.labUpPosition.Margin = new System.Windows.Forms.Padding(1);
            this.labUpPosition.Name = "labUpPosition";
            this.labUpPosition.Size = new System.Drawing.Size(88, 30);
            this.labUpPosition.TabIndex = 21;
            this.labUpPosition.Text = "LD_UP_POS";
            this.labUpPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labDownPosition
            // 
            this.labDownPosition.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labDownPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labDownPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labDownPosition.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labDownPosition.ForeColor = System.Drawing.Color.White;
            this.labDownPosition.Location = new System.Drawing.Point(94, 68);
            this.labDownPosition.Margin = new System.Windows.Forms.Padding(1);
            this.labDownPosition.Name = "labDownPosition";
            this.labDownPosition.Size = new System.Drawing.Size(88, 30);
            this.labDownPosition.TabIndex = 22;
            this.labDownPosition.Text = "LD_DOWN_POS";
            this.labDownPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labCurrentPortMode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 42);
            this.panel1.TabIndex = 33;
            // 
            // labCurrentPortMode
            // 
            this.labCurrentPortMode.BackColor = System.Drawing.Color.White;
            this.labCurrentPortMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labCurrentPortMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labCurrentPortMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labCurrentPortMode.Location = new System.Drawing.Point(0, 18);
            this.labCurrentPortMode.Margin = new System.Windows.Forms.Padding(0);
            this.labCurrentPortMode.Name = "labCurrentPortMode";
            this.labCurrentPortMode.Size = new System.Drawing.Size(109, 22);
            this.labCurrentPortMode.TabIndex = 1;
            this.labCurrentPortMode.Text = "label6";
            this.labCurrentPortMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Port Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbWIP_BCR_ID
            // 
            this.txbWIP_BCR_ID.BackColor = System.Drawing.Color.Black;
            this.txbWIP_BCR_ID.ForeColor = System.Drawing.Color.Yellow;
            this.txbWIP_BCR_ID.Location = new System.Drawing.Point(83, 195);
            this.txbWIP_BCR_ID.Name = "txbWIP_BCR_ID";
            this.txbWIP_BCR_ID.ReadOnly = true;
            this.txbWIP_BCR_ID.Size = new System.Drawing.Size(282, 23);
            this.txbWIP_BCR_ID.TabIndex = 26;
            this.txbWIP_BCR_ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(7, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "WIP BCR ID";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labUnloading
            // 
            this.labUnloading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labUnloading.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labUnloading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUnloading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labUnloading.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labUnloading.ForeColor = System.Drawing.Color.White;
            this.labUnloading.Location = new System.Drawing.Point(304, 8);
            this.labUnloading.Margin = new System.Windows.Forms.Padding(1);
            this.labUnloading.Name = "labUnloading";
            this.labUnloading.Size = new System.Drawing.Size(58, 19);
            this.labUnloading.TabIndex = 35;
            this.labUnloading.Text = "Unloading";
            this.labUnloading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLoading
            // 
            this.labLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labLoading.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labLoading.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labLoading.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labLoading.ForeColor = System.Drawing.Color.White;
            this.labLoading.Location = new System.Drawing.Point(244, 8);
            this.labLoading.Margin = new System.Windows.Forms.Padding(1);
            this.labLoading.Name = "labLoading";
            this.labLoading.Size = new System.Drawing.Size(58, 19);
            this.labLoading.TabIndex = 36;
            this.labLoading.Text = "Loading";
            this.labLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labAutoStatus
            // 
            this.labAutoStatus.BackColor = System.Drawing.Color.Orange;
            this.labAutoStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labAutoStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labAutoStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labAutoStatus.ForeColor = System.Drawing.Color.White;
            this.labAutoStatus.Location = new System.Drawing.Point(118, 8);
            this.labAutoStatus.Margin = new System.Windows.Forms.Padding(1);
            this.labAutoStatus.Name = "labAutoStatus";
            this.labAutoStatus.Size = new System.Drawing.Size(92, 42);
            this.labAutoStatus.TabIndex = 37;
            this.labAutoStatus.Text = "MANUAL";
            this.labAutoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UscConverterPortStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labAutoStatus);
            this.Controls.Add(this.labLoading);
            this.Controls.Add(this.labUnloading);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txbWIP_BCR_ID);
            this.Controls.Add(this.label1);
            this.Name = "UscConverterPortStatus";
            this.Size = new System.Drawing.Size(371, 222);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
