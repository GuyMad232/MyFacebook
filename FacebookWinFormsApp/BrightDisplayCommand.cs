using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class BrightDisplayCommand : IDisplayCommand
    {
        public BrightDisplayCommand(Dictionary<Control, ControlProperties> i_ControlProperties) : base(i_ControlProperties) { }

        public override void Execute()
        {
            foreach (Control control in m_ControlProperties.Keys)
            {
                control.BackColor = m_ControlProperties[control].InitialBackColor;
                control.ForeColor = m_ControlProperties[control].InitialForeColor;
            }
        }
    }
}