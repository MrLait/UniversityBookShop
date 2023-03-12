using MediatR;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class UpdateFacultyCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
