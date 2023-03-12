using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.Books.Queries.Get;

public class GetAllBooksQuery : IRequest<List<BookDto>>
{
}

public class GetAllBooksQueryHandler :
    IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Books
            .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<BookDto>(); // ToDo. I have to add failed message
    }
}