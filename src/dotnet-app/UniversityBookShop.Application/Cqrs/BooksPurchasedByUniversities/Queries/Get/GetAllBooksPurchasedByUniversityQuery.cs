using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.BooksPurchasedByUniversities.Queries.Get;

public class GetAllBooksPurchasedByUniversityQuery : IRequest<PaginatedList<BooksPurchasedByUniversityDto>>
{
    public PaginationParams? PaginationParams { get; set; }
}

public class GetAllBooksPurchasedByUniversityQueryHandler :
    IRequestHandler<GetAllBooksPurchasedByUniversityQuery, PaginatedList<BooksPurchasedByUniversityDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllBooksPurchasedByUniversityQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PaginatedList<BooksPurchasedByUniversityDto>> Handle(GetAllBooksPurchasedByUniversityQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.BooksPurchasedByUniversities
            .ProjectTo<BooksPurchasedByUniversityDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        return query.Items.Any() ? query : throw new Exception("Not found"); // ToDo. I have to add failed message
    }
}
