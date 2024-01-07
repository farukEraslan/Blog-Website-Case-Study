using Microsoft.AspNetCore.Http;

namespace BlogWebsite.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public UserService(IMapper mapper, UserManager<UserEntity> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(_userManager.Users.ToList());
        }

        public async Task<List<UserDTO>> GetAllWithRolesAsync()
        {
            var userList = _userManager.Users.ToList();
            var userDTOList = new List<UserDTO>();
            foreach (var user in userList)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userDTOWithRoles = _mapper.Map<UserDTO>(user);
                userDTOWithRoles.Roles = userRoles;

                userDTOList.Add(userDTOWithRoles);
            }
            return userDTOList;
        }

        public async Task<List<UserDTO>> GetAllByRoleAsync(string roleName)
        {
            var userList = await _userManager.GetUsersInRoleAsync(roleName);
            var userDTOList = new List<UserDTO>();
            foreach (var user in userList)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var userDTOWithRoles = _mapper.Map<UserDTO>(user);
                userDTOWithRoles.Roles = userRoles;

                userDTOList.Add(userDTOWithRoles);
            }
            return userDTOList;
        }

        public async Task<UserDTO> GetByIdAsync(Guid id)
        {
            return _mapper.Map<UserDTO>(await _userManager.FindByIdAsync(id.ToString()));
        }

        public async Task Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
        }

        public async Task<bool> CreateAsync(UserDTO userDTO)
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(UserUpdateDTO userUpdateDTO)
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }        

        public async Task<UserEntity> GetLoggedUser()
        {
            return await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
        }
    }
}
