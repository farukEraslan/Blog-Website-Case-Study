using BlogWebsite.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.Concrete
{
    public class BlogPostEntity : BaseEntity
    {
        public BlogPostEntity()
        {
            this.BlogPostTags = new List<BlogPostTagEntity>();
        }

        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

        //FK
        public Guid UserId { get; set; }
        // Navi Prop
        public UserEntity User { get; set; }

        // FK
        public Guid CategoryId { get; set; }
        // Navi Prop
        public CategoryEntity Category { get; set; }

        // Navi Prop
        public List<BlogPostTagEntity> BlogPostTags { get; set; }
    }
}
