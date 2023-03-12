using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;
using MediatR;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class DeleteFacultyCommandHandler : IRequestHandler<DeleteFacultyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteFacultyCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Faculties.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Faculty), request.Id);
        }

        _dbContext.Faculties.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

