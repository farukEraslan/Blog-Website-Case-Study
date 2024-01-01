using BlogWebsite.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.Concrete
{
    public class CategoryEntity : BaseEntity
    {
        public CategoryEntity()
        {
            this.BlogPosts = new List<BlogPostEntity>();
        }
        public string CategoryName { get; set; }

        // NAvi Prop
        public List<BlogPostEntity> BlogPosts { get; set; }
    }
}
