using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class BooksAvailableForFacultyDto : IMapWith<BooksAvailableForFaculty>
{
    public int? Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public bool? IsPurchased { get; set; }
    public int? UniversityId { get; set; }

    // One to Many
    public BookDto Book { get; set; }
    public FacultyDto Faculty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BooksAvailableForFaculty, BooksAvailableForFacultyDto>();
    }
}