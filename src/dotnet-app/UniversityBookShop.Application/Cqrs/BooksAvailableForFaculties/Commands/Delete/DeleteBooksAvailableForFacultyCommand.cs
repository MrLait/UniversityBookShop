using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Delete;

public class DeleteBooksAvailableForFacultyCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeleteBooksAvailableForFacultyCommandHandler : 
    IRequestHandler<DeleteBooksAvailableForFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;
    public DeleteBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeleteBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.BooksAvailableForFaculties
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) 
            ?? throw new NotFoundException(nameof(BooksAvailableForFaculties), request.Id);

        var isLast = await _dbContext.BooksAvailableForFaculties
            .CountAsync(x => x.BookId == entity.BookId && x.UniversityId == entity.UniversityId, cancellationToken) == 1;

        _dbContext.BooksAvailableForFaculties.Remove(entity);
        if (isLast)
        {
            var purchasedBookEntity = await _dbContext.PurchasedBookFaculties
                .Where(x => x.BookId == entity.BookId && x.FacultyId == entity.FacultyId)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(PurchasedBooksFaculty), request.Id);

            _dbContext.PurchasedBookFaculties.Remove(purchasedBookEntity);
            await UpdateTotalBookPriceAsync(entity.Faculty?.UniversityId, entity.Book?.Price, cancellationToken);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(Unit.Value);
    }

    private async Task UpdateTotalBookPriceAsync(int? universityId, 
        decimal? curBookPrice, CancellationToken cancellationToken)
    {
        var university = await _dbContext.Universities
            .Where(u => u.Id == universityId)
            .Include(x => x.CurrencyCode)
            .Include(x => x.Faculties)
            .FirstOrDefaultAsync(cancellationToken)
        ?? throw new NotFoundException(nameof(University), universityId ?? 0);

        university.TotalBookPrice = await _dbContext.PurchasedBookFaculties
            .SumAsync(x => x.Book!.Price, cancellationToken) - (curBookPrice ?? 0m);
    }
}
