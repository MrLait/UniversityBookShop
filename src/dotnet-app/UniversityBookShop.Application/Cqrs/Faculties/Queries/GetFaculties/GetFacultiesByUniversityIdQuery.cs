using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetFacultiesByUniversityIdQuery : IRequest<PaginatedList<FacultyDto>>
{
    public int UniversityId { get; set; }
    public PaginationParams? PaginationParams { get; set; }
}

public class GetFacultiesByUniversityIdQueryHandler : IRequestHandler<GetFacultiesByUniversityIdQuery, PaginatedList<FacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetFacultiesByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PaginatedList<FacultyDto>> Handle(GetFacultiesByUniversityIdQuery request, CancellationToken cancellationToken)
    {
        var paginatedFaculties = await _dbContext.Faculties
                                            .Where(f => f.UniversityId == request.UniversityId)
                                            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
                                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        return paginatedFaculties.Items.Any() ? paginatedFaculties : null; // ToDo. I have to add failed message
    }
}

