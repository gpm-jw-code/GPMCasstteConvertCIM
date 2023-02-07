namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    partial class TaskDispatchDialog
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbACTION = new System.Windows.Forms.ComboBox();
            this.cmbStations = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSlots = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendDispatchTask = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "動作";
            // 
            // cmbACTION
            // 
            this.cmbACTION.FormattingEnabled = true;
            this.cmbACTION.Location = new System.Drawing.Point(53, 15);
            this.cmbACTION.Name = "cmbACTION";
            this.cmbACTION.Size = new System.Drawing.Size(154, 23);
            this.cmbACTION.TabIndex = 1;
            this.cmbACTION.SelectedIndexChanged += new System.EventHandler(this.cmbACTION_SelectedIndexChanged);
            // 
            // cmbStations
            // 
            this.cmbStations.FormattingEnabled = true;
            this.cmbStations.Location = new System.Drawing.Point(53, 48);
            this.cmbStations.Name = "cmbStations";
            this.cmbStations.Size = new System.Drawing.Size(154, 23);
            this.cmbStations.TabIndex = 3;
            this.cmbStations.SelectedIndexChanged += new System.EventHandler(this.cmbStations_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "站點";
            // 
            // cmbSlots
            // 
            this.cmbSlots.FormattingEnabled = true;
            this.cmbSlots.Location = new System.Drawing.Point(252, 48);
            this.cmbSlots.Name = "cmbSlots";
            this.cmbSlots.Size = new System.Drawing.Size(115, 23);
            this.cmbSlots.TabIndex = 5;
            this.cmbSlots.Visible = false;
            this.cmbSlots.DropDown += new System.EventHandler(this.cmbSlots_DropDown);
            this.cmbSlots.SelectedIndexChanged += new System.EventHandler(this.cmbSlots_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Slot";
            this.label3.Visible = false;
            // 
            // btnSendDispatchTask
            // 
            this.btnSendDispatchTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSendDispatchTask.Location = new System.Drawing.Point(16, 89);
            this.btnSendDispatchTask.Name = "btnSendDispatchTask";
            this.btnSendDispatchTask.Size = new System.Drawing.Size(351, 66);
            this.btnSendDispatchTask.TabIndex = 6;
            this.btnSendDispatchTask.Text = "派送任務";
            this.btnSendDispatchTask.UseVisualStyleBackColor = true;
            this.btnSendDispatchTask.Click += new System.EventHandler(this.btnSendDispatchTask_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TaskDispatchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 167);
            this.Controls.Add(this.btnSendDispatchTask);
            this.Controls.Add(this.cmbSlots);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbACTION);
            this.Controls.Add(this.label1);
            this.Name = "TaskDispatchDialog";
            this.Text = "TaskDispatchDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox cmbACTION;
        private ComboBox cmbStations;
        private Label label2;
        private ComboBox cmbSlots;
        private Label label3;
        private Button btnSendDispatchTask;
        private System.Windows.Forms.Timer timer1;
    }
}