using GPMCasstteConvertCIM.Alarm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmUnHandleExceptionViewer : Form
    {
        public frmUnHandleExceptionViewer()
        {
            InitializeComponent();
        }

        private void frmUnHandleExceptionViewer_Load(object sender, EventArgs e)
        {
            RenderDatatable().ContinueWith(t =>
            {
                dgvExceptions.CellContentClick += DgvExceptions_CellContentClick;
            });
        }

        private async void DgvExceptions_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            // 確保點擊的是CheckBox列
            if (dgvExceptions.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex >= 0)
            {
                dgvExceptions.CommitEdit(DataGridViewDataErrorContexts.Commit);

                bool isChecked = (bool)dgvExceptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    var key = (DateTime)dgvExceptions.Rows[e.RowIndex].Cells[0].Value;
                    await DBhelper.ChangeExecptionCheckStateAsync(key, true);
                    var exceptionCount =  await RenderDatatable();

                    if (exceptionCount ==0) {
                        AlarmManager.ClearAlldExceptionRecored();
                    }
                }
            }
        }

        private async Task<int> RenderDatatable()
        {
            var exceptions = await LoadExceptionsFromDatabase();
            exceptions = exceptions.Where(ex => !ex.IsChecked).ToList();
            dgvExceptions.DataSource = exceptions;
            return exceptions.Count;
        }

        private async Task<List<clsExceptionDto>> LoadExceptionsFromDatabase()
        {
            return await DBhelper.GetExceptionsAsync();
        }
        private async void btnSetAllChecked_Click(object sender, EventArgs e)
        {
            AlarmManager.ClearAlldExceptionRecored();
            await RenderDatatable();
        }
    }
}
