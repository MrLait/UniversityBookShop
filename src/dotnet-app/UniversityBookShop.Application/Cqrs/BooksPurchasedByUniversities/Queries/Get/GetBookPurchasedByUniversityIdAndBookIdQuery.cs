//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using UniversityBookShop.Application.Common.Interfaces;
//using UniversityBookShop.Application.Dto;
//using UniversityBookShop.Domain.Entities;

//namespace UniversityBookShop.Application.Cqrs.BooksPurchasedByUniversities.Queries.Get;

//public class GetBookPurchasedByUniversityIdAndBookIdQuery : IRequest<BooksPurchasedByUniversityDto>
//{
//    public int? UniversityId { get; set; }
//    public int? BookId { get; set; }
//}

//public class GetPurchasedBooksByFacultyIdQueryHandler : IRequestHandler<GetBookPurchasedByUniversityIdAndBookIdQuery, BooksPurchasedByUniversityDto>
//{
//    private readonly IApplicationDbContext _dbContext;
//    private readonly IMapper _mapper;
//    public GetPurchasedBooksByFacultyIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
//        (_dbContext, _mapper) = (dbContext, mapper);

//    public async Task<BooksPurchasedByUniversityDto> Handle(GetBookPurchasedByUniversityIdAndBookIdQuery request, CancellationToken cancellationToken)
//    {
//        var entity = await _dbContext.BooksPurchasedByUniversities
//                        // .Select(b => new BooksPurchasedByUniversity()
//                        // {
//                        //     UniversityId = b.UniversityId,
//                        //     BookId = b.BookId
//                        // })
//                        .Where(p => p.BookId == request.BookId && p.UniversityId == request.UniversityId).FirstOrDefaultAsync();
//        return _mapper.Map<BooksPurchasedByUniversityDto>(entity);
//    }
//}