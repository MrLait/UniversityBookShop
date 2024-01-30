using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;

public class GetAllUniversitiesWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<UniversityDto>>>
{
    public GetAllUniversitiesWithPaginationQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetAllUniversitiesWithPaginationQueryHandler :
    IRequestHandler<GetAllUniversitiesWithPaginationQuery, ServiceResult<PaginatedList<UniversityDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllUniversitiesWithPaginationQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<UniversityDto>>> Handle(GetAllUniversitiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Universities
                            .ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        await UpdateCountsAndPrice(query.Items, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }

    private async Task UpdateCountsAndPrice(List<UniversityDto> universities, CancellationToken cancellationToken)
    {
        var universitiesId = universities.Select(u => u.Id).ToList();

        var purchasedBooksQuery = _dbContext.PurchasedBookFaculties
            .Where(x => universitiesId.Contains((int)x.Faculty!.UniversityId));
        var groupedBookCountsQuery = purchasedBooksQuery
            .GroupBy(x => x.Faculty!.UniversityId)
            .Select(group => new { UniversityId = group.Key, BookCount = group.Count() });
        var bookCountsList = await groupedBookCountsQuery.ToListAsync(cancellationToken);

        foreach (var university in universities)
        {
            university.FacultyCount = university.Faculties?.Count ?? 0;

            var bookCountInfo = bookCountsList
                .FirstOrDefault(x => x.UniversityId == university.Id);
            university.BookCount = bookCountInfo?.BookCount ?? 0;
        }
    }
}
