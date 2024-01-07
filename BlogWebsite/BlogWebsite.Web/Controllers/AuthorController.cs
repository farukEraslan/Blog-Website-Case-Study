
namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Author")]
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public AuthorController(IMapper mapper, IUserService userService, IBlogService blogService, ICategoryService categoryService)
        {
            _mapper = mapper;
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
            var blogPostCombineModel = _mapper.Map<BlogPostCreateCombineModel>(_categoryService.GetAll());
            return View(blogPostCombineModel);
        }

        public IActionResult Create(BlogPostCreateCombineModel blogPostCreateCombineModel)
        {
            _blogService.Create(blogPostCreateCombineModel);
            return RedirectToAction("Index", "Author");
        }

        public IActionResult BlogPostUpdate(Guid id)
        {
            var blogPostUpdateCombineModel = _blogService.GetById(id);
            return View(blogPostUpdateCombineModel);
        }
        public IActionResult Update(BlogPostUpdateCombineModel blogPostUpdateCombineModel)
        {
            _blogService.Update(blogPostUpdateCombineModel);
            return RedirectToAction("Index", "Author");
        }

        public IActionResult BlogPostDelete(Guid id)
        {
            _blogService.Delete(id);
            return RedirectToAction("Index", "Author");
        }
    }
}
