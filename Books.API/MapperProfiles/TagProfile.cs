using AutoMapper;
using Books.API.Dtos.Tag;
using Books.API.DTOs.Tag;
using Books.ApplicationCore.Entities.BookAggregate;

namespace Books.API.MapperProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagForReturnDto>();

            CreateMap<TagForCreationDto, Tag>();
        }
    }
}
