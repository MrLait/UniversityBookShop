using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;

public class GetAllUniversitiesQuery : IRequest<PaginatedList<UniversityDto>>
{
    public PaginationParams? PaginationParams { get; set; }
}

public class GetAllUniversitiesQueryHandler :
    IRequestHandler<GetAllUniversitiesQuery, PaginatedList<UniversityDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllUniversitiesQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<PaginatedList<UniversityDto>> Handle(GetAllUniversitiesQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Universities
                            .ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PaginationParams.PageIndex, request.PaginationParams.PageSize, cancellationToken);

        await UpdateCountsAndPrice(query.Items);

        return query.Items.Any() ? query : null; // ToDo. I have to add failed message
    }

    private async Task UpdateCountsAndPrice(List<UniversityDto> universities)
    {
        var purchasedBooks = new List<BooksPurchasedByUniversity>();

        foreach (var u in universities)
        {
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
                .Where(pb => pb.UniversityId == u.Id).ToListAsync();

            u.FacultyCount = u.Faculties.Count();
            u.BookCount = purchasedBooks.Count();
            u.TotalBookPrice = purchasedBooks.Sum(pb => pb.Book.Price);
        }
    }
}
