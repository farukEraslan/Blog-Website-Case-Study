
namespace BlogWebsite.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public UserService(IMapper mapper, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;

        }

        public async Task<List<UserDTO>> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(_userManager.Users.ToList());
        }

        public async Task<List<UserDTO>> GetAllWithRoles()
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

        public async Task<List<UserDTO>> GetAllByRole(string roleName)
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
    }
}
