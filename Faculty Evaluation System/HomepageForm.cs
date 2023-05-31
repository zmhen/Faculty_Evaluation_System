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
    public partial class HomepageForm : Form
    {
        public HomepageForm()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HomepagePanel home = new HomepagePanel();
            home.TopLevel = false;
            pnlContent.Controls.Add(home);
            home.BringToFront();
            home.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm p = new ProfileForm();
            p.TopLevel = false;
            pnlContent.Controls.Add(p);
            p.BringToFront();
            p.Show();
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
            EvaluateForm eval = new EvaluateForm();
            eval.TopLevel = false;
            pnlContent.Controls.Add(eval);
            eval.BringToFront();
            eval.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm form = new LoginForm();
            form.Show();
            this.Hide();
        }

        private void HomepageForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = InfoStorage.infoset.first_name;
            
        }

        private void menuButton_Click(object sender, EventArgs e)
        {

        }
    }
}
