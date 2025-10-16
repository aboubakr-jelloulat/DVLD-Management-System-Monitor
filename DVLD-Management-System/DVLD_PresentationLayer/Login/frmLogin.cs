using DVLD_Business;
using DVLD_PresentationLayer.Dashboard;
using DVLD_PresentationLayer.Global;
using DVLD_PresentationLayer.Notifications;
using System;

using System.Windows.Forms;

namespace DVLD_PresentationLayer.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }



        private void _ShowDashboardForm()
        {
            frmDashboard frm = new frmDashboard();

            frm.ShowDialog();

        }

        private void btnSubmet_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUsernameAndPassword(txtboxLoginUsername.Text.Trim(),
                    txtboxLoginPassword.Text.Trim());

            if (user != null)
            {

                if (chckRememberMe.Checked)
                {
                    //store username and password

                    clsGlobal.RememberUsernameAndPassword(txtboxLoginUsername.Text.Trim(),
                    txtboxLoginPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password

                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if (!user.IsActive)
                {
                    txtboxLoginUsername.Focus();
                    clsMessageBoxHelper.ShowError("In Active Account", "Your accound is not Active, Contact Admin.");
                    return ;
                }

                clsGlobal.CurrentUser = user;

                _ShowDashboardForm();

            }
            else
            {
                txtboxLoginUsername.Focus();
                clsMessageBoxHelper.ShowError("Login Failed", "Invalid username or password.");

            }

        }
    }
}

