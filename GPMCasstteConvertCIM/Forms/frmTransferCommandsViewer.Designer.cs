namespace GPMCasstteConvertCIM.Forms
{
    partial class frmTransferCommandsViewer
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
            dataGridView1 = new DataGridView();
            transferCommandModelBindingSource = new BindingSource(components);
            timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sourceIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            destinationIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            carrierIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            prorityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transferCommandModelBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextBoxColumn, sourceIDDataGridViewTextBoxColumn, destinationIDDataGridViewTextBoxColumn, carrierIDDataGridViewTextBoxColumn, prorityDataGridViewTextBoxColumn });
            dataGridView1.DataSource = transferCommandModelBindingSource;
            dataGridView1.Location = new Point(6, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(911, 523);
            dataGridView1.TabIndex = 0;
            // 
            // transferCommandModelBindingSource
            // 
            transferCommandModelBindingSource.DataSource = typeof(GPM_SECS.TransferCommandModel);
            // 
            // timeDataGridViewTextBoxColumn
            // 
            timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            timeDataGridViewTextBoxColumn.HeaderText = "時間";
            timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            timeDataGridViewTextBoxColumn.ToolTipText = "時間";
            // 
            // sourceIDDataGridViewTextBoxColumn
            // 
            sourceIDDataGridViewTextBoxColumn.DataPropertyName = "SourceID";
            sourceIDDataGridViewTextBoxColumn.HeaderText = "來源";
            sourceIDDataGridViewTextBoxColumn.Name = "sourceIDDataGridViewTextBoxColumn";
            // 
            // destinationIDDataGridViewTextBoxColumn
            // 
            destinationIDDataGridViewTextBoxColumn.DataPropertyName = "DestinationID";
            destinationIDDataGridViewTextBoxColumn.HeaderText = "目的地";
            destinationIDDataGridViewTextBoxColumn.Name = "destinationIDDataGridViewTextBoxColumn";
            // 
            // carrierIDDataGridViewTextBoxColumn
            // 
            carrierIDDataGridViewTextBoxColumn.DataPropertyName = "CarrierID";
            carrierIDDataGridViewTextBoxColumn.HeaderText = "貨物ID";
            carrierIDDataGridViewTextBoxColumn.Name = "carrierIDDataGridViewTextBoxColumn";
            // 
            // prorityDataGridViewTextBoxColumn
            // 
            prorityDataGridViewTextBoxColumn.DataPropertyName = "Prority";
            prorityDataGridViewTextBoxColumn.HeaderText = "優先權";
            prorityDataGridViewTextBoxColumn.Name = "prorityDataGridViewTextBoxColumn";
            // 
            // frmTransferCommandsViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(923, 535);
            Controls.Add(dataGridView1);
            Name = "frmTransferCommandsViewer";
            Text = "搬運命令列表";
            Load += frmTransferCommandsViewer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)transferCommandModelBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource transferCommandModelBindingSource;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sourceIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn destinationIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn carrierIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prorityDataGridViewTextBoxColumn;
    }
}