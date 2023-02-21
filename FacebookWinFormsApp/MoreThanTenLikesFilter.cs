using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class MoreThanTenLikesFilter : IFilterStrategy
    {
        public List<Post> Select(List<Post> i_Items)
        {
            IEnumerable<Post> posts = from item in i_Items
                where item.LikedBy.Count >= 10
                select item;

            return posts.ToList();
        }
    }
}