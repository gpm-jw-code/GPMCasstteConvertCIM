namespace GPMCasstteConvertCIM.Forms
{
    partial class frmUnHandleExceptionViewer
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
            dgvExceptions = new DataGridView();
            timeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            errorMessageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            classNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lineNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCheckedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            clsExceptionDtoBindingSource = new BindingSource(components);
            panel1 = new Panel();
            btnSetAllChecked = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvExceptions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clsExceptionDtoBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvExceptions
            // 
            dgvExceptions.AllowUserToAddRows = false;
            dgvExceptions.AllowUserToDeleteRows = false;
            dgvExceptions.AllowUserToOrderColumns = true;
            dgvExceptions.AutoGenerateColumns = false;
            dgvExceptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExceptions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvExceptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExceptions.Columns.AddRange(new DataGridViewColumn[] { timeDataGridViewTextBoxColumn, errorMessageDataGridViewTextBoxColumn, classNameDataGridViewTextBoxColumn, lineNumberDataGridViewTextBoxColumn, isCheckedDataGridViewCheckBoxColumn });
            dgvExceptions.DataSource = clsExceptionDtoBindingSource;
            dgvExceptions.Dock = DockStyle.Fill;
            dgvExceptions.Location = new Point(0, 49);
            dgvExceptions.Name = "dgvExceptions";
            dgvExceptions.RowHeadersVisible = false;
            dgvExceptions.RowTemplate.Height = 25;
            dgvExceptions.ShowCellErrors = false;
            dgvExceptions.ShowRowErrors = false;
            dgvExceptions.Size = new Size(856, 514);
            dgvExceptions.TabIndex = 2;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            timeDataGridViewTextBoxColumn.HeaderText = "Time";
            timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            errorMessageDataGridViewTextBoxColumn.DataPropertyName = "ErrorMessage";
            errorMessageDataGridViewTextBoxColumn.HeaderText = "ErrorMessage";
            errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            // 
            // classNameDataGridViewTextBoxColumn
            // 
            classNameDataGridViewTextBoxColumn.DataPropertyName = "ClassName";
            classNameDataGridViewTextBoxColumn.HeaderText = "ClassName";
            classNameDataGridViewTextBoxColumn.Name = "classNameDataGridViewTextBoxColumn";
            // 
            // lineNumberDataGridViewTextBoxColumn
            // 
            lineNumberDataGridViewTextBoxColumn.DataPropertyName = "LineNumber";
            lineNumberDataGridViewTextBoxColumn.HeaderText = "LineNumber";
            lineNumberDataGridViewTextBoxColumn.Name = "lineNumberDataGridViewTextBoxColumn";
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            isCheckedDataGridViewCheckBoxColumn.HeaderText = "IsChecked";
            isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            // 
            // clsExceptionDtoBindingSource
            // 
            clsExceptionDtoBindingSource.DataSource = typeof(Alarm.clsExceptionDto);
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSetAllChecked);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(3);
            panel1.Size = new Size(856, 49);
            panel1.TabIndex = 9;
            // 
            // btnSetAllChecked
            // 
            btnSetAllChecked.Dock = DockStyle.Right;
            btnSetAllChecked.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSetAllChecked.Location = new Point(702, 3);
            btnSetAllChecked.Name = "btnSetAllChecked";
            btnSetAllChecked.Size = new Size(151, 43);
            btnSetAllChecked.TabIndex = 14;
            btnSetAllChecked.Text = "全部設為已確認";
            btnSetAllChecked.UseVisualStyleBackColor = true;
            btnSetAllChecked.Click += btnSetAllChecked_Click;
            // 
            // frmUnHandleExceptionViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 563);
            Controls.Add(dgvExceptions);
            Controls.Add(panel1);
            Name = "frmUnHandleExceptionViewer";
            Text = "未捕捉例外清單";
            Load += frmUnHandleExceptionViewer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExceptions).EndInit();
            ((System.ComponentModel.ISupportInitialize)clsExceptionDtoBindingSource).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvExceptions;
        private BindingSource clsExceptionDtoBindingSource;
        private DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn classNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lineNumberDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private Panel panel1;
        private Button btnSetAllChecked;
    }
}