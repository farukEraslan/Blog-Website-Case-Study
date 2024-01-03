using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Author")]
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BlogPostCreate()
        {
            return View();
        }

        public IActionResult BlogPostUpdate()
        {
            return View();
        }

        public IActionResult BlogPostDelete()
        {
            return View();
        }
    }
}
