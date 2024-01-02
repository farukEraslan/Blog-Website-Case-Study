using Microsoft.AspNetCore.Identity;

namespace BlogWebsite.Core.Concrete
{
    public class UserEntity : IdentityUser<Guid>
    {
        public UserEntity()
        {
            this.BlogPosts = new List<BlogPostEntity>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<BlogPostEntity> BlogPosts { get; set; }
    }
}
