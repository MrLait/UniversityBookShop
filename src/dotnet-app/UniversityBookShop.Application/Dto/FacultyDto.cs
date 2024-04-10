using AutoMapper;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Dto;

public class FacultyDto : IMapWith<Faculty>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? UniversityId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Faculty, FacultyDto>()
            .ForMember(facultyDto => facultyDto.Id,
                opt => opt.MapFrom(faculty => faculty.Id))
            .ForMember(FacultyDto => FacultyDto.Name,
                opt => opt.MapFrom(faculty => faculty.Name))
            .ForMember(facultyDto => facultyDto.UniversityId,
                opt => opt.MapFrom(faculty => faculty.UniversityId));
    }
}
