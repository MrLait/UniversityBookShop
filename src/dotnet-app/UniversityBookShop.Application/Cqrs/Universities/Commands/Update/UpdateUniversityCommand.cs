using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Update;

public class UpdateUniversityCommand : IRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int CurrencyCodeId { get; set; }
}

public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public UpdateUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    public async Task<Unit> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Universities.FirstOrDefaultAsync(u =>
                u.Id == request.Id, cancellationToken);
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(University), request.Id);
        }

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.CurrencyCodesUniversitiesId = request.CurrencyCodeId;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
