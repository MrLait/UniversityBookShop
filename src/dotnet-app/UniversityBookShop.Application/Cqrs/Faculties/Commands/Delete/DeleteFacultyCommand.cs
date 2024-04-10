using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Faculties.Commands.Update;

public class DeleteFacultyCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeleteFacultyCommandHandler(IApplicationDbContext dbContext) :
    IRequestHandler<DeleteFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Faculties
            .Include(x => x.BooksAvailableForFaculty)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
        ?? throw new NotFoundException(nameof(Faculty), request.Id);

        if (entity.BooksAvailableForFaculty.Count != 0)
        {
            return ServiceResult.Failed<Unit>(ServiceError.CantDeleteFacultyBookExist);
        }

        _dbContext.Faculties.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(Unit.Value);
    }
}