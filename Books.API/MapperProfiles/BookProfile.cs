using AutoMapper;
using Books.API.Dtos.Book;
using Books.API.DTOs.Book;
using Books.ApplicationCore.Entities.BookAggregate;

namespace Books.API.MapperProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookForReturnDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                    $"{src.Author.Firstname} {src.Author.Lastname}"
                ));

            CreateMap<BookForCreationDto, Book>();
        }
    }
}
