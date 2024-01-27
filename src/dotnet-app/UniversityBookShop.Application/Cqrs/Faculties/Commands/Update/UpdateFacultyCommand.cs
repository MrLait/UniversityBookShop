using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class UpdateFacultyCommand : FacultyCommandBase, IRequest
{
    public int Id { get; set; }
}

public class UpdateFacultyCommandHandler : IRequestHandler<UpdateFacultyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateFacultyCommandHandler(IApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Faculties
            .FirstOrDefaultAsync(faculty => faculty.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Faculty), request.Id);
        }

        var universityExists = await _dbContext.Universities
            .FirstOrDefaultAsync(c => c.Id == request.UniversityId, cancellationToken)
            ?? throw new NotFoundException(nameof(University), request.UniversityId);

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.UniversityId = request.UniversityId;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

