using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get;

public class GetAllBooksWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<BookDto>>>
{
}

public class GetAllBooksWithPaginationQueryHandler :
    IRequestHandler<GetAllBooksWithPaginationQuery, ServiceResult<PaginatedList<BookDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksWithPaginationQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<BookDto>>> Handle(GetAllBooksWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Books
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}