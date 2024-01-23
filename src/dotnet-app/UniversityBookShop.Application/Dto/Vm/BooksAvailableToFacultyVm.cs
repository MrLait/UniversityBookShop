using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto.Vm;

public class BooksAvailableToFacultyVm : IMapWith<BooksAvailableForFaculty>
{
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public bool? IsPurchased { get; set; }
    public int? BooksPurchasedByUniversityId { get; set; }
    public BookDto? Book { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<BooksAvailableForFaculty, BooksAvailableToFacultyVm>();
        // .ForMember(pb => pb.BookId, opt => opt.MapFrom(src => src.BookPurchasedBookFacultyId))
        // .ForMember(pb => pb.FacultyId, opt => opt.MapFrom(src => src.FacultyPurchasedBookFacultyId));
    }
}