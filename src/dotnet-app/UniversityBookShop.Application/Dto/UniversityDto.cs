using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class UniversityDto : IMapWith<University>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IList<FacultyDto>? Faculties { get; set; }
    public decimal? TotalBookPrice { get; set; }
    public CurrencyCodeDto? CurrencyCode { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<University, UniversityDto>();
    }
}
