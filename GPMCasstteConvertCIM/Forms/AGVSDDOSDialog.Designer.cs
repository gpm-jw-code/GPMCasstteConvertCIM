namespace GPMCasstteConvertCIM.Forms
{
    partial class AGVSDDOSDialog
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
            labText = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // labText
            // 
            labText.AutoSize = true;
            labText.Font = new Font("Microsoft JhengHei UI", 21F, FontStyle.Bold, GraphicsUnit.Point);
            labText.ForeColor = Color.White;
            labText.Location = new Point(12, 40);
            labText.Name = "labText";
            labText.Size = new Size(453, 72);
            labText.TabIndex = 0;
            labText.Text = "派車系統 SECS 訊息上報 DDOS! \r\n派車系統 SECS 訊息上報 超出限額!";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // AGVSDDOSDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Red;
            ClientSize = new Size(469, 161);
            Controls.Add(labText);
            MaximumSize = new Size(485, 200);
            MinimumSize = new Size(485, 200);
            Name = "AGVSDDOSDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AGVSDDOSDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labText;
        private System.Windows.Forms.Timer timer1;
    }
}