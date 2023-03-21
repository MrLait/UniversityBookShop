using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class BooksPurchasedByUniversityDto : IMapWith<BooksPurchasedByUniversity>
{
    public int? Id { get; set; }
    public int? UniversityId { get; set; }
    public int? BookId { get; set; }
    public BookDto? Book { get; set; }

    //One to Many
    public IList<BooksAvailableForFacultyDto>? BooksAvailableForFaculty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BooksPurchasedByUniversity, BooksPurchasedByUniversityDto>();
    }
}