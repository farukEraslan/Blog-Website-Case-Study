using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorCreate()
        {
            return View();
        }

        public IActionResult AuthorUpdate()
        {
            return View();
        }

        public IActionResult AuthorDelete()
        {
            return View();
        }
    }
}
