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
            ((System.ComponentModel.ISupportInitialize)dataBinding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
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
            labEQName.Location = new Point(117, 18);
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
            labPortName.Location = new Point(117, 50);
            labPortName.Name = "labPortName";
            labPortName.Size = new Size(57, 15);
            labPortName.TabIndex = 4;
            labPortName.Text = "Port 名稱";
            // 
            // textBox1
            // 
            textBox1.DataBindings.Add(new Binding("Text", dataBinding, "ModbusIP", true));
            textBox1.Enabled = false;
            textBox1.Location = new Point(117, 86);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "127.0.0.1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.DataBindings.Add(new Binding("Value", dataBinding, "ModbusPort", true));
            numericUpDown1.Enabled = false;
            numericUpDown1.Location = new Point(232, 87);
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
            label4.Location = new Point(220, 90);
            label4.Name = "label4";
            label4.Size = new Size(10, 15);
            label4.TabIndex = 9;
            label4.Text = ":";
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(310, 86);
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
            // frmEQPortInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 128);
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
            ((System.ComponentModel.ISupportInitialize)dataBinding).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
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
    }
}