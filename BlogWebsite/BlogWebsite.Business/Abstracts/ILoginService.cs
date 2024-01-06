
namespace BlogWebsite.Business.Abstracts
{
    public interface ILoginService
    {
        Task<IList<string>> LoginAsync(LoginDTO loginDTO);

        Task LogoutAsync();
    }
}
