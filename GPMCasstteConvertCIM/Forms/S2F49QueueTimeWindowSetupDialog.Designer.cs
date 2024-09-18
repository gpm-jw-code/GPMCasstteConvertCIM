namespace GPMCasstteConvertCIM.Forms
{
    partial class S2F49QueueTimeWindowSetupDialog
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
            numud_time = new NumericUpDown();
            label2 = new Label();
            btnAccept = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numud_time).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 32);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 0;
            label1.Text = "時間設定";
            // 
            // numud_time
            // 
            numud_time.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            numud_time.Location = new Point(110, 31);
            numud_time.Name = "numud_time";
            numud_time.Size = new Size(164, 31);
            numud_time.TabIndex = 1;
            numud_time.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(280, 32);
            label2.Name = "label2";
            label2.Size = new Size(32, 25);
            label2.TabIndex = 2;
            label2.Text = "秒";
            // 
            // btnAccept
            // 
            btnAccept.Location = new Point(12, 81);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(148, 39);
            btnAccept.TabIndex = 3;
            btnAccept.Text = "修改";
            btnAccept.UseVisualStyleBackColor = true;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(166, 81);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(148, 39);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // S2F49QueueTimeWindowSetupDialog
            // 
            AcceptButton = btnAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(324, 132);
            Controls.Add(btnCancel);
            Controls.Add(btnAccept);
            Controls.Add(label2);
            Controls.Add(numud_time);
            Controls.Add(label1);
            Name = "S2F49QueueTimeWindowSetupDialog";
            Text = "S2F49 Transfer Command- 時間設定";
            Load += S2F49QueueTimeWindowSetupDialog_Load;
            ((System.ComponentModel.ISupportInitialize)numud_time).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numud_time;
        private Label label2;
        private Button btnAccept;
        private Button btnCancel;
    }
}