using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;

public class DeleteBooksAvailableForFacultyCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBooksAvailableForFacultyCommandHandler : IRequestHandler<DeleteBooksAvailableForFacultyCommand>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.BooksAvailableForFaculties.FindAsync(new object[] { request.Id });

        if (entity == null || entity.Id != request.Id)
        {
            throw new NotFoundException(nameof(BooksAvailableForFaculties), request.Id);
        }

        _dbContext.BooksAvailableForFaculties.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        //поверять последняя ли книга в универе если да то удалять из универа
        var isLastBookInUniversity = _dbContext.BooksPurchasedByUniversities.Any(b => b.Id == entity.BooksPurchasedByUniversityId && b.BooksAvailableForFaculty.Count() == 0);
        if (isLastBookInUniversity)
        {
            var bookInUniversity = await _dbContext.BooksPurchasedByUniversities.Where(u => u.Id == entity.BooksPurchasedByUniversityId).FirstOrDefaultAsync();
            _dbContext.BooksPurchasedByUniversities.Remove(bookInUniversity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
