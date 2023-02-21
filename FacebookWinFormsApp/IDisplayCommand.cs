using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public abstract class IDisplayCommand
    {
        public Dictionary<Control, ControlProperties> m_ControlProperties;

        public IDisplayCommand(Dictionary<Control, ControlProperties> i_ControlProperties)
        {
            m_ControlProperties = i_ControlProperties;
        }

        public abstract void Execute();
    }
}