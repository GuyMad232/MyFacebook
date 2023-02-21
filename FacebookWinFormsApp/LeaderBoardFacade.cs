using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public class LeaderBoardFacade
    {
        private Dictionary<string, int> m_DataBase = new Dictionary<string, int>();
        private string m_DataBaseLocation = null;

        public LeaderBoardFacade()
        {
            m_DataBaseLocation = getLocationOfDataBase();
            m_DataBase = getParsedDataBase();
        }

        public void WriteToLeaderBoardData(string i_Name)
        {
            if (m_DataBase.ContainsKey(i_Name))
            {
                m_DataBase[i_Name] += GameResults.CreateOrGetGameResults().GetGameResultsWins();
            }
            else
            {
                m_DataBase[i_Name] = GameResults.CreateOrGetGameResults().GetGameResultsWins();
            }

            try
            {
                emptyDataBaseFile();
                foreach (KeyValuePair<string, int> entry in m_DataBase)
                {
                    using (StreamWriter sw = File.AppendText(m_DataBaseLocation))
                    {
                        sw.WriteLine($"{entry.Key} {entry.Value}");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"We had an issue with adding your result to the data base: {e}");
            }
            finally
            {
                m_DataBase = getParsedDataBase();
            }
        }
        
        public KeyValuePair<string, int> TryGetScoreOfPlayerByRank(int i_Place)
        {
            KeyValuePair<string, int> scoreOfPlayerInSpecificRank= new KeyValuePair<string, int>();
            if (i_Place < 0)
            {
                throw new IndexOutOfRangeException();
            }

            try
            {
                scoreOfPlayerInSpecificRank = getKeyValuePairByPlace(m_DataBase, i_Place);
            }
            catch (Exception)
            {
                scoreOfPlayerInSpecificRank = new KeyValuePair<string, int>("mockPlayerName", 0);
            }

            return scoreOfPlayerInSpecificRank;
        }

        private KeyValuePair<TKey, TValue> getKeyValuePairByPlace<TKey, TValue>(Dictionary<TKey, TValue> i_Dictionary, int i_Place) where TValue : IComparable<TValue>
        {
            IOrderedEnumerable<KeyValuePair<TKey, TValue>> sortedDictionary = i_Dictionary.OrderByDescending(keyValuePair => keyValuePair.Value);

            return sortedDictionary.ElementAt(i_Place);
        }

        private string getLocationOfDataBase()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileLocation = Path.Combine(currentDirectory, @"..\..\..\Resources\LeaderBoardData.txt");

            return Path.GetFullPath(fileLocation);
        }

        private Dictionary<string, int> getParsedDataBase()
        {
            Dictionary<string, int> parsedData = new Dictionary<string, int>();
            string filePath = m_DataBaseLocation;
            string[] readAllLines = File.ReadAllLines(filePath);

            foreach (string line in readAllLines)
            {
                string[] oneDataLine = line.Split(' ');
                string name = oneDataLine[0];
                int wins = Int16.Parse(oneDataLine[1]);

                parsedData[name] = wins;
            }

            return parsedData;
        }

        private void emptyDataBaseFile()
        {
            File.WriteAllText(m_DataBaseLocation, string.Empty);
        }
    }
}