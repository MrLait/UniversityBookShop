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
            .Where(x => x.Id == request.Id)
            .ExecuteDeleteAsync(cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(University), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}