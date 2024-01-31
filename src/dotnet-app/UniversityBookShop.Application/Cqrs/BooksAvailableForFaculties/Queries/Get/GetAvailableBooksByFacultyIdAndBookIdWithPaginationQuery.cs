using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto.Vm;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAvailableBooksByFacultyIdAndBookIdWithPaginationQuery : PaginationParams,
    IRequest<ServiceResult<PaginatedList<BooksAvailableToFacultyVm>>>
{
    public int FacultyId { get; set; }
    public int BookId { get; set; }

    public GetAvailableBooksByFacultyIdAndBookIdWithPaginationQuery(int facultyId, int bookId, PaginationParams paginationParams)
    {
        FacultyId = facultyId;
        BookId = bookId;
        SetPaginationParams(paginationParams);
    }
}

public class GetAvailableBooksByFacultyIdAndBookIdQueryHandler :
    IRequestHandler<GetAvailableBooksByFacultyIdAndBookIdWithPaginationQuery,
        ServiceResult<PaginatedList<BooksAvailableToFacultyVm>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAvailableBooksByFacultyIdAndBookIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<BooksAvailableToFacultyVm>>> Handle(
        GetAvailableBooksByFacultyIdAndBookIdWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksAvailableForFaculties
            .AsNoTracking()
            .Where(x => x.FacultyId == request.FacultyId && x.BookId == request.BookId)
            .Include(x => x.Book)
                .ThenInclude(x => x!.CurrencyCode)
            .ProjectTo<BooksAvailableToFacultyVm>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}