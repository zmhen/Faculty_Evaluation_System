using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Evaluation_System
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean verifyAccount = ConnectAPI.AccountVerification(tbxUsername, tbxPassword);
            if (verifyAccount)
            {
                if (InfoStorage.infoset.role == "User")
                {
                    HomepageForm form = new HomepageForm();
                    form.Show();
                    this.Hide();
                }
                if (InfoStorage.infoset.role == "Admin")
                {
                    FacultysForm form = new FacultysForm();
                    form.Show();
                    this.Hide();
                }
               
            }
            else
            {
                MessageBox.Show("Cannot Verify Account!");
            }

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signup = new SignupForm();
            signup.TopLevel = false;
            pnlLogin.Controls.Add(signup);
            signup.BringToFront();
            signup.Show();
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            tbxPassword.PasswordChar = '*';
        }
    }
}

