using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get
{
    public class GetBooksWithPurchaseStatusByFacultyIdWithPaginationQuery: PaginationParams,
        IRequest<ServiceResult<PaginatedList<BookWithPurchaseStatusDto>>>
    {
        public int FacultyId { get; set; }
        public GetBooksWithPurchaseStatusByFacultyIdWithPaginationQuery(int facultyId, PaginationParams paginationParams)
        {
            SetPaginationParams(paginationParams);
            FacultyId = facultyId;
        }
    }

    public class GetBooksWithPurchaseStatusByFacultyIdWithPaginationQueryHandler :
        IRequestHandler<GetBooksWithPurchaseStatusByFacultyIdWithPaginationQuery, ServiceResult<PaginatedList<BookWithPurchaseStatusDto>>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksWithPurchaseStatusByFacultyIdWithPaginationQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ServiceResult<PaginatedList<BookWithPurchaseStatusDto>>> Handle(GetBooksWithPurchaseStatusByFacultyIdWithPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = await _dbContext.Books
                .AsNoTracking()
                .ProjectTo<BookWithPurchaseStatusDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

            if (!query.Items.Any()) 
                return ServiceResult.Failed<PaginatedList<BookWithPurchaseStatusDto>>(ServiceError.NotFound);

            var universityId = await _dbContext.Faculties
                .Where(x => x.Id == request.FacultyId)
                .Select(x => x.UniversityId)
                .SingleOrDefaultAsync();

            foreach (var bookDto in query.Items)
            {
                var bookAvailableForFaculties = await _dbContext.BooksAvailableForFaculties
                    .SingleOrDefaultAsync(x => x.FacultyId == request.FacultyId && x.BookId == bookDto.Id);
                
                var addedByCurrentFaculty = bookAvailableForFaculties != null;
                bookDto.IsPurchase = bookAvailableForFaculties?.IsPurchased ?? null;

                if (bookDto.IsPurchase == true)
                {
                    bookDto.PurchaseStatus = ApplicationConstants.PurchaseStatus.BookPurchasedByCurrentFaculty;
                    continue;
                }

                if (addedByCurrentFaculty)
                {
                    bookDto.PurchaseStatus = ApplicationConstants.PurchaseStatus.BookAddedByCurrentFaculty;
                    continue;
                }

                var otherFaculties = await _dbContext.BooksAvailableForFaculties
                    .Where(baf => baf.BookId == bookDto.Id && baf.FacultyId != request.FacultyId && baf.UniversityId == universityId)
                    .ToListAsync();

                bookDto.PurchaseStatus = otherFaculties.Any(x => x.IsPurchased == true)
                    ? ApplicationConstants.PurchaseStatus.BookAvailableForAdditionByCurrentFaculty
                    : ApplicationConstants.PurchaseStatus.BookAvailableForPurchase;
            }

            return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
        }
    }
}
