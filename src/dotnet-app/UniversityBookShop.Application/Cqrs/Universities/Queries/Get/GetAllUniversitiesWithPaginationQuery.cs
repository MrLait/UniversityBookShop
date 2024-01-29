using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.Universities.Queries.Get;

public class GetAllUniversitiesWithPaginationQuery : PaginationParams, IRequest<ServiceResult<PaginatedList<UniversityDto>>>
{
    public GetAllUniversitiesWithPaginationQuery(PaginationParams paginationParams)
    {
        SetPaginationParams(paginationParams);
    }
}

public class GetAllUniversitiesWithPaginationQueryHandler :
    IRequestHandler<GetAllUniversitiesWithPaginationQuery, ServiceResult<PaginatedList<UniversityDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllUniversitiesWithPaginationQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<PaginatedList<UniversityDto>>> Handle(GetAllUniversitiesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Universities
                            .ProjectTo<UniversityDto>(_mapper.ConfigurationProvider)
                            .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        //await UpdateCountsAndPrice(query.Items); // To do - make a selection of universities and faculties in one request, and not in a foreach.

        return query.Items.Any() ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }

    //private async Task UpdateCountsAndPrice(List<UniversityDto> universities)
    //{
    //    var purchasedBooks = new List<BooksPurchasedByUniversity>();
    //    foreach (var u in universities)
    //    {
    //        purchasedBooks = await _dbContext.BooksPurchasedByUniversities
    //            .Select(pb => new BooksPurchasedByUniversity()
    //            {
    //                UniversityId = pb.UniversityId,
    //                BookId = pb.BookId,
    //                Book = new Book()
    //                {
    //                    Price = pb.Book.Price
    //                }
    //            })
    //            .Where(pb => pb.UniversityId == u.Id).ToListAsync();

    //        u.FacultyCount = u.Faculties.Count;
    //        u.BookCount = purchasedBooks.Count();
    //        u.TotalBookPrice = purchasedBooks.Sum(pb => pb.Book.Price);
    //    }
    //}
}
