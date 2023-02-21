namespace BasicFacebookFeatures
{
    public class FamousPerson
    {
        public string m_FirstName { get; set; }
        public string m_LastName { get; set; }

        public FamousPerson(string i_FirstName, string i_LastName)
        {
            m_FirstName = i_FirstName;
            m_LastName = i_LastName;
        }

        public override string ToString()
        {
            return $"{m_FirstName} {m_LastName}";
        }
    }
}