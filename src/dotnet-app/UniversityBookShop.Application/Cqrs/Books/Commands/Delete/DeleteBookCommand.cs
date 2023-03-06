using MediatR;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Books.Commands.Delete;

public class DeleteBookCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteBookCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.Books.FindAsync(new object[] { request.Id });
        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(Book), request.Id);
        }

        _dbContext.Books.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
