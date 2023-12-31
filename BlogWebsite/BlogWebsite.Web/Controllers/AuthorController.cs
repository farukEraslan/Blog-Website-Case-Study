using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Web.Controllers
{
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
