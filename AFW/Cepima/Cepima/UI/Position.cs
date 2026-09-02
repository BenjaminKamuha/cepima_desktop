using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cepima.UI
{
    class Position
    {
        public static void CenterControl(Control control, Control panel, int y)
        {
            control.Left = (panel.ClientSize.Width - control.Width) / 2;
            control.Top = y;
        }
    }
}
