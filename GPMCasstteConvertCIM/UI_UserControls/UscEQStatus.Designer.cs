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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            EqName = new DataGridViewTextBoxColumn();
            PortName = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            unloadRequestDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            portExistDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lDUPPOSDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            lDDOWNPOSDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            portStatusDownDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            clsConverterPortBindingSource = new BindingSource(components);
            panel1 = new Panel();
            ckbSimulationMode = new CheckBox();
            btnOpenMasterMemTb = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = Color.PaleGoldenrod;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.BackgroundColor = Color.White;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("微軟正黑體", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.ColumnHeadersHeight = 42;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { EqName, PortName, dataGridViewCheckBoxColumn1, unloadRequestDataGridViewCheckBoxColumn, portExistDataGridViewCheckBoxColumn, lDUPPOSDataGridViewCheckBoxColumn, lDDOWNPOSDataGridViewCheckBoxColumn, portStatusDownDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = clsConverterPortBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 39);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle6.Font = new Font("微軟正黑體", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.Padding = new Padding(1);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle6.SelectionForeColor = Color.Gray;
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1031, 547);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // EqName
            // 
            EqName.DataPropertyName = "EqName";
            EqName.HeaderText = "EqName";
            EqName.Name = "EqName";
            EqName.ReadOnly = true;
            // 
            // PortName
            // 
            PortName.DataPropertyName = "PortName";
            PortName.HeaderText = "PortName";
            PortName.Name = "PortName";
            PortName.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "LoadRequest";
            dataGridViewCheckBoxColumn1.HeaderText = "Load Request";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // unloadRequestDataGridViewCheckBoxColumn
            // 
            unloadRequestDataGridViewCheckBoxColumn.DataPropertyName = "UnloadRequest";
            unloadRequestDataGridViewCheckBoxColumn.HeaderText = "Unload Request";
            unloadRequestDataGridViewCheckBoxColumn.Name = "unloadRequestDataGridViewCheckBoxColumn";
            unloadRequestDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // portExistDataGridViewCheckBoxColumn
            // 
            portExistDataGridViewCheckBoxColumn.DataPropertyName = "PortExist";
            portExistDataGridViewCheckBoxColumn.HeaderText = "Port Exist";
            portExistDataGridViewCheckBoxColumn.Name = "portExistDataGridViewCheckBoxColumn";
            portExistDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDUPPOSDataGridViewCheckBoxColumn
            // 
            lDUPPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_UP_POS";
            lDUPPOSDataGridViewCheckBoxColumn.HeaderText = "LD_UP_POS";
            lDUPPOSDataGridViewCheckBoxColumn.Name = "lDUPPOSDataGridViewCheckBoxColumn";
            lDUPPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // lDDOWNPOSDataGridViewCheckBoxColumn
            // 
            lDDOWNPOSDataGridViewCheckBoxColumn.DataPropertyName = "LD_DOWN_POS";
            lDDOWNPOSDataGridViewCheckBoxColumn.HeaderText = "LD_DOWN_POS";
            lDDOWNPOSDataGridViewCheckBoxColumn.Name = "lDDOWNPOSDataGridViewCheckBoxColumn";
            lDDOWNPOSDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // portStatusDownDataGridViewCheckBoxColumn
            // 
            portStatusDownDataGridViewCheckBoxColumn.DataPropertyName = "PortStatusDown";
            portStatusDownDataGridViewCheckBoxColumn.HeaderText = "EQP Status Down";
            portStatusDownDataGridViewCheckBoxColumn.Name = "portStatusDownDataGridViewCheckBoxColumn";
            portStatusDownDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // clsConverterPortBindingSource
            // 
            clsConverterPortBindingSource.DataSource = typeof(CasstteConverter.clsConverterPort);
            // 
            // panel1
            // 
            panel1.Controls.Add(btnOpenMasterMemTb);
            panel1.Controls.Add(ckbSimulationMode);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1031, 39);
            panel1.TabIndex = 1;
            // 
            // ckbSimulationMode
            // 
            ckbSimulationMode.AutoSize = true;
            ckbSimulationMode.Location = new Point(7, 8);
            ckbSimulationMode.Name = "ckbSimulationMode";
            ckbSimulationMode.Size = new Size(74, 19);
            ckbSimulationMode.TabIndex = 0;
            ckbSimulationMode.Text = "模擬模式";
            ckbSimulationMode.UseVisualStyleBackColor = true;
            ckbSimulationMode.Visible = false;
            ckbSimulationMode.CheckedChanged += ckbSimulationMode_CheckedChanged;
            // 
            // btnOpenMasterMemTb
            // 
            btnOpenMasterMemTb.BackColor = Color.FromArgb(0, 192, 192);
            btnOpenMasterMemTb.Dock = DockStyle.Right;
            btnOpenMasterMemTb.Font = new Font("微軟正黑體", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnOpenMasterMemTb.ForeColor = Color.White;
            btnOpenMasterMemTb.Location = new Point(900, 0);
            btnOpenMasterMemTb.Name = "btnOpenMasterMemTb";
            btnOpenMasterMemTb.Size = new Size(131, 39);
            btnOpenMasterMemTb.TabIndex = 1;
            btnOpenMasterMemTb.Text = "Memory Table";
            btnOpenMasterMemTb.UseVisualStyleBackColor = false;
            btnOpenMasterMemTb.Click += btnOpenMasterMemTb_Click;
            // 
            // UscEQStatus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "UscEQStatus";
            Size = new Size(1031, 586);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsConverterPortBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource clsConverterPortBindingSource;
        private DataGridViewTextBoxColumn EqName;
        private DataGridViewTextBoxColumn PortName;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewCheckBoxColumn unloadRequestDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn portExistDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn lDUPPOSDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn lDDOWNPOSDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn portStatusDownDataGridViewCheckBoxColumn;
        private Panel panel1;
        private CheckBox ckbSimulationMode;
        private Button btnOpenMasterMemTb;
    }
}
