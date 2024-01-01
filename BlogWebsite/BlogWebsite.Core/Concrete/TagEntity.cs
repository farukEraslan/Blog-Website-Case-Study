using BlogWebsite.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.Concrete
{
    public class TagEntity : BaseEntity
    {
        public TagEntity()
        {
            this.BlogPostTags = new List<BlogPostTagEntity>();
        }

        public string TagName { get; set; }

        public List<BlogPostTagEntity> BlogPostTags { get; set; }
    }
}
