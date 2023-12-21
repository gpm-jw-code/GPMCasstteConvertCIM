namespace GPMCasstteConvertCIM.Forms
{
    partial class frmAGVsDatabaseBroswer
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvTaskHistory = new DataGridView();
            taskDtoBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            btnQuery = new Button();
            comboBox1 = new ComboBox();
            label4 = new Label();
            txbAssignUserName = new TextBox();
            end_time = new DateTimePicker();
            start_time = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            end_date = new DateTimePicker();
            start_date = new DateTimePicker();
            label1 = new Label();
            tabPage2 = new TabPage();
            checkbox_column = new DataGridViewCheckBoxColumn();
            delete_btn_column = new DataGridViewButtonColumn();
            receiveTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            assignUserNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            endTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            distanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            acquireTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            depositTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cancelUserNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTTypeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            failReasonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationPortNoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationPortNoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            exeVehiclePosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaskHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskDtoBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1006, 632);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvTaskHistory);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(998, 604);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "歷史任務";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvTaskHistory
            // 
            dgvTaskHistory.AllowUserToAddRows = false;
            dgvTaskHistory.AllowUserToDeleteRows = false;
            dgvTaskHistory.AllowUserToOrderColumns = true;
            dgvTaskHistory.AutoGenerateColumns = false;
            dgvTaskHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaskHistory.Columns.AddRange(new DataGridViewColumn[] { checkbox_column, delete_btn_column, receiveTimeDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, assignUserNameDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, fromStationIdDataGridViewTextBoxColumn, toStationIdDataGridViewTextBoxColumn, fromStationDataGridViewTextBoxColumn, toStationDataGridViewTextBoxColumn, fromStationNameDataGridViewTextBoxColumn, toStationNameDataGridViewTextBoxColumn, actionTypeDataGridViewTextBoxColumn, aGVIDDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, priorityDataGridViewTextBoxColumn, repeatTimeDataGridViewTextBoxColumn, exeVehicleIDDataGridViewTextBoxColumn, startTimeDataGridViewTextBoxColumn, endTimeDataGridViewTextBoxColumn, totalTimeDataGridViewTextBoxColumn, distanceDataGridViewTextBoxColumn, acquireTimeDataGridViewTextBoxColumn, depositTimeDataGridViewTextBoxColumn, cancelUserNameDataGridViewTextBoxColumn, cSTTypeDataGridViewTextBoxColumn, failReasonDataGridViewTextBoxColumn, fromStationPortNoDataGridViewTextBoxColumn, toStationPortNoDataGridViewTextBoxColumn, exeVehiclePosDataGridViewTextBoxColumn });
            dgvTaskHistory.DataSource = taskDtoBindingSource;
            dgvTaskHistory.Dock = DockStyle.Fill;
            dgvTaskHistory.Location = new Point(3, 84);
            dgvTaskHistory.Name = "dgvTaskHistory";
            dgvTaskHistory.RowHeadersVisible = false;
            dgvTaskHistory.RowTemplate.Height = 25;
            dgvTaskHistory.ShowCellErrors = false;
            dgvTaskHistory.ShowRowErrors = false;
            dgvTaskHistory.Size = new Size(992, 517);
            dgvTaskHistory.TabIndex = 1;
            dgvTaskHistory.CellClick += DgvTaskHistory_CellClick;
            // 
            // taskDtoBindingSource
            // 
            taskDtoBindingSource.DataSource = typeof(DataBase.KGS_AGVs.Models.TaskDto);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnQuery);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txbAssignUserName);
            groupBox1.Controls.Add(end_time);
            groupBox1.Controls.Add(start_time);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(end_date);
            groupBox1.Controls.Add(start_date);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(992, 81);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "篩選";
            // 
            // btnQuery
            // 
            btnQuery.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuery.Font = new Font("Microsoft JhengHei UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            btnQuery.Location = new Point(814, 14);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new Size(172, 61);
            btnQuery.TabIndex = 13;
            btnQuery.Text = "查詢";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += BtnQuery_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(482, 14);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 23);
            comboBox1.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 46);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 11;
            label4.Text = "派工使用者";
            // 
            // txbAssignUserName
            // 
            txbAssignUserName.Location = new Point(482, 43);
            txbAssignUserName.Name = "txbAssignUserName";
            txbAssignUserName.Size = new Size(141, 23);
            txbAssignUserName.TabIndex = 10;
            // 
            // end_time
            // 
            end_time.Format = DateTimePickerFormat.Time;
            end_time.Location = new Point(260, 46);
            end_time.Name = "end_time";
            end_time.ShowUpDown = true;
            end_time.Size = new Size(118, 23);
            end_time.TabIndex = 9;
            // 
            // start_time
            // 
            start_time.Format = DateTimePickerFormat.Time;
            start_time.Location = new Point(260, 14);
            start_time.Name = "start_time";
            start_time.ShowUpDown = true;
            start_time.Size = new Size(118, 23);
            start_time.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 46);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "結束時間";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 17);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 6;
            label2.Text = "開始時間";
            // 
            // end_date
            // 
            end_date.Location = new Point(78, 46);
            end_date.Name = "end_date";
            end_date.Size = new Size(176, 23);
            end_date.TabIndex = 5;
            // 
            // start_date
            // 
            start_date.Location = new Point(78, 14);
            start_date.Name = "start_date";
            start_date.Size = new Size(176, 23);
            start_date.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(409, 17);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "任務類型";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(998, 604);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkbox_column
            // 
            checkbox_column.HeaderText = "";
            checkbox_column.Name = "checkbox_column";
            // 
            // delete_btn_column
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Red;
            dataGridViewCellStyle1.ForeColor = Color.White;
            delete_btn_column.DefaultCellStyle = dataGridViewCellStyle1;
            delete_btn_column.HeaderText = "";
            delete_btn_column.Name = "delete_btn_column";
            delete_btn_column.Resizable = DataGridViewTriState.True;
            delete_btn_column.SortMode = DataGridViewColumnSortMode.Automatic;
            delete_btn_column.Text = "Delete";
            delete_btn_column.UseColumnTextForButtonValue = true;
            // 
            // receiveTimeDataGridViewTextBoxColumn
            // 
            receiveTimeDataGridViewTextBoxColumn.DataPropertyName = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.HeaderText = "接收時間";
            receiveTimeDataGridViewTextBoxColumn.Name = "receiveTimeDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "任務名稱";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // assignUserNameDataGridViewTextBoxColumn
            // 
            assignUserNameDataGridViewTextBoxColumn.DataPropertyName = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.HeaderText = "派工人員";
            assignUserNameDataGridViewTextBoxColumn.Name = "assignUserNameDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // fromStationIdDataGridViewTextBoxColumn
            // 
            fromStationIdDataGridViewTextBoxColumn.DataPropertyName = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.HeaderText = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.Name = "fromStationIdDataGridViewTextBoxColumn";
            // 
            // toStationIdDataGridViewTextBoxColumn
            // 
            toStationIdDataGridViewTextBoxColumn.DataPropertyName = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.HeaderText = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.Name = "toStationIdDataGridViewTextBoxColumn";
            // 
            // fromStationDataGridViewTextBoxColumn
            // 
            fromStationDataGridViewTextBoxColumn.DataPropertyName = "FromStation";
            fromStationDataGridViewTextBoxColumn.HeaderText = "FromStation";
            fromStationDataGridViewTextBoxColumn.Name = "fromStationDataGridViewTextBoxColumn";
            // 
            // toStationDataGridViewTextBoxColumn
            // 
            toStationDataGridViewTextBoxColumn.DataPropertyName = "ToStation";
            toStationDataGridViewTextBoxColumn.HeaderText = "ToStation";
            toStationDataGridViewTextBoxColumn.Name = "toStationDataGridViewTextBoxColumn";
            // 
            // fromStationNameDataGridViewTextBoxColumn
            // 
            fromStationNameDataGridViewTextBoxColumn.DataPropertyName = "FromStationName";
            fromStationNameDataGridViewTextBoxColumn.HeaderText = "FromStationName";
            fromStationNameDataGridViewTextBoxColumn.Name = "fromStationNameDataGridViewTextBoxColumn";
            // 
            // toStationNameDataGridViewTextBoxColumn
            // 
            toStationNameDataGridViewTextBoxColumn.DataPropertyName = "ToStationName";
            toStationNameDataGridViewTextBoxColumn.HeaderText = "ToStationName";
            toStationNameDataGridViewTextBoxColumn.Name = "toStationNameDataGridViewTextBoxColumn";
            // 
            // actionTypeDataGridViewTextBoxColumn
            // 
            actionTypeDataGridViewTextBoxColumn.DataPropertyName = "ActionType";
            actionTypeDataGridViewTextBoxColumn.HeaderText = "ActionType";
            actionTypeDataGridViewTextBoxColumn.Name = "actionTypeDataGridViewTextBoxColumn";
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            // 
            // repeatTimeDataGridViewTextBoxColumn
            // 
            repeatTimeDataGridViewTextBoxColumn.DataPropertyName = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.HeaderText = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.Name = "repeatTimeDataGridViewTextBoxColumn";
            // 
            // exeVehicleIDDataGridViewTextBoxColumn
            // 
            exeVehicleIDDataGridViewTextBoxColumn.DataPropertyName = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.HeaderText = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.Name = "exeVehicleIDDataGridViewTextBoxColumn";
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            endTimeDataGridViewTextBoxColumn.HeaderText = "EndTime";
            endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            // 
            // totalTimeDataGridViewTextBoxColumn
            // 
            totalTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalTime";
            totalTimeDataGridViewTextBoxColumn.HeaderText = "TotalTime";
            totalTimeDataGridViewTextBoxColumn.Name = "totalTimeDataGridViewTextBoxColumn";
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            distanceDataGridViewTextBoxColumn.HeaderText = "Distance";
            distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            // 
            // acquireTimeDataGridViewTextBoxColumn
            // 
            acquireTimeDataGridViewTextBoxColumn.DataPropertyName = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.HeaderText = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.Name = "acquireTimeDataGridViewTextBoxColumn";
            // 
            // depositTimeDataGridViewTextBoxColumn
            // 
            depositTimeDataGridViewTextBoxColumn.DataPropertyName = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.HeaderText = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.Name = "depositTimeDataGridViewTextBoxColumn";
            // 
            // cancelUserNameDataGridViewTextBoxColumn
            // 
            cancelUserNameDataGridViewTextBoxColumn.DataPropertyName = "CancelUserName";
            cancelUserNameDataGridViewTextBoxColumn.HeaderText = "CancelUserName";
            cancelUserNameDataGridViewTextBoxColumn.Name = "cancelUserNameDataGridViewTextBoxColumn";
            // 
            // cSTTypeDataGridViewTextBoxColumn
            // 
            cSTTypeDataGridViewTextBoxColumn.DataPropertyName = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.HeaderText = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.Name = "cSTTypeDataGridViewTextBoxColumn";
            // 
            // failReasonDataGridViewTextBoxColumn
            // 
            failReasonDataGridViewTextBoxColumn.DataPropertyName = "FailReason";
            failReasonDataGridViewTextBoxColumn.HeaderText = "FailReason";
            failReasonDataGridViewTextBoxColumn.Name = "failReasonDataGridViewTextBoxColumn";
            // 
            // fromStationPortNoDataGridViewTextBoxColumn
            // 
            fromStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.HeaderText = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.Name = "fromStationPortNoDataGridViewTextBoxColumn";
            // 
            // toStationPortNoDataGridViewTextBoxColumn
            // 
            toStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.HeaderText = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.Name = "toStationPortNoDataGridViewTextBoxColumn";
            // 
            // exeVehiclePosDataGridViewTextBoxColumn
            // 
            exeVehiclePosDataGridViewTextBoxColumn.DataPropertyName = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.HeaderText = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.Name = "exeVehiclePosDataGridViewTextBoxColumn";
            // 
            // frmAGVsDatabaseBroswer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 632);
            Controls.Add(tabControl1);
            Name = "frmAGVsDatabaseBroswer";
            Text = "派車系統資料庫";
            FormClosing += FrmAGVsDatabaseBroswer_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaskHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskDtoBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvTaskHistory;
        private BindingSource taskDtoBindingSource;
        private Label label1;
        private GroupBox groupBox1;
        private DateTimePicker start_date;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox txbAssignUserName;
        private DateTimePicker end_time;
        private DateTimePicker start_time;
        private Label label3;
        private Label label2;
        private DateTimePicker end_date;
        private Button btnQuery;
        private DataGridViewCheckBoxColumn checkbox_column;
        private DataGridViewButtonColumn delete_btn_column;
        private DataGridViewTextBoxColumn receiveTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn assignUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
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
        private DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn acquireTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn depositTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cancelUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn failReasonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationPortNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationPortNoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn exeVehiclePosDataGridViewTextBoxColumn;
    }
}