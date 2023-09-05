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
            flowLayoutPanel1 = new FlowLayoutPanel();
            labSECS_MCS = new Label();
            labSECS_AGVS = new Label();
            labConverter = new Label();
            labAGVC = new Label();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(labSECS_MCS);
            flowLayoutPanel1.Controls.Add(labSECS_AGVS);
            flowLayoutPanel1.Controls.Add(labConverter);
            flowLayoutPanel1.Controls.Add(labAGVC);
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(131, 93);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // labSECS_MCS
            // 
            labSECS_MCS.BackColor = Color.Gray;
            labSECS_MCS.BorderStyle = BorderStyle.FixedSingle;
            labSECS_MCS.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labSECS_MCS.ForeColor = Color.White;
            labSECS_MCS.Location = new Point(2, 2);
            labSECS_MCS.Margin = new Padding(2);
            labSECS_MCS.Name = "labSECS_MCS";
            labSECS_MCS.Size = new Size(126, 42);
            labSECS_MCS.TabIndex = 4;
            labSECS_MCS.Text = "MCS";
            labSECS_MCS.TextAlign = ContentAlignment.MiddleCenter;
            labSECS_MCS.Click += labSECS_MCS_Click;
            // 
            // labSECS_AGVS
            // 
            labSECS_AGVS.BackColor = Color.Gray;
            labSECS_AGVS.BorderStyle = BorderStyle.FixedSingle;
            labSECS_AGVS.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labSECS_AGVS.ForeColor = Color.White;
            labSECS_AGVS.Location = new Point(2, 48);
            labSECS_AGVS.Margin = new Padding(2);
            labSECS_AGVS.Name = "labSECS_AGVS";
            labSECS_AGVS.Size = new Size(126, 42);
            labSECS_AGVS.TabIndex = 5;
            labSECS_AGVS.Text = "AGVS";
            labSECS_AGVS.TextAlign = ContentAlignment.MiddleCenter;
            labSECS_AGVS.Click += labSECS_AGVS_Click;
            // 
            // labConverter
            // 
            labConverter.BackColor = Color.Gray;
            labConverter.BorderStyle = BorderStyle.FixedSingle;
            labConverter.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labConverter.ForeColor = Color.White;
            labConverter.Location = new Point(2, 94);
            labConverter.Margin = new Padding(2);
            labConverter.Name = "labConverter";
            labConverter.Size = new Size(126, 42);
            labConverter.TabIndex = 6;
            labConverter.Text = "Converter";
            labConverter.TextAlign = ContentAlignment.MiddleLeft;
            labConverter.Visible = false;
            // 
            // labAGVC
            // 
            labAGVC.BackColor = Color.Gray;
            labAGVC.BorderStyle = BorderStyle.FixedSingle;
            labAGVC.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labAGVC.ForeColor = Color.White;
            labAGVC.Location = new Point(2, 140);
            labAGVC.Margin = new Padding(2);
            labAGVC.Name = "labAGVC";
            labAGVC.Size = new Size(126, 42);
            labAGVC.TabIndex = 7;
            labAGVC.Text = "AGVC";
            labAGVC.TextAlign = ContentAlignment.MiddleLeft;
            labAGVC.Visible = false;
            // 
            // UscConnectionStates
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanel1);
            MaximumSize = new Size(134, 96);
            MinimumSize = new Size(134, 96);
            Name = "UscConnectionStates";
            Size = new Size(134, 96);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labSECS_MCS;
        private Label labSECS_AGVS;
        private Label labConverter;
        private Label labAGVC;
    }
}
