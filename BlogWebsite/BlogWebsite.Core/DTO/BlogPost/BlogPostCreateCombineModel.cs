using BlogWebsite.Core.DTO.Category;

namespace BlogWebsite.Core.DTO.BlogPost
{
    public class BlogPostCreateCombineModel
    {
        public BlogPostCreateDTO BlogPostCreateDTO { get; set; }
        public List<CategoryDTO> CategoryDTO { get; set; }
    }
}
