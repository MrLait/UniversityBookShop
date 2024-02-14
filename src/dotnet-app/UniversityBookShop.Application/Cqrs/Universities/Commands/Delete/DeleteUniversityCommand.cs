using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;

public class DeleteUniversityCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}
public class DeleteUniversityCommandHandler :
    IRequestHandler<DeleteUniversityCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Universities
            .Include(x => x.Faculties)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
        ?? throw new NotFoundException(nameof(University), request.Id);

        if (entity.Faculties.Any())
        {
            return ServiceResult.Failed<Unit>(ServiceError.CantDeleteUnivarstity);
        }

        _dbContext.Universities.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);


        return ServiceResult.Success(Unit.Value);
    }
}