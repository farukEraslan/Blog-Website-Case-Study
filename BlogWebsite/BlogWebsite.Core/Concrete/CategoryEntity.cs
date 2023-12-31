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
        public string CategoryName { get; set; }
    }
}
