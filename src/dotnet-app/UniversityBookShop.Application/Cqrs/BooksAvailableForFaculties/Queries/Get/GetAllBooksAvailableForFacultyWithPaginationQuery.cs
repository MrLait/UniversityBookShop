using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAllBooksAvailableForFacultyWithPaginationQuery : PaginationParams, 
    IRequest<ServiceResult<PaginatedList<BooksAvailableForFacultyDto>>>
{
    public GetAllBooksAvailableForFacultyWithPaginationQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetAllBooksQueryHandler :
    IRequestHandler<GetAllBooksAvailableForFacultyWithPaginationQuery,
        ServiceResult<PaginatedList<BooksAvailableForFacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<BooksAvailableForFacultyDto>>> Handle(
        GetAllBooksAvailableForFacultyWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksAvailableForFaculties
            .AsNoTracking()
            .ProjectTo<BooksAvailableForFacultyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}
