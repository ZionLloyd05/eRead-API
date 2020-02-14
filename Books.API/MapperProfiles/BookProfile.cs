using AutoMapper;
using Books.API.Dtos;
using Books.ApplicationCore.Entities.BookAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        }
    }
}
