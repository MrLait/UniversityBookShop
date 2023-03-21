using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksPurchasedByUniversities.Queries.Get;

public class GetAllBooksPurchasedByUniversityQuery : IRequest<List<BooksPurchasedByUniversityDto>>
{
}

public class GetAllBooksPurchasedByUniversityQueryHandler :
    IRequestHandler<GetAllBooksPurchasedByUniversityQuery, List<BooksPurchasedByUniversityDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksPurchasedByUniversityQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<BooksPurchasedByUniversityDto>> Handle(GetAllBooksPurchasedByUniversityQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksPurchasedByUniversities
            .ProjectTo<BooksPurchasedByUniversityDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<BooksPurchasedByUniversityDto>(); // ToDo. I have to add failed message
    }
}
