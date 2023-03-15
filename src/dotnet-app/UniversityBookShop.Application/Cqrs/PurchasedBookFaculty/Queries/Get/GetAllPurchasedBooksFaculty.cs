using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.PurchasedBookFaculty.Queries.Get;

public class GetAllPurchasedBooksFaculty : IRequest<List<PurchasedBookFacultyDto>>
{
}

public class GetAllPurchasedBooksFacultyHandler : IRequestHandler<GetAllPurchasedBooksFaculty, List<PurchasedBookFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAllPurchasedBooksFacultyHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<PurchasedBookFacultyDto>> Handle(GetAllPurchasedBooksFaculty request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.PurchasedBookFaculties
        .ProjectTo<PurchasedBookFacultyDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<PurchasedBookFacultyDto>(); // ToDo. I have to add failed message
    }
}

