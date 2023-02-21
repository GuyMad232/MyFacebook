using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.IO;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormLogin : Form
    {
        public User m_LoggedInUser;
        public LoginResult m_LoginResult;
        public bool m_LoginSucceed;

        public FormLogin()
        {
            FacebookService.s_CollectionLimit = 100;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc");
            startInteraction();
        }

        private void startInteraction()
        {
            m_LoginResult = FacebookService.Login("651080139850423",
					"email",
                    "public_profile",
                    "user_age_range",
                    "user_birthday",
                    "user_events",
                    "user_friends",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos",
                    "pages_manage_engagement",
                    "pages_manage_posts",
                    "pages_read_engagement",
                    "publish_to_groups");

            loginSucceeded();
        }

        private void loginSucceeded()
        {
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                m_LoginSucceed = true;
                this.Close();
            }
            else
            {
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string fileLocation = Path.Combine(currentDirectory, @"..\..\..\Resources\ErrorSound.wav");
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Path.GetFullPath(fileLocation));

                player.Play();
                MessageBox.Show(m_LoginResult.ErrorMessage, @"Login Failed");
                m_LoginSucceed = false;
            }
        }
    }
}