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
    public partial class KnowledgeOfSubjectForm : Form
    {
        public KnowledgeOfSubjectForm()
        {
            InitializeComponent();
        }

        private void KnowledgeOfSubjectForm_Load(object sender, EventArgs e)
        {
            
            ConnectAPI.dgvViewing("Knowledge", dgvKnowledge);

            AddRadioButtonsToDataGridView();
            dgvKnowledge.Columns[0].Width = 700;
        }
        private void AddRadioButtonsToDataGridView()
        {
            for (int i = 1; i <= 5; i++)
            {
                DataGridViewRadioButtonColumn radioButtonColumn = new DataGridViewRadioButtonColumn();
                radioButtonColumn.HeaderText = $"{i}";
                radioButtonColumn.Name = $"scale {i}";
                radioButtonColumn.Width = 50;
                dgvKnowledge.Columns.Add(radioButtonColumn);
            }
        }

        private void dgvKnowledge_CellClick(object sender, DataGridViewCellEventArgs e)
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
            TeachingTableForm t = new TeachingTableForm();
            t.Show();
            this.Hide();
        }

        private void dgvKnowledge_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // get the cell content and calculate its height
                string cellText = e.FormattedValue.ToString();
                Size textSize = TextRenderer.MeasureText(cellText, dgvKnowledge.Font);
                int cellHeight = textSize.Height + 8;

                // adjust the row height if necessary
                if (dgvKnowledge.Rows[e.RowIndex].Height < cellHeight)
                {
                    dgvKnowledge.Rows[e.RowIndex].Height = cellHeight;
                    dgvKnowledge.InvalidateRow(e.RowIndex);
                }
            }
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            int total1 = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;
            foreach (DataGridViewRow row in dgvKnowledge.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    total1 += Convert.ToInt32(row.Cells[1].Value);
                }
            }
            foreach (DataGridViewRow row in dgvKnowledge.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    total2 += (2 * Convert.ToInt32(row.Cells[2].Value));
                }
            }
            foreach (DataGridViewRow row in dgvKnowledge.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    total3 += 3 * Convert.ToInt32(row.Cells[3].Value);
                }
            }
            foreach (DataGridViewRow row in dgvKnowledge.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    total4 += 4 * Convert.ToInt32(row.Cells[4].Value);
                }
            }
            foreach (DataGridViewRow row in dgvKnowledge.Rows)
            {
                if (row.Cells[5].Value != null)
                {
                    total5 += 5 * Convert.ToInt32(row.Cells[5].Value);
                }
            }
            lblResult1.Text = " " + total1.ToString();
            lblResult2.Text = " " + total2.ToString();
            lblResult3.Text = " " + total3.ToString();
            lblResult4.Text = " " + total4.ToString();
            lblResult5.Text = " " + total5.ToString();
            InfoStorage.infoset.scale1 = total1 + InfoStorage.infoset.scale1;
            InfoStorage.infoset.scale2 = total2 + InfoStorage.infoset.scale2;
            InfoStorage.infoset.scale3 = total3 + InfoStorage.infoset.scale3;
            InfoStorage.infoset.scale4 = total4 + InfoStorage.infoset.scale4;
            InfoStorage.infoset.scale5 = total5 + InfoStorage.infoset.scale5;

        }

    }
        
}
