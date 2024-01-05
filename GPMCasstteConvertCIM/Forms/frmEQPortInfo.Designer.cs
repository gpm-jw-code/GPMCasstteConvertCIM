namespace GPMCasstteConvertCIM.Forms
{
    partial class frmEQPortInfo
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            labEQName = new Label();
            dataBinding = new BindingSource(components);
            labPortName = new Label();
            textBox1 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            checkBox1 = new CheckBox();
            bindingSource1 = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            checkBox2 = new CheckBox();
            numagvhsPORT = new NumericUpDown();
            label6 = new Label();
            checkBox3 = new CheckBox();
            ckbActiveHSModbusSlave = new CheckBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataBinding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numagvhsPORT).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "設備名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 50);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 1;
            label2.Text = "Port 名稱";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(12, 86);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 2;
            label3.Text = "Modbus 位址";
            // 
            // labEQName
            // 
            labEQName.AutoSize = true;
            labEQName.DataBindings.Add(new Binding("Text", dataBinding, "EqName", true));
            labEQName.Location = new Point(134, 18);
            labEQName.Name = "labEQName";
            labEQName.Size = new Size(57, 15);
            labEQName.TabIndex = 3;
            labEQName.Text = "Port 名稱";
            // 
            // dataBinding
            // 
            dataBinding.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // labPortName
            // 
            labPortName.AutoSize = true;
            labPortName.DataBindings.Add(new Binding("Text", dataBinding, "PortName", true));
            labPortName.Location = new Point(134, 50);
            labPortName.Name = "labPortName";
            labPortName.Size = new Size(57, 15);
            labPortName.TabIndex = 4;
            labPortName.Text = "Port 名稱";
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", dataBinding, "ModbusIP", true));
            textBox1.Enabled = false;
            textBox1.Location = new Point(134, 83);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "127.0.0.1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DataBindings.Add(new Binding("Value", dataBinding, "ModbusPort", true));
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(249, 84);
            numericUpDown1.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(72, 23);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.Value = new decimal(new int[] { 1502, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(237, 87);
            label4.Name = "label4";
            label4.Size = new Size(10, 15);
            label4.TabIndex = 9;
            label4.Text = ":";
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(327, 83);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(41, 25);
            checkBox1.TabIndex = 10;
            checkBox1.Text = "修改";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // checkBox2
            // 
            checkBox2.Appearance = Appearance.Button;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(327, 125);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(41, 25);
            checkBox2.TabIndex = 15;
            checkBox2.Text = "修改";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += CheckBox2_CheckedChanged;
            // 
            // numagvhsPORT
            // 
            numagvhsPORT.Enabled = false;
            numagvhsPORT.Location = new Point(249, 125);
            numagvhsPORT.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numagvhsPORT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numagvhsPORT.Name = "numagvhsPORT";
            numagvhsPORT.Size = new Size(72, 23);
            numagvhsPORT.TabIndex = 13;
            numagvhsPORT.Value = new decimal(new int[] { 1502, 0, 0, 0 });
            numagvhsPORT.ValueChanged += NumagvhsPORT_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 125);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 11;
            label6.Text = "Modbus 位址(交握)";
            // 
            // checkBox3
            // 
            checkBox3.Appearance = Appearance.Button;
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(12, 226);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(89, 25);
            checkBox3.TabIndex = 16;
            checkBox3.Text = "交握訊號測試";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += CheckBox3_CheckedChanged;
            // 
            // ckbActiveHSModbusSlave
            // 
            ckbActiveHSModbusSlave.AutoSize = true;
            ckbActiveHSModbusSlave.Location = new Point(134, 125);
            ckbActiveHSModbusSlave.Name = "ckbActiveHSModbusSlave";
            ckbActiveHSModbusSlave.Size = new Size(50, 19);
            ckbActiveHSModbusSlave.TabIndex = 17;
            ckbActiveHSModbusSlave.Text = "啟用";
            ckbActiveHSModbusSlave.UseVisualStyleBackColor = true;
            ckbActiveHSModbusSlave.CheckedChanged += CkbActiveHSModbusSlave_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(210, 125);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 18;
            label5.Text = "Port";
            // 
            // frmEQPortInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(378, 168);
            Controls.Add(label5);
            Controls.Add(ckbActiveHSModbusSlave);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(numagvhsPORT);
            Controls.Add(label6);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox1);
            Controls.Add(labPortName);
            Controls.Add(labEQName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DataBindings.Add(new Binding("Text", dataBinding, "PortNameWithEQName", true));
            Name = "frmEQPortInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmEQPortInfo";
            Load += FrmEQPortInfo_Load;
            ((System.ComponentModel.ISupportInitialize)dataBinding).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numagvhsPORT).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label labEQName;
        private Label labPortName;
        private BindingSource dataBinding;
        private TextBox textBox1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private CheckBox checkBox1;
        private BindingSource bindingSource1;
        private System.Windows.Forms.Timer timer1;
        private CheckBox checkBox2;
        private NumericUpDown numagvhsPORT;
        private Label label6;
        private CheckBox checkBox3;
        private CheckBox ckbActiveHSModbusSlave;
        private Label label5;
    }
}