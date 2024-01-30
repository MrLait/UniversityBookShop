using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete;

public class DeletePurchasedBookFacultyCommand : IRequest<ServiceResult<Unit>>
{
    public int Id { get; set; }
}

public class DeletePurchasedBookFacultyCommandHandler : 
    IRequestHandler<DeletePurchasedBookFacultyCommand, ServiceResult<Unit>>
{
    private readonly IApplicationDbContext _dbContext;

    public DeletePurchasedBookFacultyCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<ServiceResult<Unit>> Handle(DeletePurchasedBookFacultyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.PurchasedBookFaculties
            .Include(x => x.Faculty)
            .Include(x => x.Book)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(PurchasedBooksFaculty), request.Id);

        var isBookAvailableForFaculty = await _dbContext.BooksAvailableForFaculties
            .AnyAsync(x => x.BookId == entity.BookId
            && x.Faculty.UniversityId == entity.Faculty.UniversityId, cancellationToken);
        if (isBookAvailableForFaculty) return ServiceResult.Failed<Unit>(ServiceError.CantDeleteUnivarstityBook);

        _dbContext.PurchasedBookFaculties.Remove(entity);
        await UpdateTotalBookPriceAsync(entity.Faculty?.UniversityId, entity.Book?.Price, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(Unit.Value);
    }

    private async Task UpdateTotalBookPriceAsync(
    int? universityId, decimal? curBookPrice, CancellationToken cancellationToken)
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


