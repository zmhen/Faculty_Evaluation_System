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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] column = { "first_name", "last_name", "birth_date", "username", "password", "account_role" };
            string[] data = { tbxFirstname.Text, tbxLastname.Text, dtpBirthdate.Value.ToString("yyyy-MM-dd"), tbxUsername.Text, tbxPassword.Text, cbxRole.Text, InfoStorage.infoset.token };
            ConnectAPI.createAccount( column, data);
            MessageBox.Show("SAVED!!!");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
