
namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Author")]
    public class AuthorController : Controller
    {
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public AuthorController(BlogWebsiteDbContext blogWebsiteDbContext, IMapper mapper, UserManager<UserEntity> userManager, IUserService userService, IBlogService blogService, ICategoryService categoryService)
        {
            _blogWebsiteDbContext = blogWebsiteDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _userService = userService;
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetLoggedUser();
            var userBlogPosts = await _blogService.GetUserBlogPosts(user);
            foreach (var userBlogPost in userBlogPosts)
            {
                var category = _categoryService.GetById(userBlogPost.CategoryId);
                userBlogPost.CategoryName = category.CategoryName;
                userBlogPost.AuthorFullName = $"{user.FirstName} {user.LastName}";
            }
            return View(userBlogPosts);
        }

        public async Task<IActionResult> BlogPostCreate()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_blogWebsiteDbContext.CategoryEntity.ToList());
            var blogPostCombineModel = _mapper.Map<BlogPostCreateCombineModel>(categories);
            return View(blogPostCombineModel);
        }

        public IActionResult BlogPostUpdate(Guid id)
        {
            var blogPostUpdateDto = _mapper.Map<BlogPostUpdateDTO>(_blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x => x.Id == id));
            var categoryDto = _mapper.Map<List<CategoryDTO>>(_blogWebsiteDbContext.CategoryEntity.ToList());
            var blogPostUpdateCombineModel = new BlogPostUpdateCombineModel();
            blogPostUpdateCombineModel.BlogPostUpdateDTO = blogPostUpdateDto;
            blogPostUpdateCombineModel.CategoryDTO = categoryDto;
            return View(blogPostUpdateCombineModel);
        }

        public IActionResult BlogPostDelete(Guid id)
        {
            _blogWebsiteDbContext.BlogPostEntity.Remove(_blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x=>x.Id == id));
            _blogWebsiteDbContext.SaveChanges();
            return RedirectToAction("Index", "Author");
        }

        public IActionResult Create(BlogPostCreateCombineModel blogPostCreateCombineModel)
        {
            var blogPost = _mapper.Map<BlogPostEntity>(blogPostCreateCombineModel.BlogPostCreateDTO);
            blogPost.CreatedDate = DateTime.Now;
            blogPost.ModifiedDate = DateTime.Now;
            var result = _blogWebsiteDbContext.BlogPostEntity.Add(blogPost);
            _blogWebsiteDbContext.SaveChanges();
            return RedirectToAction("Index", "Author");
        }

        public IActionResult Update(BlogPostUpdateCombineModel blogPostUpdateCombineModel)
        {
            var updatedblogPost = _mapper.Map<BlogPostEntity>(blogPostUpdateCombineModel.BlogPostUpdateDTO);
            //updatedblogPost.CreatedDate = blogPostUpdateCombineModel.BlogPostUpdateDTO.CreatedDate;
            updatedblogPost.ModifiedDate = DateTime.Now;
            var result = _blogWebsiteDbContext.BlogPostEntity.Update(updatedblogPost);
            _blogWebsiteDbContext.SaveChanges();
            return RedirectToAction("Index", "Author");
        }
    }
}
