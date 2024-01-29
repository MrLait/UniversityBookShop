using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetAllPurchasedBooksFacultyWithPaginationQuery : PaginationParams,
    IRequest<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>
{
    public GetAllPurchasedBooksFacultyWithPaginationQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetAllPurchasedBooksFacultyQueryHandler : IRequestHandler<GetAllPurchasedBooksFacultyWithPaginationQuery, ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllPurchasedBooksFacultyQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>> Handle(GetAllPurchasedBooksFacultyWithPaginationQuery request, CancellationToken cancellationToken)
    {
        PaginatedList<PurchasedBookFacultyDto> query = await _dbContext.PurchasedBookFaculties
            .ProjectTo<PurchasedBookFacultyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}

