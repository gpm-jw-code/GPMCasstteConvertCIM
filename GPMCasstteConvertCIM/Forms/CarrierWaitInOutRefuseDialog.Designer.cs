namespace GPMCasstteConvertCIM.Forms
{
    partial class CarrierWaitInOutRefuseDialog
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
            btnOK = new Button();
            labTitle = new Label();
            ckbPortExistCheck = new CheckBox();
            ckbCarrierIDReadDone = new CheckBox();
            labCarrierID = new Label();
            labTime = new Label();
            label1 = new Label();
            labPortName = new Label();
            labTimePassed = new Label();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Font = new Font("Microsoft JhengHei UI", 32F, FontStyle.Bold, GraphicsUnit.Point);
            btnOK.Location = new Point(0, 305);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(695, 95);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // labTitle
            // 
            labTitle.AutoSize = true;
            labTitle.Font = new Font("Microsoft JhengHei UI", 26F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            labTitle.ForeColor = Color.Red;
            labTitle.Location = new Point(12, 62);
            labTitle.Name = "labTitle";
            labTitle.Size = new Size(673, 44);
            labTitle.TabIndex = 1;
            labTitle.Text = "載具等待進入系統請求已被拒絕(狀態錯誤)";
            // 
            // ckbPortExistCheck
            // 
            ckbPortExistCheck.AutoSize = true;
            ckbPortExistCheck.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            ckbPortExistCheck.Location = new Point(21, 181);
            ckbPortExistCheck.Name = "ckbPortExistCheck";
            ckbPortExistCheck.Size = new Size(434, 42);
            ckbPortExistCheck.TabIndex = 2;
            ckbPortExistCheck.Text = "貨物存在於PORT中(在席檢知)";
            ckbPortExistCheck.UseVisualStyleBackColor = true;
            ckbPortExistCheck.Click += ckbsCheck_Click;
            // 
            // ckbCarrierIDReadDone
            // 
            ckbCarrierIDReadDone.AutoSize = true;
            ckbCarrierIDReadDone.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            ckbCarrierIDReadDone.Location = new Point(21, 243);
            ckbCarrierIDReadDone.Name = "ckbCarrierIDReadDone";
            ckbCarrierIDReadDone.Size = new Size(278, 42);
            ckbCarrierIDReadDone.TabIndex = 3;
            ckbCarrierIDReadDone.Text = "貨物ID已掃描完成";
            ckbCarrierIDReadDone.UseVisualStyleBackColor = true;
            ckbCarrierIDReadDone.Click += ckbsCheck_Click;
            // 
            // labCarrierID
            // 
            labCarrierID.BackColor = Color.FromArgb(51, 51, 51);
            labCarrierID.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labCarrierID.ForeColor = Color.White;
            labCarrierID.Location = new Point(295, 243);
            labCarrierID.Name = "labCarrierID";
            labCarrierID.Size = new Size(388, 42);
            labCarrierID.TabIndex = 4;
            labCarrierID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labTime
            // 
            labTime.BackColor = Color.RoyalBlue;
            labTime.Dock = DockStyle.Top;
            labTime.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labTime.ForeColor = Color.White;
            labTime.Location = new Point(0, 0);
            labTime.Name = "labTime";
            labTime.Size = new Size(695, 54);
            labTime.TabIndex = 5;
            labTime.Text = "2023/11/17 00:00:00";
            labTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 121);
            label1.Name = "label1";
            label1.Size = new Size(159, 38);
            label1.TabIndex = 6;
            label1.Text = "Port名稱 : ";
            // 
            // labPortName
            // 
            labPortName.BackColor = Color.FromArgb(51, 51, 51);
            labPortName.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            labPortName.ForeColor = Color.White;
            labPortName.Location = new Point(177, 121);
            labPortName.Name = "labPortName";
            labPortName.Size = new Size(506, 38);
            labPortName.TabIndex = 7;
            // 
            // labTimePassed
            // 
            labTimePassed.AccessibleRole = AccessibleRole.OutlineButton;
            labTimePassed.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labTimePassed.BackColor = Color.RoyalBlue;
            labTimePassed.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labTimePassed.ForeColor = Color.White;
            labTimePassed.Location = new Point(435, 0);
            labTimePassed.Name = "labTimePassed";
            labTimePassed.Size = new Size(260, 54);
            labTimePassed.TabIndex = 8;
            labTimePassed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CarrierWaitInOutRefuseDialog
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SandyBrown;
            ClientSize = new Size(695, 402);
            Controls.Add(labTimePassed);
            Controls.Add(labPortName);
            Controls.Add(label1);
            Controls.Add(labTime);
            Controls.Add(labCarrierID);
            Controls.Add(ckbCarrierIDReadDone);
            Controls.Add(ckbPortExistCheck);
            Controls.Add(labTitle);
            Controls.Add(btnOK);
            MaximizeBox = false;
            MaximumSize = new Size(711, 441);
            Name = "CarrierWaitInOutRefuseDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CIM MESSAGE";
            TopMost = true;
            Load += CarrierWaitInOutRefuseDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Label labTitle;
        private CheckBox ckbPortExistCheck;
        private CheckBox ckbCarrierIDReadDone;
        private Label labCarrierID;
        private Label labTime;
        private Label label1;
        private Label labPortName;
        private Label labTimePassed;
    }
}