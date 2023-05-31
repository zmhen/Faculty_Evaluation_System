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
    public partial class FacultysForm : Form
    {
        public FacultysForm()
        {
            InitializeComponent();
        }

        private void FacultysForm_Load(object sender, EventArgs e)
        {
            labelUser.Text = InfoStorage.infoset.first_name;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomepagePanel home = new HomepagePanel();
            home.TopLevel = false;
            pnlContents.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm p = new ProfileForm();
            p.TopLevel = false;
            pnlContents.Controls.Add(p);
            p.BringToFront();
            p.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            DashboardForm form = new DashboardForm();
            form.TopLevel = false;
            pnlContents.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void pnlContents_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
