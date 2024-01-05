using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.DTO.BlogPost
{
    public class BlogPostUpdateDTO
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
