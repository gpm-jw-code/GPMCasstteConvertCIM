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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.coilRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvHoldingRegisterMap = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.digitalIORegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holdingRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDI_EQPLC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDO_AGVS = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbSimulationLog = new System.Windows.Forms.RichTextBox();
            this.btnStartULDSim = new System.Windows.Forms.Button();
            this.btnStartLDSim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.coilRegisterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoldingRegisterMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalIORegisterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdingRegisterBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDI_EQPLC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDO_AGVS)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoldingRegisterMap
            // 
            this.dgvHoldingRegisterMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoldingRegisterMap.AutoGenerateColumns = false;
            this.dgvHoldingRegisterMap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoldingRegisterMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoldingRegisterMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.Value});
            this.dgvHoldingRegisterMap.DataSource = this.digitalIORegisterBindingSource;
            this.dgvHoldingRegisterMap.Location = new System.Drawing.Point(3, 371);
            this.dgvHoldingRegisterMap.Name = "dgvHoldingRegisterMap";
            this.dgvHoldingRegisterMap.RowTemplate.Height = 25;
            this.dgvHoldingRegisterMap.Size = new System.Drawing.Size(585, 322);
            this.dgvHoldingRegisterMap.TabIndex = 1;
            this.dgvHoldingRegisterMap.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoldingRegisterMap_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn2.HeaderText = "Register";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // digitalIORegisterBindingSource
            // 
            this.digitalIORegisterBindingSource.DataSource = typeof(GPMCasstteConvertCIM.GPM_Modbus.DigitalIORegister);
            // 
            // holdingRegisterBindingSource
            // 
            this.holdingRegisterBindingSource.DataSource = typeof(GPMCasstteConvertCIM.GPM_Modbus.HoldingRegister);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvDI_EQPLC, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHoldingRegisterMap, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDO_AGVS, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 696);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dgvDI_EQPLC
            // 
            this.dgvDI_EQPLC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDI_EQPLC.AutoGenerateColumns = false;
            this.dgvDI_EQPLC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDI_EQPLC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDI_EQPLC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.Description,
            this.State});
            this.dgvDI_EQPLC.DataSource = this.digitalIORegisterBindingSource;
            this.dgvDI_EQPLC.Location = new System.Drawing.Point(3, 23);
            this.dgvDI_EQPLC.Name = "dgvDI_EQPLC";
            this.dgvDI_EQPLC.RowTemplate.Height = 25;
            this.dgvDI_EQPLC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDI_EQPLC.Size = new System.Drawing.Size(585, 322);
            this.dgvDI_EQPLC.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn7.HeaderText = "Register";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(594, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(585, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "DO";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkCyan;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(585, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "DI";
            // 
            // dgvDO_AGVS
            // 
            this.dgvDO_AGVS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDO_AGVS.AutoGenerateColumns = false;
            this.dgvDO_AGVS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDO_AGVS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDO_AGVS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1});
            this.dgvDO_AGVS.DataSource = this.digitalIORegisterBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDO_AGVS.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDO_AGVS.Location = new System.Drawing.Point(594, 23);
            this.dgvDO_AGVS.Name = "dgvDO_AGVS";
            this.dgvDO_AGVS.RowTemplate.Height = 25;
            this.dgvDO_AGVS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDO_AGVS.Size = new System.Drawing.Size(585, 322);
            this.dgvDO_AGVS.TabIndex = 5;
            this.dgvDO_AGVS.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView_CellMouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn4.HeaderText = "Register";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "State";
            this.dataGridViewCheckBoxColumn1.HeaderText = "State";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkGreen;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(585, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Holding Register";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.rtbSimulationLog);
            this.panel1.Controls.Add(this.btnStartULDSim);
            this.panel1.Controls.Add(this.btnStartLDSim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(594, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 322);
            this.panel1.TabIndex = 8;
            // 
            // rtbSimulationLog
            // 
            this.rtbSimulationLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSimulationLog.Location = new System.Drawing.Point(154, 15);
            this.rtbSimulationLog.Name = "rtbSimulationLog";
            this.rtbSimulationLog.Size = new System.Drawing.Size(428, 304);
            this.rtbSimulationLog.TabIndex = 2;
            this.rtbSimulationLog.Text = "";
            // 
            // btnStartULDSim
            // 
            this.btnStartULDSim.Location = new System.Drawing.Point(13, 68);
            this.btnStartULDSim.Name = "btnStartULDSim";
            this.btnStartULDSim.Size = new System.Drawing.Size(135, 47);
            this.btnStartULDSim.TabIndex = 1;
            this.btnStartULDSim.Text = "開始Unload 交握模擬";
            this.btnStartULDSim.UseVisualStyleBackColor = true;
            this.btnStartULDSim.Click += new System.EventHandler(this.btnStartULDSim_Click);
            // 
            // btnStartLDSim
            // 
            this.btnStartLDSim.Location = new System.Drawing.Point(13, 15);
            this.btnStartLDSim.Name = "btnStartLDSim";
            this.btnStartLDSim.Size = new System.Drawing.Size(135, 47);
            this.btnStartLDSim.TabIndex = 0;
            this.btnStartLDSim.Text = "開始Load 交握模擬";
            this.btnStartLDSim.UseVisualStyleBackColor = true;
            this.btnStartLDSim.Click += new System.EventHandler(this.btnStartLDSim_Click);
            // 
            // UscAGVSModbusClientEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "UscAGVSModbusClientEmulator";
            this.Size = new System.Drawing.Size(1182, 696);
            this.Load += new System.EventHandler(this.UscAGVSModbusClientEmulator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.coilRegisterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoldingRegisterMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalIORegisterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holdingRegisterBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDI_EQPLC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDO_AGVS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
