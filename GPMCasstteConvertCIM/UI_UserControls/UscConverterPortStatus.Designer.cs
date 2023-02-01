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
            this.labEQPStatusRunBit = new System.Windows.Forms.Label();
            this.labEQPStatusIdleBit = new System.Windows.Forms.Label();
            this.labEQPStatusDownBit = new System.Windows.Forms.Label();
            this.labL_REQBit = new System.Windows.Forms.Label();
            this.labU_REQBit = new System.Windows.Forms.Label();
            this.labReadyBit = new System.Windows.Forms.Label();
            this.labUP_ReadyBit = new System.Windows.Forms.Label();
            this.labLOW_ReadyBit = new System.Windows.Forms.Label();
            this.labMode_Change_Request = new System.Windows.Forms.Label();
            this.labUpPosition = new System.Windows.Forms.Label();
            this.labDownPosition = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labCurrentPortMode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbWIP_BCR_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.flowLayoutPanel1.Controls.Add(this.labEQPStatusRunBit);
            this.flowLayoutPanel1.Controls.Add(this.labEQPStatusIdleBit);
            this.flowLayoutPanel1.Controls.Add(this.labEQPStatusDownBit);
            this.flowLayoutPanel1.Controls.Add(this.labL_REQBit);
            this.flowLayoutPanel1.Controls.Add(this.labU_REQBit);
            this.flowLayoutPanel1.Controls.Add(this.labReadyBit);
            this.flowLayoutPanel1.Controls.Add(this.labUP_ReadyBit);
            this.flowLayoutPanel1.Controls.Add(this.labLOW_ReadyBit);
            this.flowLayoutPanel1.Controls.Add(this.labMode_Change_Request);
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
            // labEQPStatusRunBit
            // 
            this.labEQPStatusRunBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labEQPStatusRunBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labEQPStatusRunBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labEQPStatusRunBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labEQPStatusRunBit.ForeColor = System.Drawing.Color.White;
            this.labEQPStatusRunBit.Location = new System.Drawing.Point(4, 36);
            this.labEQPStatusRunBit.Margin = new System.Windows.Forms.Padding(1);
            this.labEQPStatusRunBit.Name = "labEQPStatusRunBit";
            this.labEQPStatusRunBit.Size = new System.Drawing.Size(88, 30);
            this.labEQPStatusRunBit.TabIndex = 3;
            this.labEQPStatusRunBit.Text = "EQP RUN";
            this.labEQPStatusRunBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labEQPStatusRunBit.Visible = false;
            // 
            // labEQPStatusIdleBit
            // 
            this.labEQPStatusIdleBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labEQPStatusIdleBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labEQPStatusIdleBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labEQPStatusIdleBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labEQPStatusIdleBit.ForeColor = System.Drawing.Color.White;
            this.labEQPStatusIdleBit.Location = new System.Drawing.Point(94, 36);
            this.labEQPStatusIdleBit.Margin = new System.Windows.Forms.Padding(1);
            this.labEQPStatusIdleBit.Name = "labEQPStatusIdleBit";
            this.labEQPStatusIdleBit.Size = new System.Drawing.Size(88, 30);
            this.labEQPStatusIdleBit.TabIndex = 4;
            this.labEQPStatusIdleBit.Text = "EQP IDLE";
            this.labEQPStatusIdleBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labEQPStatusIdleBit.Visible = false;
            // 
            // labEQPStatusDownBit
            // 
            this.labEQPStatusDownBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labEQPStatusDownBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labEQPStatusDownBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labEQPStatusDownBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labEQPStatusDownBit.ForeColor = System.Drawing.Color.White;
            this.labEQPStatusDownBit.Location = new System.Drawing.Point(184, 36);
            this.labEQPStatusDownBit.Margin = new System.Windows.Forms.Padding(1);
            this.labEQPStatusDownBit.Name = "labEQPStatusDownBit";
            this.labEQPStatusDownBit.Size = new System.Drawing.Size(88, 30);
            this.labEQPStatusDownBit.TabIndex = 5;
            this.labEQPStatusDownBit.Text = "EQP DOWN";
            this.labEQPStatusDownBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labEQPStatusDownBit.Visible = false;
            // 
            // labL_REQBit
            // 
            this.labL_REQBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labL_REQBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labL_REQBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labL_REQBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labL_REQBit.ForeColor = System.Drawing.Color.White;
            this.labL_REQBit.Location = new System.Drawing.Point(274, 36);
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
            this.labU_REQBit.Location = new System.Drawing.Point(4, 68);
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
            this.labReadyBit.Location = new System.Drawing.Point(94, 68);
            this.labReadyBit.Margin = new System.Windows.Forms.Padding(1);
            this.labReadyBit.Name = "labReadyBit";
            this.labReadyBit.Size = new System.Drawing.Size(88, 30);
            this.labReadyBit.TabIndex = 8;
            this.labReadyBit.Text = "READY";
            this.labReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUP_ReadyBit
            // 
            this.labUP_ReadyBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labUP_ReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUP_ReadyBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labUP_ReadyBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labUP_ReadyBit.ForeColor = System.Drawing.Color.White;
            this.labUP_ReadyBit.Location = new System.Drawing.Point(184, 68);
            this.labUP_ReadyBit.Margin = new System.Windows.Forms.Padding(1);
            this.labUP_ReadyBit.Name = "labUP_ReadyBit";
            this.labUP_ReadyBit.Size = new System.Drawing.Size(88, 30);
            this.labUP_ReadyBit.TabIndex = 10;
            this.labUP_ReadyBit.Text = "UP_READY";
            this.labUP_ReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labLOW_ReadyBit
            // 
            this.labLOW_ReadyBit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labLOW_ReadyBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labLOW_ReadyBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labLOW_ReadyBit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labLOW_ReadyBit.ForeColor = System.Drawing.Color.White;
            this.labLOW_ReadyBit.Location = new System.Drawing.Point(274, 68);
            this.labLOW_ReadyBit.Margin = new System.Windows.Forms.Padding(1);
            this.labLOW_ReadyBit.Name = "labLOW_ReadyBit";
            this.labLOW_ReadyBit.Size = new System.Drawing.Size(88, 30);
            this.labLOW_ReadyBit.TabIndex = 11;
            this.labLOW_ReadyBit.Text = "LOW_READY";
            this.labLOW_ReadyBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labMode_Change_Request
            // 
            this.labMode_Change_Request.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labMode_Change_Request.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labMode_Change_Request.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labMode_Change_Request.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labMode_Change_Request.ForeColor = System.Drawing.Color.White;
            this.labMode_Change_Request.Location = new System.Drawing.Point(4, 100);
            this.labMode_Change_Request.Margin = new System.Windows.Forms.Padding(1);
            this.labMode_Change_Request.Name = "labMode_Change_Request";
            this.labMode_Change_Request.Size = new System.Drawing.Size(88, 30);
            this.labMode_Change_Request.TabIndex = 20;
            this.labMode_Change_Request.Text = "Mode_Change_Request";
            this.labMode_Change_Request.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labUpPosition
            // 
            this.labUpPosition.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labUpPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labUpPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labUpPosition.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labUpPosition.ForeColor = System.Drawing.Color.White;
            this.labUpPosition.Location = new System.Drawing.Point(94, 100);
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
            this.labDownPosition.Location = new System.Drawing.Point(184, 100);
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
            // UscConverterPortStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
        private Label labEQPStatusRunBit;
        private Label labEQPStatusIdleBit;
        private Label labEQPStatusDownBit;
        private Label labL_REQBit;
        private Label labU_REQBit;
        private Label labReadyBit;
        private Label labUP_ReadyBit;
        private Label labLOW_ReadyBit;
        private Label labMode_Change_Request;
        private Panel panel1;
        private Label labCurrentPortMode;
        private Label label5;
        private TextBox txbWIP_BCR_ID;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private Label labUpPosition;
        private Label labDownPosition;
    }
}
