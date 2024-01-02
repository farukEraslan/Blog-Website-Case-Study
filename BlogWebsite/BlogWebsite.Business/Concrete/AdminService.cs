using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO;

namespace BlogWebsite.Business.Concrete
{
    public class AdminService
    {
        public async void AuthorCreate(UserDTO userDTO)
        {
            //var hasUser = await _userManager.FindByEmailAsync(userDTO.Email);
            //if (hasUser == null)
            //{
            //    var newUser = new UserEntity();
            //    newUser.Email = userDTO.Email;
            //    newUser.FirstName = userDTO.FirstName;
            //    newUser.LastName = userDTO.LastName;
            //    newUser.UserName = Guid.NewGuid().ToString();

            //    var result = await _userManager.CreateAsync(newUser, userDTO.Password);

            //    if (result.Succeeded)
            //    {
            //        return RedirectToAction("AuthorCreate", "Admin");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Error", "Admin");
            //    }
            //}
            //else
            //{
            //    return RedirectToAction("Error", "Admin");
            //}
        }
    }
}
