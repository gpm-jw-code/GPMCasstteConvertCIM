namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscMemoryTable
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
            dgvEQPBitMap = new DataGridView();
            addressDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataName = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Value = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Link_Modbus_Address = new DataGridViewTextBoxColumn();
            clsMemoryAddressBindingSource = new BindingSource(components);
            dgvEQPWordMap = new DataGridView();
            addressDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            Owner = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            PropertyName = new DataGridViewTextBoxColumn();
            dataTypeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            dgvCIMBitMap = new DataGridView();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn2 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dgvCIMWordMap = new DataGridView();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEQPBitMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsMemoryAddressBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEQPWordMap).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCIMBitMap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCIMWordMap).BeginInit();
            SuspendLayout();
            // 
            // dgvEQPBitMap
            // 
            dgvEQPBitMap.AutoGenerateColumns = false;
            dgvEQPBitMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEQPBitMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEQPBitMap.Columns.AddRange(new DataGridViewColumn[] { addressDataGridViewTextBoxColumn, DataName, dataGridViewTextBoxColumn1, Value, dataGridViewTextBoxColumn2, dataTypeDataGridViewTextBoxColumn, Link_Modbus_Address });
            dgvEQPBitMap.DataSource = clsMemoryAddressBindingSource;
            dgvEQPBitMap.Dock = DockStyle.Fill;
            dgvEQPBitMap.Location = new Point(3, 60);
            dgvEQPBitMap.Name = "dgvEQPBitMap";
            dgvEQPBitMap.RowHeadersVisible = false;
            dgvEQPBitMap.RowTemplate.Height = 25;
            dgvEQPBitMap.Size = new Size(839, 227);
            dgvEQPBitMap.TabIndex = 0;
            dgvEQPBitMap.CellDoubleClick += dgvBitMap_CellDoubleClick;
            dgvEQPBitMap.CellValueChanged += dgvBitMap_CellValueChanged;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn.HeaderText = "Address";
            addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            addressDataGridViewTextBoxColumn.ReadOnly = true;
            addressDataGridViewTextBoxColumn.Width = 77;
            // 
            // DataName
            // 
            DataName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataName.DataPropertyName = "DataName";
            DataName.HeaderText = "DataName";
            DataName.Name = "DataName";
            DataName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn1.DataPropertyName = "Owner";
            dataGridViewTextBoxColumn1.HeaderText = "Owner";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 69;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Value.DataPropertyName = "Value";
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.Resizable = DataGridViewTriState.True;
            Value.SortMode = DataGridViewColumnSortMode.Automatic;
            Value.Width = 64;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "PropertyName";
            dataGridViewTextBoxColumn2.HeaderText = "PropertyName";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 115;
            // 
            // dataTypeDataGridViewTextBoxColumn
            // 
            dataTypeDataGridViewTextBoxColumn.DataPropertyName = "DataType";
            dataTypeDataGridViewTextBoxColumn.HeaderText = "DataType";
            dataTypeDataGridViewTextBoxColumn.Name = "dataTypeDataGridViewTextBoxColumn";
            dataTypeDataGridViewTextBoxColumn.ReadOnly = true;
            dataTypeDataGridViewTextBoxColumn.Width = 87;
            // 
            // Link_Modbus_Address
            // 
            Link_Modbus_Address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Link_Modbus_Address.DataPropertyName = "Link_Modbus_Address_Hex";
            Link_Modbus_Address.HeaderText = "Link_Modbus_Register_Number";
            Link_Modbus_Address.Name = "Link_Modbus_Address";
            Link_Modbus_Address.ReadOnly = true;
            // 
            // clsMemoryAddressBindingSource
            // 
            clsMemoryAddressBindingSource.DataSource = typeof(CasstteConverter.Data.clsMemoryAddress);
            // 
            // dgvEQPWordMap
            // 
            dgvEQPWordMap.AutoGenerateColumns = false;
            dgvEQPWordMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEQPWordMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEQPWordMap.Columns.AddRange(new DataGridViewColumn[] { addressDataGridViewTextBoxColumn1, dataGridViewTextBoxColumn4, Owner, dataGridViewTextBoxColumn3, PropertyName, dataTypeDataGridViewTextBoxColumn1, dataGridViewTextBoxColumn17 });
            dgvEQPWordMap.DataSource = clsMemoryAddressBindingSource;
            dgvEQPWordMap.Dock = DockStyle.Fill;
            dgvEQPWordMap.Location = new Point(848, 60);
            dgvEQPWordMap.Name = "dgvEQPWordMap";
            dgvEQPWordMap.RowHeadersVisible = false;
            dgvEQPWordMap.RowTemplate.Height = 25;
            dgvEQPWordMap.Size = new Size(840, 227);
            dgvEQPWordMap.TabIndex = 1;
            dgvEQPWordMap.CellDoubleClick += dgvWordMap_CellDoubleClick;
            dgvEQPWordMap.CellEndEdit += dgvWordMap_CellEndEdit;
            dgvEQPWordMap.CellValueChanged += dgvWordMap_CellValueChanged;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            addressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
            addressDataGridViewTextBoxColumn1.HeaderText = "Address";
            addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            addressDataGridViewTextBoxColumn1.ReadOnly = true;
            addressDataGridViewTextBoxColumn1.Width = 77;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "DataName";
            dataGridViewTextBoxColumn4.HeaderText = "DataName";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // Owner
            // 
            Owner.DataPropertyName = "Owner";
            Owner.HeaderText = "Owner";
            Owner.Name = "Owner";
            Owner.ReadOnly = true;
            Owner.Width = 69;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn3.DataPropertyName = "Value";
            dataGridViewTextBoxColumn3.HeaderText = "Value";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Resizable = DataGridViewTriState.True;
            dataGridViewTextBoxColumn3.Width = 64;
            // 
            // PropertyName
            // 
            PropertyName.DataPropertyName = "PropertyName";
            PropertyName.HeaderText = "PropertyName";
            PropertyName.Name = "PropertyName";
            PropertyName.ReadOnly = true;
            PropertyName.Width = 115;
            // 
            // dataTypeDataGridViewTextBoxColumn1
            // 
            dataTypeDataGridViewTextBoxColumn1.DataPropertyName = "DataType";
            dataTypeDataGridViewTextBoxColumn1.HeaderText = "DataType";
            dataTypeDataGridViewTextBoxColumn1.Name = "dataTypeDataGridViewTextBoxColumn1";
            dataTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            dataTypeDataGridViewTextBoxColumn1.Width = 87;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn17.DataPropertyName = "Link_Modbus_Register_Number";
            dataGridViewTextBoxColumn17.HeaderText = "Link_Modbus_Register_Number";
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label6, 0, 4);
            tableLayoutPanel1.Controls.Add(label5, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(dgvCIMBitMap, 0, 5);
            tableLayoutPanel1.Controls.Add(dgvCIMWordMap, 0, 5);
            tableLayoutPanel1.Controls.Add(dgvEQPBitMap, 0, 2);
            tableLayoutPanel1.Controls.Add(dgvEQPWordMap, 1, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1691, 578);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // label6
            // 
            label6.BackColor = Color.SlateGray;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 320);
            label6.Margin = new Padding(0);
            label6.Name = "label6";
            label6.Size = new Size(845, 25);
            label6.TabIndex = 5;
            label6.Text = "BIT";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(3, 290);
            label5.Name = "label5";
            label5.Padding = new Padding(0, 8, 0, 0);
            label5.Size = new Size(149, 28);
            label5.TabIndex = 5;
            label5.Text = "CIM Memory Map";
            // 
            // label4
            // 
            label4.BackColor = Color.MediumAquamarine;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(845, 30);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 2, 0, 2);
            label4.Size = new Size(846, 27);
            label4.TabIndex = 7;
            label4.Text = "WORD";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.BackColor = Color.SlateGray;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 30);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(845, 27);
            label3.TabIndex = 6;
            label3.Text = "BIT";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvCIMBitMap
            // 
            dgvCIMBitMap.AutoGenerateColumns = false;
            dgvCIMBitMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCIMBitMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCIMBitMap.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewCheckBoxColumn2, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15, dataGridViewTextBoxColumn16 });
            dgvCIMBitMap.DataSource = clsMemoryAddressBindingSource;
            dgvCIMBitMap.Dock = DockStyle.Fill;
            dgvCIMBitMap.Location = new Point(3, 348);
            dgvCIMBitMap.Name = "dgvCIMBitMap";
            dgvCIMBitMap.RowHeadersVisible = false;
            dgvCIMBitMap.RowTemplate.Height = 25;
            dgvCIMBitMap.Size = new Size(839, 227);
            dgvCIMBitMap.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.DataPropertyName = "Address";
            dataGridViewTextBoxColumn11.HeaderText = "Address";
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            dataGridViewTextBoxColumn11.Width = 77;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn12.DataPropertyName = "DataName";
            dataGridViewTextBoxColumn12.HeaderText = "DataName";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.DataPropertyName = "Owner";
            dataGridViewTextBoxColumn13.HeaderText = "Owner";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.Width = 69;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            dataGridViewCheckBoxColumn2.DataPropertyName = "Value";
            dataGridViewCheckBoxColumn2.HeaderText = "Value";
            dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            dataGridViewCheckBoxColumn2.ReadOnly = true;
            dataGridViewCheckBoxColumn2.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn2.SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridViewCheckBoxColumn2.Width = 64;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.DataPropertyName = "PropertyName";
            dataGridViewTextBoxColumn14.HeaderText = "PropertyName";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.Width = 115;
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.DataPropertyName = "DataType";
            dataGridViewTextBoxColumn15.HeaderText = "DataType";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            dataGridViewTextBoxColumn15.ReadOnly = true;
            dataGridViewTextBoxColumn15.Width = 87;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn16.DataPropertyName = "Link_Modbus_Address_Hex";
            dataGridViewTextBoxColumn16.HeaderText = "Link_Modbus_Address";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dgvCIMWordMap
            // 
            dgvCIMWordMap.AutoGenerateColumns = false;
            dgvCIMWordMap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCIMWordMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCIMWordMap.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10 });
            dgvCIMWordMap.DataSource = clsMemoryAddressBindingSource;
            dgvCIMWordMap.Dock = DockStyle.Fill;
            dgvCIMWordMap.Location = new Point(848, 348);
            dgvCIMWordMap.Name = "dgvCIMWordMap";
            dgvCIMWordMap.RowHeadersVisible = false;
            dgvCIMWordMap.RowTemplate.Height = 25;
            dgvCIMWordMap.Size = new Size(840, 227);
            dgvCIMWordMap.TabIndex = 2;
            dgvCIMWordMap.CellDoubleClick += dgvWordMap_CellDoubleClick;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Address";
            dataGridViewTextBoxColumn5.HeaderText = "Address";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 77;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn6.DataPropertyName = "DataName";
            dataGridViewTextBoxColumn6.HeaderText = "DataName";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.DataPropertyName = "Owner";
            dataGridViewTextBoxColumn7.HeaderText = "Owner";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 69;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "Value";
            dataGridViewCheckBoxColumn1.HeaderText = "Value";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn1.Width = 64;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.DataPropertyName = "PropertyName";
            dataGridViewTextBoxColumn8.HeaderText = "PropertyName";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 115;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "DataType";
            dataGridViewTextBoxColumn9.HeaderText = "DataType";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Width = 87;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn10.DataPropertyName = "Link_Modbus_Register_Number";
            dataGridViewTextBoxColumn10.HeaderText = "Link_Modbus_Register_Number";
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Padding = new Padding(0, 8, 0, 0);
            label1.Size = new Size(149, 28);
            label1.TabIndex = 4;
            label1.Text = "EQP Memory Map";
            // 
            // label2
            // 
            label2.BackColor = Color.MediumAquamarine;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft JhengHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(845, 320);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Padding = new Padding(0, 2, 0, 2);
            label2.Size = new Size(846, 25);
            label2.TabIndex = 5;
            label2.Text = "WORD";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UscMemoryTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            DoubleBuffered = true;
            Name = "UscMemoryTable";
            Size = new Size(1691, 578);
            ((System.ComponentModel.ISupportInitialize)dgvEQPBitMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsMemoryAddressBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEQPWordMap).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCIMBitMap).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCIMWordMap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvEQPBitMap;
        private DataGridView dgvEQPWordMap;
        private BindingSource clsMemoryAddressBindingSource;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvCIMBitMap;
        private DataGridView dgvCIMWordMap;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn Owner;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn PropertyName;
        private DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DataName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn Value;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Link_Modbus_Address;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
    }
}
