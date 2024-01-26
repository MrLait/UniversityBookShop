using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Cqrs.Books.Commands.AbstractValidator;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Update;

public class UpdateBookCommand : BookCommandBase, IRequest
{
    public int Id { get; set; }
}

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateBookCommandHandler(IApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Books.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(Book), request.Id);

        var currencyCodeExists = await _dbContext.CurrencyCodes.AnyAsync(c => c.Id == request.CurrencyCodeId, cancellationToken);

        if (!currencyCodeExists)
            throw new NotFoundException(nameof(CurrencyCode), request.CurrencyCodeId);

        entity.Id = request.Id;
        entity.Isbn = request.Isbn;
        entity.Name = request.Name;
        entity.Author = request.Author;
        entity.Price = request.Price;
        entity.CurrencyCodesId = request.CurrencyCodeId;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}

