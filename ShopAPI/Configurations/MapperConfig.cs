using AutoMapper;
using ShopAPI.Controllers;
using ShopAPI.Data;
using ShopAPI.Models.Authors;
using ShopAPI.Models.Books;

namespace ShopAPI.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<AuthorReadDto, Authors>().ReverseMap();
        CreateMap<AuthorCreateDto, Authors>().ReverseMap();
        CreateMap<AuthorUpdateDto, Authors>().ReverseMap();

        CreateMap<BookCreateDto, Books>().ReverseMap();
        CreateMap<BookUpdateDto, Books>().ReverseMap();
        CreateMap<Books, BookReadOnlyDto>()
            .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

        CreateMap<Books, BookDetailsDto>()
            .ForMember(q => q.AuthorName, d => d.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
            .ReverseMap();

        CreateMap<APIUser, UserDto>().ReverseMap();
    }
}