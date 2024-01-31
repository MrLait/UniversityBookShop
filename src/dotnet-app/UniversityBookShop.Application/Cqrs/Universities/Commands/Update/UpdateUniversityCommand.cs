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
    public UpdateUniversityCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(UpdateUniversityCommand request, CancellationToken cancellationToken)
    {
        var currencyCodeExists = await _dbContext.CurrencyCodes
            .AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);
        if (!currencyCodeExists)
            throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        var entity = await _dbContext.Universities
            .Where(u => u.Id == request.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, request.Name)
                .SetProperty(x => x.Description, request.Description)
                .SetProperty(x => x.CurrencyCodesId, request.CurrencyCodeId), cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(University), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}
