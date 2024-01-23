using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Create;

public class CreateBookCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? Isbn { get; set; }
    public string? Name { get; set; }
    public string? Author { get; set; }
    public decimal? Price { get; set; }
    public int CurrencyCodeId { get; set; }
}

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private protected IApplicationDbContext _dbContext;
    public CreateBookCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Id = request.Id,
            Isbn = request.Isbn,
            Name = request.Name,
            Author = request.Author,
            Price = request.Price,
            CurrencyCodesId = request.CurrencyCodeId
        };
        await _dbContext.Books.AddAsync(book, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return book.Id;
    }
}
