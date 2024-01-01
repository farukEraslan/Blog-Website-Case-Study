using BlogWebsite.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.Concrete
{
    public class BlogPostTagEntity : BaseEntity
    {
        // FK
        public Guid TagId { get; set; }
        // Navi Prop
        public TagEntity Tag { get; set; }

        // Fk
        public Guid BlogPostId { get; set; }
        //Navi Prop
        public BlogPostEntity BlogPost { get; set; }
    }
}
