
namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Author")]
    public class AuthorController : Controller
    {
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public AuthorController(BlogWebsiteDbContext blogWebsiteDbContext, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _blogWebsiteDbContext = blogWebsiteDbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Giriş yapan kullanıcının ID sini bulma
            var author = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            // Giriş yapan kullanıcının blog postlarını bulma
            var blogPosts = _blogWebsiteDbContext.BlogPostEntity.Where(x => x.UserId == author.Id).ToList();
            var blogPostsList = _mapper.Map<List<BlogPostDTO>>(blogPosts);
            // Kategori ve isim atanması
            foreach (var blogPostDto in blogPostsList)
            {
                var category = _blogWebsiteDbContext.CategoryEntity.FirstOrDefault(x => x.Id == blogPostDto.CategoryId);
                blogPostDto.CategoryName = category.CategoryName;
                blogPostDto.AuthorFullName = $"{author.FirstName} {author.LastName}";
            }

            return View(blogPostsList);
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
