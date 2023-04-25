using GPMCasstteConvertCIM.CasstteConverter.Data;
using GPMCasstteConvertCIM.Emulators;
using GPMCasstteConvertCIM.GPM_Modbus;
using GPMCasstteConvertCIM.UI_UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.CasstteConverter.Data.clsMemoryAddress;
using static GPMCasstteConvertCIM.UI_UserControls.Extensions;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmModbusTCPServer : Form
    {
        private BindingList<HoldingRegister> holdingRegisterList = new BindingList<HoldingRegister>();
        private BindingList<DigitalIORegister> digitalInputs = new BindingList<DigitalIORegister>();
        private BindingList<DigitalIORegister> digitalOutputs = new BindingList<DigitalIORegister>();

        /// <summary>
        /// AGVS 會用 function code 02 讀 / 用 05 寫
        /// </summary>
        public frmModbusTCPServer()
        {
            InitializeComponent();
            dgvDITable.CellFormatting += DgvTable_CellFormatting;
            dgvDOTable.CellFormatting += DgvTable_CellFormatting;
        }

        private void DgvTable_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DigitalIORegister addressDto = dgv.Rows[e.RowIndex].DataBoundItem as DigitalIORegister;
                bool active = (bool)addressDto.State;
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = active ? Color.Lime : Color.White;
            }
        }

      

        public int Port
        {
            set
            {
                labPort.Text = value.ToString();
            }
        }

        internal ModbusTCPServer _ModbusTCPServer;
        internal ModbusTCPServer ModbusTCPServer
        {
            get => _ModbusTCPServer;
            set
            {
                _ModbusTCPServer = value;
                _ModbusTCPServer.OnTCPDataReceieved += _ModbusTCPServer_OnMessageReceieved;
                _ModbusTCPServer.OnTCPDataSend += _ModbusTCPServer_OnTCPDataSend;
                BindingHoldingRegisterTable();
                BindingCoilRegisterTable();

                Text = $"Modbus TCP Server - {_ModbusTCPServer.linkedCasstteConverter.converterType}";
            }
        }

        private void _ModbusTCPServer_OnTCPDataSend(object? sender, byte[] e)
        {
            WriteLog(string.Format("{0} Server-->Client (FC{1}){2}", DateTime.Now, e[7], string.Join(" ", e.Select(b => b.ToString("X2")))), Color.LightBlue);
        }

        private void _ModbusTCPServer_OnMessageReceieved(object? sender, NetworkConnectionParameter e)
        {
            WriteLog(string.Format("{0} Server<--Client (FC{1}){2}", DateTime.Now, e.bytes[7], string.Join(" ", e.bytes.Select(b => b.ToString("X2")))), Color.Orange);
        }
        private delegate void WriteLogDelagate(string msg, Color foreColor);
        private void WriteLog(string msg, Color foreColor)
        {
            if (!Created)
            {
                return;
            }
            if (InvokeRequired)
            {
                WriteLogDelagate del = new WriteLogDelagate(WriteLog);
                Invoke(del, msg, foreColor);
            }
            else
            {
                richTextBox1.SelectionColor = foreColor;
                richTextBox1.AppendText(msg + "\n");
                richTextBox1.ScrollToCaret();
            }
        }
        private void BindingHoldingRegisterTable()
        {
            List<CasstteConverter.Data.clsMemoryAddress> plc_word_addresses = _ModbusTCPServer.linkedCasstteConverter.LinkWordMap.FindAll(mem => mem.Link_Modbus_Register_Number != -1);

            for (int i = 1; i <= plc_word_addresses.Count; i++)
            {
                try
                {
                    var plcAddress = plc_word_addresses.FirstOrDefault(ad => ad.Link_Modbus_Register_Number == i);
                    holdingRegisterList.Add(new HoldingRegister()
                    {
                        Index = i,
                        Value = _ModbusTCPServer.holdingRegisters.localArray[i],
                        LinkPLCAddress = plcAddress?.Address,
                        Description = plcAddress?.DataName
                    });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            dgvHoldingRegisterTable.DataSource = holdingRegisterList;
        }
        private void BindingCoilRegisterTable()
        {

            List<CasstteConverter.Data.clsMemoryAddress> modbus_linked_addresses = _ModbusTCPServer.linkedCasstteConverter.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.EQP && mem.Link_Modbus_Register_Number != -1);
            List<CasstteConverter.Data.clsMemoryAddress> DI_modbus_linked_addresses = _ModbusTCPServer.linkedCasstteConverter.LinkBitMap.FindAll(mem => mem.EOwner == OWNER.CIM && mem.Link_Modbus_Register_Number != -1);

            for (int i = 1; i <= 255; i++)
            {
                var plc_Address = DI_modbus_linked_addresses.FirstOrDefault(m => m.Link_Modbus_Register_Number == i);
                DigitalIORegister DI = new DigitalIORegister(DigitalIORegister.IO_TYPE.INPUT)
                {
                    Index = i,
                    State = _ModbusTCPServer.discreteInputs.localArray[i],
                    Description = plc_Address?.DataName,
                    LinkPLCAddress = plc_Address?.Address
                };
                digitalInputs.Add(DI);


                plc_Address = modbus_linked_addresses.FirstOrDefault(m => m.Link_Modbus_Register_Number == i);
                var DO = new DigitalIORegister(DigitalIORegister.IO_TYPE.OUTPUT)
                {
                    Index = i,
                    State = _ModbusTCPServer.coils.localArray[i],
                    Description = plc_Address?.DataName,
                    LinkPLCAddress = plc_Address?.Address

                };
                digitalOutputs.Add(DO);
            }
            //var source = new BindingSource()
            //{
            //    DataSource = coilRegisterList
            //};
            dgvDITable.DataSource = digitalInputs;
            dgvDOTable.DataSource = digitalOutputs;
        }

      
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ModbusTCPServer != null)
            {
                labConnectedClientNum.Text = ModbusTCPServer.ConnectedClientNum.ToString();
                for (int i = 1; i <= 255; i++)
                {
                    digitalInputs[i - 1].State = _ModbusTCPServer.coils.localArray[i + 1];
                    digitalOutputs[i - 1].State = _ModbusTCPServer.discreteInputs.localArray[i];
                }

                for (int i = 1; i <= holdingRegisterList.Count; i++)
                {
                    holdingRegisterList[i - 1].Value = _ModbusTCPServer.holdingRegisters.localArray[i];
                }
            }

        }

        private void frmModbusTCPServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }


        private void agvsEmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAGVS_Modbus_Emulator AGVSModbusEmulator = new frmAGVS_Modbus_Emulator();
            AGVSModbusEmulator.Show();
        }

        private void frmModbusTCPServer_Load(object sender, EventArgs e)
        {
            dgvDOTable.RowColorSet(DataGridViewType.MODBUS);
            dgvDITable.RowColorSet(DataGridViewType.MODBUS);
        }

        private void dgvDITable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void closeServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ModbusTCPServer.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            developDropDownBtn.Visible = !developDropDownBtn.Visible;
        }
    }
}
