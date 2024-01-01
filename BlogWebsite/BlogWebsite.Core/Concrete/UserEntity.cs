using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Core.Concrete
{
    public class UserEntity : IdentityUser<Guid>
    {
        public UserEntity()
        {
            this.BlogPosts = new List<BlogPostEntity>();
        }

        public List<BlogPostEntity> BlogPosts { get; set; }
    }
}
