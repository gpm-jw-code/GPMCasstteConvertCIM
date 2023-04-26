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
            btnAlarmReset = new Button();
            labAlarmCount = new Label();
            labDescription = new Label();
            labClassify = new Label();
            labAlarmLevel = new Label();
            labAlarmTime = new Label();
            animate = new System.Windows.Forms.Timer(components);
            alarm_loop_play_timer = new System.Windows.Forms.Timer(components);
            pnlAlarmShow.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAlarmShow
            // 
            pnlAlarmShow.BackColor = Color.Transparent;
            pnlAlarmShow.BorderStyle = BorderStyle.Fixed3D;
            pnlAlarmShow.Controls.Add(btnAlarmReset);
            pnlAlarmShow.Controls.Add(labAlarmCount);
            pnlAlarmShow.Controls.Add(labDescription);
            pnlAlarmShow.Controls.Add(labClassify);
            pnlAlarmShow.Controls.Add(labAlarmLevel);
            pnlAlarmShow.Controls.Add(labAlarmTime);
            pnlAlarmShow.Dock = DockStyle.Top;
            pnlAlarmShow.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            pnlAlarmShow.ForeColor = Color.White;
            pnlAlarmShow.Location = new Point(0, 0);
            pnlAlarmShow.Name = "pnlAlarmShow";
            pnlAlarmShow.Size = new Size(1088, 39);
            pnlAlarmShow.TabIndex = 10;
            // 
            // btnAlarmReset
            // 
            btnAlarmReset.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAlarmReset.BackColor = SystemColors.ActiveCaption;
            btnAlarmReset.FlatStyle = FlatStyle.System;
            btnAlarmReset.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlarmReset.Location = new Point(979, 1);
            btnAlarmReset.Name = "btnAlarmReset";
            btnAlarmReset.Size = new Size(102, 33);
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
            labAlarmCount.Size = new Size(32, 28);
            labAlarmCount.TabIndex = 5;
            labAlarmCount.Text = "0";
            labAlarmCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labDescription
            // 
            labDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labDescription.BackColor = Color.Transparent;
            labDescription.BorderStyle = BorderStyle.Fixed3D;
            labDescription.FlatStyle = FlatStyle.Flat;
            labDescription.Location = new Point(523, 4);
            labDescription.Name = "labDescription";
            labDescription.Size = new Size(450, 28);
            labDescription.TabIndex = 4;
            labDescription.Text = "{{Alarm Description}}";
            labDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labClassify
            // 
            labClassify.BackColor = Color.Transparent;
            labClassify.BorderStyle = BorderStyle.Fixed3D;
            labClassify.FlatStyle = FlatStyle.Flat;
            labClassify.Location = new Point(371, 4);
            labClassify.Name = "labClassify";
            labClassify.Size = new Size(146, 28);
            labClassify.TabIndex = 3;
            labClassify.Text = "{{Class}}";
            labClassify.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labAlarmLevel
            // 
            labAlarmLevel.BackColor = Color.Transparent;
            labAlarmLevel.BorderStyle = BorderStyle.Fixed3D;
            labAlarmLevel.FlatStyle = FlatStyle.Flat;
            labAlarmLevel.Location = new Point(252, 4);
            labAlarmLevel.Name = "labAlarmLevel";
            labAlarmLevel.Size = new Size(113, 28);
            labAlarmLevel.TabIndex = 1;
            labAlarmLevel.Text = "WARNING";
            labAlarmLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labAlarmTime
            // 
            labAlarmTime.Location = new Point(41, 4);
            labAlarmTime.Name = "labAlarmTime";
            labAlarmTime.Size = new Size(205, 28);
            labAlarmTime.TabIndex = 0;
            labAlarmTime.Text = "2023/04/26 12:00:00";
            labAlarmTime.TextAlign = ContentAlignment.MiddleLeft;
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
            alarm_loop_play_timer.Interval = 3000;
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
            Size = new Size(1088, 39);
            pnlAlarmShow.ResumeLayout(false);
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
    }
}
