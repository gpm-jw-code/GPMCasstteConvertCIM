namespace GPMCasstteConvertCIM
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
            this.uscMemoryTable1 = new GPMCasstteConvertCIM.UI_UserControls.UscMemoryTable();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckbMonitor = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uscMemoryTable1
            // 
            this.uscMemoryTable1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uscMemoryTable1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uscMemoryTable1.Location = new System.Drawing.Point(12, 51);
            this.uscMemoryTable1.Name = "uscMemoryTable1";
            this.uscMemoryTable1.Size = new System.Drawing.Size(986, 501);
            this.uscMemoryTable1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.ckbMonitor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 45);
            this.panel1.TabIndex = 1;
            // 
            // ckbMonitor
            // 
            this.ckbMonitor.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckbMonitor.AutoSize = true;
            this.ckbMonitor.Checked = true;
            this.ckbMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMonitor.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.ckbMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbMonitor.Location = new System.Drawing.Point(12, 12);
            this.ckbMonitor.Name = "ckbMonitor";
            this.ckbMonitor.Size = new System.Drawing.Size(63, 25);
            this.ckbMonitor.TabIndex = 0;
            this.ckbMonitor.Text = "Monitor";
            this.ckbMonitor.UseVisualStyleBackColor = true;
            this.ckbMonitor.CheckedChanged += new System.EventHandler(this.ckbMonitor_CheckedChanged);
            // 
            // frmConvertPLCMemoryTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 564);
            this.Controls.Add(this.uscMemoryTable1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "frmConvertPLCMemoryTables";
            this.Text = "PLC Memory Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConvertPLCMemoryTables_FormClosing);
            this.Load += new System.EventHandler(this.frmConvertPLCMemoryTables_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UI_UserControls.UscMemoryTable uscMemoryTable1;
        private Panel panel1;
        private CheckBox ckbMonitor;
    }
}