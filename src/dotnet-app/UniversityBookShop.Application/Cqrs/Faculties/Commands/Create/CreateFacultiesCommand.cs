using MediatR;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;

public class CreateFacultyCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
