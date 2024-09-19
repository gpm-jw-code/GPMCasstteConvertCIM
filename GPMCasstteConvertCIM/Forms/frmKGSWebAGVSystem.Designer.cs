namespace GPMCasstteConvertCIM.Forms
{
    partial class frmKGSWebAGVSystem
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dgvExecutingTask = new DataGridView();
            cancelBtnCol = new DataGridViewButtonColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            receiveTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            toStationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
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
            cSTLayersDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            executingTaskBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dgvTaskHistory = new DataGridView();
            deleteCol = new DataGridViewButtonColumn();
            nameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            receiveTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            fromStationIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            toStationIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            fromStationDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            toStationDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            actionTypeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            aGVIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cSTIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            priorityDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            repeatTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            exeVehicleIDDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            startTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            endTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            distanceDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            acquireTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            depositTimeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            assignUserNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cancelUserNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cSTTypeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            failReasonDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fromStationPortNoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            toStationPortNoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            exeVehiclePosDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cSTLayersDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            taskBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            toolStripComboBox1 = new ToolStripDropDownButton();
            RefreshToolStripMenuItem = new ToolStripMenuItem();
            autoRefreshToolStripMenuItem = new ToolStripMenuItem();
            autoRefreshTimer = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tlabDBConnectionStr = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            tlabKGAGVSAPIUrl = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            tlabWebServerActionInfo = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvExecutingTask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaskHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExecutingTask
            // 
            dgvExecutingTask.AllowUserToAddRows = false;
            dgvExecutingTask.AllowUserToDeleteRows = false;
            dgvExecutingTask.AutoGenerateColumns = false;
            dgvExecutingTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvExecutingTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExecutingTask.Columns.AddRange(new DataGridViewColumn[] { cancelBtnCol, nameDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, receiveTimeDataGridViewTextBoxColumn, fromStationIdDataGridViewTextBoxColumn, toStationIdDataGridViewTextBoxColumn, fromStationDataGridViewTextBoxColumn, toStationDataGridViewTextBoxColumn, actionTypeDataGridViewTextBoxColumn, aGVIDDataGridViewTextBoxColumn, cSTIDDataGridViewTextBoxColumn, priorityDataGridViewTextBoxColumn, repeatTimeDataGridViewTextBoxColumn, exeVehicleIDDataGridViewTextBoxColumn, startTimeDataGridViewTextBoxColumn, distanceDataGridViewTextBoxColumn, acquireTimeDataGridViewTextBoxColumn, depositTimeDataGridViewTextBoxColumn, assignUserNameDataGridViewTextBoxColumn, cSTTypeDataGridViewTextBoxColumn, fromStationPortNoDataGridViewTextBoxColumn, toStationPortNoDataGridViewTextBoxColumn, exeVehiclePosDataGridViewTextBoxColumn, cSTLayersDataGridViewTextBoxColumn });
            dgvExecutingTask.DataSource = executingTaskBindingSource;
            dgvExecutingTask.Dock = DockStyle.Fill;
            dgvExecutingTask.Location = new Point(3, 19);
            dgvExecutingTask.Name = "dgvExecutingTask";
            dgvExecutingTask.ReadOnly = true;
            dgvExecutingTask.RowTemplate.Height = 25;
            dgvExecutingTask.Size = new Size(1217, 306);
            dgvExecutingTask.TabIndex = 0;
            dgvExecutingTask.CellContentClick += dgvExecutingTask_CellContentClick;
            dgvExecutingTask.CellMouseDown += dgvExecutingTask_CellMouseDown;
            // 
            // cancelBtnCol
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            cancelBtnCol.DefaultCellStyle = dataGridViewCellStyle1;
            cancelBtnCol.FlatStyle = FlatStyle.Flat;
            cancelBtnCol.HeaderText = "取消";
            cancelBtnCol.Name = "cancelBtnCol";
            cancelBtnCol.ReadOnly = true;
            cancelBtnCol.Text = "取消";
            cancelBtnCol.UseColumnTextForButtonValue = true;
            cancelBtnCol.Width = 37;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            nameDataGridViewTextBoxColumn.Width = 67;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "Status";
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            statusDataGridViewTextBoxColumn.Width = 66;
            // 
            // receiveTimeDataGridViewTextBoxColumn
            // 
            receiveTimeDataGridViewTextBoxColumn.DataPropertyName = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.HeaderText = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn.Name = "receiveTimeDataGridViewTextBoxColumn";
            receiveTimeDataGridViewTextBoxColumn.ReadOnly = true;
            receiveTimeDataGridViewTextBoxColumn.Width = 109;
            // 
            // fromStationIdDataGridViewTextBoxColumn
            // 
            fromStationIdDataGridViewTextBoxColumn.DataPropertyName = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.HeaderText = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn.Name = "fromStationIdDataGridViewTextBoxColumn";
            fromStationIdDataGridViewTextBoxColumn.ReadOnly = true;
            fromStationIdDataGridViewTextBoxColumn.Width = 112;
            // 
            // toStationIdDataGridViewTextBoxColumn
            // 
            toStationIdDataGridViewTextBoxColumn.DataPropertyName = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.HeaderText = "ToStationId";
            toStationIdDataGridViewTextBoxColumn.Name = "toStationIdDataGridViewTextBoxColumn";
            toStationIdDataGridViewTextBoxColumn.ReadOnly = true;
            toStationIdDataGridViewTextBoxColumn.Width = 98;
            // 
            // fromStationDataGridViewTextBoxColumn
            // 
            fromStationDataGridViewTextBoxColumn.DataPropertyName = "FromStation";
            fromStationDataGridViewTextBoxColumn.HeaderText = "FromStation";
            fromStationDataGridViewTextBoxColumn.Name = "fromStationDataGridViewTextBoxColumn";
            fromStationDataGridViewTextBoxColumn.ReadOnly = true;
            fromStationDataGridViewTextBoxColumn.Width = 101;
            // 
            // toStationDataGridViewTextBoxColumn
            // 
            toStationDataGridViewTextBoxColumn.DataPropertyName = "ToStation";
            toStationDataGridViewTextBoxColumn.HeaderText = "ToStation";
            toStationDataGridViewTextBoxColumn.Name = "toStationDataGridViewTextBoxColumn";
            toStationDataGridViewTextBoxColumn.ReadOnly = true;
            toStationDataGridViewTextBoxColumn.Width = 87;
            // 
            // actionTypeDataGridViewTextBoxColumn
            // 
            actionTypeDataGridViewTextBoxColumn.DataPropertyName = "ActionType";
            actionTypeDataGridViewTextBoxColumn.HeaderText = "ActionType";
            actionTypeDataGridViewTextBoxColumn.Name = "actionTypeDataGridViewTextBoxColumn";
            actionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            actionTypeDataGridViewTextBoxColumn.Width = 96;
            // 
            // aGVIDDataGridViewTextBoxColumn
            // 
            aGVIDDataGridViewTextBoxColumn.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn.Name = "aGVIDDataGridViewTextBoxColumn";
            aGVIDDataGridViewTextBoxColumn.ReadOnly = true;
            aGVIDDataGridViewTextBoxColumn.Width = 69;
            // 
            // cSTIDDataGridViewTextBoxColumn
            // 
            cSTIDDataGridViewTextBoxColumn.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn.Name = "cSTIDDataGridViewTextBoxColumn";
            cSTIDDataGridViewTextBoxColumn.ReadOnly = true;
            cSTIDDataGridViewTextBoxColumn.Width = 66;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            priorityDataGridViewTextBoxColumn.DataPropertyName = "Priority";
            priorityDataGridViewTextBoxColumn.HeaderText = "Priority";
            priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            priorityDataGridViewTextBoxColumn.ReadOnly = true;
            priorityDataGridViewTextBoxColumn.Width = 71;
            // 
            // repeatTimeDataGridViewTextBoxColumn
            // 
            repeatTimeDataGridViewTextBoxColumn.DataPropertyName = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.HeaderText = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn.Name = "repeatTimeDataGridViewTextBoxColumn";
            repeatTimeDataGridViewTextBoxColumn.ReadOnly = true;
            repeatTimeDataGridViewTextBoxColumn.Width = 101;
            // 
            // exeVehicleIDDataGridViewTextBoxColumn
            // 
            exeVehicleIDDataGridViewTextBoxColumn.DataPropertyName = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.HeaderText = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn.Name = "exeVehicleIDDataGridViewTextBoxColumn";
            exeVehicleIDDataGridViewTextBoxColumn.ReadOnly = true;
            exeVehicleIDDataGridViewTextBoxColumn.Width = 105;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            startTimeDataGridViewTextBoxColumn.Width = 86;
            // 
            // distanceDataGridViewTextBoxColumn
            // 
            distanceDataGridViewTextBoxColumn.DataPropertyName = "Distance";
            distanceDataGridViewTextBoxColumn.HeaderText = "Distance";
            distanceDataGridViewTextBoxColumn.Name = "distanceDataGridViewTextBoxColumn";
            distanceDataGridViewTextBoxColumn.ReadOnly = true;
            distanceDataGridViewTextBoxColumn.Width = 80;
            // 
            // acquireTimeDataGridViewTextBoxColumn
            // 
            acquireTimeDataGridViewTextBoxColumn.DataPropertyName = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.HeaderText = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn.Name = "acquireTimeDataGridViewTextBoxColumn";
            acquireTimeDataGridViewTextBoxColumn.ReadOnly = true;
            acquireTimeDataGridViewTextBoxColumn.Width = 103;
            // 
            // depositTimeDataGridViewTextBoxColumn
            // 
            depositTimeDataGridViewTextBoxColumn.DataPropertyName = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.HeaderText = "DepositTime";
            depositTimeDataGridViewTextBoxColumn.Name = "depositTimeDataGridViewTextBoxColumn";
            depositTimeDataGridViewTextBoxColumn.ReadOnly = true;
            depositTimeDataGridViewTextBoxColumn.Width = 104;
            // 
            // assignUserNameDataGridViewTextBoxColumn
            // 
            assignUserNameDataGridViewTextBoxColumn.DataPropertyName = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.HeaderText = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn.Name = "assignUserNameDataGridViewTextBoxColumn";
            assignUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            assignUserNameDataGridViewTextBoxColumn.Width = 128;
            // 
            // cSTTypeDataGridViewTextBoxColumn
            // 
            cSTTypeDataGridViewTextBoxColumn.DataPropertyName = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.HeaderText = "CSTType";
            cSTTypeDataGridViewTextBoxColumn.Name = "cSTTypeDataGridViewTextBoxColumn";
            cSTTypeDataGridViewTextBoxColumn.ReadOnly = true;
            cSTTypeDataGridViewTextBoxColumn.Width = 82;
            // 
            // fromStationPortNoDataGridViewTextBoxColumn
            // 
            fromStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.HeaderText = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn.Name = "fromStationPortNoDataGridViewTextBoxColumn";
            fromStationPortNoDataGridViewTextBoxColumn.ReadOnly = true;
            fromStationPortNoDataGridViewTextBoxColumn.Width = 142;
            // 
            // toStationPortNoDataGridViewTextBoxColumn
            // 
            toStationPortNoDataGridViewTextBoxColumn.DataPropertyName = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.HeaderText = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn.Name = "toStationPortNoDataGridViewTextBoxColumn";
            toStationPortNoDataGridViewTextBoxColumn.ReadOnly = true;
            toStationPortNoDataGridViewTextBoxColumn.Width = 128;
            // 
            // exeVehiclePosDataGridViewTextBoxColumn
            // 
            exeVehiclePosDataGridViewTextBoxColumn.DataPropertyName = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.HeaderText = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn.Name = "exeVehiclePosDataGridViewTextBoxColumn";
            exeVehiclePosDataGridViewTextBoxColumn.ReadOnly = true;
            exeVehiclePosDataGridViewTextBoxColumn.Width = 113;
            // 
            // cSTLayersDataGridViewTextBoxColumn
            // 
            cSTLayersDataGridViewTextBoxColumn.DataPropertyName = "CSTLayers";
            cSTLayersDataGridViewTextBoxColumn.HeaderText = "CSTLayers";
            cSTLayersDataGridViewTextBoxColumn.Name = "cSTLayersDataGridViewTextBoxColumn";
            cSTLayersDataGridViewTextBoxColumn.ReadOnly = true;
            cSTLayersDataGridViewTextBoxColumn.Width = 89;
            // 
            // executingTaskBindingSource
            // 
            executingTaskBindingSource.DataSource = typeof(KGSWebAGVSystemAPI.Models.ExecutingTask);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvExecutingTask);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1223, 328);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "執行中任務";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvTaskHistory);
            groupBox2.Dock = DockStyle.Top;
            groupBox2.Location = new Point(0, 353);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1223, 328);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "歷史任務";
            // 
            // dgvTaskHistory
            // 
            dgvTaskHistory.AllowUserToAddRows = false;
            dgvTaskHistory.AllowUserToDeleteRows = false;
            dgvTaskHistory.AutoGenerateColumns = false;
            dgvTaskHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTaskHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaskHistory.Columns.AddRange(new DataGridViewColumn[] { deleteCol, nameDataGridViewTextBoxColumn1, statusDataGridViewTextBoxColumn1, receiveTimeDataGridViewTextBoxColumn1, fromStationIdDataGridViewTextBoxColumn1, toStationIdDataGridViewTextBoxColumn1, fromStationDataGridViewTextBoxColumn1, toStationDataGridViewTextBoxColumn1, actionTypeDataGridViewTextBoxColumn1, aGVIDDataGridViewTextBoxColumn1, cSTIDDataGridViewTextBoxColumn1, priorityDataGridViewTextBoxColumn1, repeatTimeDataGridViewTextBoxColumn1, exeVehicleIDDataGridViewTextBoxColumn1, startTimeDataGridViewTextBoxColumn1, endTimeDataGridViewTextBoxColumn, totalTimeDataGridViewTextBoxColumn, distanceDataGridViewTextBoxColumn1, acquireTimeDataGridViewTextBoxColumn1, depositTimeDataGridViewTextBoxColumn1, assignUserNameDataGridViewTextBoxColumn1, cancelUserNameDataGridViewTextBoxColumn, cSTTypeDataGridViewTextBoxColumn1, failReasonDataGridViewTextBoxColumn, fromStationPortNoDataGridViewTextBoxColumn1, toStationPortNoDataGridViewTextBoxColumn1, exeVehiclePosDataGridViewTextBoxColumn1, cSTLayersDataGridViewTextBoxColumn1 });
            dgvTaskHistory.DataSource = taskBindingSource;
            dgvTaskHistory.Dock = DockStyle.Fill;
            dgvTaskHistory.Location = new Point(3, 19);
            dgvTaskHistory.Name = "dgvTaskHistory";
            dgvTaskHistory.ReadOnly = true;
            dgvTaskHistory.RowTemplate.Height = 25;
            dgvTaskHistory.Size = new Size(1217, 306);
            dgvTaskHistory.TabIndex = 0;
            dgvTaskHistory.CellContentClick += dgvTaskHistory_CellContentClick;
            dgvTaskHistory.CellMouseDown += dgvTaskHistory_CellMouseDown;
            // 
            // deleteCol
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Red;
            dataGridViewCellStyle2.ForeColor = Color.White;
            deleteCol.DefaultCellStyle = dataGridViewCellStyle2;
            deleteCol.FlatStyle = FlatStyle.Flat;
            deleteCol.HeaderText = "Delete";
            deleteCol.Name = "deleteCol";
            deleteCol.ReadOnly = true;
            deleteCol.Text = "Delete";
            deleteCol.UseColumnTextForButtonValue = true;
            deleteCol.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            nameDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            nameDataGridViewTextBoxColumn1.ReadOnly = true;
            nameDataGridViewTextBoxColumn1.Width = 67;
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn1.HeaderText = "Status";
            statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            statusDataGridViewTextBoxColumn1.ReadOnly = true;
            statusDataGridViewTextBoxColumn1.Width = 66;
            // 
            // receiveTimeDataGridViewTextBoxColumn1
            // 
            receiveTimeDataGridViewTextBoxColumn1.DataPropertyName = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn1.HeaderText = "Receive_Time";
            receiveTimeDataGridViewTextBoxColumn1.Name = "receiveTimeDataGridViewTextBoxColumn1";
            receiveTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            receiveTimeDataGridViewTextBoxColumn1.Width = 109;
            // 
            // fromStationIdDataGridViewTextBoxColumn1
            // 
            fromStationIdDataGridViewTextBoxColumn1.DataPropertyName = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn1.HeaderText = "FromStationId";
            fromStationIdDataGridViewTextBoxColumn1.Name = "fromStationIdDataGridViewTextBoxColumn1";
            fromStationIdDataGridViewTextBoxColumn1.ReadOnly = true;
            fromStationIdDataGridViewTextBoxColumn1.Width = 112;
            // 
            // toStationIdDataGridViewTextBoxColumn1
            // 
            toStationIdDataGridViewTextBoxColumn1.DataPropertyName = "ToStationId";
            toStationIdDataGridViewTextBoxColumn1.HeaderText = "ToStationId";
            toStationIdDataGridViewTextBoxColumn1.Name = "toStationIdDataGridViewTextBoxColumn1";
            toStationIdDataGridViewTextBoxColumn1.ReadOnly = true;
            toStationIdDataGridViewTextBoxColumn1.Width = 98;
            // 
            // fromStationDataGridViewTextBoxColumn1
            // 
            fromStationDataGridViewTextBoxColumn1.DataPropertyName = "FromStation";
            fromStationDataGridViewTextBoxColumn1.HeaderText = "FromStation";
            fromStationDataGridViewTextBoxColumn1.Name = "fromStationDataGridViewTextBoxColumn1";
            fromStationDataGridViewTextBoxColumn1.ReadOnly = true;
            fromStationDataGridViewTextBoxColumn1.Width = 101;
            // 
            // toStationDataGridViewTextBoxColumn1
            // 
            toStationDataGridViewTextBoxColumn1.DataPropertyName = "ToStation";
            toStationDataGridViewTextBoxColumn1.HeaderText = "ToStation";
            toStationDataGridViewTextBoxColumn1.Name = "toStationDataGridViewTextBoxColumn1";
            toStationDataGridViewTextBoxColumn1.ReadOnly = true;
            toStationDataGridViewTextBoxColumn1.Width = 87;
            // 
            // actionTypeDataGridViewTextBoxColumn1
            // 
            actionTypeDataGridViewTextBoxColumn1.DataPropertyName = "ActionType";
            actionTypeDataGridViewTextBoxColumn1.HeaderText = "ActionType";
            actionTypeDataGridViewTextBoxColumn1.Name = "actionTypeDataGridViewTextBoxColumn1";
            actionTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            actionTypeDataGridViewTextBoxColumn1.Width = 96;
            // 
            // aGVIDDataGridViewTextBoxColumn1
            // 
            aGVIDDataGridViewTextBoxColumn1.DataPropertyName = "AGVID";
            aGVIDDataGridViewTextBoxColumn1.HeaderText = "AGVID";
            aGVIDDataGridViewTextBoxColumn1.Name = "aGVIDDataGridViewTextBoxColumn1";
            aGVIDDataGridViewTextBoxColumn1.ReadOnly = true;
            aGVIDDataGridViewTextBoxColumn1.Width = 69;
            // 
            // cSTIDDataGridViewTextBoxColumn1
            // 
            cSTIDDataGridViewTextBoxColumn1.DataPropertyName = "CSTID";
            cSTIDDataGridViewTextBoxColumn1.HeaderText = "CSTID";
            cSTIDDataGridViewTextBoxColumn1.Name = "cSTIDDataGridViewTextBoxColumn1";
            cSTIDDataGridViewTextBoxColumn1.ReadOnly = true;
            cSTIDDataGridViewTextBoxColumn1.Width = 66;
            // 
            // priorityDataGridViewTextBoxColumn1
            // 
            priorityDataGridViewTextBoxColumn1.DataPropertyName = "Priority";
            priorityDataGridViewTextBoxColumn1.HeaderText = "Priority";
            priorityDataGridViewTextBoxColumn1.Name = "priorityDataGridViewTextBoxColumn1";
            priorityDataGridViewTextBoxColumn1.ReadOnly = true;
            priorityDataGridViewTextBoxColumn1.Width = 71;
            // 
            // repeatTimeDataGridViewTextBoxColumn1
            // 
            repeatTimeDataGridViewTextBoxColumn1.DataPropertyName = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn1.HeaderText = "RepeatTime";
            repeatTimeDataGridViewTextBoxColumn1.Name = "repeatTimeDataGridViewTextBoxColumn1";
            repeatTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            repeatTimeDataGridViewTextBoxColumn1.Width = 101;
            // 
            // exeVehicleIDDataGridViewTextBoxColumn1
            // 
            exeVehicleIDDataGridViewTextBoxColumn1.DataPropertyName = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn1.HeaderText = "ExeVehicleID";
            exeVehicleIDDataGridViewTextBoxColumn1.Name = "exeVehicleIDDataGridViewTextBoxColumn1";
            exeVehicleIDDataGridViewTextBoxColumn1.ReadOnly = true;
            exeVehicleIDDataGridViewTextBoxColumn1.Width = 105;
            // 
            // startTimeDataGridViewTextBoxColumn1
            // 
            startTimeDataGridViewTextBoxColumn1.DataPropertyName = "StartTime";
            startTimeDataGridViewTextBoxColumn1.HeaderText = "StartTime";
            startTimeDataGridViewTextBoxColumn1.Name = "startTimeDataGridViewTextBoxColumn1";
            startTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            startTimeDataGridViewTextBoxColumn1.Width = 86;
            // 
            // endTimeDataGridViewTextBoxColumn
            // 
            endTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime";
            endTimeDataGridViewTextBoxColumn.HeaderText = "EndTime";
            endTimeDataGridViewTextBoxColumn.Name = "endTimeDataGridViewTextBoxColumn";
            endTimeDataGridViewTextBoxColumn.ReadOnly = true;
            endTimeDataGridViewTextBoxColumn.Width = 82;
            // 
            // totalTimeDataGridViewTextBoxColumn
            // 
            totalTimeDataGridViewTextBoxColumn.DataPropertyName = "TotalTime";
            totalTimeDataGridViewTextBoxColumn.HeaderText = "TotalTime";
            totalTimeDataGridViewTextBoxColumn.Name = "totalTimeDataGridViewTextBoxColumn";
            totalTimeDataGridViewTextBoxColumn.ReadOnly = true;
            totalTimeDataGridViewTextBoxColumn.Width = 89;
            // 
            // distanceDataGridViewTextBoxColumn1
            // 
            distanceDataGridViewTextBoxColumn1.DataPropertyName = "Distance";
            distanceDataGridViewTextBoxColumn1.HeaderText = "Distance";
            distanceDataGridViewTextBoxColumn1.Name = "distanceDataGridViewTextBoxColumn1";
            distanceDataGridViewTextBoxColumn1.ReadOnly = true;
            distanceDataGridViewTextBoxColumn1.Width = 80;
            // 
            // acquireTimeDataGridViewTextBoxColumn1
            // 
            acquireTimeDataGridViewTextBoxColumn1.DataPropertyName = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn1.HeaderText = "AcquireTime";
            acquireTimeDataGridViewTextBoxColumn1.Name = "acquireTimeDataGridViewTextBoxColumn1";
            acquireTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            acquireTimeDataGridViewTextBoxColumn1.Width = 103;
            // 
            // depositTimeDataGridViewTextBoxColumn1
            // 
            depositTimeDataGridViewTextBoxColumn1.DataPropertyName = "DepositTime";
            depositTimeDataGridViewTextBoxColumn1.HeaderText = "DepositTime";
            depositTimeDataGridViewTextBoxColumn1.Name = "depositTimeDataGridViewTextBoxColumn1";
            depositTimeDataGridViewTextBoxColumn1.ReadOnly = true;
            depositTimeDataGridViewTextBoxColumn1.Width = 104;
            // 
            // assignUserNameDataGridViewTextBoxColumn1
            // 
            assignUserNameDataGridViewTextBoxColumn1.DataPropertyName = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn1.HeaderText = "AssignUserName";
            assignUserNameDataGridViewTextBoxColumn1.Name = "assignUserNameDataGridViewTextBoxColumn1";
            assignUserNameDataGridViewTextBoxColumn1.ReadOnly = true;
            assignUserNameDataGridViewTextBoxColumn1.Width = 128;
            // 
            // cancelUserNameDataGridViewTextBoxColumn
            // 
            cancelUserNameDataGridViewTextBoxColumn.DataPropertyName = "CancelUserName";
            cancelUserNameDataGridViewTextBoxColumn.HeaderText = "CancelUserName";
            cancelUserNameDataGridViewTextBoxColumn.Name = "cancelUserNameDataGridViewTextBoxColumn";
            cancelUserNameDataGridViewTextBoxColumn.ReadOnly = true;
            cancelUserNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // cSTTypeDataGridViewTextBoxColumn1
            // 
            cSTTypeDataGridViewTextBoxColumn1.DataPropertyName = "CSTType";
            cSTTypeDataGridViewTextBoxColumn1.HeaderText = "CSTType";
            cSTTypeDataGridViewTextBoxColumn1.Name = "cSTTypeDataGridViewTextBoxColumn1";
            cSTTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            cSTTypeDataGridViewTextBoxColumn1.Width = 82;
            // 
            // failReasonDataGridViewTextBoxColumn
            // 
            failReasonDataGridViewTextBoxColumn.DataPropertyName = "FailReason";
            failReasonDataGridViewTextBoxColumn.HeaderText = "FailReason";
            failReasonDataGridViewTextBoxColumn.Name = "failReasonDataGridViewTextBoxColumn";
            failReasonDataGridViewTextBoxColumn.ReadOnly = true;
            failReasonDataGridViewTextBoxColumn.Width = 93;
            // 
            // fromStationPortNoDataGridViewTextBoxColumn1
            // 
            fromStationPortNoDataGridViewTextBoxColumn1.DataPropertyName = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn1.HeaderText = "FromStationPortNo";
            fromStationPortNoDataGridViewTextBoxColumn1.Name = "fromStationPortNoDataGridViewTextBoxColumn1";
            fromStationPortNoDataGridViewTextBoxColumn1.ReadOnly = true;
            fromStationPortNoDataGridViewTextBoxColumn1.Width = 142;
            // 
            // toStationPortNoDataGridViewTextBoxColumn1
            // 
            toStationPortNoDataGridViewTextBoxColumn1.DataPropertyName = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn1.HeaderText = "ToStationPortNo";
            toStationPortNoDataGridViewTextBoxColumn1.Name = "toStationPortNoDataGridViewTextBoxColumn1";
            toStationPortNoDataGridViewTextBoxColumn1.ReadOnly = true;
            toStationPortNoDataGridViewTextBoxColumn1.Width = 128;
            // 
            // exeVehiclePosDataGridViewTextBoxColumn1
            // 
            exeVehiclePosDataGridViewTextBoxColumn1.DataPropertyName = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn1.HeaderText = "ExeVehiclePos";
            exeVehiclePosDataGridViewTextBoxColumn1.Name = "exeVehiclePosDataGridViewTextBoxColumn1";
            exeVehiclePosDataGridViewTextBoxColumn1.ReadOnly = true;
            exeVehiclePosDataGridViewTextBoxColumn1.Width = 113;
            // 
            // cSTLayersDataGridViewTextBoxColumn1
            // 
            cSTLayersDataGridViewTextBoxColumn1.DataPropertyName = "CSTLayers";
            cSTLayersDataGridViewTextBoxColumn1.HeaderText = "CSTLayers";
            cSTLayersDataGridViewTextBoxColumn1.Name = "cSTLayersDataGridViewTextBoxColumn1";
            cSTLayersDataGridViewTextBoxColumn1.ReadOnly = true;
            cSTLayersDataGridViewTextBoxColumn1.Width = 89;
            // 
            // taskBindingSource
            // 
            taskBindingSource.DataSource = typeof(KGSWebAGVSystemAPI.Models.Task);
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1223, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownItems.AddRange(new ToolStripItem[] { RefreshToolStripMenuItem, autoRefreshToolStripMenuItem });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(47, 22);
            toolStripComboBox1.Text = "View";
            // 
            // RefreshToolStripMenuItem
            // 
            RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            RefreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            RefreshToolStripMenuItem.Size = new Size(142, 22);
            RefreshToolStripMenuItem.Text = "重新整理";
            RefreshToolStripMenuItem.Click += RefreshToolStripMenuItem_Click;
            // 
            // autoRefreshToolStripMenuItem
            // 
            autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            autoRefreshToolStripMenuItem.Size = new Size(142, 22);
            autoRefreshToolStripMenuItem.Text = "自動更新";
            autoRefreshToolStripMenuItem.Click += autoRefreshToolStripMenuItem_Click;
            // 
            // autoRefreshTimer
            // 
            autoRefreshTimer.Interval = 1000;
            autoRefreshTimer.Tick += autoRefreshTimer_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tlabDBConnectionStr, toolStripStatusLabel2, tlabKGAGVSAPIUrl, toolStripStatusLabel3, tlabWebServerActionInfo });
            statusStrip1.Location = new Point(0, 707);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1223, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(64, 17);
            toolStripStatusLabel1.Text = "Database:";
            // 
            // tlabDBConnectionStr
            // 
            tlabDBConnectionStr.Name = "tlabDBConnectionStr";
            tlabDBConnectionStr.Size = new Size(12, 17);
            tlabDBConnectionStr.Text = "-";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(72, 17);
            toolStripStatusLabel2.Text = "Web Server";
            // 
            // tlabKGAGVSAPIUrl
            // 
            tlabKGAGVSAPIUrl.Name = "tlabKGAGVSAPIUrl";
            tlabKGAGVSAPIUrl.Size = new Size(12, 17);
            tlabKGAGVSAPIUrl.Text = "-";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(1036, 17);
            toolStripStatusLabel3.Spring = true;
            // 
            // tlabWebServerActionInfo
            // 
            tlabWebServerActionInfo.Name = "tlabWebServerActionInfo";
            tlabWebServerActionInfo.Size = new Size(12, 17);
            tlabWebServerActionInfo.Text = "-";
            // 
            // frmKGSWebAGVSystem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 729);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(toolStrip1);
            Name = "frmKGSWebAGVSystem";
            Text = "KGS WebAGVSystem";
            FormClosing += frmKGSWebAGVSystem_FormClosing;
            Load += frmKGSWebAGVSystem_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExecutingTask).EndInit();
            ((System.ComponentModel.ISupportInitialize)executingTaskBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaskHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvExecutingTask;
        private GroupBox groupBox1;
        private DataGridViewTextBoxColumn fromStationNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationNameDataGridViewTextBoxColumn;
        private BindingSource executingTaskBindingSource;
        private GroupBox groupBox2;
        private DataGridView dgvTaskHistory;
        private DataGridViewTextBoxColumn fromStationNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn toStationNameDataGridViewTextBoxColumn1;
        private BindingSource taskBindingSource;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripComboBox1;
        private ToolStripMenuItem RefreshToolStripMenuItem;
        private DataGridViewButtonColumn deleteCol;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn receiveTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fromStationIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn toStationIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn fromStationDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn toStationDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn actionTypeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn aGVIDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cSTIDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn repeatTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn exeVehicleIDDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn endTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn acquireTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn depositTimeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn assignUserNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cancelUserNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cSTTypeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn failReasonDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationPortNoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn toStationPortNoDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn exeVehiclePosDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cSTLayersDataGridViewTextBoxColumn1;
        private DataGridViewButtonColumn cancelBtnCol;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn receiveTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fromStationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn toStationDataGridViewTextBoxColumn;
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
        private DataGridViewTextBoxColumn cSTLayersDataGridViewTextBoxColumn;
        private ToolStripMenuItem autoRefreshToolStripMenuItem;
        private System.Windows.Forms.Timer autoRefreshTimer;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tlabDBConnectionStr;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel tlabKGAGVSAPIUrl;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel tlabWebServerActionInfo;
    }
}