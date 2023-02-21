using System;
using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class LastMonthFilter : IFilterStrategy
    {
        public List<Post> Select(List<Post> i_Items)
        {
            IEnumerable<Post> posts = from item in i_Items
                where item.CreatedTime > DateTime.Now.AddMonths(-1)
                select item;

            return posts.ToList();
        }
    }
}