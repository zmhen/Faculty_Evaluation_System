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
    public partial class EvaluateForm : Form
    {
        public EvaluateForm()
        {
            InitializeComponent();
        }
        private void EvaluateForm_Load(object sender, EventArgs e)
        {
            ConnectAPI.cbxView("Search", "name", "users_id", cbxFaculty);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            InfoStorage.infoset.faculty_id = Convert.ToInt32(cbxFaculty.SelectedValue);
            CommitmentTableForm c = new CommitmentTableForm();
            c.Show();
            this.Hide();
        }
    }
}
