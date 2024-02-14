using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Update;

public class UpdateBookCommand : BookCommandBase, IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class UpdateBookCommandHandler :
    IRequestHandler<UpdateBookCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateBookCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var currencyCodeExists = await _dbContext.CurrencyCodes
            .AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);
        if (!currencyCodeExists)
            throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        int entity = await _dbContext.Books
            .Where(x => x.Id == request.Id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Isbn, request.Isbn)
                .SetProperty(x => x.Name, request.Name)
                .SetProperty(x => x.Author, request.Author)
                .SetProperty(x => x.Price, request.Price)
                .SetProperty(x => x.CurrencyCodesId, request.CurrencyCodeId), cancellationToken);

        if (entity == 0)
            throw new NotFoundException(nameof(Book), request.Id);

        return ServiceResult.Success(Unit.Value);
    }
}

