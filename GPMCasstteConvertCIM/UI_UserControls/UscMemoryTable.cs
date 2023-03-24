using GPMCasstteConvertCIM.CasstteConverter.Data;
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
        public bool Editable = true;
        private BindingList<clsMemoryAddress> eqp_bitMemoryAddressList = new BindingList<clsMemoryAddress>();
        private BindingList<clsMemoryAddress> eqp_wordMemoryAddressList = new BindingList<clsMemoryAddress>();

        private BindingList<clsMemoryAddress> cim_bitMemoryAddressList = new BindingList<clsMemoryAddress>();
        private BindingList<clsMemoryAddress> cim_wordMemoryAddressList = new BindingList<clsMemoryAddress>();

        internal event EventHandler<clsMemoryAddress> bitValueOnChanged;
        internal event EventHandler<clsMemoryAddress> wordValueOnChanged;
        public UscMemoryTable()
        {
            InitializeComponent();
        }

        public List<clsMemoryAddress> bitMemoryAddressList
        {
            set
            {
                foreach (clsMemoryAddress item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.EQP))
                {
                    item.PropertyChanged += Item_PropertyChanged;
                    eqp_bitMemoryAddressList.Add(item);
                }

                foreach (clsMemoryAddress item in value.FindAll(v => v.EOwner == clsMemoryAddress.OWNER.CIM))
                {
                    item.PropertyChanged += Item_PropertyChanged;
                    cim_bitMemoryAddressList.Add(item);
                }

                dgvEQPBitMap.DataSource = eqp_bitMemoryAddressList;
                dgvCIMBitMap.DataSource = cim_bitMemoryAddressList;
                //dgvBitMap.DataSource = value;
            }
        }

        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            try
            {
                clsMemoryAddress memState = sender as clsMemoryAddress;
                DataGridView dgv = memState.EOwner == clsMemoryAddress.OWNER.EQP ? dgvEQPBitMap : dgvCIMBitMap;
                var row = dgv.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => (r.DataBoundItem as clsMemoryAddress).Address == memState.Address);
                row.DefaultCellStyle.BackColor = (bool)memState.Value ? Color.Lime : Color.White;
            }
            catch (NullReferenceException ex)
            {

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


                dgvEQPWordMap.DataSource = eqp_wordMemoryAddressList;
                dgvCIMWordMap.DataSource = cim_wordMemoryAddressList;
            }
        }

        private void dgvBitMap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBitMap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Editable | e.ColumnIndex < 0 | e.RowIndex < 0)
                return;

            clsMemoryAddress? addressData = dgvEQPBitMap.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
            addressData.Value = !(bool)addressData.Value;
            bitValueOnChanged?.Invoke(this, addressData);
        }

        private void dgvWordMap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvWordMap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvWordMap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!Editable | e.ColumnIndex != 3 | e.RowIndex < 0)
                return;
            clsMemoryAddress? addressData = dgvEQPWordMap.Rows[e.RowIndex].DataBoundItem as clsMemoryAddress;
            WordValueChangeDialog dialog = new WordValueChangeDialog();
            var newValue = dialog.ShowDialog(addressData.Address, (int)addressData.Value);
            if (dialog.DialogResult == DialogResult.OK)
            {
                addressData.Value = newValue;
                wordValueOnChanged?.Invoke(this, addressData);
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
    }
}
