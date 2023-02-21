using System.Drawing;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class ControlProperties
    {
        public Color InitialBackColor { get; set; }

        public Color InitialForeColor { get; set; }

        public ControlProperties(Control control)
        {
            InitialBackColor = control.BackColor;
            InitialForeColor = control.ForeColor;
        }
    }
}