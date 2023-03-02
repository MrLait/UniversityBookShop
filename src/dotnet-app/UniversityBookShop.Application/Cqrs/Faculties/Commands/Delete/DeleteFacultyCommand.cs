using MediatR;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class DeleteFacultyCommand : IRequest
{
    public int Id { get; set; }
}
