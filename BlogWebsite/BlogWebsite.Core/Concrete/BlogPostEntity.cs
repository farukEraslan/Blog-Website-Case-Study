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
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }

        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid TagId { get; set; }
    }
}
