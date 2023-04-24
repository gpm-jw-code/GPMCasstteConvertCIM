namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscAlarmShow
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlAlarmShow = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labAlarmTime = new Label();
            labEQPName = new Label();
            labAlarmLevel = new Label();
            labDescription = new Label();
            labClassify = new Label();
            btnAlarmReset = new Button();
            labAlarmCount = new Label();
            animate = new System.Windows.Forms.Timer(components);
            alarm_loop_play_timer = new System.Windows.Forms.Timer(components);
            pnlAlarmShow.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAlarmShow
            // 
            pnlAlarmShow.BackColor = Color.Transparent;
            pnlAlarmShow.BorderStyle = BorderStyle.Fixed3D;
            pnlAlarmShow.Controls.Add(tableLayoutPanel1);
            pnlAlarmShow.Controls.Add(btnAlarmReset);
            pnlAlarmShow.Controls.Add(labAlarmCount);
            pnlAlarmShow.Dock = DockStyle.Top;
            pnlAlarmShow.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            pnlAlarmShow.ForeColor = Color.White;
            pnlAlarmShow.Location = new Point(0, 0);
            pnlAlarmShow.Name = "pnlAlarmShow";
            pnlAlarmShow.Size = new Size(1179, 74);
            pnlAlarmShow.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 162F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label5, 4, 0);
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(labAlarmTime, 0, 1);
            tableLayoutPanel1.Controls.Add(labEQPName, 3, 1);
            tableLayoutPanel1.Controls.Add(labAlarmLevel, 1, 1);
            tableLayoutPanel1.Controls.Add(labDescription, 4, 1);
            tableLayoutPanel1.Controls.Add(labClassify, 2, 1);
            tableLayoutPanel1.Location = new Point(42, 5);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1022, 62);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(689, 1);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 1, 0, 2);
            label5.Size = new Size(329, 29);
            label5.TabIndex = 12;
            label5.Text = "警報描述";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(497, 1);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 1, 0, 2);
            label4.Size = new Size(185, 29);
            label4.TabIndex = 11;
            label4.Text = "設備名稱";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(283, 1);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 1, 0, 2);
            label3.Size = new Size(207, 29);
            label3.TabIndex = 10;
            label3.Text = "類別";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(167, 1);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 1, 0, 2);
            label2.Size = new Size(109, 29);
            label2.TabIndex = 9;
            label2.Text = "LEVEL";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Microsoft JhengHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 1, 0, 2);
            label1.Size = new Size(156, 29);
            label1.TabIndex = 8;
            label1.Text = "時間";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labAlarmTime
            // 
            labAlarmTime.Dock = DockStyle.Fill;
            labAlarmTime.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labAlarmTime.Location = new Point(4, 31);
            labAlarmTime.Name = "labAlarmTime";
            labAlarmTime.Padding = new Padding(0, 1, 0, 2);
            labAlarmTime.Size = new Size(156, 30);
            labAlarmTime.TabIndex = 0;
            labAlarmTime.Text = " 2022/03/31 12:00:00";
            labAlarmTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labEQPName
            // 
            labEQPName.AutoSize = true;
            labEQPName.BackColor = Color.Transparent;
            labEQPName.BorderStyle = BorderStyle.Fixed3D;
            labEQPName.Dock = DockStyle.Fill;
            labEQPName.FlatStyle = FlatStyle.Flat;
            labEQPName.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labEQPName.Location = new Point(497, 31);
            labEQPName.Name = "labEQPName";
            labEQPName.Padding = new Padding(0, 1, 0, 2);
            labEQPName.Size = new Size(185, 30);
            labEQPName.TabIndex = 7;
            labEQPName.Text = " ";
            labEQPName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labAlarmLevel
            // 
            labAlarmLevel.BackColor = Color.Transparent;
            labAlarmLevel.BorderStyle = BorderStyle.Fixed3D;
            labAlarmLevel.Dock = DockStyle.Fill;
            labAlarmLevel.FlatStyle = FlatStyle.Flat;
            labAlarmLevel.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labAlarmLevel.Location = new Point(167, 31);
            labAlarmLevel.Name = "labAlarmLevel";
            labAlarmLevel.Padding = new Padding(0, 1, 0, 2);
            labAlarmLevel.Size = new Size(109, 30);
            labAlarmLevel.TabIndex = 1;
            labAlarmLevel.Text = "WARNING";
            labAlarmLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDescription
            // 
            labDescription.BackColor = Color.Transparent;
            labDescription.BorderStyle = BorderStyle.Fixed3D;
            labDescription.Dock = DockStyle.Fill;
            labDescription.FlatStyle = FlatStyle.Flat;
            labDescription.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labDescription.Location = new Point(689, 31);
            labDescription.Name = "labDescription";
            labDescription.Padding = new Padding(0, 1, 0, 2);
            labDescription.Size = new Size(329, 30);
            labDescription.TabIndex = 4;
            labDescription.Text = " ";
            labDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labClassify
            // 
            labClassify.AutoSize = true;
            labClassify.BackColor = Color.Transparent;
            labClassify.BorderStyle = BorderStyle.Fixed3D;
            labClassify.Dock = DockStyle.Fill;
            labClassify.FlatStyle = FlatStyle.Flat;
            labClassify.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            labClassify.Location = new Point(283, 31);
            labClassify.Name = "labClassify";
            labClassify.Padding = new Padding(0, 1, 0, 2);
            labClassify.Size = new Size(207, 30);
            labClassify.TabIndex = 3;
            labClassify.Text = " ";
            labClassify.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAlarmReset
            // 
            btnAlarmReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAlarmReset.BackColor = SystemColors.ActiveCaption;
            btnAlarmReset.FlatStyle = FlatStyle.System;
            btnAlarmReset.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlarmReset.Location = new Point(1070, 1);
            btnAlarmReset.Name = "btnAlarmReset";
            btnAlarmReset.Size = new Size(102, 65);
            btnAlarmReset.TabIndex = 6;
            btnAlarmReset.Text = "異常復歸";
            btnAlarmReset.UseVisualStyleBackColor = false;
            btnAlarmReset.Visible = false;
            btnAlarmReset.Click += btnAlarmReset_Click;
            // 
            // labAlarmCount
            // 
            labAlarmCount.BorderStyle = BorderStyle.Fixed3D;
            labAlarmCount.Location = new Point(3, 5);
            labAlarmCount.Name = "labAlarmCount";
            labAlarmCount.Size = new Size(37, 61);
            labAlarmCount.TabIndex = 5;
            labAlarmCount.Text = "0";
            labAlarmCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // animate
            // 
            animate.Enabled = true;
            animate.Interval = 1000;
            animate.Tick += animate_Tick;
            // 
            // alarm_loop_play_timer
            // 
            alarm_loop_play_timer.Enabled = true;
            alarm_loop_play_timer.Interval = 1000;
            alarm_loop_play_timer.Tick += alarm_loop_play_timer_Tick;
            // 
            // UscAlarmShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Gray;
            Controls.Add(pnlAlarmShow);
            Name = "UscAlarmShow";
            Size = new Size(1179, 74);
            pnlAlarmShow.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlAlarmShow;
        private Label labAlarmLevel;
        private Label labAlarmTime;
        private System.Windows.Forms.Timer animate;
        private System.Windows.Forms.Timer alarm_loop_play_timer;
        private Label labDescription;
        private Label labClassify;
        private Label labAlarmCount;
        private Button btnAlarmReset;
        private Label labEQPName;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
