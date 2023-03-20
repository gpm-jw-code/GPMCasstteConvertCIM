namespace GPMCasstteConvertCIM.Forms
{
    partial class frmPortEventReportTest
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
            btnInServiceReport = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // btnInServiceReport
            // 
            btnInServiceReport.Location = new Point(12, 12);
            btnInServiceReport.Name = "btnInServiceReport";
            btnInServiceReport.Size = new Size(273, 36);
            btnInServiceReport.TabIndex = 0;
            btnInServiceReport.Text = "Port In Service";
            btnInServiceReport.UseVisualStyleBackColor = true;
            btnInServiceReport.Click += btnInServiceReport_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 54);
            button1.Name = "button1";
            button1.Size = new Size(273, 36);
            button1.TabIndex = 1;
            button1.Text = "Port Out Of Service";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnOutOfServiceReport_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 96);
            button2.Name = "button2";
            button2.Size = new Size(273, 36);
            button2.TabIndex = 2;
            button2.Text = "Port Type Input";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnPortTypeOutputReport_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 138);
            button3.Name = "button3";
            button3.Size = new Size(273, 36);
            button3.TabIndex = 3;
            button3.Text = "Port Type Output";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btnPortTypeOutputReport_Click;
            // 
            // frmPortEventReportTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 191);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnInServiceReport);
            Name = "frmPortEventReportTest";
            Text = "轉換架 Port- SECS Report Test";
            Load += frmPortEventReportTest_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnInServiceReport;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}