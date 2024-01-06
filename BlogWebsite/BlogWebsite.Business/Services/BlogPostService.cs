
namespace BlogWebsite.Business.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;
        private readonly UserManager<UserEntity> _userManager;

        public BlogPostService(IMapper mapper, BlogWebsiteDbContext blogWebsiteDbContext, UserManager<UserEntity> userManager, ICategoryService categoryService)
        {
            _mapper = mapper;
            _blogWebsiteDbContext = blogWebsiteDbContext;
            _userManager = userManager;
            _categoryService = categoryService;

        }

        public async Task<List<BlogPostDTO>> GetAll()
        {
            var blogPosts = _blogWebsiteDbContext.BlogPostEntity.Where(x => x.Status == true).ToList();
            var blogPostsList = _mapper.Map<List<BlogPostDTO>>(blogPosts);
            // Kategori ve isim atanması
            foreach (var blogPostDto in blogPostsList)
            {
                // Kategori Adı Tanımlaması
                var category = _categoryService.GetById(blogPostDto.CategoryId);
                blogPostDto.CategoryName = category.CategoryName;
                // Yazar Adı-Soyadı Tanımlaması
                var author = await _userManager.FindByIdAsync(blogPostDto.UserId.ToString());
                blogPostDto.AuthorFullName = $"{author.FirstName} {author.LastName}";
            }
            return blogPostsList;
        }

        public BlogPostDTO GetById(Guid id)
        {
            return _mapper.Map<BlogPostDTO>(_blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x => x.Id == id));
        }
    }
}
