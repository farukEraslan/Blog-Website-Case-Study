using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.Business.Abstracts
{
    public interface IBlogService
    {
        Task<List<BlogPostDTO>> GetUserBlogPosts(UserEntity user);
    }
}
