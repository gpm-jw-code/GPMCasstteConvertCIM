namespace GPMCasstteConvertCIM.Emulators
{
    partial class UscAGVSModbusClientEmulator
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            coilRegisterBindingSource = new BindingSource(components);
            dgvHoldingRegisterMap = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            digitalIORegisterBindingSource = new BindingSource(components);
            holdingRegisterBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvDI_EQPLC = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            State = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            label2 = new Label();
            dgvDO_AGVS = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            label3 = new Label();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            btnStopTest = new Button();
            label4 = new Label();
            cmbPortSelector = new ComboBox();
            btnStartLDSim = new Button();
            btnStartULDSim = new Button();
            rtbSimulationLog = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)coilRegisterBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoldingRegisterMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)digitalIORegisterBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)holdingRegisterBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDI_EQPLC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDO_AGVS).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvHoldingRegisterMap
            // 
            dgvHoldingRegisterMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoldingRegisterMap.AutoGenerateColumns = false;
            dgvHoldingRegisterMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoldingRegisterMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoldingRegisterMap.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn1, Value });
            dgvHoldingRegisterMap.DataSource = digitalIORegisterBindingSource;
            dgvHoldingRegisterMap.Location = new Point(3, 371);
            dgvHoldingRegisterMap.Name = "dgvHoldingRegisterMap";
            dgvHoldingRegisterMap.RowTemplate.Height = 25;
            dgvHoldingRegisterMap.Size = new Size(616, 322);
            dgvHoldingRegisterMap.TabIndex = 1;
            dgvHoldingRegisterMap.CellDoubleClick += dgvHoldingRegisterMap_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Address";
            dataGridViewTextBoxColumn2.HeaderText = "Register";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            dataGridViewTextBoxColumn1.HeaderText = "Description";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Value
            // 
            Value.DataPropertyName = "Value";
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.ReadOnly = true;
            // 
            // digitalIORegisterBindingSource
            // 
            digitalIORegisterBindingSource.DataSource = typeof(GPM_Modbus.DigitalIORegister);
            // 
            // holdingRegisterBindingSource
            // 
            holdingRegisterBindingSource.DataSource = typeof(GPM_Modbus.HoldingRegister);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(dgvDI_EQPLC, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvHoldingRegisterMap, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvDO_AGVS, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1244, 696);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvDI_EQPLC
            // 
            dgvDI_EQPLC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDI_EQPLC.AutoGenerateColumns = false;
            dgvDI_EQPLC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDI_EQPLC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDI_EQPLC.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, Description, State });
            dgvDI_EQPLC.DataSource = digitalIORegisterBindingSource;
            dgvDI_EQPLC.Location = new Point(3, 23);
            dgvDI_EQPLC.Name = "dgvDI_EQPLC";
            dgvDI_EQPLC.RowTemplate.Height = 25;
            dgvDI_EQPLC.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDI_EQPLC.Size = new Size(616, 322);
            dgvDI_EQPLC.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Address";
            dataGridViewTextBoxColumn7.HeaderText = "Register";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // State
            // 
            State.DataPropertyName = "State";
            State.HeaderText = "State";
            State.Name = "State";
            State.ReadOnly = true;
            // 
            // label1
            // 
            label1.BackColor = Color.DarkGoldenrod;
            label1.Dock = DockStyle.Fill;
            label1.ForeColor = Color.White;
            label1.Location = new Point(625, 0);
            label1.Name = "label1";
            label1.Size = new Size(616, 20);
            label1.TabIndex = 3;
            label1.Text = "DO";
            // 
            // label2
            // 
            label2.BackColor = Color.DarkCyan;
            label2.Dock = DockStyle.Fill;
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(616, 20);
            label2.TabIndex = 4;
            label2.Text = "DI";
            // 
            // dgvDO_AGVS
            // 
            dgvDO_AGVS.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDO_AGVS.AutoGenerateColumns = false;
            dgvDO_AGVS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDO_AGVS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDO_AGVS.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn3, dataGridViewCheckBoxColumn1 });
            dgvDO_AGVS.DataSource = digitalIORegisterBindingSource;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvDO_AGVS.DefaultCellStyle = dataGridViewCellStyle1;
            dgvDO_AGVS.Location = new Point(625, 23);
            dgvDO_AGVS.Name = "dgvDO_AGVS";
            dgvDO_AGVS.RowTemplate.Height = 25;
            dgvDO_AGVS.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvDO_AGVS.Size = new Size(616, 322);
            dgvDO_AGVS.TabIndex = 5;
            dgvDO_AGVS.CellMouseDoubleClick += DataGridView_CellMouseDoubleClick;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Address";
            dataGridViewTextBoxColumn4.HeaderText = "Register";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            dataGridViewTextBoxColumn3.HeaderText = "Description";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "State";
            dataGridViewCheckBoxColumn1.HeaderText = "State";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // label3
            // 
            label3.BackColor = Color.DarkGreen;
            label3.Dock = DockStyle.Fill;
            label3.ForeColor = Color.White;
            label3.Location = new Point(3, 348);
            label3.Name = "label3";
            label3.Size = new Size(616, 20);
            label3.TabIndex = 7;
            label3.Text = "Holding Register";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(625, 371);
            panel1.Name = "panel1";
            panel1.Size = new Size(616, 322);
            panel1.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStopTest);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbPortSelector);
            groupBox1.Controls.Add(btnStartLDSim);
            groupBox1.Controls.Add(btnStartULDSim);
            groupBox1.Controls.Add(rtbSimulationLog);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(616, 322);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "LD/ULD Simulation";
            // 
            // btnStopTest
            // 
            btnStopTest.Location = new Point(6, 185);
            btnStopTest.Name = "btnStopTest";
            btnStopTest.Size = new Size(135, 47);
            btnStopTest.TabIndex = 5;
            btnStopTest.Text = "停止測試";
            btnStopTest.UseVisualStyleBackColor = true;
            btnStopTest.Click += btnStopTest_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 28);
            label4.Name = "label4";
            label4.Size = new Size(67, 16);
            label4.TabIndex = 3;
            label4.Text = "Port Select";
            // 
            // cmbPortSelector
            // 
            cmbPortSelector.FormattingEnabled = true;
            cmbPortSelector.Items.AddRange(new object[] { "1", "2" });
            cmbPortSelector.Location = new Point(8, 49);
            cmbPortSelector.Name = "cmbPortSelector";
            cmbPortSelector.Size = new Size(133, 24);
            cmbPortSelector.TabIndex = 4;
            cmbPortSelector.SelectedIndexChanged += cmbPortSelector_SelectedIndexChanged;
            // 
            // btnStartLDSim
            // 
            btnStartLDSim.Location = new Point(6, 79);
            btnStartLDSim.Name = "btnStartLDSim";
            btnStartLDSim.Size = new Size(135, 47);
            btnStartLDSim.TabIndex = 0;
            btnStartLDSim.Text = "開始Load 交握模擬";
            btnStartLDSim.UseVisualStyleBackColor = true;
            btnStartLDSim.Click += btnStartLDSim_Click;
            // 
            // btnStartULDSim
            // 
            btnStartULDSim.Location = new Point(6, 132);
            btnStartULDSim.Name = "btnStartULDSim";
            btnStartULDSim.Size = new Size(135, 47);
            btnStartULDSim.TabIndex = 1;
            btnStartULDSim.Text = "開始Unload 交握模擬";
            btnStartULDSim.UseVisualStyleBackColor = true;
            btnStartULDSim.Click += btnStartULDSim_Click;
            // 
            // rtbSimulationLog
            // 
            rtbSimulationLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSimulationLog.Location = new Point(158, 49);
            rtbSimulationLog.Name = "rtbSimulationLog";
            rtbSimulationLog.Size = new Size(452, 267);
            rtbSimulationLog.TabIndex = 2;
            rtbSimulationLog.Text = "";
            // 
            // UscAGVSModbusClientEmulator
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "UscAGVSModbusClientEmulator";
            Size = new Size(1244, 696);
            Load += UscAGVSModbusClientEmulator_Load;
            ((System.ComponentModel.ISupportInitialize)coilRegisterBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoldingRegisterMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)digitalIORegisterBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)holdingRegisterBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDI_EQPLC).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDO_AGVS).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn indexDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn stateDataGridViewCheckBoxColumn;
        private BindingSource coilRegisterBindingSource;
        private DataGridView dgvHoldingRegisterMap;
        private TableLayoutPanel tableLayoutPanel1;
        private BindingSource holdingRegisterBindingSource;
        private Label label1;
        private Label label2;
        private DataGridView dgvDO_AGVS;
        private DataGridView dgvDI_EQPLC;
        private BindingSource digitalIORegisterBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn State;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Value;
        private Panel panel1;
        private RichTextBox rtbSimulationLog;
        private Button btnStartULDSim;
        private Button btnStartLDSim;
        private Label label4;
        private GroupBox groupBox1;
        private ComboBox cmbPortSelector;
        private Button button1;
        private Button btnStopTest;
    }
}
