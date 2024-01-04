using AutoMapper;
using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO.BlogPost;
using BlogWebsite.Core.DTO.Login;
using BlogWebsite.DataAccess.Context;
using BlogWebsite.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogWebsite.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IMapper _mapper;
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;

        public HomeController(ILogger<HomeController> logger, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IMapper mapper, BlogWebsiteDbContext blogWebsiteDbContext)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _blogWebsiteDbContext = blogWebsiteDbContext;
        }

        public async Task<IActionResult> Index()
        {
            // Giriþ yapan kullanýcýnýn blog postlarýný bulma
            var blogPosts = _blogWebsiteDbContext.BlogPostEntity.Where(x => x.Status == true).ToList();
            var blogPostsList = _mapper.Map<List<BlogPostDTO>>(blogPosts);
            // Kategori ve isim atanmasý
            foreach (var blogPostDto in blogPostsList)
            {
                var category = _blogWebsiteDbContext.CategoryEntity.FirstOrDefault(x => x.Id == blogPostDto.CategoryId);
                blogPostDto.CategoryName = category.CategoryName;
                var author = await _userManager.FindByIdAsync(blogPostDto.UserId.ToString());
                blogPostDto.AuthorFullName = $"{author.FirstName} {author.LastName}";
            }
            return View(blogPostsList);
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SignIn(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (result.Succeeded)
            {

                if (HttpContext.User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (HttpContext.User.IsInRole("Author"))
                {
                    return RedirectToAction("Index", "Author");
                }
                else
                {
                    await _signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult BlogPost(Guid id)
        {
            var blogPost = _blogWebsiteDbContext.BlogPostEntity.FirstOrDefault(x=> x.Id == id);
            var blogPostDto = _mapper.Map<BlogPostDTO>(blogPost);
            return View(blogPostDto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
