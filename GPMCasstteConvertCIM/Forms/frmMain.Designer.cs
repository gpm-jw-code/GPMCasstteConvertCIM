namespace GPMCasstteConvertCIM.Forms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tlpConverterContainer = new TableLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            dgvMsgFromMCS = new DataGridView();
            primaryMessageSMLDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            secondaryMessageSMLDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            primaryMessageWrapperBindingSource4 = new BindingSource(components);
            dgvMsgFromAGVS = new DataGridView();
            primaryMessageSMLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            secondaryMessageSMLDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            primaryMessageWrapperBindingSource1 = new BindingSource(components);
            dgvActiveMsgToMCS = new DataGridView();
            primaryMessageSMLDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            secondaryMessageSMLDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            primaryMessageWrapperBindingSource3 = new BindingSource(components);
            dgvActiveMsgToAGVS = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            secondaryMessageSMLDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            primaryMessageWrapperBindingSource2 = new BindingSource(components);
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            tabPage3 = new TabPage();
            uscAlarmTable1 = new UI_UserControls.UscAlarmTable();
            tabPage2 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBox2 = new CheckBox();
            rtbSecsHostLog = new RichTextBox();
            rtbSecsClientLog = new RichTextBox();
            checkBox1 = new CheckBox();
            checkBox5 = new CheckBox();
            rtbModbusTcpServerLog = new RichTextBox();
            messageWrapperBindingSource = new BindingSource(components);
            primaryMessageWrapperBindingSource = new BindingSource(components);
            GPMRDMenuStrip = new MenuStrip();
            toolStripComboBox_Emulators = new ToolStripMenuItem();
            mCS模擬器ToolStripMenuItem = new ToolStripMenuItem();
            轉換架模擬器ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_OpenConvert_1_Simulator = new ToolStripMenuItem();
            toolStripMenuItem_OpenConvert_2_Simulator = new ToolStripMenuItem();
            AGVS_modbus_sim_ToolStripMenuItem = new ToolStripMenuItem();
            aGVSEmuToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            pnlSideLeft = new Panel();
            btnOpenLoginFOrm = new Button();
            label6 = new Label();
            uscConnectionStates1 = new UI_UserControls.UscConnectionStates();
            label1 = new Label();
            panel1 = new Panel();
            btnClearInfoLog = new Button();
            rtbSystemLogShow = new RichTextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            labSysTime = new ToolStripStatusLabel();
            SysTimer = new System.Windows.Forms.Timer(components);
            uscAlarmShow1 = new UI_UserControls.UscAlarmShow();
            splitContainer1 = new SplitContainer();
            ckbRemoteModeIndi = new CheckBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMsgFromMCS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMsgFromAGVS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveMsgToMCS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveMsgToAGVS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource2).BeginInit();
            tabPage3.SuspendLayout();
            tabPage2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)messageWrapperBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource).BeginInit();
            GPMRDMenuStrip.SuspendLayout();
            pnlSideLeft.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.HotTrack = true;
            tabControl1.ItemSize = new Size(96, 30);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1274, 415);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(tlpConverterContainer);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1266, 377);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "HOME";
            // 
            // tlpConverterContainer
            // 
            tlpConverterContainer.AutoScroll = true;
            tlpConverterContainer.BackColor = Color.WhiteSmoke;
            tlpConverterContainer.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpConverterContainer.ColumnCount = 1;
            tlpConverterContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpConverterContainer.Dock = DockStyle.Fill;
            tlpConverterContainer.Location = new Point(3, 3);
            tlpConverterContainer.Name = "tlpConverterContainer";
            tlpConverterContainer.RowCount = 2;
            tlpConverterContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpConverterContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpConverterContainer.Size = new Size(517, 371);
            tlpConverterContainer.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(520, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(743, 371);
            panel2.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dgvMsgFromMCS, 0, 1);
            tableLayoutPanel2.Controls.Add(dgvMsgFromAGVS, 0, 3);
            tableLayoutPanel2.Controls.Add(dgvActiveMsgToMCS, 1, 1);
            tableLayoutPanel2.Controls.Add(dgvActiveMsgToAGVS, 1, 3);
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(label4, 0, 2);
            tableLayoutPanel2.Controls.Add(label3, 1, 0);
            tableLayoutPanel2.Controls.Add(label5, 1, 2);
            tableLayoutPanel2.Location = new Point(5, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 17F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(733, 365);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // dgvMsgFromMCS
            // 
            dgvMsgFromMCS.AllowUserToDeleteRows = false;
            dgvMsgFromMCS.AllowUserToOrderColumns = true;
            dgvMsgFromMCS.AutoGenerateColumns = false;
            dgvMsgFromMCS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMsgFromMCS.BackgroundColor = Color.Black;
            dgvMsgFromMCS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvMsgFromMCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMsgFromMCS.Columns.AddRange(new DataGridViewColumn[] { primaryMessageSMLDataGridViewTextBoxColumn2, secondaryMessageSMLDataGridViewTextBoxColumn3 });
            dgvMsgFromMCS.DataSource = primaryMessageWrapperBindingSource4;
            dgvMsgFromMCS.Dock = DockStyle.Fill;
            dgvMsgFromMCS.GridColor = Color.DarkCyan;
            dgvMsgFromMCS.Location = new Point(4, 22);
            dgvMsgFromMCS.Name = "dgvMsgFromMCS";
            dgvMsgFromMCS.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMsgFromMCS.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMsgFromMCS.RowHeadersVisible = false;
            dgvMsgFromMCS.RowTemplate.Height = 25;
            dgvMsgFromMCS.Size = new Size(359, 157);
            dgvMsgFromMCS.TabIndex = 6;
            // 
            // primaryMessageSMLDataGridViewTextBoxColumn2
            // 
            primaryMessageSMLDataGridViewTextBoxColumn2.DataPropertyName = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn2.HeaderText = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn2.Name = "primaryMessageSMLDataGridViewTextBoxColumn2";
            primaryMessageSMLDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // secondaryMessageSMLDataGridViewTextBoxColumn3
            // 
            secondaryMessageSMLDataGridViewTextBoxColumn3.DataPropertyName = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn3.HeaderText = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn3.Name = "secondaryMessageSMLDataGridViewTextBoxColumn3";
            secondaryMessageSMLDataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // primaryMessageWrapperBindingSource4
            // 
            primaryMessageWrapperBindingSource4.DataSource = typeof(Secs4Net.PrimaryMessageWrapper);
            // 
            // dgvMsgFromAGVS
            // 
            dgvMsgFromAGVS.AllowUserToDeleteRows = false;
            dgvMsgFromAGVS.AllowUserToOrderColumns = true;
            dgvMsgFromAGVS.AutoGenerateColumns = false;
            dgvMsgFromAGVS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMsgFromAGVS.BackgroundColor = Color.Black;
            dgvMsgFromAGVS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvMsgFromAGVS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMsgFromAGVS.Columns.AddRange(new DataGridViewColumn[] { primaryMessageSMLDataGridViewTextBoxColumn, secondaryMessageSMLDataGridViewTextBoxColumn });
            dgvMsgFromAGVS.DataSource = primaryMessageWrapperBindingSource1;
            dgvMsgFromAGVS.Dock = DockStyle.Fill;
            dgvMsgFromAGVS.GridColor = Color.DarkCyan;
            dgvMsgFromAGVS.Location = new Point(4, 204);
            dgvMsgFromAGVS.Name = "dgvMsgFromAGVS";
            dgvMsgFromAGVS.ReadOnly = true;
            dgvMsgFromAGVS.RowHeadersVisible = false;
            dgvMsgFromAGVS.RowTemplate.Height = 25;
            dgvMsgFromAGVS.Size = new Size(359, 157);
            dgvMsgFromAGVS.TabIndex = 8;
            // 
            // primaryMessageSMLDataGridViewTextBoxColumn
            // 
            primaryMessageSMLDataGridViewTextBoxColumn.DataPropertyName = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn.HeaderText = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn.Name = "primaryMessageSMLDataGridViewTextBoxColumn";
            primaryMessageSMLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // secondaryMessageSMLDataGridViewTextBoxColumn
            // 
            secondaryMessageSMLDataGridViewTextBoxColumn.DataPropertyName = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn.HeaderText = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn.Name = "secondaryMessageSMLDataGridViewTextBoxColumn";
            secondaryMessageSMLDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primaryMessageWrapperBindingSource1
            // 
            primaryMessageWrapperBindingSource1.DataSource = typeof(Secs4Net.PrimaryMessageWrapper);
            // 
            // dgvActiveMsgToMCS
            // 
            dgvActiveMsgToMCS.AllowUserToDeleteRows = false;
            dgvActiveMsgToMCS.AutoGenerateColumns = false;
            dgvActiveMsgToMCS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActiveMsgToMCS.BackgroundColor = Color.Black;
            dgvActiveMsgToMCS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvActiveMsgToMCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveMsgToMCS.Columns.AddRange(new DataGridViewColumn[] { primaryMessageSMLDataGridViewTextBoxColumn1, secondaryMessageSMLDataGridViewTextBoxColumn2 });
            dgvActiveMsgToMCS.DataSource = primaryMessageWrapperBindingSource3;
            dgvActiveMsgToMCS.Dock = DockStyle.Fill;
            dgvActiveMsgToMCS.GridColor = Color.DarkCyan;
            dgvActiveMsgToMCS.Location = new Point(370, 22);
            dgvActiveMsgToMCS.Name = "dgvActiveMsgToMCS";
            dgvActiveMsgToMCS.ReadOnly = true;
            dgvActiveMsgToMCS.RowHeadersVisible = false;
            dgvActiveMsgToMCS.RowTemplate.Height = 25;
            dgvActiveMsgToMCS.Size = new Size(359, 157);
            dgvActiveMsgToMCS.TabIndex = 7;
            // 
            // primaryMessageSMLDataGridViewTextBoxColumn1
            // 
            primaryMessageSMLDataGridViewTextBoxColumn1.DataPropertyName = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn1.HeaderText = "PrimaryMessageSML";
            primaryMessageSMLDataGridViewTextBoxColumn1.Name = "primaryMessageSMLDataGridViewTextBoxColumn1";
            primaryMessageSMLDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // secondaryMessageSMLDataGridViewTextBoxColumn2
            // 
            secondaryMessageSMLDataGridViewTextBoxColumn2.DataPropertyName = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn2.HeaderText = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn2.Name = "secondaryMessageSMLDataGridViewTextBoxColumn2";
            secondaryMessageSMLDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // primaryMessageWrapperBindingSource3
            // 
            primaryMessageWrapperBindingSource3.DataSource = typeof(Secs4Net.PrimaryMessageWrapper);
            // 
            // dgvActiveMsgToAGVS
            // 
            dgvActiveMsgToAGVS.AllowUserToDeleteRows = false;
            dgvActiveMsgToAGVS.AutoGenerateColumns = false;
            dgvActiveMsgToAGVS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActiveMsgToAGVS.BackgroundColor = Color.Black;
            dgvActiveMsgToAGVS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvActiveMsgToAGVS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveMsgToAGVS.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, secondaryMessageSMLDataGridViewTextBoxColumn1 });
            dgvActiveMsgToAGVS.DataSource = primaryMessageWrapperBindingSource2;
            dgvActiveMsgToAGVS.Dock = DockStyle.Fill;
            dgvActiveMsgToAGVS.GridColor = Color.DarkCyan;
            dgvActiveMsgToAGVS.Location = new Point(370, 204);
            dgvActiveMsgToAGVS.Name = "dgvActiveMsgToAGVS";
            dgvActiveMsgToAGVS.ReadOnly = true;
            dgvActiveMsgToAGVS.RowHeadersVisible = false;
            dgvActiveMsgToAGVS.RowTemplate.Height = 25;
            dgvActiveMsgToAGVS.Size = new Size(359, 157);
            dgvActiveMsgToAGVS.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "PrimaryMessageSML";
            dataGridViewTextBoxColumn6.HeaderText = "PrimaryMessageSML";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // secondaryMessageSMLDataGridViewTextBoxColumn1
            // 
            secondaryMessageSMLDataGridViewTextBoxColumn1.DataPropertyName = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn1.HeaderText = "SecondaryMessageSML";
            secondaryMessageSMLDataGridViewTextBoxColumn1.Name = "secondaryMessageSMLDataGridViewTextBoxColumn1";
            secondaryMessageSMLDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // primaryMessageWrapperBindingSource2
            // 
            primaryMessageWrapperBindingSource2.DataSource = typeof(Secs4Net.PrimaryMessageWrapper);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 57, 155);
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Fill;
            label2.ForeColor = Color.White;
            label2.Location = new Point(1, 1);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(365, 17);
            label2.TabIndex = 10;
            label2.Text = "From MCS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 57, 155);
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Fill;
            label4.ForeColor = Color.White;
            label4.Location = new Point(1, 183);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(365, 17);
            label4.TabIndex = 12;
            label4.Text = "From AGVS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 57, 155);
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
            label3.ForeColor = Color.White;
            label3.Location = new Point(367, 1);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(365, 17);
            label3.TabIndex = 11;
            label3.Text = "To MCS";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(0, 57, 155);
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Fill;
            label5.ForeColor = Color.White;
            label5.Location = new Point(367, 183);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(365, 17);
            label5.TabIndex = 13;
            label5.Text = "To AGVS";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(uscAlarmTable1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1266, 377);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "系統警報";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // uscAlarmTable1
            // 
            uscAlarmTable1.BackColor = Color.White;
            uscAlarmTable1.Dock = DockStyle.Fill;
            uscAlarmTable1.Location = new Point(3, 3);
            uscAlarmTable1.Name = "uscAlarmTable1";
            uscAlarmTable1.Size = new Size(1260, 371);
            uscAlarmTable1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1266, 377);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "LOG";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(checkBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(rtbSecsHostLog, 0, 1);
            tableLayoutPanel1.Controls.Add(rtbSecsClientLog, 1, 1);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBox5, 2, 0);
            tableLayoutPanel1.Controls.Add(rtbModbusTcpServerLog, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1260, 371);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // checkBox2
            // 
            checkBox2.Appearance = Appearance.Button;
            checkBox2.BackColor = Color.Gray;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Dock = DockStyle.Fill;
            checkBox2.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox2.FlatStyle = FlatStyle.Flat;
            checkBox2.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox2.ForeColor = Color.White;
            checkBox2.Location = new Point(423, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(414, 35);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "CIM<->AGVS";
            checkBox2.TextAlign = ContentAlignment.MiddleCenter;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // rtbSecsHostLog
            // 
            rtbSecsHostLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSecsHostLog.BackColor = SystemColors.InfoText;
            rtbSecsHostLog.ForeColor = Color.White;
            rtbSecsHostLog.Location = new Point(3, 44);
            rtbSecsHostLog.Name = "rtbSecsHostLog";
            rtbSecsHostLog.Size = new Size(414, 324);
            rtbSecsHostLog.TabIndex = 1;
            rtbSecsHostLog.Text = "";
            // 
            // rtbSecsClientLog
            // 
            rtbSecsClientLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSecsClientLog.BackColor = SystemColors.InfoText;
            rtbSecsClientLog.ForeColor = Color.White;
            rtbSecsClientLog.Location = new Point(423, 44);
            rtbSecsClientLog.Name = "rtbSecsClientLog";
            rtbSecsClientLog.Size = new Size(414, 324);
            rtbSecsClientLog.TabIndex = 2;
            rtbSecsClientLog.Text = "";
            // 
            // checkBox1
            // 
            checkBox1.Appearance = Appearance.Button;
            checkBox1.BackColor = Color.Gray;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox1.FlatStyle = FlatStyle.Flat;
            checkBox1.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.White;
            checkBox1.Location = new Point(3, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(414, 35);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "CIM<->MCS";
            checkBox1.TextAlign = ContentAlignment.MiddleCenter;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            checkBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkBox5.Appearance = Appearance.Button;
            checkBox5.BackColor = Color.Gray;
            checkBox5.Checked = true;
            checkBox5.CheckState = CheckState.Checked;
            checkBox5.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox5.FlatStyle = FlatStyle.Flat;
            checkBox5.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox5.ForeColor = Color.White;
            checkBox5.Location = new Point(843, 3);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(414, 35);
            checkBox5.TabIndex = 9;
            checkBox5.Text = "ModbusTcpServer";
            checkBox5.TextAlign = ContentAlignment.MiddleCenter;
            checkBox5.UseVisualStyleBackColor = false;
            // 
            // rtbModbusTcpServerLog
            // 
            rtbModbusTcpServerLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbModbusTcpServerLog.BackColor = SystemColors.InfoText;
            rtbModbusTcpServerLog.ForeColor = Color.White;
            rtbModbusTcpServerLog.Location = new Point(843, 44);
            rtbModbusTcpServerLog.Name = "rtbModbusTcpServerLog";
            rtbModbusTcpServerLog.Size = new Size(414, 324);
            rtbModbusTcpServerLog.TabIndex = 7;
            rtbModbusTcpServerLog.Text = "";
            // 
            // GPMRDMenuStrip
            // 
            GPMRDMenuStrip.BackColor = Color.FromArgb(53, 53, 53);
            GPMRDMenuStrip.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GPMRDMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripComboBox_Emulators, toolStripMenuItem1 });
            GPMRDMenuStrip.Location = new Point(0, 0);
            GPMRDMenuStrip.Name = "GPMRDMenuStrip";
            GPMRDMenuStrip.Padding = new Padding(6, 2, 0, 6);
            GPMRDMenuStrip.RenderMode = ToolStripRenderMode.System;
            GPMRDMenuStrip.Size = new Size(1407, 32);
            GPMRDMenuStrip.TabIndex = 3;
            GPMRDMenuStrip.Text = "menuStrip1";
            // 
            // toolStripComboBox_Emulators
            // 
            toolStripComboBox_Emulators.DropDownItems.AddRange(new ToolStripItem[] { mCS模擬器ToolStripMenuItem, 轉換架模擬器ToolStripMenuItem, AGVS_modbus_sim_ToolStripMenuItem, aGVSEmuToolStripMenuItem });
            toolStripComboBox_Emulators.ForeColor = Color.White;
            toolStripComboBox_Emulators.Name = "toolStripComboBox_Emulators";
            toolStripComboBox_Emulators.ShowShortcutKeys = false;
            toolStripComboBox_Emulators.Size = new Size(69, 24);
            toolStripComboBox_Emulators.Text = "模擬器";
            // 
            // mCS模擬器ToolStripMenuItem
            // 
            mCS模擬器ToolStripMenuItem.Name = "mCS模擬器ToolStripMenuItem";
            mCS模擬器ToolStripMenuItem.ShortcutKeys = Keys.F1;
            mCS模擬器ToolStripMenuItem.Size = new Size(239, 24);
            mCS模擬器ToolStripMenuItem.Text = "MCS 模擬器";
            mCS模擬器ToolStripMenuItem.Click += btnOpenMCSSimulatorForm_Click;
            // 
            // 轉換架模擬器ToolStripMenuItem
            // 
            轉換架模擬器ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_OpenConvert_1_Simulator, toolStripMenuItem_OpenConvert_2_Simulator });
            轉換架模擬器ToolStripMenuItem.Name = "轉換架模擬器ToolStripMenuItem";
            轉換架模擬器ToolStripMenuItem.Size = new Size(239, 24);
            轉換架模擬器ToolStripMenuItem.Text = "轉換架模擬器";
            // 
            // toolStripMenuItem_OpenConvert_1_Simulator
            // 
            toolStripMenuItem_OpenConvert_1_Simulator.Name = "toolStripMenuItem_OpenConvert_1_Simulator";
            toolStripMenuItem_OpenConvert_1_Simulator.ShortcutKeys = Keys.F3;
            toolStripMenuItem_OpenConvert_1_Simulator.Size = new Size(175, 24);
            toolStripMenuItem_OpenConvert_1_Simulator.Text = "轉換架 [1]";
            toolStripMenuItem_OpenConvert_1_Simulator.Click += toolStripMenuItem_OpenConvert_1_Simulator_Click;
            // 
            // toolStripMenuItem_OpenConvert_2_Simulator
            // 
            toolStripMenuItem_OpenConvert_2_Simulator.Name = "toolStripMenuItem_OpenConvert_2_Simulator";
            toolStripMenuItem_OpenConvert_2_Simulator.ShortcutKeys = Keys.F4;
            toolStripMenuItem_OpenConvert_2_Simulator.Size = new Size(175, 24);
            toolStripMenuItem_OpenConvert_2_Simulator.Text = "轉換架 [2]";
            toolStripMenuItem_OpenConvert_2_Simulator.Click += toolStripMenuItem_OpenConvert_2_Simulator_Click;
            // 
            // AGVS_modbus_sim_ToolStripMenuItem
            // 
            AGVS_modbus_sim_ToolStripMenuItem.Name = "AGVS_modbus_sim_ToolStripMenuItem";
            AGVS_modbus_sim_ToolStripMenuItem.Size = new Size(239, 24);
            AGVS_modbus_sim_ToolStripMenuItem.Text = "AGVS Modbus 模擬器";
            AGVS_modbus_sim_ToolStripMenuItem.Click += Agvs_modbus_emu_selBtn_Click;
            // 
            // aGVSEmuToolStripMenuItem
            // 
            aGVSEmuToolStripMenuItem.Name = "aGVSEmuToolStripMenuItem";
            aGVSEmuToolStripMenuItem.Size = new Size(239, 24);
            aGVSEmuToolStripMenuItem.Text = "AGVS 派車模擬器";
            aGVSEmuToolStripMenuItem.Click += aGVS派車模擬器ToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(37, 24);
            toolStripMenuItem1.Text = "　";
            // 
            // pnlSideLeft
            // 
            pnlSideLeft.BackColor = Color.FromArgb(51, 51, 51);
            pnlSideLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlSideLeft.Controls.Add(btnOpenLoginFOrm);
            pnlSideLeft.Controls.Add(label6);
            pnlSideLeft.Controls.Add(uscConnectionStates1);
            pnlSideLeft.Controls.Add(label1);
            pnlSideLeft.Dock = DockStyle.Left;
            pnlSideLeft.ForeColor = Color.White;
            pnlSideLeft.Location = new Point(0, 32);
            pnlSideLeft.Name = "pnlSideLeft";
            pnlSideLeft.Size = new Size(133, 667);
            pnlSideLeft.TabIndex = 5;
            // 
            // btnOpenLoginFOrm
            // 
            btnOpenLoginFOrm.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnOpenLoginFOrm.ForeColor = Color.Black;
            btnOpenLoginFOrm.Location = new Point(5, 3);
            btnOpenLoginFOrm.Name = "btnOpenLoginFOrm";
            btnOpenLoginFOrm.Size = new Size(123, 36);
            btnOpenLoginFOrm.TabIndex = 8;
            btnOpenLoginFOrm.Text = "Login";
            btnOpenLoginFOrm.UseVisualStyleBackColor = true;
            btnOpenLoginFOrm.Click += btnOpenLoginFOrm_Click;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ActiveCaption;
            label6.Location = new Point(5, 51);
            label6.Name = "label6";
            label6.Size = new Size(121, 66);
            label6.TabIndex = 7;
            label6.Text = "VISITOR";
            label6.TextAlign = ContentAlignment.TopCenter;
            // 
            // uscConnectionStates1
            // 
            uscConnectionStates1.AutoSize = true;
            uscConnectionStates1.BackColor = Color.Transparent;
            uscConnectionStates1.Dock = DockStyle.Bottom;
            uscConnectionStates1.Location = new Point(0, 518);
            uscConnectionStates1.MaximumSize = new Size(134, 96);
            uscConnectionStates1.MinimumSize = new Size(134, 96);
            uscConnectionStates1.Name = "uscConnectionStates1";
            uscConnectionStates1.Padding = new Padding(1);
            uscConnectionStates1.Size = new Size(134, 96);
            uscConnectionStates1.TabIndex = 5;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 57, 155);
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 614);
            label1.Name = "label1";
            label1.Size = new Size(131, 51);
            label1.TabIndex = 6;
            label1.Text = "SECS/GEM \r\n通訊狀態";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnClearInfoLog);
            panel1.Controls.Add(rtbSystemLogShow);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(1274, 174);
            panel1.TabIndex = 6;
            // 
            // btnClearInfoLog
            // 
            btnClearInfoLog.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClearInfoLog.FlatStyle = FlatStyle.Flat;
            btnClearInfoLog.Location = new Point(1190, 6);
            btnClearInfoLog.Name = "btnClearInfoLog";
            btnClearInfoLog.Size = new Size(75, 23);
            btnClearInfoLog.TabIndex = 1;
            btnClearInfoLog.Text = "清除";
            btnClearInfoLog.UseVisualStyleBackColor = true;
            btnClearInfoLog.Click += btnClearInfoLog_Click;
            // 
            // rtbSystemLogShow
            // 
            rtbSystemLogShow.BackColor = Color.Black;
            rtbSystemLogShow.BorderStyle = BorderStyle.FixedSingle;
            rtbSystemLogShow.Dock = DockStyle.Fill;
            rtbSystemLogShow.ForeColor = Color.White;
            rtbSystemLogShow.Location = new Point(1, 1);
            rtbSystemLogShow.Name = "rtbSystemLogShow";
            rtbSystemLogShow.Size = new Size(1270, 170);
            rtbSystemLogShow.TabIndex = 0;
            rtbSystemLogShow.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(0, 57, 155);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, labSysTime });
            statusStrip1.Location = new Point(0, 699);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1407, 24);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Transparent;
            toolStripStatusLabel1.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            toolStripStatusLabel1.ForeColor = Color.WhiteSmoke;
            toolStripStatusLabel1.LinkColor = Color.FromArgb(53, 53, 53);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1271, 19);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "GPM AGV SYSTEM CIM";
            // 
            // labSysTime
            // 
            labSysTime.BackColor = Color.Transparent;
            labSysTime.BorderSides = ToolStripStatusLabelBorderSides.Left;
            labSysTime.Font = new Font("Maiandra GD", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labSysTime.ForeColor = Color.Snow;
            labSysTime.LinkColor = Color.FromArgb(53, 53, 53);
            labSysTime.Name = "labSysTime";
            labSysTime.Size = new Size(121, 19);
            labSysTime.Text = "1991/10/20 10:00:00";
            // 
            // SysTimer
            // 
            SysTimer.Enabled = true;
            SysTimer.Interval = 1000;
            SysTimer.Tick += SysTimer_Tick;
            // 
            // uscAlarmShow1
            // 
            uscAlarmShow1.AutoSize = true;
            uscAlarmShow1.BackColor = Color.FromArgb(0, 57, 155);
            uscAlarmShow1.Dock = DockStyle.Top;
            uscAlarmShow1.ForeColor = Color.White;
            uscAlarmShow1.Location = new Point(133, 32);
            uscAlarmShow1.Name = "uscAlarmShow1";
            uscAlarmShow1.Size = new Size(1274, 74);
            uscAlarmShow1.TabIndex = 10;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(53, 53, 53);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(133, 106);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(53, 53, 53);
            splitContainer1.Panel1.Controls.Add(tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1274, 593);
            splitContainer1.SplitterDistance = 415;
            splitContainer1.TabIndex = 12;
            // 
            // ckbRemoteModeIndi
            // 
            ckbRemoteModeIndi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ckbRemoteModeIndi.Appearance = Appearance.Button;
            ckbRemoteModeIndi.BackColor = Color.Red;
            ckbRemoteModeIndi.FlatAppearance.BorderColor = Color.Black;
            ckbRemoteModeIndi.FlatAppearance.CheckedBackColor = Color.SeaGreen;
            ckbRemoteModeIndi.FlatStyle = FlatStyle.Flat;
            ckbRemoteModeIndi.ForeColor = Color.White;
            ckbRemoteModeIndi.Location = new Point(1327, 3);
            ckbRemoteModeIndi.Name = "ckbRemoteModeIndi";
            ckbRemoteModeIndi.Size = new Size(77, 25);
            ckbRemoteModeIndi.TabIndex = 14;
            ckbRemoteModeIndi.Text = "OFFLINE";
            ckbRemoteModeIndi.TextAlign = ContentAlignment.MiddleCenter;
            ckbRemoteModeIndi.UseVisualStyleBackColor = false;
            ckbRemoteModeIndi.CheckedChanged += ckbRemoteModeIndi_CheckedChanged;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1407, 723);
            Controls.Add(ckbRemoteModeIndi);
            Controls.Add(splitContainer1);
            Controls.Add(uscAlarmShow1);
            Controls.Add(pnlSideLeft);
            Controls.Add(statusStrip1);
            Controls.Add(GPMRDMenuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = GPMRDMenuStrip;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GPM AGVS CIM_V23.5.23.1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMsgFromMCS).EndInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMsgFromAGVS).EndInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveMsgToMCS).EndInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActiveMsgToAGVS).EndInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource2).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)messageWrapperBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource).EndInit();
            GPMRDMenuStrip.ResumeLayout(false);
            GPMRDMenuStrip.PerformLayout();
            pnlSideLeft.ResumeLayout(false);
            pnlSideLeft.PerformLayout();
            panel1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private BindingSource primaryMessageWrapperBindingSource;
        private MenuStrip GPMRDMenuStrip;
        private ToolStripMenuItem toolStripComboBox_Emulators;
        private ToolStripMenuItem mCS模擬器ToolStripMenuItem;
        private ToolStripMenuItem 轉換架模擬器ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_OpenConvert_1_Simulator;
        private ToolStripMenuItem toolStripMenuItem_OpenConvert_2_Simulator;
        private Panel pnlSideLeft;
        private Label label1;
        private Panel panel1;
        private RichTextBox rtbSystemLogShow;
        private DataGridView dgvMsgFromMCS;
        private DataGridView dgvActiveMsgToMCS;
        private DataGridView dgvMsgFromAGVS;
        private DataGridView dgvActiveMsgToAGVS;
        private BindingSource messageWrapperBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private RichTextBox rtbModbusTcpServerLog;
        private RichTextBox rtbSecsHostLog;
        private RichTextBox rtbSecsClientLog;
        private CheckBox checkBox5;
        private ToolStripMenuItem AGVS_modbus_sim_ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel labSysTime;
        private System.Windows.Forms.Timer SysTimer;
        private DataGridViewTextBoxColumn primaryMessageSMLDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn secondaryMessageSMLDataGridViewTextBoxColumn3;
        private BindingSource primaryMessageWrapperBindingSource4;
        private DataGridViewTextBoxColumn primaryMessageSMLDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn secondaryMessageSMLDataGridViewTextBoxColumn;
        private BindingSource primaryMessageWrapperBindingSource1;
        private DataGridViewTextBoxColumn primaryMessageSMLDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn secondaryMessageSMLDataGridViewTextBoxColumn2;
        private BindingSource primaryMessageWrapperBindingSource3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn secondaryMessageSMLDataGridViewTextBoxColumn1;
        private BindingSource primaryMessageWrapperBindingSource2;
        private ToolStripMenuItem aGVSEmuToolStripMenuItem;
        private TableLayoutPanel tlpConverterContainer;
        private Panel panel2;
        private UI_UserControls.UscConnectionStates uscConnectionStates1;
        private Label label6;
        private Button btnOpenLoginFOrm;
        private UI_UserControls.UscAlarmShow uscAlarmShow1;
        private TabPage tabPage3;
        private UI_UserControls.UscAlarmTable uscAlarmTable1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem toolStripMenuItem1;
        private CheckBox ckbRemoteModeIndi;
        private Button btnClearInfoLog;
    }
}