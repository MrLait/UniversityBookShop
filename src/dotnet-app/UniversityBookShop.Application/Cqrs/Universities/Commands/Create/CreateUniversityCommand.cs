using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Create;

public class CreateUniversityCommand : UniversityCommandBase, IRequest<ServiceResult<int>>
{
}

public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommand, ServiceResult<int>>
{
    private readonly IApplicationDbContext _dbContext;
    public CreateUniversityCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<int>> Handle(CreateUniversityCommand request, CancellationToken cancellationToken)
    {
        var currencyCodeExists = await _dbContext.CurrencyCodes.AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);
        if (!currencyCodeExists) throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        var university = new University
        {
            Name = request.Name,
            Description = request.Description,
            CurrencyCodesId = request.CurrencyCodeId
        };

        await _dbContext.Universities.AddAsync(university, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(university.Id);
    }
}