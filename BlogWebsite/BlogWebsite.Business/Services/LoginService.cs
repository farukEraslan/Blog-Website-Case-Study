
namespace BlogWebsite.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly IMapper _mapper;

        public LoginService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        public async Task<IList<string>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, false);
            if (result.Succeeded)
            {
                 var userRoles =  await _userManager.GetRolesAsync(user);
                return userRoles;
            }
            else
            {
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
