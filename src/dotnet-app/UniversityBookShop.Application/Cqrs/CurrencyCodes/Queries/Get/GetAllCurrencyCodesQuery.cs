using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;

namespace UniversityBookShop.Application.Cqrs.CurrencyCodes.Queries.Get;

public class GetAllCurrencyCodesQuery : IRequest<List<CurrencyCodeDto>>
{
}

public class GetAllCurrencyCodesHandler : IRequestHandler<GetAllCurrencyCodesQuery, List<CurrencyCodeDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllCurrencyCodesHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<CurrencyCodeDto>> Handle(GetAllCurrencyCodesQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.CurrencyCodes
            .ProjectTo<CurrencyCodeDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return query.Count > 0 ? query : new List<CurrencyCodeDto>(); // ToDo. I have to add failed message
    }
}
