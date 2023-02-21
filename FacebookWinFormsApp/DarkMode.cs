using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class DarkMode
    {
        public event Action<string> m_ReportClickedDelegates;
        private Button m_DarkModeButton;
        private bool m_Enabled = false;
        private string m_Status = "bright";

        public void buttonDarkMode_Click(object sender, EventArgs e)
        {
            changeEnabledStatus();
            notifyClickObservers();
        }

        public Button GetDarkModeButton()
        {
            return m_DarkModeButton;
        }

        public DarkMode()
        {
            m_DarkModeButton = new Button();
            m_DarkModeButton.Click += new System.EventHandler(this.buttonDarkMode_Click);
        }

        private void changeEnabledStatus()
        {
            m_Enabled = !m_Enabled;

            if (m_Enabled)
            {
                m_Status = "dark";
                brightButtonAppearance();
            }

            if (!m_Enabled)
            {
                m_Status = "bright";
                darkButtonAppearance();
            }
        }

        private void brightButtonAppearance()
        {
            m_DarkModeButton.BackColor = System.Drawing.SystemColors.Control;
            m_DarkModeButton.ForeColor = System.Drawing.Color.RoyalBlue;
            m_DarkModeButton.Text = "Back";
        }

        private void darkButtonAppearance()
        {
            m_DarkModeButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            m_DarkModeButton.ForeColor = System.Drawing.Color.White;
            m_DarkModeButton.Text = "DarkMode";
        }

        private void notifyClickObservers()
        {
            m_ReportClickedDelegates?.Invoke(m_Status);
        }
    }
}