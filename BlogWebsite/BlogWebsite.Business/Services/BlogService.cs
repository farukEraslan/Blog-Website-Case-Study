
using BlogWebsite.DataAccess.Context;

namespace BlogWebsite.Business.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;

        public BlogService(IMapper mapper, BlogWebsiteDbContext blogWebsiteDbContext)
        {
            _mapper = mapper;
            _blogWebsiteDbContext = blogWebsiteDbContext;
        }

        public async Task<List<BlogPostDTO>> GetUserBlogPosts(UserEntity user)
        {
            return _mapper.Map<List<BlogPostDTO>>(_blogWebsiteDbContext.BlogPostEntity.Where(x => x.UserId == user.Id).ToList());
        }
    }
}
