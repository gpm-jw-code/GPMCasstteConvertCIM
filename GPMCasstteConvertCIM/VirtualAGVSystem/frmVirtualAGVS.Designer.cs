namespace GPMCasstteConvertCIM.VirtualAGVSystem
{
    partial class frmVirtualAGVS
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_Cookie_io = new System.Windows.Forms.TextBox();
            this.txbCookie_ConnectSid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.carNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aGVIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSTID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batteryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.onlineStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtcuteTaskBtnColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clsAGVCStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSetCookie = new System.Windows.Forms.Button();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsAGVCStateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "io";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "connect.sid";
            // 
            // txb_Cookie_io
            // 
            this.txb_Cookie_io.Location = new System.Drawing.Point(89, 257);
            this.txb_Cookie_io.Name = "txb_Cookie_io";
            this.txb_Cookie_io.Size = new System.Drawing.Size(461, 23);
            this.txb_Cookie_io.TabIndex = 14;
            // 
            // txbCookie_ConnectSid
            // 
            this.txbCookie_ConnectSid.Location = new System.Drawing.Point(89, 228);
            this.txbCookie_ConnectSid.Name = "txbCookie_ConnectSid";
            this.txbCookie_ConnectSid.Size = new System.Drawing.Size(461, 23);
            this.txbCookie_ConnectSid.TabIndex = 13;
            this.txbCookie_ConnectSid.Text = "s%3AdxkjsEgCfNN2aq40Pbvs1rTryFKM53Eu.pCWvdU%2FtbbAAFEWxhxYnlRpuVvN5MgbgDAY7QZC18u" +
    "I";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carNameDataGridViewTextBoxColumn,
            this.aGVIDDataGridViewTextBoxColumn,
            this.tagIDDataGridViewTextBoxColumn,
            this.CSTID,
            this.batteryDataGridViewTextBoxColumn,
            this.runStateDataGridViewTextBoxColumn,
            this.onlineStateDataGridViewTextBoxColumn,
            this.autoStateDataGridViewTextBoxColumn,
            this.ExtcuteTaskBtnColumn});
            this.dataGridView1.DataSource = this.clsAGVCStateBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1138, 197);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // carNameDataGridViewTextBoxColumn
            // 
            this.carNameDataGridViewTextBoxColumn.DataPropertyName = "CarName";
            this.carNameDataGridViewTextBoxColumn.HeaderText = "CarName";
            this.carNameDataGridViewTextBoxColumn.Name = "carNameDataGridViewTextBoxColumn";
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            this.aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGV_ID";
            this.aGVIDDataGridViewTextBoxColumn.HeaderText = "AGV_ID";
            this.aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            // 
            // tagIDDataGridViewTextBoxColumn
            // 
            this.tagIDDataGridViewTextBoxColumn.DataPropertyName = "TagID";
            this.tagIDDataGridViewTextBoxColumn.HeaderText = "TagID";
            this.tagIDDataGridViewTextBoxColumn.Name = "tagIDDataGridViewTextBoxColumn";
            // 
            // CSTID
            // 
            this.CSTID.DataPropertyName = "CSTID";
            this.CSTID.HeaderText = "CSTID";
            this.CSTID.Name = "CSTID";
            this.CSTID.ReadOnly = true;
            // 
            // batteryDataGridViewTextBoxColumn
            // 
            this.batteryDataGridViewTextBoxColumn.DataPropertyName = "Battery";
            this.batteryDataGridViewTextBoxColumn.HeaderText = "Battery";
            this.batteryDataGridViewTextBoxColumn.Name = "batteryDataGridViewTextBoxColumn";
            // 
            // runStateDataGridViewTextBoxColumn
            // 
            this.runStateDataGridViewTextBoxColumn.DataPropertyName = "RunState";
            this.runStateDataGridViewTextBoxColumn.HeaderText = "RunState";
            this.runStateDataGridViewTextBoxColumn.Name = "runStateDataGridViewTextBoxColumn";
            // 
            // onlineStateDataGridViewTextBoxColumn
            // 
            this.onlineStateDataGridViewTextBoxColumn.DataPropertyName = "OnlineState";
            this.onlineStateDataGridViewTextBoxColumn.HeaderText = "OnlineState";
            this.onlineStateDataGridViewTextBoxColumn.Name = "onlineStateDataGridViewTextBoxColumn";
            // 
            // autoStateDataGridViewTextBoxColumn
            // 
            this.autoStateDataGridViewTextBoxColumn.DataPropertyName = "AutoState";
            this.autoStateDataGridViewTextBoxColumn.HeaderText = "AutoState";
            this.autoStateDataGridViewTextBoxColumn.Name = "autoStateDataGridViewTextBoxColumn";
            // 
            // ExtcuteTaskBtnColumn
            // 
            this.ExtcuteTaskBtnColumn.DataPropertyName = "AGV_ID";
            this.ExtcuteTaskBtnColumn.HeaderText = "";
            this.ExtcuteTaskBtnColumn.Name = "ExtcuteTaskBtnColumn";
            this.ExtcuteTaskBtnColumn.Text = "任務";
            this.ExtcuteTaskBtnColumn.UseColumnTextForButtonValue = true;
            // 
            // clsAGVCStateBindingSource
            // 
            this.clsAGVCStateBindingSource.DataSource = typeof(GPMCasstteConvertCIM.VirtualAGVSystem.clsAGVCState);
            // 
            // btnSetCookie
            // 
            this.btnSetCookie.Location = new System.Drawing.Point(556, 228);
            this.btnSetCookie.Name = "btnSetCookie";
            this.btnSetCookie.Size = new System.Drawing.Size(151, 52);
            this.btnSetCookie.TabIndex = 19;
            this.btnSetCookie.Text = "Set-Cookie";
            this.btnSetCookie.UseVisualStyleBackColor = true;
            this.btnSetCookie.Click += new System.EventHandler(this.btnSetCookie_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.Location = new System.Drawing.Point(12, 296);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(1138, 246);
            this.rtbLog.TabIndex = 20;
            this.rtbLog.Text = "";
            // 
            // frmVirtualAGVS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 554);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnSetCookie);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_Cookie_io);
            this.Controls.Add(this.txbCookie_ConnectSid);
            this.Name = "frmVirtualAGVS";
            this.Text = "AGVS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVirtualAGVS_FormClosing);
            this.Load += new System.EventHandler(this.frmVirtualAGVS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clsAGVCStateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label5;
        private Label label4;
        private TextBox txb_Cookie_io;
        private TextBox txbCookie_ConnectSid;
        private DataGridView dataGridView1;
        private BindingSource clsAGVCStateBindingSource;
        private Button btnSetCookie;
        private DataGridViewTextBoxColumn carNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tagIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CSTID;
        private DataGridViewTextBoxColumn batteryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn runStateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn onlineStateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn autoStateDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn ExtcuteTaskBtnColumn;
        private RichTextBox rtbLog;
    }
}