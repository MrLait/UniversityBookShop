using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;


public class GetUniversityByUniversityIdQuery : IRequest<UniversityDto>
{
    public int UniversityId { get; set; }
}

public class GetUniversityByUniversityIdQueryHandler : IRequestHandler<GetUniversityByUniversityIdQuery, UniversityDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetUniversityByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UniversityDto> Handle(GetUniversityByUniversityIdQuery request, CancellationToken cancellationToken)
    {

        var university = await _dbContext.Universities
                        .Where(u => u.Id == request.UniversityId)
                        .FirstOrDefaultAsync();
        await _dbContext.Faculties.Where(f => f.UniversityId == university.Id).LoadAsync();
        await _dbContext.CurrencyCodes.Where(c => c.Id == university.CurrencyCodesId).LoadAsync();

        var query = _mapper.Map<UniversityDto>(university);
        await UpdateCountsAndPrice(query);
        return query; // ToDo. I have to add failed message
    }

    private async Task UpdateCountsAndPrice(UniversityDto university)
    {
        var purchasedBooks = new List<BooksPurchasedByUniversity>();

        purchasedBooks = await _dbContext.BooksPurchasedByUniversities
            .Select(pb => new BooksPurchasedByUniversity()
            {
                UniversityId = pb.UniversityId,
                BookId = pb.BookId,
                Book = new Book()
                {
                    Price = pb.Book.Price
                }
            })
            .Where(pb => pb.UniversityId == university.Id).ToListAsync();

        university.FacultyCount = university.Faculties.Count();
        university.BookCount = purchasedBooks.Count();
        university.TotalBookPrice = purchasedBooks.Sum(pb => pb.Book.Price);
    }

}