using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetAllFacultiesWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<FacultyDto>>>
{
    public GetAllFacultiesWithPaginationQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetAllFacultiesQueryHandler : IRequestHandler<GetAllFacultiesWithPaginationQuery, ServiceResult<PaginatedList<FacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllFacultiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<FacultyDto>>> Handle(GetAllFacultiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Faculties
            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}

