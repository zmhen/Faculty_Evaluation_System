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
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            tbxFname.Text = InfoStorage.infoset.first_name;
            tbxLname.Text = InfoStorage.infoset.last_name;
            dtpBirthdate.Value = InfoStorage.infoset.birthdate;
            tbxUsername.Text = InfoStorage.infoset.username;
            tbxPassword.Text = InfoStorage.infoset.password;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] column = { "first_name", "last_name","birth_date", "username", "password", "account_role"};
            string[] data = { tbxFname.Text, tbxLname.Text, dtpBirthdate.Value.ToString("yyyy-MM-dd"),tbxUsername.Text, tbxPassword.Text, cbxRole.Text, InfoStorage.infoset.token };
            ConnectAPI.updateData("User Info", column, data, InfoStorage.infoset.faculty_id);

          

            MessageBox.Show("Saved!!!");
        }
    }
}
