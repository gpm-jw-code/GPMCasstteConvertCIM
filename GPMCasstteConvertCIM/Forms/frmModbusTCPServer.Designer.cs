namespace GPMCasstteConvertCIM.Forms
{
    partial class frmModbusTCPServer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModbusTCPServer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labConnectedClientNum = new System.Windows.Forms.Label();
            this.registerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.digitalIORegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coilRegisterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.agvsEmuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developDropDownBtn = new System.Windows.Forms.ToolStripDropDownButton();
            this.closeServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDITable = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHoldingRegisterTable = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value_Hex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkPLCAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDOTable = new System.Windows.Forms.DataGridView();
            this.addressDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalIORegisterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coilRegisterBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDITable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoldingRegisterTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDOTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(950, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(986, 36);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(30, 15);
            this.labPort.TabIndex = 1;
            this.labPort.Text = "Port";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labConnectedClientNum
            // 
            this.labConnectedClientNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labConnectedClientNum.AutoSize = true;
            this.labConnectedClientNum.Location = new System.Drawing.Point(1215, 6);
            this.labConnectedClientNum.Name = "labConnectedClientNum";
            this.labConnectedClientNum.Size = new System.Drawing.Size(42, 15);
            this.labConnectedClientNum.TabIndex = 2;
            this.labConnectedClientNum.Text = "label2";
            // 
            // registerBindingSource
            // 
            this.registerBindingSource.DataSource = typeof(GPMCasstteConvertCIM.GPM_Modbus.HoldingRegister);
            // 
            // digitalIORegisterBindingSource
            // 
            this.digitalIORegisterBindingSource.DataSource = typeof(GPMCasstteConvertCIM.GPM_Modbus.DigitalIORegister);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.developDropDownBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1269, 25);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agvsEmuToolStripMenuItem});
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "模擬器";
            this.toolStripLabel1.Visible = false;
            // 
            // agvsEmuToolStripMenuItem
            // 
            this.agvsEmuToolStripMenuItem.Name = "agvsEmuToolStripMenuItem";
            this.agvsEmuToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.agvsEmuToolStripMenuItem.Text = "AGVS";
            this.agvsEmuToolStripMenuItem.Click += new System.EventHandler(this.agvsEmuToolStripMenuItem_Click);
            // 
            // developDropDownBtn
            // 
            this.developDropDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.developDropDownBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeServerToolStripMenuItem});
            this.developDropDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("developDropDownBtn.Image")));
            this.developDropDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.developDropDownBtn.Name = "developDropDownBtn";
            this.developDropDownBtn.Size = new System.Drawing.Size(79, 22);
            this.developDropDownBtn.Text = "Developer";
            this.developDropDownBtn.Visible = false;
            // 
            // closeServerToolStripMenuItem
            // 
            this.closeServerToolStripMenuItem.Name = "closeServerToolStripMenuItem";
            this.closeServerToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.closeServerToolStripMenuItem.Text = "Close Server";
            this.closeServerToolStripMenuItem.Click += new System.EventHandler(this.closeServerToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1269, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "127.0.0.1:503";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1269, 514);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDITable, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvHoldingRegisterTable, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDOTable, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1269, 329);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSlateGray;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(848, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(417, 28);
            this.label6.TabIndex = 17;
            this.label6.Text = "Holding Register";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.RosyBrown;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(415, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "DO(EQPLC)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(426, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(415, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "DI(CIM/AGVS)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDITable
            // 
            this.dgvDITable.AllowUserToDeleteRows = false;
            this.dgvDITable.AllowUserToOrderColumns = true;
            this.dgvDITable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDITable.AutoGenerateColumns = false;
            this.dgvDITable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDITable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDITable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDITable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.descriptionDataGridViewTextBoxColumn,
            this.State,
            this.dataGridViewTextBoxColumn3});
            this.dgvDITable.DataSource = this.digitalIORegisterBindingSource;
            this.dgvDITable.Location = new System.Drawing.Point(426, 33);
            this.dgvDITable.Name = "dgvDITable";
            this.dgvDITable.RowHeadersVisible = false;
            this.dgvDITable.RowTemplate.Height = 25;
            this.dgvDITable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDITable.Size = new System.Drawing.Size(415, 292);
            this.dgvDITable.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn2.HeaderText = "Register";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 96;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "LinkPLCAddress";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dgvHoldingRegisterTable
            // 
            this.dgvHoldingRegisterTable.AllowUserToDeleteRows = false;
            this.dgvHoldingRegisterTable.AllowUserToOrderColumns = true;
            this.dgvHoldingRegisterTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoldingRegisterTable.AutoGenerateColumns = false;
            this.dgvHoldingRegisterTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoldingRegisterTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvHoldingRegisterTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoldingRegisterTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.dataGridViewTextBoxColumn4,
            this.valueDataGridViewTextBoxColumn,
            this.Value_Hex,
            this.LinkPLCAddress});
            this.dgvHoldingRegisterTable.DataSource = this.registerBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoldingRegisterTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoldingRegisterTable.Location = new System.Drawing.Point(848, 33);
            this.dgvHoldingRegisterTable.Name = "dgvHoldingRegisterTable";
            this.dgvHoldingRegisterTable.RowHeadersVisible = false;
            this.dgvHoldingRegisterTable.RowTemplate.Height = 25;
            this.dgvHoldingRegisterTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoldingRegisterTable.Size = new System.Drawing.Size(417, 292);
            this.dgvHoldingRegisterTable.TabIndex = 3;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Register";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 96;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value(DEC)";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // Value_Hex
            // 
            this.Value_Hex.DataPropertyName = "Value_Hex";
            this.Value_Hex.HeaderText = "Value(HEX)";
            this.Value_Hex.Name = "Value_Hex";
            this.Value_Hex.ReadOnly = true;
            // 
            // LinkPLCAddress
            // 
            this.LinkPLCAddress.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LinkPLCAddress.DefaultCellStyle = dataGridViewCellStyle2;
            this.LinkPLCAddress.HeaderText = "LinkPLCAddress";
            this.LinkPLCAddress.Name = "LinkPLCAddress";
            this.LinkPLCAddress.ReadOnly = true;
            // 
            // dgvDOTable
            // 
            this.dgvDOTable.AllowUserToDeleteRows = false;
            this.dgvDOTable.AllowUserToOrderColumns = true;
            this.dgvDOTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDOTable.AutoGenerateColumns = false;
            this.dgvDOTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDOTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDOTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDOTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressDataGridViewTextBoxColumn1,
            this.Description,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1});
            this.dgvDOTable.DataSource = this.digitalIORegisterBindingSource;
            this.dgvDOTable.Location = new System.Drawing.Point(4, 33);
            this.dgvDOTable.Name = "dgvDOTable";
            this.dgvDOTable.RowHeadersVisible = false;
            this.dgvDOTable.RowTemplate.Height = 25;
            this.dgvDOTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDOTable.Size = new System.Drawing.Size(415, 292);
            this.dgvDOTable.TabIndex = 7;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            this.addressDataGridViewTextBoxColumn1.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn1.FillWeight = 20F;
            this.addressDataGridViewTextBoxColumn1.HeaderText = "Register";
            this.addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            this.addressDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 96;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "State";
            this.dataGridViewCheckBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewCheckBoxColumn1.HeaderText = "State";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "LinkPLCAddress";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1269, 181);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(3, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1263, 159);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // frmModbusTCPServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labConnectedClientNum);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Name = "frmModbusTCPServer";
            this.Text = "Modbus TCP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModbusTCPServer_FormClosing);
            this.Load += new System.EventHandler(this.frmModbusTCPServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalIORegisterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coilRegisterBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDITable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoldingRegisterTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDOTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label labPort;
        private System.Windows.Forms.Timer timer1;
        private Label labConnectedClientNum;
        private BindingSource registerBindingSource;
        private BindingSource coilRegisterBindingSource;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton toolStripLabel1;
        private ToolStripMenuItem agvsEmuToolStripMenuItem;
        private BindingSource digitalIORegisterBindingSource;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripDropDownButton developDropDownBtn;
        private ToolStripMenuItem closeServerToolStripMenuItem;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label6;
        private Label label4;
        private Label label5;
        private DataGridView dgvDITable;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn State;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridView dgvHoldingRegisterTable;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Value_Hex;
        private DataGridViewTextBoxColumn LinkPLCAddress;
        private DataGridView dgvDOTable;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
    }
}