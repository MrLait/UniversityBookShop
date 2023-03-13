using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class BookDto : IMapWith<Book>
{
    public int Id { get; set; }
    public string? Isbn { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public decimal? Price { get; set; }
    public CurrencyCodeDto? CurrencyCode { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, BookDto>();
    }
}
