using AutoMapper;
using BlogWebsite.Core.Concrete;
using BlogWebsite.Core.DTO;

namespace BlogWebsite.Business.MapProfiles
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
        }
    }
}
