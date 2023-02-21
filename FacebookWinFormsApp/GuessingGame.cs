using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace BasicFacebookFeatures
{
    internal class GuessingGame
    {
        private Dictionary<string, EnumerableFamousPersons> m_Database = new Dictionary<string, EnumerableFamousPersons>();
        private List<string> m_FourCelebrities = new List<string>();
        private string m_MonthOfBirth;
        private List<string> m_MonthsInYear = new List<string>();

        public GuessingGame(string i_BirthMonth)
        {
            new Thread(setCelebrityDictionary).Start();

            m_MonthOfBirth = i_BirthMonth;
            setMonthsList();
        }

        public List<string> PlayGame()
        {
            chooseFourRandomCelebrities();

            return m_FourCelebrities;
        }

        private string getLocationOfDataBase()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileLocation = Path.Combine(currentDirectory, @"..\..\..\Resources\Database.txt");
            return Path.GetFullPath(fileLocation);
        }

        private void setCelebrityDictionary()
        {
            string[] readAllLines = File.ReadAllLines(getLocationOfDataBase());

            foreach (string line in readAllLines)
            {
                string[] oneDataLine = line.Split(' ');
                string firstName = oneDataLine[1];
                string lastName = oneDataLine[2];
                string month = oneDataLine[oneDataLine.Length - 3];

                if (m_Database.ContainsKey(month))
                {
                    m_Database[month].AddFamousPerson(new FamousPerson(firstName, lastName));
                }
                else
                {
                    EnumerableFamousPersons freshEnumerableFamousPersons = new EnumerableFamousPersons();
                    freshEnumerableFamousPersons.AddFamousPerson(new FamousPerson(firstName, lastName));
                    m_Database.Add(month, freshEnumerableFamousPersons);
                }
            }
        }

        private void setMonthsList()
        {
            for(int i = 1; i < 13; i++)
            {
                m_MonthsInYear.Add(i.ToString());
            }
        }

        private string chooseRandomCelebrityBornInMonth(string i_MonthOfBirth)
        {
            EnumerableFamousPersons namesByGivenMonth = m_Database[i_MonthOfBirth];
            Random randomNumber = new Random();
            int randomIndex = randomNumber.Next(namesByGivenMonth.Count());
            string generatedRandomCelebrityFullName = null;

            using (IEnumerator<FamousPerson> enumerator = namesByGivenMonth.GetEnumerator())
            {
                while (enumerator.MoveNext() && randomIndex-- >= 0)
                {
                    generatedRandomCelebrityFullName = enumerator.Current.ToString();
                }
            }

            return generatedRandomCelebrityFullName;
        }

        private List<string> chooseThreeRandomMonths()
        {
            List<string> listOfThreeMonths = new List<string>();
            Random randomNumber = new Random();

            while (listOfThreeMonths.Count < 3)
            {
                string month = m_MonthsInYear[randomNumber.Next(m_MonthsInYear.Count)];
                if (month != m_MonthOfBirth)
                {
                    listOfThreeMonths.Add(month);
                }
            }

            return listOfThreeMonths;
        }

        private void chooseFourRandomCelebrities()
        {
            List<string> fourMonthsOfCurrentGame = chooseThreeRandomMonths();
            fourMonthsOfCurrentGame.Add(m_MonthOfBirth);

            foreach (string month in fourMonthsOfCurrentGame)
            {
                string celebrityName = chooseRandomCelebrityBornInMonth(month);

                while (m_FourCelebrities.Contains(celebrityName))
                {
                    celebrityName = chooseRandomCelebrityBornInMonth(month);
                }

                m_FourCelebrities.Add(celebrityName);
            }
        }
    }
}