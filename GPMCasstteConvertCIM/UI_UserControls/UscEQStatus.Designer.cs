namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscEQStatus
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            EqName = new DataGridViewTextBoxColumn();
            PortName = new DataGridViewTextBoxColumn();
            StatusMemStartAddress = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            unloadRequestDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            portExistDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lDUPPOSDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lDDOWNPOSDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            portStatusDownDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            To_EQ_UP = new DataGridViewCheckBoxColumn();
            To_EQ_Low = new DataGridViewCheckBoxColumn();
            CMD_Reserve_Up = new DataGridViewCheckBoxColumn();
            CMD_Reserve_Low = new DataGridViewCheckBoxColumn();
            WIPINFO_BCR_ID = new DataGridViewTextBoxColumn();
            colModbus = new DataGridViewButtonColumn();
            EPortType = new DataGridViewTextBoxColumn();
            colIOSim = new DataGridViewCheckBoxColumn();
            colSettings = new DataGridViewButtonColumn();
            clsConverterPortBindingSource = new BindingSource(components);
            pnlHeader = new Panel();
            labConnectionState = new Label();
            ckbSimulationMode = new CheckBox();
            eqCombobox1 = new EQCombobox();
            btnOpenMasterMemTb = new Button();
            label1 = new Label();
            portTypeContextMenuStrip = new ContextMenuStrip(components);
            changePortTypeToolStripMenuItem = new ToolStripMenuItem();
            debugToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).BeginInit();
            pnlHeader.SuspendLayout();
            portTypeContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.PaleGoldenrod;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeight = 60;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EqName, PortName, StatusMemStartAddress, dataGridViewCheckBoxColumn1, unloadRequestDataGridViewCheckBoxColumn, portExistDataGridViewCheckBoxColumn, lDUPPOSDataGridViewCheckBoxColumn, lDDOWNPOSDataGridViewCheckBoxColumn, portStatusDownDataGridViewCheckBoxColumn, To_EQ_UP, To_EQ_Low, CMD_Reserve_Up, CMD_Reserve_Low, WIPINFO_BCR_ID, colModbus, EPortType, colIOSim, colSettings });
            dataGridView1.DataSource = clsConverterPortBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Transparent;
            dataGridViewCellStyle5.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(0, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle6.Font = new Font("微軟正黑體", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.Padding = new Padding(1);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle6.SelectionForeColor = Color.Gray;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(1355, 559);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.SizeChanged += dataGridView1_SizeChanged;
            dataGridView1.Resize += dataGridView1_Resize;
            // 
            // EqName
            // 
            EqName.DataPropertyName = "EqName";
            EqName.HeaderText = "設備名稱";
            EqName.MinimumWidth = 6;
            EqName.Name = "EqName";
            EqName.ReadOnly = true;
            // 
            // PortName
            // 
            PortName.DataPropertyName = "PortName";
            PortName.HeaderText = "PORT名稱";
            PortName.MinimumWidth = 6;
            PortName.Name = "PortName";
            PortName.ReadOnly = true;
            // 
            // StatusMemStartAddress
            // 
            StatusMemStartAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StatusMemStartAddress.DataPropertyName = "StatusMemStartAddress";
            StatusMemStartAddress.HeaderText = "起始位址";
            StatusMemStartAddress.MinimumWidth = 6;
            StatusMemStartAddress.Name = "StatusMemStartAddress";
            StatusMemStartAddress.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "LoadRequest";
            dataGridViewCheckBoxColumn1.HeaderText = "Load Request(+0)";
            dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // unloadRequestDataGridViewCheckBoxColumn
            // 
            unloadRequestDataGridViewCheckBoxColumn.DataPropertyName = "UnloadRequest";
            unloadRequestDataGridViewCheckBoxColumn.HeaderText = "Unload Request(+1)";
            unloadRequestDataGridViewCheckBoxColumn.MinimumWidth = 6;
            unloadRequestDataGridViewCheckBoxColumn.Name = "unloadRequestDataGridViewCheckBoxColumn";
            unloadRequestDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // portExistDataGridViewCheckBoxColumn
            // 
            portExistDataGridViewCheckBoxColumn.DataPropertyName = "PortExist";
            portExistDataGridViewCheckBoxColumn.HeaderText = "Port Exist(+2)";
            portExistDataGridViewCheckBoxColumn.MinimumWidth = 6;
            portExistDataGridViewCheckBoxColumn.Name = "portExistDataGridViewCheckBoxColumn";
            portExistDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDUPPOSDataGridViewCheckBoxColumn
            // 
            lDUPPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_UP_POS";
            lDUPPOSDataGridViewCheckBoxColumn.HeaderText = "LD UPPO (+3)";
            lDUPPOSDataGridViewCheckBoxColumn.MinimumWidth = 6;
            lDUPPOSDataGridViewCheckBoxColumn.Name = "lDUPPOSDataGridViewCheckBoxColumn";
            lDUPPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDDOWNPOSDataGridViewCheckBoxColumn
            // 
            lDDOWNPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_DOWN_POS";
            lDDOWNPOSDataGridViewCheckBoxColumn.HeaderText = "LD DOWN POS(+4)";
            lDDOWNPOSDataGridViewCheckBoxColumn.MinimumWidth = 6;
            lDDOWNPOSDataGridViewCheckBoxColumn.Name = "lDDOWNPOSDataGridViewCheckBoxColumn";
            lDDOWNPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            lDDOWNPOSDataGridViewCheckBoxColumn.ToolTipText = " ";
            // 
            // portStatusDownDataGridViewCheckBoxColumn
            // 
            portStatusDownDataGridViewCheckBoxColumn.DataPropertyName = "PortStatusDown";
            portStatusDownDataGridViewCheckBoxColumn.HeaderText = "EQP Status Down(+5)";
            portStatusDownDataGridViewCheckBoxColumn.MinimumWidth = 6;
            portStatusDownDataGridViewCheckBoxColumn.Name = "portStatusDownDataGridViewCheckBoxColumn";
            portStatusDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // To_EQ_UP
            // 
            To_EQ_UP.DataPropertyName = "To_EQ_UP";
            To_EQ_UP.HeaderText = "To_EQ UP";
            To_EQ_UP.MinimumWidth = 6;
            To_EQ_UP.Name = "To_EQ_UP";
            To_EQ_UP.ReadOnly = true;
            // 
            // To_EQ_Low
            // 
            To_EQ_Low.DataPropertyName = "To_EQ_Low";
            To_EQ_Low.HeaderText = "To_EQ Low";
            To_EQ_Low.MinimumWidth = 6;
            To_EQ_Low.Name = "To_EQ_Low";
            To_EQ_Low.ReadOnly = true;
            // 
            // CMD_Reserve_Up
            // 
            CMD_Reserve_Up.DataPropertyName = "CMD_Reserve_Up";
            CMD_Reserve_Up.HeaderText = "CMD Reserve Up";
            CMD_Reserve_Up.MinimumWidth = 6;
            CMD_Reserve_Up.Name = "CMD_Reserve_Up";
            CMD_Reserve_Up.ReadOnly = true;
            // 
            // CMD_Reserve_Low
            // 
            CMD_Reserve_Low.DataPropertyName = "CMD_Reserve_Low";
            CMD_Reserve_Low.HeaderText = "CMD Reserve Low";
            CMD_Reserve_Low.MinimumWidth = 6;
            CMD_Reserve_Low.Name = "CMD_Reserve_Low";
            CMD_Reserve_Low.ReadOnly = true;
            // 
            // WIPINFO_BCR_ID
            // 
            WIPINFO_BCR_ID.DataPropertyName = "WIPINFO_BCR_ID";
            WIPINFO_BCR_ID.HeaderText = "BCR_ID";
            WIPINFO_BCR_ID.MinimumWidth = 6;
            WIPINFO_BCR_ID.Name = "WIPINFO_BCR_ID";
            WIPINFO_BCR_ID.ReadOnly = true;
            // 
            // colModbus
            // 
            colModbus.HeaderText = "Modbus";
            colModbus.MinimumWidth = 6;
            colModbus.Name = "colModbus";
            colModbus.ReadOnly = true;
            colModbus.Text = "Modbus";
            colModbus.UseColumnTextForButtonValue = true;
            colModbus.Visible = false;
            // 
            // EPortType
            // 
            EPortType.DataPropertyName = "EPortType";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            EPortType.DefaultCellStyle = dataGridViewCellStyle3;
            EPortType.HeaderText = "Port Type";
            EPortType.Name = "EPortType";
            EPortType.ReadOnly = true;
            // 
            // colIOSim
            // 
            colIOSim.DataPropertyName = "IsIOSimulating";
            colIOSim.HeaderText = "IO模擬";
            colIOSim.MinimumWidth = 6;
            colIOSim.Name = "colIOSim";
            colIOSim.ReadOnly = true;
            colIOSim.Visible = false;
            // 
            // colSettings
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.Silver;
            dataGridViewCellStyle4.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            colSettings.DefaultCellStyle = dataGridViewCellStyle4;
            colSettings.HeaderText = "設置";
            colSettings.MinimumWidth = 6;
            colSettings.Name = "colSettings";
            colSettings.ReadOnly = true;
            colSettings.Text = "設置";
            colSettings.UseColumnTextForButtonValue = true;
            colSettings.Visible = false;
            // 
            // clsConverterPortBindingSource
            // 
            clsConverterPortBindingSource.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Red;
            pnlHeader.Controls.Add(labConnectionState);
            pnlHeader.Controls.Add(ckbSimulationMode);
            pnlHeader.Controls.Add(eqCombobox1);
            pnlHeader.Controls.Add(btnOpenMasterMemTb);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.ForeColor = Color.White;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1355, 27);
            pnlHeader.TabIndex = 1;
            // 
            // labConnectionState
            // 
            labConnectionState.Dock = DockStyle.Fill;
            labConnectionState.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labConnectionState.Location = new Point(421, 0);
            labConnectionState.Name = "labConnectionState";
            labConnectionState.Padding = new Padding(0, 5, 0, 0);
            labConnectionState.Size = new Size(809, 27);
            labConnectionState.TabIndex = 4;
            labConnectionState.Text = "斷線";
            labConnectionState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ckbSimulationMode
            // 
            ckbSimulationMode.AutoSize = true;
            ckbSimulationMode.Dock = DockStyle.Left;
            ckbSimulationMode.Location = new Point(335, 0);
            ckbSimulationMode.Name = "ckbSimulationMode";
            ckbSimulationMode.Padding = new Padding(12, 0, 0, 0);
            ckbSimulationMode.Size = new Size(86, 27);
            ckbSimulationMode.TabIndex = 0;
            ckbSimulationMode.Text = "模擬模式";
            ckbSimulationMode.UseVisualStyleBackColor = true;
            ckbSimulationMode.Visible = false;
            ckbSimulationMode.CheckedChanged += ckbSimulationMode_CheckedChanged;
            // 
            // eqCombobox1
            // 
            eqCombobox1.AutoSize = true;
            eqCombobox1.DisplayText = "";
            eqCombobox1.Dock = DockStyle.Left;
            eqCombobox1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            eqCombobox1.Location = new Point(73, 0);
            eqCombobox1.Margin = new Padding(0);
            eqCombobox1.Name = "eqCombobox1";
            eqCombobox1.Padding = new Padding(0, 6, 0, 0);
            eqCombobox1.SelectedIndex = -1;
            eqCombobox1.Size = new Size(262, 27);
            eqCombobox1.TabIndex = 2;
            eqCombobox1.OnEQSelectChanged += eqCombobox1_OnEQSelectChanged;
            // 
            // btnOpenMasterMemTb
            // 
            btnOpenMasterMemTb.BackColor = SystemColors.Control;
            btnOpenMasterMemTb.Dock = DockStyle.Right;
            btnOpenMasterMemTb.FlatStyle = FlatStyle.Flat;
            btnOpenMasterMemTb.Font = new Font("微軟正黑體", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenMasterMemTb.ForeColor = Color.Black;
            btnOpenMasterMemTb.Location = new Point(1230, 0);
            btnOpenMasterMemTb.Name = "btnOpenMasterMemTb";
            btnOpenMasterMemTb.Size = new Size(125, 27);
            btnOpenMasterMemTb.TabIndex = 1;
            btnOpenMasterMemTb.Text = "Memory Table";
            btnOpenMasterMemTb.UseVisualStyleBackColor = false;
            btnOpenMasterMemTb.Click += btnOpenMasterMemTb_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 3, 0, 0);
            label1.Size = new Size(73, 23);
            label1.TabIndex = 3;
            label1.Text = "選擇設備";
            // 
            // portTypeContextMenuStrip
            // 
            portTypeContextMenuStrip.Items.AddRange(new ToolStripItem[] { changePortTypeToolStripMenuItem, debugToolStripMenuItem });
            portTypeContextMenuStrip.Name = "portTypeContextMenuStrip";
            portTypeContextMenuStrip.Size = new Size(153, 48);
            // 
            // changePortTypeToolStripMenuItem
            // 
            changePortTypeToolStripMenuItem.Name = "changePortTypeToolStripMenuItem";
            changePortTypeToolStripMenuItem.Size = new Size(152, 22);
            changePortTypeToolStripMenuItem.Text = "變更Port Type";
            changePortTypeToolStripMenuItem.Click += changePortTypeToolStripMenuItem_Click;
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            debugToolStripMenuItem.Size = new Size(152, 22);
            debugToolStripMenuItem.Text = "Debug";
            debugToolStripMenuItem.Click += debugToolStripMenuItem_Click;
            // 
            // UscEQStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(pnlHeader);
            Name = "UscEQStatus";
            Size = new Size(1355, 586);
            Load += UscEQStatus_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            portTypeContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource clsConverterPortBindingSource;
        private Panel pnlHeader;
        private CheckBox ckbSimulationMode;
        private Button btnOpenMasterMemTb;
        private EQCombobox eqCombobox1;
        private Label label1;
        private Label labConnectionState;
        private ContextMenuStrip portTypeContextMenuStrip;
        private ToolStripMenuItem changePortTypeToolStripMenuItem;
        private DataGridViewTextBoxColumn EqName;
        private DataGridViewTextBoxColumn PortName;
        private DataGridViewTextBoxColumn StatusMemStartAddress;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn unloadRequestDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn portExistDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn lDUPPOSDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn lDDOWNPOSDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn portStatusDownDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn To_EQ_UP;
        private DataGridViewCheckBoxColumn To_EQ_Low;
        private DataGridViewCheckBoxColumn CMD_Reserve_Up;
        private DataGridViewCheckBoxColumn CMD_Reserve_Low;
        private DataGridViewTextBoxColumn WIPINFO_BCR_ID;
        private DataGridViewButtonColumn colModbus;
        private DataGridViewTextBoxColumn EPortType;
        private DataGridViewCheckBoxColumn colIOSim;
        private DataGridViewButtonColumn colSettings;
        private ToolStripMenuItem debugToolStripMenuItem;
    }
}
