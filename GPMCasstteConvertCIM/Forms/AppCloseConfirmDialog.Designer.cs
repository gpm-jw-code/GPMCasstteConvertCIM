namespace GPMCasstteConvertCIM.Forms
{
    partial class AppCloseConfirmDialog
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
            btnAccept = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnAccept
            // 
            btnAccept.DialogResult = DialogResult.OK;
            btnAccept.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            btnAccept.Location = new Point(14, 148);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(224, 63);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "確定";
            btnAccept.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Microsoft JhengHei UI", 22F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(250, 148);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(224, 63);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(84, 38);
            label1.Name = "label1";
            label1.Size = new Size(339, 43);
            label1.TabIndex = 2;
            label1.Text = "確定要關閉CIM程式?";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(14, 91);
            label2.Name = "label2";
            label2.Size = new Size(460, 25);
            label2.TabIndex = 3;
            label2.Text = "Confirm the termination of the CIM application?";
            // 
            // AppCloseConfirmDialog
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(481, 223);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(497, 262);
            MinimizeBox = false;
            MinimumSize = new Size(497, 262);
            Name = "AppCloseConfirmDialog";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAccept;
        private Button btnCancel;
        private Label label1;
        private Label label2;
    }
}