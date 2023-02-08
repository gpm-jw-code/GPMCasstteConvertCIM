namespace GPMCasstteConvertCIM.Emulators
{
    partial class frmDemo
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
            this.groupBox_LoadDemo = new System.Windows.Forms.GroupBox();
            this.btnRunLoadDemo = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDemoAGV = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_UnloadDemo = new System.Windows.Forms.GroupBox();
            this.btnRunUnloadDemo = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox_LoadDemo.SuspendLayout();
            this.groupBox_UnloadDemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_LoadDemo
            // 
            this.groupBox_LoadDemo.Controls.Add(this.btnRunLoadDemo);
            this.groupBox_LoadDemo.Controls.Add(this.comboBox2);
            this.groupBox_LoadDemo.Controls.Add(this.label2);
            this.groupBox_LoadDemo.Controls.Add(this.comboBox1);
            this.groupBox_LoadDemo.Controls.Add(this.label1);
            this.groupBox_LoadDemo.Enabled = false;
            this.groupBox_LoadDemo.Location = new System.Drawing.Point(12, 58);
            this.groupBox_LoadDemo.Name = "groupBox_LoadDemo";
            this.groupBox_LoadDemo.Size = new System.Drawing.Size(707, 85);
            this.groupBox_LoadDemo.TabIndex = 0;
            this.groupBox_LoadDemo.TabStop = false;
            this.groupBox_LoadDemo.Text = "Load Demo";
            // 
            // btnRunLoadDemo
            // 
            this.btnRunLoadDemo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRunLoadDemo.Location = new System.Drawing.Point(565, 22);
            this.btnRunLoadDemo.Name = "btnRunLoadDemo";
            this.btnRunLoadDemo.Size = new System.Drawing.Size(136, 46);
            this.btnRunLoadDemo.TabIndex = 5;
            this.btnRunLoadDemo.Text = "放貨DEMO";
            this.btnRunLoadDemo.UseVisualStyleBackColor = true;
            this.btnRunLoadDemo.Click += new System.EventHandler(this.btnRunLoadDemo_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(251, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "轉換架";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Station";
            // 
            // cmbDemoAGV
            // 
            this.cmbDemoAGV.FormattingEnabled = true;
            this.cmbDemoAGV.Items.AddRange(new object[] {
            "AGV_1",
            "AGV_2"});
            this.cmbDemoAGV.Location = new System.Drawing.Point(83, 17);
            this.cmbDemoAGV.Name = "cmbDemoAGV";
            this.cmbDemoAGV.Size = new System.Drawing.Size(121, 23);
            this.cmbDemoAGV.TabIndex = 4;
            this.cmbDemoAGV.SelectedIndexChanged += new System.EventHandler(this.cmbDemoAGV_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "AGV";
            // 
            // groupBox_UnloadDemo
            // 
            this.groupBox_UnloadDemo.Controls.Add(this.btnRunUnloadDemo);
            this.groupBox_UnloadDemo.Controls.Add(this.comboBox3);
            this.groupBox_UnloadDemo.Controls.Add(this.label4);
            this.groupBox_UnloadDemo.Controls.Add(this.comboBox4);
            this.groupBox_UnloadDemo.Controls.Add(this.label5);
            this.groupBox_UnloadDemo.Enabled = false;
            this.groupBox_UnloadDemo.Location = new System.Drawing.Point(12, 155);
            this.groupBox_UnloadDemo.Name = "groupBox_UnloadDemo";
            this.groupBox_UnloadDemo.Size = new System.Drawing.Size(707, 85);
            this.groupBox_UnloadDemo.TabIndex = 5;
            this.groupBox_UnloadDemo.TabStop = false;
            this.groupBox_UnloadDemo.Text = "Unload Demo";
            // 
            // btnRunUnloadDemo
            // 
            this.btnRunUnloadDemo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRunUnloadDemo.Location = new System.Drawing.Point(565, 22);
            this.btnRunUnloadDemo.Name = "btnRunUnloadDemo";
            this.btnRunUnloadDemo.Size = new System.Drawing.Size(136, 46);
            this.btnRunUnloadDemo.TabIndex = 5;
            this.btnRunUnloadDemo.Text = "取貨DEMO";
            this.btnRunUnloadDemo.UseVisualStyleBackColor = true;
            this.btnRunUnloadDemo.Click += new System.EventHandler(this.btnRunUnloadDemo_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(251, 36);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 23);
            this.comboBox3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "轉換架";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(71, 36);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 23);
            this.comboBox4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Station";
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 260);
            this.Controls.Add(this.groupBox_UnloadDemo);
            this.Controls.Add(this.cmbDemoAGV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox_LoadDemo);
            this.Name = "frmDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDemo";
            this.Load += new System.EventHandler(this.frmDemo_Load);
            this.groupBox_LoadDemo.ResumeLayout(false);
            this.groupBox_LoadDemo.PerformLayout();
            this.groupBox_UnloadDemo.ResumeLayout(false);
            this.groupBox_UnloadDemo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox_LoadDemo;
        private Label label1;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label2;
        private Button btnRunLoadDemo;
        private ComboBox cmbDemoAGV;
        private Label label3;
        private GroupBox groupBox_UnloadDemo;
        private Button btnRunUnloadDemo;
        private ComboBox comboBox3;
        private Label label4;
        private ComboBox comboBox4;
        private Label label5;
    }
}