using BlogWebsite.Core.DTO.Category;

namespace BlogWebsite.Core.DTO.BlogPost
{
    public class BlogPostUpdateCombineModel
    {
        public BlogPostUpdateDTO BlogPostUpdateDTO { get; set; }
        public List<CategoryDTO> CategoryDTO { get; set; }
    }
}
