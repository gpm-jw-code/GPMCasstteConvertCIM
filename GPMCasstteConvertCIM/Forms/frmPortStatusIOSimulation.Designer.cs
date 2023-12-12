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
            btnLoadable = new Button();
            btnUnloadable = new Button();
            btnDownStatus = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            tlpSingleConvertsContainer = new TableLayoutPanel();
            tlpIndicatorContainer = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            labIndicator = new Label();
            tlpSingleConvertsContainer.SuspendLayout();
            tlpIndicatorContainer.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
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
            tlpSingleConvertsContainer.Dock = DockStyle.Bottom;
            tlpSingleConvertsContainer.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tlpSingleConvertsContainer.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tlpSingleConvertsContainer.Location = new Point(0, 43);
            tlpSingleConvertsContainer.Name = "tlpSingleConvertsContainer";
            tlpSingleConvertsContainer.RowCount = 1;
            tlpSingleConvertsContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpSingleConvertsContainer.Size = new Size(367, 133);
            tlpSingleConvertsContainer.TabIndex = 13;
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
            // frmPortStatusIOSimulation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(367, 176);
            Controls.Add(tlpSingleConvertsContainer);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Name = "frmPortStatusIOSimulation";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPortStatusIOSimulation";
            TopMost = true;
            Load += frmPortStatusIOSimulation_Load;
            tlpSingleConvertsContainer.ResumeLayout(false);
            tlpIndicatorContainer.ResumeLayout(false);
            tlpIndicatorContainer.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
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
    }
}