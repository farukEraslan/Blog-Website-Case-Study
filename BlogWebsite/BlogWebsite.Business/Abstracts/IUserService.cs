
namespace BlogWebsite.Business.Abstracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> GetAllWithRoles();
        Task<List<UserDTO>> GetAllByRole(string roleName);
    }
}
