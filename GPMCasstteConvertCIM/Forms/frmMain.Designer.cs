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
            tabPage2 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            checkBox4 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox2 = new CheckBox();
            rtbSecsHostLog = new RichTextBox();
            rtbSecsClientLog = new RichTextBox();
            rtbCasstteConvertLog = new RichTextBox();
            richTextBox3 = new RichTextBox();
            checkBox1 = new CheckBox();
            checkBox5 = new CheckBox();
            rtbModbusTcpServerLog = new RichTextBox();
            messageWrapperBindingSource = new BindingSource(components);
            primaryMessageWrapperBindingSource = new BindingSource(components);
            GPMRDMenuStrip = new MenuStrip();
            toolStripComboBox1 = new ToolStripMenuItem();
            mCS模擬器ToolStripMenuItem = new ToolStripMenuItem();
            轉換架模擬器ToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem_OpenConvert_1_Simulator = new ToolStripMenuItem();
            toolStripMenuItem_OpenConvert_2_Simulator = new ToolStripMenuItem();
            AGVS_modbus_sim_ToolStripMenuItem = new ToolStripMenuItem();
            aGVS派車模擬器ToolStripMenuItem = new ToolStripMenuItem();
            pnlSideLeft = new Panel();
            btnOpenLoginFOrm = new Button();
            label6 = new Label();
            uscConnectionStates1 = new UI_UserControls.UscConnectionStates();
            label1 = new Label();
            panel1 = new Panel();
            rtbSystemLogShow = new RichTextBox();
            statusStrip1 = new StatusStrip();
            labSysTime = new ToolStripStatusLabel();
            SysTimer = new System.Windows.Forms.Timer(components);
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
            tabPage2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)messageWrapperBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)primaryMessageWrapperBindingSource).BeginInit();
            GPMRDMenuStrip.SuspendLayout();
            pnlSideLeft.SuspendLayout();
            panel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(133, 32);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1173, 430);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(tlpConverterContainer);
            tabPage1.Controls.Add(panel2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1165, 402);
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
            tlpConverterContainer.Size = new Size(416, 396);
            tlpConverterContainer.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel2);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(419, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(743, 396);
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
            tableLayoutPanel2.Size = new Size(733, 390);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // dgvMsgFromMCS
            // 
            dgvMsgFromMCS.AllowUserToDeleteRows = false;
            dgvMsgFromMCS.AllowUserToOrderColumns = true;
            dgvMsgFromMCS.AutoGenerateColumns = false;
            dgvMsgFromMCS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMsgFromMCS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvMsgFromMCS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMsgFromMCS.Columns.AddRange(new DataGridViewColumn[] { primaryMessageSMLDataGridViewTextBoxColumn2, secondaryMessageSMLDataGridViewTextBoxColumn3 });
            dgvMsgFromMCS.DataSource = primaryMessageWrapperBindingSource4;
            dgvMsgFromMCS.Dock = DockStyle.Fill;
            dgvMsgFromMCS.GridColor = Color.DarkCyan;
            dgvMsgFromMCS.Location = new Point(4, 22);
            dgvMsgFromMCS.Name = "dgvMsgFromMCS";
            dgvMsgFromMCS.ReadOnly = true;
            dgvMsgFromMCS.RowHeadersVisible = false;
            dgvMsgFromMCS.RowTemplate.Height = 25;
            dgvMsgFromMCS.Size = new Size(359, 169);
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
            dgvMsgFromAGVS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvMsgFromAGVS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMsgFromAGVS.Columns.AddRange(new DataGridViewColumn[] { primaryMessageSMLDataGridViewTextBoxColumn, secondaryMessageSMLDataGridViewTextBoxColumn });
            dgvMsgFromAGVS.DataSource = primaryMessageWrapperBindingSource1;
            dgvMsgFromAGVS.Dock = DockStyle.Fill;
            dgvMsgFromAGVS.GridColor = Color.DarkCyan;
            dgvMsgFromAGVS.Location = new Point(4, 216);
            dgvMsgFromAGVS.Name = "dgvMsgFromAGVS";
            dgvMsgFromAGVS.ReadOnly = true;
            dgvMsgFromAGVS.RowHeadersVisible = false;
            dgvMsgFromAGVS.RowTemplate.Height = 25;
            dgvMsgFromAGVS.Size = new Size(359, 170);
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
            dgvActiveMsgToMCS.Size = new Size(359, 169);
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
            dgvActiveMsgToAGVS.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dgvActiveMsgToAGVS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveMsgToAGVS.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, secondaryMessageSMLDataGridViewTextBoxColumn1 });
            dgvActiveMsgToAGVS.DataSource = primaryMessageWrapperBindingSource2;
            dgvActiveMsgToAGVS.Dock = DockStyle.Fill;
            dgvActiveMsgToAGVS.GridColor = Color.DarkCyan;
            dgvActiveMsgToAGVS.Location = new Point(370, 216);
            dgvActiveMsgToAGVS.Name = "dgvActiveMsgToAGVS";
            dgvActiveMsgToAGVS.ReadOnly = true;
            dgvActiveMsgToAGVS.RowHeadersVisible = false;
            dgvActiveMsgToAGVS.RowTemplate.Height = 25;
            dgvActiveMsgToAGVS.Size = new Size(359, 170);
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
            label2.BackColor = Color.Aquamarine;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Dock = DockStyle.Fill;
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
            label4.BackColor = Color.Wheat;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(1, 195);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(365, 17);
            label4.TabIndex = 12;
            label4.Text = "From AGVS";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Aquamarine;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Dock = DockStyle.Fill;
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
            label5.BackColor = Color.Wheat;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(367, 195);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(365, 17);
            label5.TabIndex = 13;
            label5.Text = "To AGVS";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1165, 402);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "LOG";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(checkBox4, 3, 0);
            tableLayoutPanel1.Controls.Add(checkBox3, 2, 0);
            tableLayoutPanel1.Controls.Add(checkBox2, 1, 0);
            tableLayoutPanel1.Controls.Add(rtbSecsHostLog, 0, 1);
            tableLayoutPanel1.Controls.Add(rtbSecsClientLog, 1, 1);
            tableLayoutPanel1.Controls.Add(rtbCasstteConvertLog, 2, 1);
            tableLayoutPanel1.Controls.Add(richTextBox3, 3, 1);
            tableLayoutPanel1.Controls.Add(checkBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(checkBox5, 0, 2);
            tableLayoutPanel1.Controls.Add(rtbModbusTcpServerLog, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1159, 396);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // checkBox4
            // 
            checkBox4.Appearance = Appearance.Button;
            checkBox4.BackColor = Color.Gray;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Dock = DockStyle.Fill;
            checkBox4.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox4.FlatStyle = FlatStyle.Flat;
            checkBox4.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox4.ForeColor = Color.White;
            checkBox4.Location = new Point(870, 3);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(286, 35);
            checkBox4.TabIndex = 8;
            checkBox4.Text = "---";
            checkBox4.TextAlign = ContentAlignment.MiddleCenter;
            checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            checkBox3.Appearance = Appearance.Button;
            checkBox3.BackColor = Color.Gray;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Dock = DockStyle.Fill;
            checkBox3.FlatAppearance.CheckedBackColor = Color.Green;
            checkBox3.FlatStyle = FlatStyle.Flat;
            checkBox3.Font = new Font("Microsoft JhengHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox3.ForeColor = Color.White;
            checkBox3.Location = new Point(581, 3);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(283, 35);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "---";
            checkBox3.TextAlign = ContentAlignment.MiddleCenter;
            checkBox3.UseVisualStyleBackColor = false;
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
            checkBox2.Location = new Point(292, 3);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(283, 35);
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
            rtbSecsHostLog.Size = new Size(283, 151);
            rtbSecsHostLog.TabIndex = 1;
            rtbSecsHostLog.Text = "";
            // 
            // rtbSecsClientLog
            // 
            rtbSecsClientLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbSecsClientLog.BackColor = SystemColors.InfoText;
            rtbSecsClientLog.ForeColor = Color.White;
            rtbSecsClientLog.Location = new Point(292, 44);
            rtbSecsClientLog.Name = "rtbSecsClientLog";
            rtbSecsClientLog.Size = new Size(283, 151);
            rtbSecsClientLog.TabIndex = 2;
            rtbSecsClientLog.Text = "";
            // 
            // rtbCasstteConvertLog
            // 
            rtbCasstteConvertLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbCasstteConvertLog.BackColor = SystemColors.InfoText;
            rtbCasstteConvertLog.ForeColor = Color.White;
            rtbCasstteConvertLog.Location = new Point(581, 44);
            rtbCasstteConvertLog.Name = "rtbCasstteConvertLog";
            rtbCasstteConvertLog.Size = new Size(283, 151);
            rtbCasstteConvertLog.TabIndex = 3;
            rtbCasstteConvertLog.Text = "";
            // 
            // richTextBox3
            // 
            richTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox3.BackColor = SystemColors.InfoText;
            richTextBox3.ForeColor = Color.White;
            richTextBox3.Location = new Point(870, 44);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(286, 151);
            richTextBox3.TabIndex = 4;
            richTextBox3.Text = "";
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
            checkBox1.Size = new Size(283, 35);
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
            checkBox5.Location = new Point(3, 201);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(283, 35);
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
            rtbModbusTcpServerLog.Location = new Point(3, 242);
            rtbModbusTcpServerLog.Name = "rtbModbusTcpServerLog";
            rtbModbusTcpServerLog.Size = new Size(283, 151);
            rtbModbusTcpServerLog.TabIndex = 7;
            rtbModbusTcpServerLog.Text = "";
            // 
            // GPMRDMenuStrip
            // 
            GPMRDMenuStrip.BackColor = SystemColors.ActiveCaptionText;
            GPMRDMenuStrip.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GPMRDMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            GPMRDMenuStrip.Location = new Point(0, 0);
            GPMRDMenuStrip.Name = "GPMRDMenuStrip";
            GPMRDMenuStrip.Padding = new Padding(6, 2, 0, 6);
            GPMRDMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            GPMRDMenuStrip.Size = new Size(1306, 32);
            GPMRDMenuStrip.TabIndex = 3;
            GPMRDMenuStrip.Text = "menuStrip1";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownItems.AddRange(new ToolStripItem[] { mCS模擬器ToolStripMenuItem, 轉換架模擬器ToolStripMenuItem, AGVS_modbus_sim_ToolStripMenuItem, aGVS派車模擬器ToolStripMenuItem });
            toolStripComboBox1.ForeColor = Color.White;
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.ShowShortcutKeys = false;
            toolStripComboBox1.Size = new Size(69, 24);
            toolStripComboBox1.Text = "模擬器";
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
            // 
            // aGVS派車模擬器ToolStripMenuItem
            // 
            aGVS派車模擬器ToolStripMenuItem.Name = "aGVS派車模擬器ToolStripMenuItem";
            aGVS派車模擬器ToolStripMenuItem.Size = new Size(239, 24);
            aGVS派車模擬器ToolStripMenuItem.Text = "AGVS 派車模擬器";
            aGVS派車模擬器ToolStripMenuItem.Click += aGVS派車模擬器ToolStripMenuItem_Click;
            // 
            // pnlSideLeft
            // 
            pnlSideLeft.BackColor = Color.Transparent;
            pnlSideLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlSideLeft.Controls.Add(btnOpenLoginFOrm);
            pnlSideLeft.Controls.Add(label6);
            pnlSideLeft.Controls.Add(uscConnectionStates1);
            pnlSideLeft.Controls.Add(label1);
            pnlSideLeft.Dock = DockStyle.Left;
            pnlSideLeft.ForeColor = Color.White;
            pnlSideLeft.Location = new Point(0, 32);
            pnlSideLeft.Name = "pnlSideLeft";
            pnlSideLeft.Size = new Size(133, 577);
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
            uscConnectionStates1.Location = new Point(0, 428);
            uscConnectionStates1.MaximumSize = new Size(134, 96);
            uscConnectionStates1.MinimumSize = new Size(134, 96);
            uscConnectionStates1.Name = "uscConnectionStates1";
            uscConnectionStates1.Padding = new Padding(1);
            uscConnectionStates1.Size = new Size(134, 96);
            uscConnectionStates1.TabIndex = 5;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Dock = DockStyle.Bottom;
            label1.Font = new Font("Microsoft JhengHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(0, 524);
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
            panel1.Controls.Add(rtbSystemLogShow);
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(133, 462);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(1);
            panel1.Size = new Size(1173, 147);
            panel1.TabIndex = 6;
            // 
            // rtbSystemLogShow
            // 
            rtbSystemLogShow.BackColor = Color.Black;
            rtbSystemLogShow.BorderStyle = BorderStyle.FixedSingle;
            rtbSystemLogShow.Dock = DockStyle.Fill;
            rtbSystemLogShow.ForeColor = Color.White;
            rtbSystemLogShow.Location = new Point(1, 1);
            rtbSystemLogShow.Name = "rtbSystemLogShow";
            rtbSystemLogShow.Size = new Size(1169, 143);
            rtbSystemLogShow.TabIndex = 0;
            rtbSystemLogShow.Text = "";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.Transparent;
            statusStrip1.Items.AddRange(new ToolStripItem[] { labSysTime });
            statusStrip1.Location = new Point(0, 609);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.Professional;
            statusStrip1.Size = new Size(1306, 22);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // labSysTime
            // 
            labSysTime.ForeColor = Color.Coral;
            labSysTime.Name = "labSysTime";
            labSysTime.Size = new Size(124, 17);
            labSysTime.Text = "1991/10/20 10:00:00";
            // 
            // SysTimer
            // 
            SysTimer.Enabled = true;
            SysTimer.Interval = 1000;
            SysTimer.Tick += SysTimer_Tick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(51, 51, 51);
            ClientSize = new Size(1306, 631);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Controls.Add(pnlSideLeft);
            Controls.Add(statusStrip1);
            Controls.Add(GPMRDMenuStrip);
            MainMenuStrip = GPMRDMenuStrip;
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GPM AGVS CIM_V1.0.0";
            WindowState = FormWindowState.Maximized;
            FormClosing += Form1_FormClosing;
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private BindingSource primaryMessageWrapperBindingSource;
        private MenuStrip GPMRDMenuStrip;
        private ToolStripMenuItem toolStripComboBox1;
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
        private RichTextBox rtbCasstteConvertLog;
        private RichTextBox richTextBox3;
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
        private ToolStripMenuItem aGVS派車模擬器ToolStripMenuItem;
        private TableLayoutPanel tlpConverterContainer;
        private Panel panel2;
        private UI_UserControls.UscConnectionStates uscConnectionStates1;
        private Label label6;
        private Button btnOpenLoginFOrm;
    }
}