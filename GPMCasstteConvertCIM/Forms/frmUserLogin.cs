using GPMCasstteConvertCIM.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void txbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40 | e.KeyValue == 13)
            {
                //方向鑑下
                txbPassword.Focus();
            }
        }

        private void txbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 38)
            {
                //方向鑑up
                txbAccount.Focus();
            }
            if (e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txbAccount_Enter(object sender, EventArgs e)
        {
            AcceptButton = null;
            this.KeyDown -= frmUserLogin_KeyDown;
        }

        private void txbAccount_Leave(object sender, EventArgs e)
        {
        }

        private async void txbPassword_Enter(object sender, EventArgs e)
        {
            this.KeyDown += frmUserLogin_KeyDown;
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
