using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByUniversityIdWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>
{
    public int UniversityId { get; set; }

    public GetPurchasedBooksByUniversityIdWithPaginationQuery(PaginationParams paginationParams, int universityId)
    {
        SetPaginationParams(paginationParams);
        UniversityId = universityId;
    }
}

public class GetPurchasedBooksByUniversityIdQueryHandler : IRequestHandler<GetPurchasedBooksByUniversityIdWithPaginationQuery, ServiceResult<PaginatedList<PurchasedBookFacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<PurchasedBookFacultyDto>>> Handle(GetPurchasedBooksByUniversityIdWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.PurchasedBookFaculties
            .Where(x => x.Faculty!.UniversityId == request.UniversityId)
            .Include(x => x.Book)
                .ThenInclude(x => x!.CurrencyCode)
            .Include(x => x.Faculty)
            .Select(x => _mapper.Map<PurchasedBookFacultyDto>(x))
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}