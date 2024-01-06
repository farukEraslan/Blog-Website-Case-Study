
namespace BlogWebsite.Business.Abstracts
{
    public interface IBlogPostService
    {
        Task<List<BlogPostDTO>> GetAll();

        BlogPostDTO GetById(Guid id);
    }
}
