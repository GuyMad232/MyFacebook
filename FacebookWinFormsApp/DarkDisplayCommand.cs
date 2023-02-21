using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class DarkDisplayCommand : IDisplayCommand
    {
        public DarkDisplayCommand(Dictionary<Control, ControlProperties> i_ControlProperties) : base(i_ControlProperties) { }

        public override void Execute()
        {
            foreach (Control control in m_ControlProperties.Keys)
            {
                control.BackColor = System.Drawing.SystemColors.ControlDarkDark;
                control.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}