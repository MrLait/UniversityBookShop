using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Helpers;
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
            .Include(x => x.Book)
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) 
            ?? throw new NotFoundException(nameof(BooksAvailableForFaculties), request.Id);

        if(entity.IsPurchased == true)
        { 
            var isBookAddedToOtherFaculty = await _dbContext.BooksAvailableForFaculties
                .AnyAsync(x => x.BookId == entity.BookId && x.FacultyId != entity.FacultyId
                && x.UniversityId == entity.UniversityId, cancellationToken);
            if (isBookAddedToOtherFaculty) return ServiceResult.Failed<Unit>(ServiceError.CantDeleteUnivarstityBook);

            _dbContext.BooksAvailableForFaculties.Remove(entity);

            var purchasedBookEntity = await _dbContext.PurchasedBookFaculties
                .Where(x => x.BookId == entity.BookId && x.FacultyId == entity.FacultyId)
                .FirstOrDefaultAsync(cancellationToken)
            ?? throw new NotFoundException(nameof(PurchasedBooksFaculty), request.Id);

            _dbContext.PurchasedBookFaculties.Remove(purchasedBookEntity);
            await UniversityTotalBookPriceUpdater.DecrementTotalBookPriceAsync(_dbContext, entity.UniversityId, entity.Book?.Price, cancellationToken);
        }
        else
        {
            _dbContext.BooksAvailableForFaculties.Remove(entity);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success(Unit.Value);
    }
}
