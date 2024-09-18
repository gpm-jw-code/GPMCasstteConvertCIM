namespace GPMCasstteConvertCIM.API.KGAGVS
{
    partial class UnknownIDNotifyDialog
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
            labCarrierID = new Label();
            labNotifyText = new Label();
            btnAccept = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // labCarrierID
            // 
            labCarrierID.BorderStyle = BorderStyle.FixedSingle;
            labCarrierID.Dock = DockStyle.Fill;
            labCarrierID.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            labCarrierID.ForeColor = Color.White;
            labCarrierID.Location = new Point(0, 112);
            labCarrierID.Margin = new Padding(3, 0, 3, 5);
            labCarrierID.Name = "labCarrierID";
            labCarrierID.Size = new Size(574, 80);
            labCarrierID.TabIndex = 7;
            labCarrierID.Text = "TUNXXXXXXX";
            labCarrierID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labNotifyText
            // 
            labNotifyText.Dock = DockStyle.Top;
            labNotifyText.Font = new Font("Microsoft JhengHei UI", 25F, FontStyle.Bold, GraphicsUnit.Point);
            labNotifyText.Location = new Point(0, 0);
            labNotifyText.Name = "labNotifyText";
            labNotifyText.Size = new Size(574, 112);
            labNotifyText.TabIndex = 6;
            labNotifyText.Text = "UNKnown ID";
            labNotifyText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            btnAccept.DialogResult = DialogResult.OK;
            btnAccept.Dock = DockStyle.Bottom;
            btnAccept.FlatStyle = FlatStyle.System;
            btnAccept.Font = new Font("Microsoft JhengHei UI", 28F, FontStyle.Bold, GraphicsUnit.Point);
            btnAccept.Location = new Point(0, 220);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(574, 86);
            btnAccept.TabIndex = 4;
            btnAccept.Text = "確定";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.Dock = DockStyle.Bottom;
            linkLabel1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkLabel1.LinkColor = Color.Black;
            linkLabel1.Location = new Point(0, 192);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(574, 28);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "前往帳籍管理頁面";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // UnknownIDNotifyDialog
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            CancelButton = btnAccept;
            ClientSize = new Size(574, 306);
            Controls.Add(labCarrierID);
            Controls.Add(linkLabel1);
            Controls.Add(labNotifyText);
            Controls.Add(btnAccept);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "UnknownIDNotifyDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Unknown ID 提醒";
            TopMost = true;
            ResumeLayout(false);
        }

        #endregion

        private Label labCarrierID;
        private Label labNotifyText;
        private Button btnAccept;
        private LinkLabel linkLabel1;
    }
}