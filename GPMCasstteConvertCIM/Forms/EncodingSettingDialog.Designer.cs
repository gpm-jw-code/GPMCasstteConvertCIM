namespace GPMCasstteConvertCIM.Forms
{
    partial class EncodingSettingDialog
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
            label1 = new Label();
            cmbEncodingSelector = new ComboBox();
            btnConfirm = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 23);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 0;
            label1.Text = "編碼模式";
            // 
            // cmbEncodingSelector
            // 
            cmbEncodingSelector.FormattingEnabled = true;
            cmbEncodingSelector.Location = new Point(121, 23);
            cmbEncodingSelector.Name = "cmbEncodingSelector";
            cmbEncodingSelector.Size = new Size(232, 33);
            cmbEncodingSelector.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(23, 77);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(330, 42);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "設定";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.DialogResult = DialogResult.Cancel;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(23, 125);
            button1.Name = "button1";
            button1.Size = new Size(330, 42);
            button1.TabIndex = 3;
            button1.Text = "取消";
            button1.UseVisualStyleBackColor = false;
            // 
            // EncodingSettingDialog
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(12F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button1;
            ClientSize = new Size(377, 176);
            Controls.Add(button1);
            Controls.Add(btnConfirm);
            Controls.Add(cmbEncodingSelector);
            Controls.Add(label1);
            Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "EncodingSettingDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "編碼設定";
            Load += EncodingSettingDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbEncodingSelector;
        private Button btnConfirm;
        private Button button1;
    }
}