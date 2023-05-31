using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Faculty_Evaluation_System
{
    public class DataGridViewRadioButtonCell : DataGridViewCheckBoxCell
    {
        public DataGridViewRadioButtonCell()
        {
            ValueType = typeof(bool);
            Value = false;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts & ~DataGridViewPaintParts.ContentForeground);

            if (Application.RenderWithVisualStyles)
            {
                var radioButtonBounds = new Rectangle(cellBounds.X + cellBounds.Width / 2 - 6, cellBounds.Y + cellBounds.Height / 2 - 6, 12, 12);
                RadioButtonState radioButtonState = (bool)formattedValue ? RadioButtonState.CheckedNormal : RadioButtonState.UncheckedNormal;
                RadioButtonRenderer.DrawRadioButton(graphics, radioButtonBounds.Location, radioButtonState);
            }
        }
    }
}
