using GPMCasstteConvertCIM.Utilities;
using GPMCasstteConvertCIM.Utilities.SysConfigs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GPMCasstteConvertCIM.Utilities.SysConfigs.clsSECSConfigs;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class EncodingSettingDialog : Form
    {
        public EncodingSettingDialog()
        {
            InitializeComponent();
        }

        private void EncodingSettingDialog_Load(object sender, EventArgs e)
        {
            var options = Enum.GetValues(typeof(ENCODING)).Cast<ENCODING>().Select(e => (object)e).ToArray();
            cmbEncodingSelector.Items.AddRange(options);
            cmbEncodingSelector.SelectedItem = Utility.SysConfigs.SECS.ASCIIEncoding;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var settingVal = (ENCODING)cmbEncodingSelector.SelectedItem;
            Utility.SysConfigs.SECS.ASCIIEncoding = settingVal;
            Utility.SaveConfigs();
            Utility.SystemLogger.Info($"User-{StaUsersManager.CurrentUser.Name} Seting Encoding = {settingVal}");
            MessageBox.Show($"設定成功!\r\n當前編碼={Utility.SysConfigs.SECS.SECESAEncoding.EncodingName}", "編碼設定成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }
    }
}
