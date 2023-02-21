using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class ShowAllFilter : IFilterStrategy
    {
        public List<Post> Select(List<Post> i_Items)
        {
            return i_Items;
        }
    }
}