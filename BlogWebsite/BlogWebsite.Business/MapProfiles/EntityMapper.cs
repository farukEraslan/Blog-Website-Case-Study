using AutoMapper;
using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO.BlogPost;
using BlogWebsite.Core.DTO.Category;
using BlogWebsite.Core.DTO.User;

namespace BlogWebsite.Business.MapProfiles
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserUpdateDTO, UserEntity>().ReverseMap();
            CreateMap<BlogPostDTO, BlogPostEntity>().ReverseMap();
            CreateMap<CategoryDTO, CategoryEntity>().ReverseMap();
            CreateMap<List<CategoryDTO>, BlogPostCreateCombineModel>().ForMember(dest => dest.CategoryDTO, opt => opt.MapFrom(src => src));
            CreateMap<List<BlogPostCreateDTO>, BlogPostCreateCombineModel>().ForMember(dest => dest.BlogPostCreateDTO, opt => opt.MapFrom(src => src));
            CreateMap<BlogPostCreateDTO, BlogPostEntity>();
        }
    }
}
