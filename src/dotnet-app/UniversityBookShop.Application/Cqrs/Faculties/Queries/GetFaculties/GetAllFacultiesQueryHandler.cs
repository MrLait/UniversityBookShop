using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetAllFacultiesQueryHandler : IRequestHandler<GetAllFacultiesQuery, List<FacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllFacultiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<FacultyDto>> Handle(GetAllFacultiesQuery request, CancellationToken cancellationToken)
    {
        var facultiesQuery = await _dbContext.Faculties
            //.Where(f => f.Id == request.Id) //ToDo delete
            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        return facultiesQuery.Count > 0 ? facultiesQuery : new List<FacultyDto>(); // ToDo. I have to add failed message
    }
}
