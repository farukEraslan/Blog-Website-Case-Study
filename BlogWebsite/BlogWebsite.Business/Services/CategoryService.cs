
namespace BlogWebsite.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly BlogWebsiteDbContext _blogWebsiteDbContext;

        public CategoryService(IMapper mapper, BlogWebsiteDbContext blogWebsiteDbContext)
        {
            _mapper = mapper;
            _blogWebsiteDbContext = blogWebsiteDbContext;

        }

        public CategoryDTO GetById(Guid id)
        {
            return _mapper.Map<CategoryDTO>( _blogWebsiteDbContext.CategoryEntity.FirstOrDefault(x => x.Id == id) );
        }
    }
}
