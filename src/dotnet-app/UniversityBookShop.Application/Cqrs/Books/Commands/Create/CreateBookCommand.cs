using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.AbstractValidators;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Create;

public class CreateBookCommand : BookCommandBase, IRequest<ServiceResult<int>>
{
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, ServiceResult<int>>
{
    private protected IApplicationDbContext _dbContext;
    public CreateBookCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var currencyCodeExists = await _dbContext.CurrencyCodes.AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);
        if (!currencyCodeExists) throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        var book = new Book
        {
            Isbn = request.Isbn,
            Name = request.Name,
            Author = request.Author,
            Price = request.Price,
            CurrencyCodesId = request.CurrencyCodeId
        };

        await _dbContext.Books.AddAsync(book, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(book.Id);
    }
}
