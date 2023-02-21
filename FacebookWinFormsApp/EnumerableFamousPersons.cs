using System.Collections;
using System.Collections.Generic;

namespace BasicFacebookFeatures
{
    public class EnumerableFamousPersons : IEnumerable<FamousPerson>
    {
        private List<FamousPerson> m_FamousPersons;

        public EnumerableFamousPersons()
        {
            m_FamousPersons = new List<FamousPerson>();
        }

        public void AddFamousPerson(FamousPerson i_FamousPerson)
        {
            m_FamousPersons.Add(i_FamousPerson);
        }

        public IEnumerator<FamousPerson> GetEnumerator()
        {
            foreach (var famousPerson in m_FamousPersons)
            {
                yield return famousPerson;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}