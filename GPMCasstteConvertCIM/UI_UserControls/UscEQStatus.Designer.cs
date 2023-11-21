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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            btnColumn = new DataGridViewButtonColumn();
            clsConverterPortBindingSource = new BindingSource(components);
            panel1 = new Panel();
            label1 = new Label();
            eqCombobox1 = new EQCombobox();
            btnOpenMasterMemTb = new Button();
            ckbSimulationMode = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).BeginInit();
            panel1.SuspendLayout();
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EqName, PortName, StatusMemStartAddress, dataGridViewCheckBoxColumn1, unloadRequestDataGridViewCheckBoxColumn, portExistDataGridViewCheckBoxColumn, lDUPPOSDataGridViewCheckBoxColumn, lDDOWNPOSDataGridViewCheckBoxColumn, portStatusDownDataGridViewCheckBoxColumn, To_EQ_UP, To_EQ_Low, CMD_Reserve_Up, CMD_Reserve_Low, btnColumn });
            dataGridView1.DataSource = clsConverterPortBindingSource;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Transparent;
            dataGridViewCellStyle4.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.Black;
            dataGridView1.Location = new Point(0, 39);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle5.Font = new Font("微軟正黑體", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.Padding = new Padding(1);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle5.SelectionForeColor = Color.Gray;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowCellToolTips = false;
            dataGridView1.ShowEditingIcon = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(1295, 547);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            dataGridView1.SizeChanged += dataGridView1_SizeChanged;
            dataGridView1.Resize += dataGridView1_Resize;
            // 
            // EqName
            // 
            EqName.DataPropertyName = "EqName";
            EqName.HeaderText = "設備名稱";
            EqName.Name = "EqName";
            EqName.ReadOnly = true;
            // 
            // PortName
            // 
            PortName.DataPropertyName = "PortName";
            PortName.HeaderText = "PORT名稱";
            PortName.Name = "PortName";
            PortName.ReadOnly = true;
            // 
            // StatusMemStartAddress
            // 
            StatusMemStartAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            StatusMemStartAddress.DataPropertyName = "StatusMemStartAddress";
            StatusMemStartAddress.HeaderText = "起始位址";
            StatusMemStartAddress.Name = "StatusMemStartAddress";
            StatusMemStartAddress.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "LoadRequest";
            dataGridViewCheckBoxColumn1.HeaderText = "Load Request(+0)";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // unloadRequestDataGridViewCheckBoxColumn
            // 
            unloadRequestDataGridViewCheckBoxColumn.DataPropertyName = "UnloadRequest";
            unloadRequestDataGridViewCheckBoxColumn.HeaderText = "Unload Request(+1)";
            unloadRequestDataGridViewCheckBoxColumn.Name = "unloadRequestDataGridViewCheckBoxColumn";
            unloadRequestDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // portExistDataGridViewCheckBoxColumn
            // 
            portExistDataGridViewCheckBoxColumn.DataPropertyName = "PortExist";
            portExistDataGridViewCheckBoxColumn.HeaderText = "Port Exist(+2)";
            portExistDataGridViewCheckBoxColumn.Name = "portExistDataGridViewCheckBoxColumn";
            portExistDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDUPPOSDataGridViewCheckBoxColumn
            // 
            lDUPPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_UP_POS";
            lDUPPOSDataGridViewCheckBoxColumn.HeaderText = "LD UPPO (+3)";
            lDUPPOSDataGridViewCheckBoxColumn.Name = "lDUPPOSDataGridViewCheckBoxColumn";
            lDUPPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDDOWNPOSDataGridViewCheckBoxColumn
            // 
            lDDOWNPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_DOWN_POS";
            lDDOWNPOSDataGridViewCheckBoxColumn.HeaderText = "LD DOWN POS(+4)";
            lDDOWNPOSDataGridViewCheckBoxColumn.Name = "lDDOWNPOSDataGridViewCheckBoxColumn";
            lDDOWNPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            lDDOWNPOSDataGridViewCheckBoxColumn.ToolTipText = " ";
            // 
            // portStatusDownDataGridViewCheckBoxColumn
            // 
            portStatusDownDataGridViewCheckBoxColumn.DataPropertyName = "PortStatusDown";
            portStatusDownDataGridViewCheckBoxColumn.HeaderText = "EQP Status Down(+5)";
            portStatusDownDataGridViewCheckBoxColumn.Name = "portStatusDownDataGridViewCheckBoxColumn";
            portStatusDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // To_EQ_UP
            // 
            To_EQ_UP.DataPropertyName = "To_EQ_UP";
            To_EQ_UP.HeaderText = "To_EQ UP";
            To_EQ_UP.Name = "To_EQ_UP";
            To_EQ_UP.ReadOnly = true;
            // 
            // To_EQ_Low
            // 
            To_EQ_Low.DataPropertyName = "To_EQ_Low";
            To_EQ_Low.HeaderText = "To_EQ Low";
            To_EQ_Low.Name = "To_EQ_Low";
            To_EQ_Low.ReadOnly = true;
            // 
            // CMD_Reserve_Up
            // 
            CMD_Reserve_Up.DataPropertyName = "CMD_Reserve_Up";
            CMD_Reserve_Up.HeaderText = "CMD Reserve Up";
            CMD_Reserve_Up.Name = "CMD_Reserve_Up";
            CMD_Reserve_Up.ReadOnly = true;
            // 
            // CMD_Reserve_Low
            // 
            CMD_Reserve_Low.DataPropertyName = "CMD_Reserve_Low";
            CMD_Reserve_Low.HeaderText = "CMD Reserve Low";
            CMD_Reserve_Low.Name = "CMD_Reserve_Low";
            CMD_Reserve_Low.ReadOnly = true;
            // 
            // btnColumn
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.Silver;
            dataGridViewCellStyle3.Font = new Font("微軟正黑體", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnColumn.DefaultCellStyle = dataGridViewCellStyle3;
            btnColumn.HeaderText = "詳情";
            btnColumn.Name = "btnColumn";
            btnColumn.ReadOnly = true;
            btnColumn.Text = "詳情";
            btnColumn.UseColumnTextForButtonValue = true;
            // 
            // clsConverterPortBindingSource
            // 
            clsConverterPortBindingSource.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(eqCombobox1);
            panel1.Controls.Add(btnOpenMasterMemTb);
            panel1.Controls.Add(ckbSimulationMode);
            panel1.Dock = DockStyle.Top;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1295, 39);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 5);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 3;
            label1.Text = "選擇設備";
            // 
            // eqCombobox1
            // 
            eqCombobox1.AutoSize = true;
            eqCombobox1.DisplayText = "";
            eqCombobox1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            eqCombobox1.Location = new Point(87, 5);
            eqCombobox1.Margin = new Padding(0);
            eqCombobox1.Name = "eqCombobox1";
            eqCombobox1.SelectedIndex = -1;
            eqCombobox1.Size = new Size(264, 31);
            eqCombobox1.TabIndex = 2;
            eqCombobox1.OnEQSelectChanged += eqCombobox1_OnEQSelectChanged;
            // 
            // btnOpenMasterMemTb
            // 
            btnOpenMasterMemTb.BackColor = Color.FromArgb(64, 64, 64);
            btnOpenMasterMemTb.Dock = DockStyle.Right;
            btnOpenMasterMemTb.FlatStyle = FlatStyle.Flat;
            btnOpenMasterMemTb.Font = new Font("微軟正黑體", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenMasterMemTb.ForeColor = Color.WhiteSmoke;
            btnOpenMasterMemTb.Location = new Point(1187, 0);
            btnOpenMasterMemTb.Name = "btnOpenMasterMemTb";
            btnOpenMasterMemTb.Size = new Size(108, 39);
            btnOpenMasterMemTb.TabIndex = 1;
            btnOpenMasterMemTb.Text = "Memory Table";
            btnOpenMasterMemTb.UseVisualStyleBackColor = false;
            btnOpenMasterMemTb.Click += btnOpenMasterMemTb_Click;
            // 
            // ckbSimulationMode
            // 
            ckbSimulationMode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckbSimulationMode.AutoSize = true;
            ckbSimulationMode.Location = new Point(1084, 8);
            ckbSimulationMode.Name = "ckbSimulationMode";
            ckbSimulationMode.Size = new Size(74, 19);
            ckbSimulationMode.TabIndex = 0;
            ckbSimulationMode.Text = "模擬模式";
            ckbSimulationMode.UseVisualStyleBackColor = true;
            ckbSimulationMode.Visible = false;
            ckbSimulationMode.CheckedChanged += ckbSimulationMode_CheckedChanged;
            // 
            // UscEQStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UscEQStatus";
            Size = new Size(1295, 586);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource clsConverterPortBindingSource;
        private Panel panel1;
        private CheckBox ckbSimulationMode;
        private Button btnOpenMasterMemTb;
        private EQCombobox eqCombobox1;
        private Label label1;
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
        private DataGridViewButtonColumn btnColumn;
    }
}
