using AutoMapper;
using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public AdminController(IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

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

        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                var hasUser = await _userManager.FindByEmailAsync(userDTO.Email);
                if (hasUser == null)
                {
                    var newUser = new UserEntity();
                    newUser.Email = userDTO.Email;
                    newUser.FirstName = userDTO.FirstName;
                    newUser.LastName = userDTO.LastName;
                    newUser.UserName = Guid.NewGuid().ToString();

                    var result = await _userManager.CreateAsync(newUser, userDTO.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("AuthorCreate", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Admin");
                    }
                }
                else
                {
                    return RedirectToAction("Error", "Admin");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Admin");
            }
        }
    }
}
