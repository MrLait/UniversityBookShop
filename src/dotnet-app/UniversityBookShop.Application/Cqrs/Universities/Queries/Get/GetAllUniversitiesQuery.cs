using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;

public class GetAllUniversitiesQuery : IRequest<List<UniversityDto>>
{
}

public class GetAllUniversitiesQueryHandler :
    IRequestHandler<GetAllUniversitiesQuery, List<UniversityDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllUniversitiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<UniversityDto>> Handle(GetAllUniversitiesQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Universities
            .ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<UniversityDto>(); // ToDo. I have to add failed message
    }
}
