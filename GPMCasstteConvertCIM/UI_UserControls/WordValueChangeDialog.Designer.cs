namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class WordValueChangeDialog
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
            labWordAddress = new Label();
            label1 = new Label();
            label2 = new Label();
            btnComfirm = new Button();
            btnCancel = new Button();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // labWordAddress
            // 
            labWordAddress.AutoSize = true;
            labWordAddress.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labWordAddress.Location = new Point(12, 9);
            labWordAddress.Name = "labWordAddress";
            labWordAddress.Size = new Size(69, 25);
            labWordAddress.TabIndex = 0;
            labWordAddress.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(16, 45);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 2;
            label1.Text = "原始值";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(16, 76);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 4;
            label2.Text = "新值";
            // 
            // btnComfirm
            // 
            btnComfirm.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnComfirm.Location = new Point(20, 111);
            btnComfirm.Name = "btnComfirm";
            btnComfirm.Size = new Size(113, 49);
            btnComfirm.TabIndex = 5;
            btnComfirm.Text = "變更";
            btnComfirm.UseVisualStyleBackColor = true;
            btnComfirm.Click += btnComfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancel.Location = new Point(150, 111);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(113, 49);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Enabled = false;
            numericUpDown1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(87, 45);
            numericUpDown1.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 32767, 0, 0, int.MinValue });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(176, 28);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.TextAlign = HorizontalAlignment.Center;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown2.Location = new Point(87, 74);
            numericUpDown2.Maximum = new decimal(new int[] { 32767, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 32767, 0, 0, int.MinValue });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(176, 28);
            numericUpDown2.TabIndex = 0;
            numericUpDown2.TextAlign = HorizontalAlignment.Center;
            numericUpDown2.KeyDown += numericUpDown2_KeyDown;
            // 
            // WordValueChangeDialog
            // 
            AcceptButton = btnComfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(288, 172);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(btnCancel);
            Controls.Add(btnComfirm);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labWordAddress);
            Name = "WordValueChangeDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Load += WordValueChangeDialog_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labWordAddress;
        private Label label1;
        private Label label2;
        private Button btnComfirm;
        private Button btnCancel;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
    }
}