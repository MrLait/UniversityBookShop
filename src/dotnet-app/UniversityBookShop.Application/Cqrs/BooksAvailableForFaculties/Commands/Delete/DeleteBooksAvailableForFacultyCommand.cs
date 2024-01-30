using MediatR;
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

        //var isLastBookAtUniversity = _dbContext.BooksPurchasedByUniversities.Any(b => b.Id == entity.UniversityId && b.BooksAvailableForFaculty.Count() == 0);
        //if (isLastBookAtUniversity)
        //{
        //    var bookAtUniversity = await _dbContext.BooksPurchasedByUniversities.Where(u => u.Id == entity.UniversityId).FirstOrDefaultAsync();
        //    _dbContext.BooksPurchasedByUniversities.Remove(bookAtUniversity);
            //await _dbContext.SaveChangesAsync(cancellationToken);
        //}
        return Unit.Value;
    }
}
