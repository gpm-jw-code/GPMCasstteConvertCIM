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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModbusTCPServer));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            labPort = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            labConnectedClientNum = new Label();
            registerBindingSource = new BindingSource(components);
            digitalIORegisterBindingSource = new BindingSource(components);
            coilRegisterBindingSource = new BindingSource(components);
            toolStrip1 = new ToolStrip();
            toolStripLabel1 = new ToolStripDropDownButton();
            agvsEmuToolStripMenuItem = new ToolStripMenuItem();
            developDropDownBtn = new ToolStripDropDownButton();
            closeServerToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvDITable = new DataGridView();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            State = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dgvHoldingRegisterTable = new DataGridView();
            Address = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            valueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Value_Hex = new DataGridViewTextBoxColumn();
            LinkPLCAddress = new DataGridViewTextBoxColumn();
            dgvDOTable = new DataGridView();
            addressDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)registerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)digitalIORegisterBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)coilRegisterBindingSource).BeginInit();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDITable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoldingRegisterTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDOTable).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(950, 36);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Port";
            label1.Click += label1_Click;
            // 
            // labPort
            // 
            labPort.AutoSize = true;
            labPort.Location = new Point(986, 36);
            labPort.Name = "labPort";
            labPort.Size = new Size(30, 15);
            labPort.TabIndex = 1;
            labPort.Text = "Port";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // labConnectedClientNum
            // 
            labConnectedClientNum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labConnectedClientNum.AutoSize = true;
            labConnectedClientNum.Location = new Point(1214, 6);
            labConnectedClientNum.Name = "labConnectedClientNum";
            labConnectedClientNum.Size = new Size(42, 15);
            labConnectedClientNum.TabIndex = 2;
            labConnectedClientNum.Text = "label2";
            // 
            // registerBindingSource
            // 
            registerBindingSource.DataSource = typeof(GPM_Modbus.HoldingRegister);
            // 
            // digitalIORegisterBindingSource
            // 
            digitalIORegisterBindingSource.DataSource = typeof(GPM_Modbus.DigitalIORegister);
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripLabel1, developDropDownBtn });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1268, 25);
            toolStrip1.TabIndex = 15;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.DropDownItems.AddRange(new ToolStripItem[] { agvsEmuToolStripMenuItem });
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(56, 22);
            toolStripLabel1.Text = "模擬器";
            toolStripLabel1.Visible = false;
            // 
            // agvsEmuToolStripMenuItem
            // 
            agvsEmuToolStripMenuItem.Name = "agvsEmuToolStripMenuItem";
            agvsEmuToolStripMenuItem.Size = new Size(106, 22);
            agvsEmuToolStripMenuItem.Text = "AGVS";
            agvsEmuToolStripMenuItem.Click += agvsEmuToolStripMenuItem_Click;
            // 
            // developDropDownBtn
            // 
            developDropDownBtn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            developDropDownBtn.DropDownItems.AddRange(new ToolStripItem[] { closeServerToolStripMenuItem });
            developDropDownBtn.Image = (Image)resources.GetObject("developDropDownBtn.Image");
            developDropDownBtn.ImageTransparentColor = Color.Magenta;
            developDropDownBtn.Name = "developDropDownBtn";
            developDropDownBtn.Size = new Size(79, 22);
            developDropDownBtn.Text = "Developer";
            developDropDownBtn.Visible = false;
            // 
            // closeServerToolStripMenuItem
            // 
            closeServerToolStripMenuItem.Name = "closeServerToolStripMenuItem";
            closeServerToolStripMenuItem.Size = new Size(143, 22);
            closeServerToolStripMenuItem.Text = "Close Server";
            closeServerToolStripMenuItem.Click += closeServerToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 669);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            statusStrip1.Size = new Size(1268, 22);
            statusStrip1.TabIndex = 17;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(82, 17);
            toolStripStatusLabel1.Text = "127.0.0.1:503";
            toolStripStatusLabel1.Click += toolStripStatusLabel1_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(64, 64, 64);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(groupBox1);
            splitContainer1.Size = new Size(1268, 644);
            splitContainer1.SplitterDistance = 412;
            splitContainer1.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label6, 2, 0);
            tableLayoutPanel1.Controls.Add(label4, 0, 0);
            tableLayoutPanel1.Controls.Add(label5, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvDITable, 1, 1);
            tableLayoutPanel1.Controls.Add(dgvHoldingRegisterTable, 2, 1);
            tableLayoutPanel1.Controls.Add(dgvDOTable, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1268, 412);
            tableLayoutPanel1.TabIndex = 15;
            // 
            // label6
            // 
            label6.BackColor = Color.LightSlateGray;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(848, 1);
            label6.Name = "label6";
            label6.Size = new Size(416, 28);
            label6.TabIndex = 17;
            label6.Text = "Holding Register";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.BackColor = Color.RosyBrown;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(4, 1);
            label4.Name = "label4";
            label4.Size = new Size(415, 28);
            label4.TabIndex = 13;
            label4.Text = "DO(EQPLC)";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.CornflowerBlue;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("微軟正黑體", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(426, 1);
            label5.Name = "label5";
            label5.Size = new Size(415, 28);
            label5.TabIndex = 14;
            label5.Text = "DI(CIM/AGVS)";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvDITable
            // 
            dgvDITable.AllowUserToDeleteRows = false;
            dgvDITable.AllowUserToOrderColumns = true;
            dgvDITable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDITable.AutoGenerateColumns = false;
            dgvDITable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDITable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvDITable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDITable.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn2, descriptionDataGridViewTextBoxColumn, State, dataGridViewTextBoxColumn3 });
            dgvDITable.DataSource = digitalIORegisterBindingSource;
            dgvDITable.Location = new Point(426, 33);
            dgvDITable.Name = "dgvDITable";
            dgvDITable.RowHeadersVisible = false;
            dgvDITable.RowTemplate.Height = 25;
            dgvDITable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDITable.Size = new Size(415, 375);
            dgvDITable.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "AddressHex";
            dataGridViewTextBoxColumn2.HeaderText = "Address";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            descriptionDataGridViewTextBoxColumn.Width = 96;
            // 
            // State
            // 
            State.DataPropertyName = "State";
            State.FlatStyle = FlatStyle.Popup;
            State.HeaderText = "State";
            State.Name = "State";
            State.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewTextBoxColumn3.HeaderText = "LinkPLCAddress";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dgvHoldingRegisterTable
            // 
            dgvHoldingRegisterTable.AllowUserToDeleteRows = false;
            dgvHoldingRegisterTable.AllowUserToOrderColumns = true;
            dgvHoldingRegisterTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoldingRegisterTable.AutoGenerateColumns = false;
            dgvHoldingRegisterTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoldingRegisterTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvHoldingRegisterTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoldingRegisterTable.Columns.AddRange(new DataGridViewColumn[] { Address, dataGridViewTextBoxColumn4, valueDataGridViewTextBoxColumn, Value_Hex, LinkPLCAddress });
            dgvHoldingRegisterTable.DataSource = registerBindingSource;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHoldingRegisterTable.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHoldingRegisterTable.Location = new Point(848, 33);
            dgvHoldingRegisterTable.Name = "dgvHoldingRegisterTable";
            dgvHoldingRegisterTable.RowHeadersVisible = false;
            dgvHoldingRegisterTable.RowTemplate.Height = 25;
            dgvHoldingRegisterTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoldingRegisterTable.Size = new Size(416, 375);
            dgvHoldingRegisterTable.TabIndex = 3;
            // 
            // Address
            // 
            Address.DataPropertyName = "Address_Hex";
            Address.HeaderText = "Address";
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            dataGridViewTextBoxColumn4.HeaderText = "Description";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 96;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            valueDataGridViewTextBoxColumn.HeaderText = "Value(DEC)";
            valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // Value_Hex
            // 
            Value_Hex.DataPropertyName = "Value_Hex";
            Value_Hex.HeaderText = "Value(HEX)";
            Value_Hex.Name = "Value_Hex";
            Value_Hex.ReadOnly = true;
            // 
            // LinkPLCAddress
            // 
            LinkPLCAddress.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            LinkPLCAddress.DefaultCellStyle = dataGridViewCellStyle2;
            LinkPLCAddress.HeaderText = "LinkPLCAddress";
            LinkPLCAddress.Name = "LinkPLCAddress";
            LinkPLCAddress.ReadOnly = true;
            // 
            // dgvDOTable
            // 
            dgvDOTable.AllowUserToDeleteRows = false;
            dgvDOTable.AllowUserToOrderColumns = true;
            dgvDOTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDOTable.AutoGenerateColumns = false;
            dgvDOTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDOTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvDOTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDOTable.Columns.AddRange(new DataGridViewColumn[] { addressDataGridViewTextBoxColumn1, Description, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn1 });
            dgvDOTable.DataSource = digitalIORegisterBindingSource;
            dgvDOTable.Location = new Point(4, 33);
            dgvDOTable.Name = "dgvDOTable";
            dgvDOTable.RowHeadersVisible = false;
            dgvDOTable.RowTemplate.Height = 25;
            dgvDOTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDOTable.Size = new Size(415, 375);
            dgvDOTable.TabIndex = 7;
            // 
            // addressDataGridViewTextBoxColumn1
            // 
            addressDataGridViewTextBoxColumn1.DataPropertyName = "AddressHex";
            addressDataGridViewTextBoxColumn1.FillWeight = 20F;
            addressDataGridViewTextBoxColumn1.HeaderText = "Address";
            addressDataGridViewTextBoxColumn1.Name = "addressDataGridViewTextBoxColumn1";
            addressDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 96;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "State";
            dataGridViewCheckBoxColumn1.FlatStyle = FlatStyle.Popup;
            dataGridViewCheckBoxColumn1.HeaderText = "State";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "LinkPLCAddress";
            dataGridViewCellStyle4.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewTextBoxColumn1.HeaderText = "LinkPLCAddress";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(richTextBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1268, 228);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Black;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(3, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1262, 206);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // frmModbusTCPServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 691);
            Controls.Add(splitContainer1);
            Controls.Add(labConnectedClientNum);
            Controls.Add(toolStrip1);
            Controls.Add(labPort);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            DoubleBuffered = true;
            Name = "frmModbusTCPServer";
            Text = "Modbus TCP Server";
            FormClosing += frmModbusTCPServer_FormClosing;
            Load += frmModbusTCPServer_Load;
            ((System.ComponentModel.ISupportInitialize)registerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)digitalIORegisterBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)coilRegisterBindingSource).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDITable).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHoldingRegisterTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDOTable).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dgvHoldingRegisterTable;
        private DataGridView dgvDOTable;
        private GroupBox groupBox1;
        private RichTextBox richTextBox1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn State;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Value_Hex;
        private DataGridViewTextBoxColumn LinkPLCAddress;
        private DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}