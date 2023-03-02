using MediatR;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetAllFacultiesQuery : IRequest<List<FacultyDto>>
{
    public int Id { get; set; }
}
