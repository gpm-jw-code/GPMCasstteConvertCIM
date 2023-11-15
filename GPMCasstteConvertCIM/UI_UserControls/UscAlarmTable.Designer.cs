namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscAlarmTable
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
            dataGridView1 = new DataGridView();
            clsAlarmDtoBindingSource = new BindingSource(components);
            timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Code_int = new DataGridViewTextBoxColumn();
            classifyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eQPNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsAlarmDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn, Code_int, classifyDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, eQPNameDataGridViewTextBoxColumn });
            dataGridView1.DataSource = clsAlarmDtoBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1084, 467);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataError += dataGridView1_DataError;
            // 
            // clsAlarmDtoBindingSource
            // 
            clsAlarmDtoBindingSource.DataSource = typeof(Alarm.clsAlarmDto);
            clsAlarmDtoBindingSource.CurrentChanged += clsAlarmDtoBindingSource_CurrentChanged;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            timeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            timeDataGridViewTextBoxColumn.HeaderText = "時間";
            timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            timeDataGridViewTextBoxColumn.ReadOnly = true;
            timeDataGridViewTextBoxColumn.Width = 56;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            levelDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            levelDataGridViewTextBoxColumn.HeaderText = "警報類型";
            levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            levelDataGridViewTextBoxColumn.ReadOnly = true;
            levelDataGridViewTextBoxColumn.Width = 80;
            // 
            // Code_int
            // 
            Code_int.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Code_int.DataPropertyName = "Code_int";
            Code_int.HeaderText = "異常碼";
            Code_int.Name = "Code_int";
            Code_int.ReadOnly = true;
            Code_int.Width = 68;
            // 
            // classifyDataGridViewTextBoxColumn
            // 
            classifyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            classifyDataGridViewTextBoxColumn.DataPropertyName = "Classify";
            classifyDataGridViewTextBoxColumn.HeaderText = "異常分類";
            classifyDataGridViewTextBoxColumn.Name = "classifyDataGridViewTextBoxColumn";
            classifyDataGridViewTextBoxColumn.ReadOnly = true;
            classifyDataGridViewTextBoxColumn.Width = 80;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "異常描述";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // eQPNameDataGridViewTextBoxColumn
            // 
            eQPNameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            eQPNameDataGridViewTextBoxColumn.DataPropertyName = "EQPName";
            eQPNameDataGridViewTextBoxColumn.HeaderText = "設備名稱";
            eQPNameDataGridViewTextBoxColumn.Name = "eQPNameDataGridViewTextBoxColumn";
            eQPNameDataGridViewTextBoxColumn.ReadOnly = true;
            eQPNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // UscAlarmTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dataGridView1);
            Name = "UscAlarmTable";
            Size = new Size(1084, 467);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsAlarmDtoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource clsAlarmDtoBindingSource;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Code_int;
        private DataGridViewTextBoxColumn classifyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eQPNameDataGridViewTextBoxColumn;
    }
}
