using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Faculties.Queries.GetFaculties;

public class GetAllFacultiesQuery : IRequest<PaginatedList<FacultyDto>>
{
    public PaginationParams? PaginationParams { get; set; }
}

public class GetAllFacultiesQueryHandler : IRequestHandler<GetAllFacultiesQuery, PaginatedList<FacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllFacultiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PaginatedList<FacultyDto>> Handle(GetAllFacultiesQuery request, CancellationToken cancellationToken)
    {
        var paginatedFaculties = await _dbContext.Faculties
                                            .ProjectTo<FacultyDto>(_mapper.ConfigurationProvider)
                                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        return paginatedFaculties.Items.Any() ? paginatedFaculties : throw new Exception("Not found"); // ToDo. I have to add failed message
    }
}

