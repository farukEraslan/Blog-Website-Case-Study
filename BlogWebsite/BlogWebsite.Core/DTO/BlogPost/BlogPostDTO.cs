﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Core.DTO.BlogPost
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string Tags { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public string AuthorFullName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
