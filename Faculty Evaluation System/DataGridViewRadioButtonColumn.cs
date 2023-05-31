using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty_Evaluation_System
{
    public class DataGridViewRadioButtonColumn : DataGridViewColumn
    {
        public DataGridViewRadioButtonColumn()
        {
            CellTemplate = new DataGridViewRadioButtonCell();
        }
    }
}
