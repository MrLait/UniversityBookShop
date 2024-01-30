using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Update;

public class UpdateUniversityCommand : UniversityCommandBase, IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class UpdateUniversityCommandHandler : 
    IRequestHandler<UpdateUniversityCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;
    public UpdateUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Universities
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(University), request.Id);

        var currencyCodeExists = await _dbContext.CurrencyCodes.AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);

        if (!currencyCodeExists)
            throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        entity.Id = request.Id;
        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.CurrencyCodesId = request.CurrencyCodeId;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(Unit.Value);
    }
}
