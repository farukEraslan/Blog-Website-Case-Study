
namespace BlogWebsite.Business.Abstracts
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAll();
        Task<List<UserDTO>> GetAllWithRolesAsync();
        Task<List<UserDTO>> GetAllByRoleAsync(string roleName);
        Task<UserDTO> GetByIdAsync(Guid id);
        Task Delete(Guid id);
        Task<bool> CreateAsync(UserDTO userDTO);
        Task<bool> UpdateAsync(UserUpdateDTO userUpdateDTO);
        Task<UserEntity> GetLoggedUser();
    }
}
