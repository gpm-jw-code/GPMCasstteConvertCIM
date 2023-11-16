using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.UI_UserControls
{
    public partial class UscMemoryTable : UserControl
    {
        private bool _Editable = true;
        public bool Editable
        {
            get => _Editable;
            set
            {
                dgvEQPBitMap.Columns["valueTogglebtn"].Visible = _Editable = value;
            }
        }
        private BindingList<clsMemoryAddress> eqp_bitMemoryAddressList = new BindingList<clsMemoryAddress>();
        private BindingList<clsMemoryAddress> eqp_wordMemoryAddressList = new BindingList<clsMemoryAddress>();

        private BindingList<clsMemoryAddress> cim_bitMemoryAddressList = new BindingList<clsMemoryAddress>();
        private BindingList<clsMemoryAddress> cim_wordMemoryAddressList = new BindingList<clsMemoryAddress>();

        internal event EventHandler<(string bitAddress, bool state)> EQPBitValueOnChanged;
        internal event EventHandler<(string bitAddress, bool state)> CIMBitValueOnChanged;
        internal event EventHandler<clsMemoryAddress> EQPWordValueOnChanged;
        internal event EventHandler<clsMemoryAddress> CIMWordValueOnChanged;

        private int BitMapToggleBtnColIndex = 6;
        private int WordMapValueColIndex = 5;
        private string _SpecficEqName = "STK";
        public string SpecficEqName
        {
            get => _SpecficEqName;
            set
            {
                dgvEQPBitMap.SuspendLayout();
                dgvCIMBitMap.SuspendLayout();
                dgvEQPWordMap.SuspendLayout();
                dgvCIMWordMap.SuspendLayout();
                if (value.ToUpper() != "ALL")
                {
                    dgvEQPBitMap.DataSource = new BindingList<clsMemoryAddress>(eqp_bitMemoryAddressList.Where(eq => eq.EQ_Name.ToString() == value).ToList());
                    dgvCIMBitMap.DataSource = new BindingList<clsMemoryAddress>(cim_bitMemoryAddressList.Where(eq => eq.EQ_Name.ToString() == value).ToList());

                    dgvEQPWordMap.DataSource = new BindingList<clsMemoryAddress>(eqp_wordMemoryAddressList.Where(q => q.EQ_Name.ToString() == value).ToList());
                    dgvCIMWordMap.DataSource = new BindingList<clsMemoryAddress>(cim_wordMemoryAddressList.Where(q => q.EQ_Name.ToString() == value).ToList()); ;
                }
                else
                {
                    dgvEQPBitMap.DataSource = eqp_bitMemoryAddressList;
                    dgvCIMBitMap.DataSource = cim_bitMemoryAddressList;

                    dgvEQPWordMap.DataSource = eqp_wordMemoryAddressList;
                    dgvCIMWordMap.DataSource = cim_wordMemoryAddressList;
                }

                dgvEQPBitMap.ResumeLayout();
                dgvCIMBitMap.ResumeLayout();
                dgvEQPWordMap.ResumeLayout();
                dgvCIMWordMap.ResumeLayout();
                _SpecficEqName = value;
            }
        }

        public UscMemoryTable()
        {
            InitializeComponent();

            dgvEQPBitMap.CellFormatting += DgvEQPBitMap_CellFormatting;
            dgvCIMBitMap.CellFormatting += DgvEQPBitMap_CellFormatting;

        }

        private void DgvEQPBitMap_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                clsMemoryAddress addressDto = dgv.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
                bool active = (bool)addressDto.Value;
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = active ? Color.Lime : Color.FromArgb(51, 51, 51);
                dgv.Rows[e.RowIndex].DefaultCellStyle.ForeColor = active ? Color.Black : Color.White;
            }
        }

        public List<clsMemoryAddress> bitMemoryAddressList
        {
            set
            {
                foreach (clsMemoryAddress item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP))
                {
                    eqp_bitMemoryAddressList.Add(item);
                }

                foreach (clsMemoryAddress item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM))
                {
                    cim_bitMemoryAddressList.Add(item);
                }
                if (SpecficEqName != "ALL")
                {
                    dgvEQPBitMap.DataSource = new BindingList<clsMemoryAddress>(eqp_bitMemoryAddressList.Where(eq => eq.EQ_Name.ToString() == SpecficEqName).ToList());
                    dgvCIMBitMap.DataSource = new BindingList<clsMemoryAddress>(cim_bitMemoryAddressList.Where(eq => eq.EQ_Name.ToString() == SpecficEqName).ToList());
                }
                else
                {
                    dgvEQPBitMap.DataSource = eqp_bitMemoryAddressList;
                    dgvCIMBitMap.DataSource = cim_bitMemoryAddressList;
                }
            }
        }
        public List<clsMemoryAddress> wordMemoryAddressList
        {
            set
            {
                foreach (var item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP))
                    eqp_wordMemoryAddressList.Add(item);
                foreach (var item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM))
                    cim_wordMemoryAddressList.Add(item);


                if (SpecficEqName.ToUpper() != "ALL")
                {
                    dgvEQPWordMap.DataSource = new BindingList<clsMemoryAddress>(eqp_wordMemoryAddressList.Where(q => q.EQ_Name.ToString() == SpecficEqName).ToList());
                    dgvCIMWordMap.DataSource = new BindingList<clsMemoryAddress>(cim_wordMemoryAddressList.Where(q => q.EQ_Name.ToString() == SpecficEqName).ToList()); ;
                }
                else
                {

                    dgvEQPWordMap.DataSource = eqp_wordMemoryAddressList;
                    dgvCIMWordMap.DataSource = cim_wordMemoryAddressList;

                }
            }
        }

        private void dgvBitMap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBitMap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (!Editable | e.ColumnIndex < 0 | e.RowIndex < 0)
            //    return;
            //Invoke(new Action(() =>
            //{
            //    clsMemoryAddress? addressData = dgvEQPBitMap.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
            //    var newValue = !(bool)addressData.Value;
            //    EQPBitValueOnChanged?.Invoke(this, (addressData.Address, newValue));
            //}));
        }

        private void dgvWordMap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvWordMap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvWordMap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvEQPWordMap
            //dgvCIMWordMap

            if (!Editable | e.ColumnIndex != WordMapValueColIndex | e.RowIndex < 0)
                return;

            DataGridView word_dgv = sender as DataGridView;
            bool isEQP = word_dgv.Name == dgvEQPWordMap.Name;
            clsMemoryAddress? addressData = word_dgv.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
            WordValueChangeDialog dialog = new WordValueChangeDialog();
            var newValue = dialog.ShowDialog(addressData.Address, (int)addressData.Value);
            if (dialog.DialogResult == DialogResult.OK)
            {
                clsMemoryAddress addressDataCopy = addressData.Copy();
                addressDataCopy.Value = newValue;
                if (isEQP)
                    EQPWordValueOnChanged?.Invoke(this, addressDataCopy);
                else
                    CIMWordValueOnChanged?.Invoke(this, addressDataCopy);

                Invalidate();
            }
        }

        internal new void Invalidate()
        {
            dgvEQPBitMap.Invalidate();
            dgvEQPWordMap.Invalidate();
            dgvCIMBitMap.Invalidate();
            dgvCIMWordMap.Invalidate();
            base.Invalidate();
        }

        internal void DataTableColorInitSet()
        {
            dgvCIMBitMap.RowColorSet(Extensions.DataGridViewType.PLC);
            dgvEQPBitMap.RowColorSet(Extensions.DataGridViewType.PLC);
        }

        private void dgvEQPBitMap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == BitMapToggleBtnColIndex)
            {
                clsMemoryAddress? addressData = dgvEQPBitMap.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
                bool state = !(bool)addressData.Value;
                EQPBitValueOnChanged?.Invoke(this, (addressData.Address, state));
                dgvEQPBitMap.Invalidate();
            }
        }

        private void dgvCIMBitMap_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == BitMapToggleBtnColIndex)
            {
                clsMemoryAddress? addressData = dgvCIMBitMap.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
                bool state = !(bool)addressData.Value;
                CIMBitValueOnChanged?.Invoke(this, (addressData.Address, state));
                dgvCIMBitMap.Invalidate();
            }
        }
    }
}
