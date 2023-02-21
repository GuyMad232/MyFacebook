using System;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormLeaderBoard : Form
    {
        private string m_UserEmail;
        private LeaderBoardFacade m_LeaderBoardFacade = new LeaderBoardFacade();

        public FormLeaderBoard(string i_UserNameEmail, string i_UserProfilePictureUrl)
        {
            InitializeComponent();
            m_UserEmail = i_UserNameEmail;
            pictureBoxProfilePicturePodium.LoadAsync(i_UserProfilePictureUrl);
            updateScore();
        }

        private void checkBoxUpdateScore_CheckedChanged(object sender, EventArgs e)
        {
            m_LeaderBoardFacade.WriteToLeaderBoardData(m_UserEmail);
            updateScore();
        }

        private void updateScore()
        {
            labelNumberOfWins.Text = GameResults.CreateOrGetGameResults().GetGameResultsWins().ToString();
            labelFirstPlace.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(0).Key;
            labelSecondPlace.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(1).Key;
            labelThirdPlace.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(2).Key;
            labelFirstNumWins.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(0).Value.ToString();
            labelSecondNumWins.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(1).Value.ToString();
            labelThirdNumWins.Text = m_LeaderBoardFacade.TryGetScoreOfPlayerByRank(2).Value.ToString();
        }
    }
}