using GPMCasstteConvertCIM.CasstteConverter;
using GPMCasstteConvertCIM.Devices;
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

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmEQPortInfo : Form
    {
        private clsConverterPort portEntity => dataBinding.DataSource as clsConverterPort;

        public frmEQPortInfo(clsConverterPort portData)
        {
            InitializeComponent();
            dataBinding.DataSource = portData;
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
    }
}
