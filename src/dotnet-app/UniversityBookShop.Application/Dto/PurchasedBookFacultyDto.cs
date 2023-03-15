using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Create;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class PurchasedBookFacultyDto : IMapWith<PurchasedBookFaculty>
{
    public int Id { get; set; }
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public BookDto? Book { get; set; }
    public FacultyDto? Faculty { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PurchasedBookFaculty, PurchasedBookFacultyDto>()
        .ForMember(pb => pb.BookId, opt => opt.MapFrom(src => src.BookPurchasedBookFacultyId))
        .ForMember(pb => pb.FacultyId, opt => opt.MapFrom(src => src.FacultyPurchasedBookFacultyId));
    }
}
