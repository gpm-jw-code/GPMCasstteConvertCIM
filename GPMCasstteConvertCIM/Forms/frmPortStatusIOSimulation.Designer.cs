namespace GPMCasstteConvertCIM.Forms
{
    partial class frmPortStatusIOSimulation
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
            btnLoadable = new Button();
            btnUnloadable = new Button();
            btnDownStatus = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            tlpSingleConvertsContainer = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tlpIndicatorContainer = new TableLayoutPanel();
            labIndicator = new Label();
            ckbEQ_L_REQ = new CheckBox();
            ckbEQ_U_REQ = new CheckBox();
            ckbEQ_READY = new CheckBox();
            ckbEQ_BUSY = new CheckBox();
            ckb_agv_ready = new CheckBox();
            ckb_agv_busy = new CheckBox();
            ckb_agv_tr_req = new CheckBox();
            ckb_agv_valid = new CheckBox();
            ckb_agv_compt = new CheckBox();
            timer1 = new System.Windows.Forms.Timer(components);
            tlpSingleConvertsContainer.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tlpIndicatorContainer.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoadable
            // 
            btnLoadable.BackColor = SystemColors.Control;
            btnLoadable.FlatStyle = FlatStyle.Flat;
            btnLoadable.Font = new Font("微軟正黑體", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadable.ForeColor = Color.Black;
            btnLoadable.Location = new Point(4, 4);
            btnLoadable.Name = "btnLoadable";
            btnLoadable.Size = new Size(313, 36);
            btnLoadable.TabIndex = 2;
            btnLoadable.Text = "可載入(Load)";
            btnLoadable.UseVisualStyleBackColor = false;
            btnLoadable.Click += btnLoadable_Click;
            // 
            // btnUnloadable
            // 
            btnUnloadable.BackColor = SystemColors.Control;
            btnUnloadable.FlatStyle = FlatStyle.Flat;
            btnUnloadable.Font = new Font("微軟正黑體", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnUnloadable.ForeColor = Color.Black;
            btnUnloadable.Location = new Point(4, 47);
            btnUnloadable.Name = "btnUnloadable";
            btnUnloadable.Size = new Size(313, 36);
            btnUnloadable.TabIndex = 3;
            btnUnloadable.Text = "可載出(Unload)";
            btnUnloadable.UseVisualStyleBackColor = false;
            btnUnloadable.Click += btnUnloadable_Click;
            // 
            // btnDownStatus
            // 
            btnDownStatus.BackColor = Color.Red;
            btnDownStatus.FlatStyle = FlatStyle.Flat;
            btnDownStatus.Font = new Font("微軟正黑體", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnDownStatus.ForeColor = Color.White;
            btnDownStatus.Location = new Point(4, 90);
            btnDownStatus.Name = "btnDownStatus";
            btnDownStatus.Size = new Size(313, 37);
            btnDownStatus.TabIndex = 4;
            btnDownStatus.Text = "Down";
            btnDownStatus.UseVisualStyleBackColor = false;
            btnDownStatus.Click += btnDownStatus_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "ON", "OFF" });
            comboBox1.Location = new Point(47, 9);
            comboBox1.Margin = new Padding(0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(71, 23);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 8);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 3, 0, 0);
            label1.Size = new Size(41, 23);
            label1.TabIndex = 6;
            label1.Text = "啟用";
            // 
            // tlpSingleConvertsContainer
            // 
            tlpSingleConvertsContainer.AutoScroll = true;
            tlpSingleConvertsContainer.BackColor = Color.Transparent;
            tlpSingleConvertsContainer.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpSingleConvertsContainer.ColumnCount = 2;
            tlpSingleConvertsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.2328768F));
            tlpSingleConvertsContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 88.76712F));
            tlpSingleConvertsContainer.Controls.Add(tableLayoutPanel2, 1, 0);
            tlpSingleConvertsContainer.Controls.Add(tlpIndicatorContainer, 0, 0);
            tlpSingleConvertsContainer.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tlpSingleConvertsContainer.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpSingleConvertsContainer.Location = new Point(0, 43);
            tlpSingleConvertsContainer.Name = "tlpSingleConvertsContainer";
            tlpSingleConvertsContainer.RowCount = 1;
            tlpSingleConvertsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSingleConvertsContainer.Size = new Size(367, 133);
            tlpSingleConvertsContainer.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoScroll = true;
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnLoadable, 0, 0);
            tableLayoutPanel2.Controls.Add(btnUnloadable, 0, 1);
            tableLayoutPanel2.Controls.Add(btnDownStatus, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel2.Location = new Point(42, 1);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Size = new Size(324, 131);
            tableLayoutPanel2.TabIndex = 15;
            // 
            // tlpIndicatorContainer
            // 
            tlpIndicatorContainer.AutoScroll = true;
            tlpIndicatorContainer.BackColor = Color.Transparent;
            tlpIndicatorContainer.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpIndicatorContainer.ColumnCount = 1;
            tlpIndicatorContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpIndicatorContainer.Controls.Add(labIndicator, 0, 0);
            tlpIndicatorContainer.Dock = DockStyle.Fill;
            tlpIndicatorContainer.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tlpIndicatorContainer.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpIndicatorContainer.Location = new Point(1, 1);
            tlpIndicatorContainer.Margin = new Padding(0);
            tlpIndicatorContainer.Name = "tlpIndicatorContainer";
            tlpIndicatorContainer.RowCount = 3;
            tlpIndicatorContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpIndicatorContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpIndicatorContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlpIndicatorContainer.Size = new Size(40, 131);
            tlpIndicatorContainer.TabIndex = 14;
            // 
            // labIndicator
            // 
            labIndicator.AutoSize = true;
            labIndicator.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            labIndicator.Location = new Point(4, 1);
            labIndicator.Name = "labIndicator";
            labIndicator.Padding = new Padding(0, 3, 0, 0);
            labIndicator.Size = new Size(32, 31);
            labIndicator.TabIndex = 7;
            labIndicator.Text = "→";
            // 
            // ckbEQ_L_REQ
            // 
            ckbEQ_L_REQ.AutoSize = true;
            ckbEQ_L_REQ.Location = new Point(136, 195);
            ckbEQ_L_REQ.Name = "ckbEQ_L_REQ";
            ckbEQ_L_REQ.Size = new Size(62, 19);
            ckbEQ_L_REQ.TabIndex = 14;
            ckbEQ_L_REQ.Text = "L_REQ";
            ckbEQ_L_REQ.UseVisualStyleBackColor = true;
            ckbEQ_L_REQ.CheckedChanged += CkbEQ_L_REQ_CheckedChanged;
            // 
            // ckbEQ_U_REQ
            // 
            ckbEQ_U_REQ.AutoSize = true;
            ckbEQ_U_REQ.Location = new Point(136, 220);
            ckbEQ_U_REQ.Name = "ckbEQ_U_REQ";
            ckbEQ_U_REQ.Size = new Size(65, 19);
            ckbEQ_U_REQ.TabIndex = 15;
            ckbEQ_U_REQ.Text = "U_REQ";
            ckbEQ_U_REQ.UseVisualStyleBackColor = true;
            ckbEQ_U_REQ.CheckedChanged += CkbEQ_U_REQ_CheckedChanged;
            // 
            // ckbEQ_READY
            // 
            ckbEQ_READY.AutoSize = true;
            ckbEQ_READY.Location = new Point(136, 245);
            ckbEQ_READY.Name = "ckbEQ_READY";
            ckbEQ_READY.Size = new Size(65, 19);
            ckbEQ_READY.TabIndex = 16;
            ckbEQ_READY.Text = "READY";
            ckbEQ_READY.UseVisualStyleBackColor = true;
            ckbEQ_READY.CheckedChanged += CkbEQ_READY_CheckedChanged;
            // 
            // ckbEQ_BUSY
            // 
            ckbEQ_BUSY.AutoSize = true;
            ckbEQ_BUSY.Location = new Point(136, 270);
            ckbEQ_BUSY.Name = "ckbEQ_BUSY";
            ckbEQ_BUSY.Size = new Size(56, 19);
            ckbEQ_BUSY.TabIndex = 17;
            ckbEQ_BUSY.Text = "BUSY";
            ckbEQ_BUSY.UseVisualStyleBackColor = true;
            ckbEQ_BUSY.CheckedChanged += CkbEQ_BUSY_CheckedChanged;
            // 
            // ckb_agv_ready
            // 
            ckb_agv_ready.AutoSize = true;
            ckb_agv_ready.Enabled = false;
            ckb_agv_ready.Location = new Point(12, 270);
            ckb_agv_ready.Name = "ckb_agv_ready";
            ckb_agv_ready.Size = new Size(65, 19);
            ckb_agv_ready.TabIndex = 21;
            ckb_agv_ready.Text = "READY";
            ckb_agv_ready.UseVisualStyleBackColor = true;
            // 
            // ckb_agv_busy
            // 
            ckb_agv_busy.AutoSize = true;
            ckb_agv_busy.Enabled = false;
            ckb_agv_busy.Location = new Point(12, 245);
            ckb_agv_busy.Name = "ckb_agv_busy";
            ckb_agv_busy.Size = new Size(56, 19);
            ckb_agv_busy.TabIndex = 20;
            ckb_agv_busy.Text = "BUSY";
            ckb_agv_busy.UseVisualStyleBackColor = true;
            // 
            // ckb_agv_tr_req
            // 
            ckb_agv_tr_req.AutoSize = true;
            ckb_agv_tr_req.Enabled = false;
            ckb_agv_tr_req.Location = new Point(12, 220);
            ckb_agv_tr_req.Name = "ckb_agv_tr_req";
            ckb_agv_tr_req.Size = new Size(71, 19);
            ckb_agv_tr_req.TabIndex = 19;
            ckb_agv_tr_req.Text = "TR_REQ";
            ckb_agv_tr_req.UseVisualStyleBackColor = true;
            // 
            // ckb_agv_valid
            // 
            ckb_agv_valid.AutoSize = true;
            ckb_agv_valid.Enabled = false;
            ckb_agv_valid.Location = new Point(12, 195);
            ckb_agv_valid.Name = "ckb_agv_valid";
            ckb_agv_valid.Size = new Size(90, 19);
            ckb_agv_valid.TabIndex = 18;
            ckb_agv_valid.Text = "AGV_VALID";
            ckb_agv_valid.UseVisualStyleBackColor = true;
            // 
            // ckb_agv_compt
            // 
            ckb_agv_compt.AutoSize = true;
            ckb_agv_compt.Enabled = false;
            ckb_agv_compt.Location = new Point(12, 295);
            ckb_agv_compt.Name = "ckb_agv_compt";
            ckb_agv_compt.Size = new Size(70, 19);
            ckb_agv_compt.TabIndex = 22;
            ckb_agv_compt.Text = "COMPT";
            ckb_agv_compt.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += Timer1_Tick;
            // 
            // frmPortStatusIOSimulation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 330);
            Controls.Add(ckb_agv_compt);
            Controls.Add(ckb_agv_ready);
            Controls.Add(ckb_agv_busy);
            Controls.Add(ckb_agv_tr_req);
            Controls.Add(ckb_agv_valid);
            Controls.Add(ckbEQ_BUSY);
            Controls.Add(ckbEQ_READY);
            Controls.Add(ckbEQ_U_REQ);
            Controls.Add(ckbEQ_L_REQ);
            Controls.Add(tlpSingleConvertsContainer);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "frmPortStatusIOSimulation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPortStatusIOSimulation";
            TopMost = true;
            Load += frmPortStatusIOSimulation_Load;
            tlpSingleConvertsContainer.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tlpIndicatorContainer.ResumeLayout(false);
            tlpIndicatorContainer.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoadable;
        private Button btnUnloadable;
        private Button btnDownStatus;
        private ComboBox comboBox1;
        private Label label1;
        private TableLayoutPanel tlpSingleConvertsContainer;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tlpIndicatorContainer;
        private Label labIndicator;
        private CheckBox ckbEQ_L_REQ;
        private CheckBox ckbEQ_U_REQ;
        private CheckBox ckbEQ_READY;
        private CheckBox ckbEQ_BUSY;
        private CheckBox ckb_agv_ready;
        private CheckBox ckb_agv_busy;
        private CheckBox ckb_agv_tr_req;
        private CheckBox ckb_agv_valid;
        private CheckBox ckb_agv_compt;
        private System.Windows.Forms.Timer timer1;
    }
}