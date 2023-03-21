using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAllBooksAvailableForFacultyQuery : IRequest<List<BooksAvailableForFacultyDto>>
{
}

public class GetAllBooksQueryHandler :
    IRequestHandler<GetAllBooksAvailableForFacultyQuery, List<BooksAvailableForFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<BooksAvailableForFacultyDto>> Handle(GetAllBooksAvailableForFacultyQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksAvailableForFaculties
            .ProjectTo<BooksAvailableForFacultyDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<BooksAvailableForFacultyDto>(); // ToDo. I have to add failed message
    }
}
