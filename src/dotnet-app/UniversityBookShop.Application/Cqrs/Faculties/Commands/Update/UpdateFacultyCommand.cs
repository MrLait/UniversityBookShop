using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class UpdateFacultyCommand : FacultyCommandBase, IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class UpdateFacultyCommandHandler :
    IRequestHandler<UpdateFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateFacultyCommandHandler(IApplicationDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(UpdateFacultyCommand request, CancellationToken cancellationToken)
    {
        var universityExists = await _dbContext.Universities
            .AnyAsync(c => c.Id == request.UniversityId, cancellationToken);
        if(!universityExists)
            throw new NotFoundException(nameof(University), request.UniversityId);

        var entity = await _dbContext.Faculties
            .Where(faculty => faculty.Id == request.Id)
            .ExecuteUpdateAsync(x => x
            .SetProperty(x => x.Name, request.Name)
            .SetProperty(x => x.UniversityId, request.UniversityId), cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(Faculty), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}

