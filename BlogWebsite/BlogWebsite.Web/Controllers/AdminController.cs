using AutoMapper;
using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Web.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public AdminController(IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Author");
            var userList = _mapper.Map<List<UserEntity>>(users);
            return View(userList);
        }

        public IActionResult AuthorCreate()
        {
            return View();
        }

        public async Task<IActionResult> AuthorUpdate(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var updateUser = _mapper.Map<UserUpdateDTO>(user);
            return View(updateUser);
        }

        public async Task<IActionResult> AuthorDelete(Guid id)
        {
            var user = await _userManager.FindByIdAsync($"{id}");
            await _userManager.DeleteAsync(user);
            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                var hasUser = await _userManager.FindByEmailAsync(userDTO.Email);
                if (hasUser == null)
                {
                    var newUser = _mapper.Map<UserEntity>(userDTO);
                    newUser.UserName = Guid.NewGuid().ToString();
                    var result = await _userManager.CreateAsync(newUser, userDTO.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(newUser, "Author");
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

        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var updatedUser = await _userManager.FindByIdAsync(userUpdateDTO.Id.ToString());
                if (updatedUser != null)
                {
                    updatedUser.Email = userUpdateDTO.Email;
                    updatedUser.FirstName = userUpdateDTO.FirstName;
                    updatedUser.LastName = userUpdateDTO.LastName;
                    var result = await _userManager.UpdateAsync(updatedUser);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Admin");
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
