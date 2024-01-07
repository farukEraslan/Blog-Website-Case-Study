
namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllByRoleAsync("Author"));
        }

        public IActionResult AuthorCreate()
        {
            return View();
        }

        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            var result = await _userService.CreateAsync(userDTO);

            if (result) return RedirectToAction("Index", "Admin");
            else if (result) return RedirectToAction("AuthorCreate", "Admin");
            else return RedirectToAction("Error", "Home");
        }

        public async Task<IActionResult> AuthorUpdate(Guid id)
        {
            return View(await _userService.GetByIdAsync(id));
        }

        public async Task<IActionResult> AuthorDelete(Guid id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            var result = await _userService.UpdateAsync(userUpdateDTO);
            if (result) return RedirectToAction("Index", "Admin");
            else if (result) return RedirectToAction("AuthorUpdate", "Admin");
            else return RedirectToAction("Error", "Home");
        }
    }
}
