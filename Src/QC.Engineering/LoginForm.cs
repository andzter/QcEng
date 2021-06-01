using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QC.Engineering
{
    public partial class LoginForm : Telerik.WinControls.UI.ShapedForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bLog_Click(object sender, EventArgs e)
        {
            //this.Close();
            Form main = new QC.Engineering.Main();

            var id = (new Repository.Users()).LoginUser(txtUser.Text, txtPassword.Text);

            try
            {

                if (string.IsNullOrEmpty(id))
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "Invalid Username or password!\nPlease try again.";
                }
                else
                {
                    main.Show();
                    Lib.Settings.SetSetting("username", txtUser.Text);
                    Lib.Settings.SetSetting("userid", id);
                    this.Hide();
                }
            }
            catch
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Error encountered!\nPlease contact your administator.";
            }
        }
         

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
            {
                bLog_Click(sender, e);
            }
        }
    }
}
