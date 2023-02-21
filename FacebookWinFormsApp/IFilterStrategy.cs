using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public interface IFilterStrategy 
    { 
        List<Post> Select(List<Post> i_Items);
    }
}