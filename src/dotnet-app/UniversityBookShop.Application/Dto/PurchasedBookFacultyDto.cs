using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class PurchasedBookFacultyDto : IMapWith<PurchasedBookFaculty>
{
    public int Id { get; set; }
    public int? BookPurchasedBookFacultyId { get; set; }
    public int? FacultyPurchasedBookFacultyId { get; set; }
    public BookDto? Book { get; set; }
    public FacultyDto? Faculty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PurchasedBookFaculty, PurchasedBookFacultyDto>();
    }
}
