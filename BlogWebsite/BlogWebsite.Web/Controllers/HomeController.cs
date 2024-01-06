
namespace BlogWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogPostService _blogPostService;
        private readonly ILoginService _loginService;

        public HomeController(ILogger<HomeController> logger, IBlogPostService blogPostService, ILoginService loginService)
        {
            _logger = logger;
            _blogPostService = blogPostService;
            _loginService = loginService;
        }

        public async Task<IActionResult> Index()
        {
            var blogPosts = await _blogPostService.GetAll();
            return View(blogPosts);
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(LoginDTO loginDTO)
        {
            var userRoles = await _loginService.LoginAsync(loginDTO);
            foreach (var role in userRoles)
            {
                if (role == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (role == "Author")
                {
                    return RedirectToAction("Index", "Author");
                }
            }
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> SignOut()
        {
            await _loginService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult BlogPost(Guid id)
        {
            return View( _blogPostService.GetById(id) );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
