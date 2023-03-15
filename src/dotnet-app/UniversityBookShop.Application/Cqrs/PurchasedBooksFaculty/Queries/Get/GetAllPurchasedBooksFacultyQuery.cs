using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetAllPurchasedBooksFacultyQuery : IRequest<List<PurchasedBookFacultyDto>>
{
}

public class GetAllPurchasedBooksFacultyQueryHandler : IRequestHandler<GetAllPurchasedBooksFacultyQuery, List<PurchasedBookFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllPurchasedBooksFacultyQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<PurchasedBookFacultyDto>> Handle(GetAllPurchasedBooksFacultyQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.PurchasedBookFaculties
        .ProjectTo<PurchasedBookFacultyDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<PurchasedBookFacultyDto>(); // ToDo. I have to add failed message
    }
}

