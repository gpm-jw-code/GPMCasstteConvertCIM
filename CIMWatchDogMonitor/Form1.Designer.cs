namespace CIMWatchDogMonitor
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aliveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lastDataRecieveTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastInputChangedTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputsStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modbusWatchDogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modbusWatchDogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceNameDataGridViewTextBoxColumn,
            this.ipDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.aliveDataGridViewCheckBoxColumn,
            this.lastDataRecieveTimeDataGridViewTextBoxColumn,
            this.lastInputChangedTimeDataGridViewTextBoxColumn,
            this.inputsStrDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.modbusWatchDogBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 33);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(885, 408);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "deviceName";
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "元件";
            this.deviceNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deviceNameDataGridViewTextBoxColumn.Width = 51;
            // 
            // ipDataGridViewTextBoxColumn
            // 
            this.ipDataGridViewTextBoxColumn.DataPropertyName = "ip";
            this.ipDataGridViewTextBoxColumn.HeaderText = "IP";
            this.ipDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ipDataGridViewTextBoxColumn.Name = "ipDataGridViewTextBoxColumn";
            this.ipDataGridViewTextBoxColumn.ReadOnly = true;
            this.ipDataGridViewTextBoxColumn.Width = 125;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.portDataGridViewTextBoxColumn.DataPropertyName = "port";
            this.portDataGridViewTextBoxColumn.HeaderText = "PORT";
            this.portDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            this.portDataGridViewTextBoxColumn.Width = 59;
            // 
            // aliveDataGridViewCheckBoxColumn
            // 
            this.aliveDataGridViewCheckBoxColumn.DataPropertyName = "alive";
            this.aliveDataGridViewCheckBoxColumn.HeaderText = "存活";
            this.aliveDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.aliveDataGridViewCheckBoxColumn.Name = "aliveDataGridViewCheckBoxColumn";
            this.aliveDataGridViewCheckBoxColumn.ReadOnly = true;
            this.aliveDataGridViewCheckBoxColumn.Width = 50;
            // 
            // lastDataRecieveTimeDataGridViewTextBoxColumn
            // 
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.DataPropertyName = "lastDataRecieveTime";
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.HeaderText = "資料接收時間";
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.Name = "lastDataRecieveTimeDataGridViewTextBoxColumn";
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastDataRecieveTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastInputChangedTimeDataGridViewTextBoxColumn
            // 
            this.lastInputChangedTimeDataGridViewTextBoxColumn.DataPropertyName = "lastInputChangedTime";
            this.lastInputChangedTimeDataGridViewTextBoxColumn.HeaderText = "前次IO變化時間";
            this.lastInputChangedTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lastInputChangedTimeDataGridViewTextBoxColumn.Name = "lastInputChangedTimeDataGridViewTextBoxColumn";
            this.lastInputChangedTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastInputChangedTimeDataGridViewTextBoxColumn.Width = 125;
            // 
            // inputsStrDataGridViewTextBoxColumn
            // 
            this.inputsStrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.inputsStrDataGridViewTextBoxColumn.DataPropertyName = "InputsStr";
            this.inputsStrDataGridViewTextBoxColumn.HeaderText = "CIM 輸出";
            this.inputsStrDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.inputsStrDataGridViewTextBoxColumn.Name = "inputsStrDataGridViewTextBoxColumn";
            this.inputsStrDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // modbusWatchDogBindingSource
            // 
            this.modbusWatchDogBindingSource.DataSource = typeof(CIMWatchDogMonitor.ModbusWatchDogWorker.ModbusWatchDog);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 4);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 24);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(817, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Http 測試";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 446);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "CIM Watch";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modbusWatchDogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.BindingSource modbusWatchDogBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aliveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastDataRecieveTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastInputChangedTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputsStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

