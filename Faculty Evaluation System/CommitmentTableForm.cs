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
    public partial class CommitmentTableForm : Form
    {
        public CommitmentTableForm()
        {
            InitializeComponent();
        }

        private void CommitmentTableForm_Load(object sender, EventArgs e)
        {
            ConnectAPI.dgvViewing("Commitment", dgvCommitment);

            AddRadioButtonsToDataGridView();
            dgvCommitment.Columns[0].Width = 600;
        }
        private void AddRadioButtonsToDataGridView()
        {
            for (int i = 1; i <= 5; i++)
            {
                DataGridViewRadioButtonColumn radioButtonColumn = new DataGridViewRadioButtonColumn();
                radioButtonColumn.HeaderText = $"{i}";
                radioButtonColumn.Name = $"scale {i}";
                radioButtonColumn.Width = 50;
                dgvCommitment.Columns.Add(radioButtonColumn);
            }
        }

        private void dgvCommitment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1) return; // Ignore clicks on non-radio button columns

            var dataGridView = (DataGridView)sender;
            var radioButtonCell = dataGridView[e.ColumnIndex, e.RowIndex] as DataGridViewRadioButtonCell;

            if (radioButtonCell != null)
            {
                // Clear the previous selection in the same row
                for (int i = 1; i < dataGridView.ColumnCount; i++) // start at column 2 to skip non-radio button columns
                {
                    if (i != e.ColumnIndex)
                    {
                        dataGridView[i, e.RowIndex].Value = false;
                    }
                }

                // Set the clicked cell's value to true
                radioButtonCell.Value = true;

                // Update the display of the grid
                dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);


            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            KnowledgeOfSubjectForm form = new KnowledgeOfSubjectForm();
            form.Show();
            this.Hide();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;
            foreach (DataGridViewRow row in dgvCommitment.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    total1 += Convert.ToInt32(row.Cells[1].Value);
                }
            }
            foreach (DataGridViewRow row in dgvCommitment.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    total2 +=( 2*Convert.ToInt32(row.Cells[2].Value));
                }
            }
            foreach (DataGridViewRow row in dgvCommitment.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    total3 += 3*Convert.ToInt32(row.Cells[3].Value);
                }
            }
            foreach (DataGridViewRow row in dgvCommitment.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total4 += 4*Convert.ToInt32(row.Cells[4].Value);
                }
            }
            foreach (DataGridViewRow row in dgvCommitment.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    total5 += 5*Convert.ToInt32(row.Cells[5].Value);
                }
            }
            lblResult1.Text = " " + total1.ToString();
            lblResult2.Text = " " + total2.ToString();
            lblResult3.Text = " " + total3.ToString();
            lblResult4.Text = " " + total4.ToString();
            lblResult5.Text = " " + total5.ToString();
            InfoStorage.infoset.scale1 = total1;
            InfoStorage.infoset.scale2 = total2;
            InfoStorage.infoset.scale3 = total3;
            InfoStorage.infoset.scale4 = total4;
            InfoStorage.infoset.scale5 = total5;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
