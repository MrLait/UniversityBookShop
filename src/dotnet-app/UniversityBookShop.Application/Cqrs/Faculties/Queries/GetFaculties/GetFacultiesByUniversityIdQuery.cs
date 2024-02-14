using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetFacultiesByUniversityIdQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<FacultyDto>>>
{
    public int UniversityId { get; set; }

    public GetFacultiesByUniversityIdQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetFacultiesByUniversityIdQueryHandler : IRequestHandler<GetFacultiesByUniversityIdQuery, ServiceResult<PaginatedList<FacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetFacultiesByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<FacultyDto>>> Handle(GetFacultiesByUniversityIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Faculties
            .AsNoTracking()
            .Where(f => f.UniversityId == request.UniversityId)
            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        return query.Items.Any() ? ServiceResult.Success(query): ServiceResult.Failed(query, ServiceError.NotFound);
    }
}

