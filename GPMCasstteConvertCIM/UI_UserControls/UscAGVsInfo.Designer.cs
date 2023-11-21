namespace GPMCasstteConvertCIM.UI_UserControls
{
    partial class UscAGVsInfo
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
            label1 = new Label();
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            receiveTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            actionTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aGVIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            priorityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            repeatTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            exeVehicleIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            startTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            distanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            acquireTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            depositTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assignUserNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationPortNoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationPortNoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            exeVehiclePosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            executingTaskBindingSource = new BindingSource(components);
            button1 = new Button();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Bottom;
            label1.Location = new Point(0, 493);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "AGVs";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, receiveTimeDataGridViewTextBoxColumn, fromStationIdDataGridViewTextBoxColumn, toStationIdDataGridViewTextBoxColumn, fromStationDataGridViewTextBoxColumn, toStationDataGridViewTextBoxColumn, fromStationNameDataGridViewTextBoxColumn, toStationNameDataGridViewTextBoxColumn, actionTypeDataGridViewTextBoxColumn, aGVIDDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, priorityDataGridViewTextBoxColumn, repeatTimeDataGridViewTextBoxColumn, exeVehicleIDDataGridViewTextBoxColumn, startTimeDataGridViewTextBoxColumn, distanceDataGridViewTextBoxColumn, acquireTimeDataGridViewTextBoxColumn, depositTimeDataGridViewTextBoxColumn, assignUserNameDataGridViewTextBoxColumn, cSTTypeDataGridViewTextBoxColumn, fromStationPortNoDataGridViewTextBoxColumn, toStationPortNoDataGridViewTextBoxColumn, exeVehiclePosDataGridViewTextBoxColumn });
            dataGridView1.DataSource = executingTaskBindingSource;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.ShowCellErrors = false;
            dataGridView1.ShowRowErrors = false;
            dataGridView1.Size = new Size(997, 423);
            dataGridView1.TabIndex = 1;
            dataGridView1.DataError += dataGridView1_DataError;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receiveTimeDataGridViewTextBoxColumn
            // 
            receiveTimeDataGridViewTextBoxColumn.DataPropertyName = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.HeaderText = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.Name = "receiveTimeDataGridViewTextBoxColumn";
            receiveTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromStationIdDataGridViewTextBoxColumn
            // 
            fromStationIdDataGridViewTextBoxColumn.DataPropertyName = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.HeaderText = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.Name = "fromStationIdDataGridViewTextBoxColumn";
            fromStationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toStationIdDataGridViewTextBoxColumn
            // 
            toStationIdDataGridViewTextBoxColumn.DataPropertyName = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.HeaderText = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.Name = "toStationIdDataGridViewTextBoxColumn";
            toStationIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromStationDataGridViewTextBoxColumn
            // 
            fromStationDataGridViewTextBoxColumn.DataPropertyName = "FromStation";
            fromStationDataGridViewTextBoxColumn.HeaderText = "FromStation";
            fromStationDataGridViewTextBoxColumn.Name = "fromStationDataGridViewTextBoxColumn";
            fromStationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toStationDataGridViewTextBoxColumn
            // 
            toStationDataGridViewTextBoxColumn.DataPropertyName = "ToStation";
            toStationDataGridViewTextBoxColumn.HeaderText = "ToStation";
            toStationDataGridViewTextBoxColumn.Name = "toStationDataGridViewTextBoxColumn";
            toStationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromStationNameDataGridViewTextBoxColumn
            // 
            fromStationNameDataGridViewTextBoxColumn.DataPropertyName = "FromStationName";
            fromStationNameDataGridViewTextBoxColumn.HeaderText = "FromStationName";
            fromStationNameDataGridViewTextBoxColumn.Name = "fromStationNameDataGridViewTextBoxColumn";
            fromStationNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toStationNameDataGridViewTextBoxColumn
            // 
            toStationNameDataGridViewTextBoxColumn.DataPropertyName = "ToStationName";
            toStationNameDataGridViewTextBoxColumn.HeaderText = "ToStationName";
            toStationNameDataGridViewTextBoxColumn.Name = "toStationNameDataGridViewTextBoxColumn";
            toStationNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // actionTypeDataGridViewTextBoxColumn
            // 
            actionTypeDataGridViewTextBoxColumn.DataPropertyName = "ActionType";
            actionTypeDataGridViewTextBoxColumn.HeaderText = "ActionType";
            actionTypeDataGridViewTextBoxColumn.Name = "actionTypeDataGridViewTextBoxColumn";
            actionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            aGVIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            cSTIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            priorityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // repeatTimeDataGridViewTextBoxColumn
            // 
            repeatTimeDataGridViewTextBoxColumn.DataPropertyName = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.HeaderText = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.Name = "repeatTimeDataGridViewTextBoxColumn";
            repeatTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // exeVehicleIDDataGridViewTextBoxColumn
            // 
            exeVehicleIDDataGridViewTextBoxColumn.DataPropertyName = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.HeaderText = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.Name = "exeVehicleIDDataGridViewTextBoxColumn";
            exeVehicleIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            distanceDataGridViewTextBoxColumn.HeaderText = "Distance";
            distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            distanceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // acquireTimeDataGridViewTextBoxColumn
            // 
            acquireTimeDataGridViewTextBoxColumn.DataPropertyName = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.HeaderText = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.Name = "acquireTimeDataGridViewTextBoxColumn";
            acquireTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depositTimeDataGridViewTextBoxColumn
            // 
            depositTimeDataGridViewTextBoxColumn.DataPropertyName = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.HeaderText = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.Name = "depositTimeDataGridViewTextBoxColumn";
            depositTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // assignUserNameDataGridViewTextBoxColumn
            // 
            assignUserNameDataGridViewTextBoxColumn.DataPropertyName = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.HeaderText = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.Name = "assignUserNameDataGridViewTextBoxColumn";
            assignUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cSTTypeDataGridViewTextBoxColumn
            // 
            cSTTypeDataGridViewTextBoxColumn.DataPropertyName = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.HeaderText = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.Name = "cSTTypeDataGridViewTextBoxColumn";
            cSTTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromStationPortNoDataGridViewTextBoxColumn
            // 
            fromStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.HeaderText = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.Name = "fromStationPortNoDataGridViewTextBoxColumn";
            fromStationPortNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toStationPortNoDataGridViewTextBoxColumn
            // 
            toStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.HeaderText = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.Name = "toStationPortNoDataGridViewTextBoxColumn";
            toStationPortNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // exeVehiclePosDataGridViewTextBoxColumn
            // 
            exeVehiclePosDataGridViewTextBoxColumn.DataPropertyName = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.HeaderText = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.Name = "exeVehiclePosDataGridViewTextBoxColumn";
            exeVehiclePosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // executingTaskBindingSource
            // 
            executingTaskBindingSource.DataSource = typeof(DataBase.KGS_AGVs.Models.ExecutingTask);
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(3, 432);
            button1.Name = "button1";
            button1.Size = new Size(92, 44);
            button1.TabIndex = 2;
            button1.Text = "生成假資料";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(101, 432);
            button2.Name = "button2";
            button2.Size = new Size(92, 44);
            button2.TabIndex = 3;
            button2.Text = "清空任務";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // UscAGVsInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "UscAGVsInfo";
            Size = new Size(1003, 508);
            Load += UscAGVsInfo_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource executingTaskBindingSource;
        private Button button1;
        private Button button2;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn receiveTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn actionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn repeatTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn exeVehicleIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acquireTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn depositTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assignUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationPortNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationPortNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn exeVehiclePosDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timer1;
    }
}
