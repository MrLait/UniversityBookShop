using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Helpers;
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

        var isBookAddedToOtherFaculty = await _dbContext.BooksAvailableForFaculties
            .AnyAsync(x => x.BookId == entity.BookId && x.FacultyId != entity.FacultyId
            && x.Faculty.UniversityId == entity.Faculty.UniversityId, cancellationToken);

        if (isBookAddedToOtherFaculty) return ServiceResult.Failed<Unit>(ServiceError.CantDeleteUnivarstityBook);

        await _dbContext.BooksAvailableForFaculties
            .Where(x => x.BookId == entity.BookId && x.FacultyId == entity.FacultyId)
            .ExecuteDeleteAsync(cancellationToken);

        _dbContext.PurchasedBookFaculties.Remove(entity);
        await UniversityTotalBookPriceUpdater.DecrementTotalBookPriceAsync(_dbContext, entity.Faculty?.UniversityId, entity.Book?.Price, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return ServiceResult.Success(Unit.Value);
    }

}


