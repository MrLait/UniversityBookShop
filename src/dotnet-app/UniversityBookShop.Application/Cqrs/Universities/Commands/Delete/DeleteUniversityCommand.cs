using MediatR;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Delete;

public class DeleteUniversityCommand : IRequest
{
    public int Id { get; set; }
}
public class DeleteUniversityCommandHandler : IRequestHandler<DeleteUniversityCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteUniversityCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Universities.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(University), request.Id);
        }

        _dbContext.Universities.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}