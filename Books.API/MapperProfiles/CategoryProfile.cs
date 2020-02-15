

using AutoMapper;
using Books.API.Dtos.Category;
using Books.API.DTOs.Category;
using Books.ApplicationCore.Entities.BookAggregate;

namespace Books.API.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryForReturnDto>();

            CreateMap<CategoryForCreationDto, Category>();
        }
    }
}
