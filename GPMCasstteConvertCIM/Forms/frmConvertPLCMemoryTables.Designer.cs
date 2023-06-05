namespace GPMCasstteConvertCIM.Forms
{
    partial class frmConvertPLCMemoryTables
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
            panel1 = new Panel();
            ckbMonitor = new CheckBox();
            uscMemoryTable1 = new UI_UserControls.UscMemoryTable();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ckbMonitor);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1385, 45);
            panel1.TabIndex = 1;
            // 
            // ckbMonitor
            // 
            ckbMonitor.Appearance = Appearance.Button;
            ckbMonitor.AutoSize = true;
            ckbMonitor.Checked = true;
            ckbMonitor.CheckState = CheckState.Checked;
            ckbMonitor.FlatAppearance.CheckedBackColor = Color.Lime;
            ckbMonitor.FlatStyle = FlatStyle.Flat;
            ckbMonitor.Location = new Point(12, 12);
            ckbMonitor.Name = "ckbMonitor";
            ckbMonitor.Size = new Size(63, 25);
            ckbMonitor.TabIndex = 0;
            ckbMonitor.Text = "Monitor";
            ckbMonitor.UseVisualStyleBackColor = true;
            ckbMonitor.CheckedChanged += ckbMonitor_CheckedChanged;
            // 
            // uscMemoryTable1
            // 
            uscMemoryTable1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            uscMemoryTable1.BorderStyle = BorderStyle.FixedSingle;
            uscMemoryTable1.Editable = true;
            uscMemoryTable1.Location = new Point(12, 51);
            uscMemoryTable1.Name = "uscMemoryTable1";
            uscMemoryTable1.Size = new Size(1361, 610);
            uscMemoryTable1.TabIndex = 0;
            // 
            // frmConvertPLCMemoryTables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1385, 673);
            Controls.Add(uscMemoryTable1);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Name = "frmConvertPLCMemoryTables";
            Text = "PLC Memory Table";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmConvertPLCMemoryTables_FormClosing;
            Load += frmConvertPLCMemoryTables_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private CheckBox ckbMonitor;
        private UI_UserControls.UscMemoryTable uscMemoryTable1;
    }
}