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
            timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classifyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eQPNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            durationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clsAlarmDtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsAlarmDtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn, codeDataGridViewTextBoxColumn, classifyDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, eQPNameDataGridViewTextBoxColumn, durationDataGridViewTextBoxColumn });
            dataGridView1.DataSource = clsAlarmDtoBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1084, 467);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataError += dataGridView1_DataError;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            timeDataGridViewTextBoxColumn.FillWeight = 44F;
            timeDataGridViewTextBoxColumn.HeaderText = "Time";
            timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // levelDataGridViewTextBoxColumn
            // 
            levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            levelDataGridViewTextBoxColumn.FillWeight = 33F;
            levelDataGridViewTextBoxColumn.HeaderText = "Level";
            levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            // 
            // codeDataGridViewTextBoxColumn
            // 
            codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            codeDataGridViewTextBoxColumn.FillWeight = 33F;
            codeDataGridViewTextBoxColumn.HeaderText = "Code";
            codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            // 
            // classifyDataGridViewTextBoxColumn
            // 
            classifyDataGridViewTextBoxColumn.DataPropertyName = "Classify";
            classifyDataGridViewTextBoxColumn.FillWeight = 44F;
            classifyDataGridViewTextBoxColumn.HeaderText = "Classify";
            classifyDataGridViewTextBoxColumn.Name = "classifyDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // eQPNameDataGridViewTextBoxColumn
            // 
            eQPNameDataGridViewTextBoxColumn.DataPropertyName = "EQPName";
            eQPNameDataGridViewTextBoxColumn.FillWeight = 44F;
            eQPNameDataGridViewTextBoxColumn.HeaderText = "EQPName";
            eQPNameDataGridViewTextBoxColumn.Name = "eQPNameDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            durationDataGridViewTextBoxColumn.FillWeight = 33F;
            durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // clsAlarmDtoBindingSource
            // 
            clsAlarmDtoBindingSource.DataSource = typeof(Alarm.clsAlarmDto);
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
        private DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classifyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eQPNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
    }
}
