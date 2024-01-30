//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using UniversityBookShop.Application.Common.Interfaces;
//using UniversityBookShop.Application.Dto;
//using UniversityBookShop.Domain.Entities;

//namespace UniversityBookShop.Application.Cqrs.BooksPurchasedByUniversities.Queries.Get;

//public class GetIsBookAtUniversityQuery : IRequest<bool>
//{
//    public int? UniversityId { get; set; }
//    public int? BookId { get; set; }
//}

//public class GetIsBookAtUniversityQueryHandler : IRequestHandler<GetIsBookAtUniversityQuery, bool>
//{
//    private readonly IApplicationDbContext _dbContext;
//    private readonly IMapper _mapper;
//    public GetIsBookAtUniversityQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
//        (_dbContext, _mapper) = (dbContext, mapper);

//    public async Task<bool> Handle(GetIsBookAtUniversityQuery request, CancellationToken cancellationToken)
//    {
//        var isBookAtUniversity = await _dbContext.BooksPurchasedByUniversities
//                        .AnyAsync(p => p.BookId == request.BookId && p.UniversityId == request.UniversityId);
//        return isBookAtUniversity;
//    }
//}