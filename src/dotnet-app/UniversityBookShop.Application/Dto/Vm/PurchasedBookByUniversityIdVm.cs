using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto.Vm;

public class PurchasedBookByUniversityIdVm : IMapWith<PurchasedBookFaculty>
{
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public BookDto? Book { get; set; }
    public FacultyDto? Faculty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PurchasedBookFaculty, PurchasedBookByUniversityIdVm>()
        .ForMember(pb => pb.BookId, opt => opt.MapFrom(src => src.BookPurchasedBookFacultyId))
        .ForMember(pb => pb.FacultyId, opt => opt.MapFrom(src => src.FacultyPurchasedBookFacultyId));
    }
}
