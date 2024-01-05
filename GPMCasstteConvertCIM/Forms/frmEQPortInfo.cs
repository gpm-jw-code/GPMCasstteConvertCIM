using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmEQPortInfo : Form
    {
        private clsConverterPort portEntity => dataBinding.DataSource as clsConverterPort;

        public frmEQPortInfo(clsConverterPort portData)
        {
            InitializeComponent();
            dataBinding.DataSource = portData;
            numagvhsPORT.Value = portData.Properties.AGVHandshakeModbus_PORT;

            ckbActiveHSModbusSlave.CheckedChanged -= CkbActiveHSModbusSlave_CheckedChanged;

            ckbActiveHSModbusSlave.Checked = portData.Properties.AGVHandshakeModbusGatewayActive;

            ckbActiveHSModbusSlave.CheckedChanged += CkbActiveHSModbusSlave_CheckedChanged;
        }

        private void btnModifyModbusHost_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Enabled = numericUpDown1.Enabled = checkBox1.Checked;
            checkBox1.Text = checkBox1.Checked ? "儲存" : "修改";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //修改
            }
            else
            {

                if (StaUsersManager.CurrentUser.Group == StaUsersManager.USER_GROUP.VISITOR)
                {
                    MessageBox.Show($"您沒有修改的權限!請洽GPM。", "Modbus TCP Setting Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var port = DevicesManager.GetAllPorts().FirstOrDefault(p => p.PortName == portEntity.PortName && p.EqName == portEntity.EqName);


                string newHost = $"{textBox1.Text}:{(int)numericUpDown1.Value}";

                if (port.ModbusHost == newHost)
                    return;

                if (DevicesManager.GetAllPorts().Select(p => p.ModbusHost).Contains(newHost))
                {
                    MessageBox.Show($"位址 {newHost} 已經被使用。", "Modbus TCP Setting Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    checkBox1.Checked = true;
                    return;
                }

                //儲存
                if (portEntity.BuildModbusTCPServer(textBox1.Text, (int)numericUpDown1.Value, out string msg))
                {
                    var eqOption = DevicesManager.DevicesConnectionsOpts.PLCEQS.FirstOrDefault(p => p.Ports.Values.FirstOrDefault() != null);
                    eqOption.Ports.First(p => p.Value.PortID == port.PortName).Value.ModbusServer_IP = port.Properties.ModbusServer_IP;
                    eqOption.Ports.First(p => p.Value.PortID == port.PortName).Value.ModbusServer_PORT = port.Properties.ModbusServer_PORT;
                    DevicesManager.SaveDeviceConnectionOpts();
                    MessageBox.Show("修改成功!", "Modbus TCP Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"修改失敗...{msg}", "Modbus TCP Setting FAIL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmEQPortInfo_Load(object sender, EventArgs e)
        {

        }
        private bool testBol = false;
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            testBol = !testBol;
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(portEntity.PortEQBitAddress[Enums.PROPERTY.EQ_READY], testBol);
            DevicesManager.cclink_master.EQPMemOptions.memoryTable.WriteOneBit(portEntity.PortEQBitAddress[Enums.PROPERTY.U_REQ], testBol);

        }

        private void CkbActiveHSModbusSlave_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbActiveHSModbusSlave.Checked)
            {
                bool success = portEntity.ActiveAGVHSModbusGateway(out string errorMsg);
                if (success)
                {
                    MessageBox.Show($"AGV 交握 MODBUS SERVER 啟用成功!(:{portEntity.Properties.AGVHandshakeModbus_PORT})", "啟用成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"AGV 交握 MODBUS SERVER 啟用失敗..(:{portEntity.Properties.AGVHandshakeModbus_PORT})\n{errorMsg}", "啟用失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                portEntity.DisableAGVHSModbusGateway();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            numagvhsPORT.Enabled = checkBox2.Checked;
        }

        private void NumagvhsPORT_ValueChanged(object sender, EventArgs e)
        {
            portEntity.Properties.AGVHandshakeModbus_PORT = (int)numagvhsPORT.Value;
            DevicesManager.SaveDeviceConnectionOpts();

            if (portEntity.Properties.AGVHandshakeModbusGatewayActive)
            {
                portEntity.DisableAGVHSModbusGateway();
                
                if(!portEntity.ActiveAGVHSModbusGateway(out var errmsg))
                {
                    MessageBox.Show($"AGV 交握 MODBUS SERVER 啟用失敗..(:{portEntity.Properties.AGVHandshakeModbus_PORT})\n{errmsg}", "啟用失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }
    }
}
