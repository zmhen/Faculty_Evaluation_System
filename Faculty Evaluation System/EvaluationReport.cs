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
    public partial class EvaluationReport : Form
    {
        public EvaluationReport()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string[] column = { "total_evaluation_score", "total_evaluation_item" };
            string[] data = { lblScore.Text, lbltotal.Text, InfoStorage.infoset.token };
            ConnectAPI.updateData("Score", column, data, InfoStorage.infoset.faculty_id);
           
            MessageBox.Show("Saved!");
        }

        private void EvaluationReport_Load(object sender, EventArgs e)
        {
            lblScore.Text = (InfoStorage.infoset.scale1 + InfoStorage.infoset.scale2 + InfoStorage.infoset.scale3 + InfoStorage.infoset.scale4 + InfoStorage.infoset.scale5).ToString();
        }
    }
}
