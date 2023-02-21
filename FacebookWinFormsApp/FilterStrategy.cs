using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class FilterStrategy
    {
        private IFilterStrategy m_Strategy;

        public void SetSelectionStrategy(IFilterStrategy i_Strategy)
        {
            m_Strategy = i_Strategy;
        }

        public List<Post> Select(List<Post> items)
        {
            return m_Strategy.Select(items);
        }
    }
}