namespace GPMCasstteConvertCIM.Forms
{
    partial class frmChangePortType
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
            cmbPortTypes = new ComboBox();
            label2 = new Label();
            labCurrentPortType = new Label();
            bindingSource1 = new BindingSource(components);
            clsConverterPortBindingSource = new BindingSource(components);
            labConverterPortTypeChangeRequestingNotify = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "當前類型";
            // 
            // cmbPortTypes
            // 
            cmbPortTypes.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            cmbPortTypes.FormattingEnabled = true;
            cmbPortTypes.Location = new Point(91, 55);
            cmbPortTypes.Name = "cmbPortTypes";
            cmbPortTypes.Size = new Size(297, 28);
            cmbPortTypes.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 2;
            label2.Text = "變更為";
            // 
            // labCurrentPortType
            // 
            labCurrentPortType.AutoSize = true;
            labCurrentPortType.DataBindings.Add(new Binding("Text", bindingSource1, "EPortType", true));
            labCurrentPortType.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labCurrentPortType.Location = new Point(91, 21);
            labCurrentPortType.Name = "labCurrentPortType";
            labCurrentPortType.Size = new Size(73, 20);
            labCurrentPortType.TabIndex = 3;
            labCurrentPortType.Text = "當前類型";
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // clsConverterPortBindingSource
            // 
            clsConverterPortBindingSource.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // labConverterPortTypeChangeRequestingNotify
            // 
            labConverterPortTypeChangeRequestingNotify.AutoSize = true;
            labConverterPortTypeChangeRequestingNotify.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labConverterPortTypeChangeRequestingNotify.ForeColor = Color.Crimson;
            labConverterPortTypeChangeRequestingNotify.Location = new Point(91, 89);
            labConverterPortTypeChangeRequestingNotify.Name = "labConverterPortTypeChangeRequestingNotify";
            labConverterPortTypeChangeRequestingNotify.Size = new Size(289, 20);
            labConverterPortTypeChangeRequestingNotify.TabIndex = 4;
            labConverterPortTypeChangeRequestingNotify.Text = "請稍後，轉換架Port Type 轉換請求中...";
            labConverterPortTypeChangeRequestingNotify.Visible = false;
            // 
            // frmChangePortType
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 118);
            Controls.Add(labConverterPortTypeChangeRequestingNotify);
            Controls.Add(labCurrentPortType);
            Controls.Add(label2);
            Controls.Add(cmbPortTypes);
            Controls.Add(label1);
            Name = "frmChangePortType";
            Text = "Port Type 變更";
            Load += frmChangePortType_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbPortTypes;
        private Label label2;
        private Label labCurrentPortType;
        private BindingSource clsConverterPortBindingSource;
        private BindingSource bindingSource1;
        private Label labConverterPortTypeChangeRequestingNotify;
    }
}