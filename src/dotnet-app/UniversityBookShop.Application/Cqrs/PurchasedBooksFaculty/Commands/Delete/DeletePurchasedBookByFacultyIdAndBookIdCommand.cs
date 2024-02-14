using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Exceptions;
using UniversityBookShop.Application.Common.Helpers;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Commands.Delete
{
    public class DeletePurchasedBookByFacultyIdAndBookIdCommand : IRequest<ServiceResult<Unit>>
    {
        public int Facultyid { get; set; }
        public int BookId { get; set; }
        public DeletePurchasedBookByFacultyIdAndBookIdCommand(int facultyId, int bookId)
        {
            Facultyid = facultyId;
            BookId = bookId;
        }
    }

    public class DeletePurchasedBookByFacultyIdAndBookIdCommandHandler :
        IRequestHandler<DeletePurchasedBookByFacultyIdAndBookIdCommand, ServiceResult<Unit>>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeletePurchasedBookByFacultyIdAndBookIdCommandHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<ServiceResult<Unit>> Handle(DeletePurchasedBookByFacultyIdAndBookIdCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.PurchasedBookFaculties
                .Include(x => x.Faculty)
                .Include(x => x.Book)
                .FirstOrDefaultAsync(x => x.FacultyId == request.Facultyid && x.BookId == request.BookId, cancellationToken)
                ?? throw new NotFoundException(nameof(PurchasedBooksFaculty), request.Facultyid, request.BookId);

            var isBookAddedToOtherFaculty= await _dbContext.BooksAvailableForFaculties
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
}
