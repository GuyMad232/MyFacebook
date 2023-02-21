namespace BasicFacebookFeatures
{
    public class GameResults
    {
        private static GameResults s_GameResults = null;
        private int m_Wins;
        private int m_Loses;
        private static readonly object sr_GameResultsLock = new object();

        public static GameResults CreateOrGetGameResults()
        {
            if (s_GameResults == null)
            {
                lock (sr_GameResultsLock)
                {
                    if (s_GameResults == null)
                    {
                        s_GameResults = new GameResults();
                    }
                }
            }

            return s_GameResults;
        }

        public void UpdateGameResults(bool i_WinningRound)
        {

            lock (sr_GameResultsLock)
            {
                if (i_WinningRound)
                {
                    m_Wins++;
                }
                else
                {
                    m_Loses++;
                }
            }
        }

        public int GetGameResultsWins()
        {
            return m_Wins;
        }

        public int GetGameResultsLoses()
        {
            return m_Loses;
        }

        private GameResults()
        {
            m_Wins = 0;
            m_Loses = 0;
        }
    }
}