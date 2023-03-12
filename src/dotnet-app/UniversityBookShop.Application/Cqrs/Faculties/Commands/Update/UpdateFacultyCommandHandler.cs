using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;
using MediatR;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateFacultyCommandHandler(IApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Faculties.FirstOrDefaultAsync(faculty =>
                faculty.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Faculty), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

