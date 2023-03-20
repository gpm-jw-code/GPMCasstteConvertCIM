namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscConnectionStates
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labSECS_MCS = new System.Windows.Forms.Label();
            this.labSECS_AGVS = new System.Windows.Forms.Label();
            this.labConverter = new System.Windows.Forms.Label();
            this.labAGVC = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.labSECS_MCS);
            this.flowLayoutPanel1.Controls.Add(this.labSECS_AGVS);
            this.flowLayoutPanel1.Controls.Add(this.labConverter);
            this.flowLayoutPanel1.Controls.Add(this.labAGVC);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(131, 189);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labSECS_MCS
            // 
            this.labSECS_MCS.BackColor = System.Drawing.Color.Gray;
            this.labSECS_MCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labSECS_MCS.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labSECS_MCS.ForeColor = System.Drawing.Color.White;
            this.labSECS_MCS.Location = new System.Drawing.Point(2, 2);
            this.labSECS_MCS.Margin = new System.Windows.Forms.Padding(2);
            this.labSECS_MCS.Name = "labSECS_MCS";
            this.labSECS_MCS.Size = new System.Drawing.Size(126, 42);
            this.labSECS_MCS.TabIndex = 4;
            this.labSECS_MCS.Text = "SECS<->MCS";
            this.labSECS_MCS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labSECS_AGVS
            // 
            this.labSECS_AGVS.BackColor = System.Drawing.Color.Gray;
            this.labSECS_AGVS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labSECS_AGVS.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labSECS_AGVS.ForeColor = System.Drawing.Color.White;
            this.labSECS_AGVS.Location = new System.Drawing.Point(2, 48);
            this.labSECS_AGVS.Margin = new System.Windows.Forms.Padding(2);
            this.labSECS_AGVS.Name = "labSECS_AGVS";
            this.labSECS_AGVS.Size = new System.Drawing.Size(126, 42);
            this.labSECS_AGVS.TabIndex = 5;
            this.labSECS_AGVS.Text = "SECS<->AGVS";
            this.labSECS_AGVS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labConverter
            // 
            this.labConverter.BackColor = System.Drawing.Color.Gray;
            this.labConverter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labConverter.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labConverter.ForeColor = System.Drawing.Color.White;
            this.labConverter.Location = new System.Drawing.Point(2, 94);
            this.labConverter.Margin = new System.Windows.Forms.Padding(2);
            this.labConverter.Name = "labConverter";
            this.labConverter.Size = new System.Drawing.Size(126, 42);
            this.labConverter.TabIndex = 6;
            this.labConverter.Text = "Converter";
            this.labConverter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labConverter.Visible = false;
            // 
            // labAGVC
            // 
            this.labAGVC.BackColor = System.Drawing.Color.Gray;
            this.labAGVC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labAGVC.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labAGVC.ForeColor = System.Drawing.Color.White;
            this.labAGVC.Location = new System.Drawing.Point(2, 140);
            this.labAGVC.Margin = new System.Windows.Forms.Padding(2);
            this.labAGVC.Name = "labAGVC";
            this.labAGVC.Size = new System.Drawing.Size(126, 42);
            this.labAGVC.TabIndex = 7;
            this.labAGVC.Text = "AGVC";
            this.labAGVC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labAGVC.Visible = false;
            // 
            // UscConnectionStates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "UscConnectionStates";
            this.Size = new System.Drawing.Size(134, 192);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labSECS_MCS;
        private Label labSECS_AGVS;
        private Label labConverter;
        private Label labAGVC;
    }
}
