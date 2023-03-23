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
using static GPMCasstteConvertCIM.Utilities.StaUsersManager;

namespace GPMCasstteConvertCIM.Forms
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txbAccount.Text;
            string pw = txbPassword.Text;

            if (name == "")
            {
                MessageBox.Show("請輸入帳號!");
                return;
            }

            if (pw == "")
            {
                MessageBox.Show("請輸入密碼");
                return;
            }

            bool success = StaUsersManager.TryLogin(name, pw, out User user);
            if (!success)
            {
                MessageBox.Show("登入失敗!\r\n錯誤的帳號或密碼。", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("登入成功!", "Login Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
