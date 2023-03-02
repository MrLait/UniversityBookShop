using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Create;

public class CreateFacultiesCommandHandler : IRequestHandler<CreateFacultyCommand, int>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateFacultiesCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<int> Handle(CreateFacultyCommand request, CancellationToken cancellationToken)
    {
        var faculty = new Faculty
        {
            Id = request.Id,
            Name = request.Name
        };

        await _dbContext.Faculties.AddAsync(faculty, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return faculty.Id;
    }
}
