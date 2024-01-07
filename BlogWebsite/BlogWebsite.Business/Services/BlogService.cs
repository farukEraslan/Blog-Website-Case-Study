
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

        public BlogPostUpdateCombineModel GetById(Guid id)
        {
            var blogPostUpdateDto = _mapper.Map<BlogPostUpdateDTO>(_blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x => x.Id == id));
            var categoryDto = _mapper.Map<List<CategoryDTO>>(_blogWebsiteDbContext.CategoryEntity.ToList());
            var blogPostUpdateCombineModel = new BlogPostUpdateCombineModel();
            blogPostUpdateCombineModel.BlogPostUpdateDTO = blogPostUpdateDto;
            blogPostUpdateCombineModel.CategoryDTO = categoryDto;
            return blogPostUpdateCombineModel;
        }

        public async Task<List<BlogPostDTO>> GetUserBlogPosts(UserEntity user)
        {
            return _mapper.Map<List<BlogPostDTO>>(_blogWebsiteDbContext.BlogPostEntity.Where(x => x.UserId == user.Id).ToList());
        }

        public void Create(BlogPostCreateCombineModel blogPostCreateCombineModel)
        {
            var blogPost = _mapper.Map<BlogPostEntity>(blogPostCreateCombineModel.BlogPostCreateDTO);
            blogPost.CreatedDate = DateTime.Now;
            blogPost.ModifiedDate = DateTime.Now;
            var result = _blogWebsiteDbContext.BlogPostEntity.Add(blogPost);
            _blogWebsiteDbContext.SaveChanges();
        }

        public void Update(BlogPostUpdateCombineModel blogPostUpdateCombineModel)
        {
            var updatedblogPost = _mapper.Map<BlogPostEntity>(blogPostUpdateCombineModel.BlogPostUpdateDTO);
            updatedblogPost.ModifiedDate = DateTime.Now;
            var result = _blogWebsiteDbContext.BlogPostEntity.Update(updatedblogPost);
            _blogWebsiteDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _blogWebsiteDbContext.BlogPostEntity.Remove(_blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x => x.Id == id));
            _blogWebsiteDbContext.SaveChanges();
        }
    }
}
