using AutoMapper;
using MediatR;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Application.Common.Models.Pagination;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByUniversityIdWithPaginationQuery : PaginationParams, IRequest<ServiceResult<List<PurchasedBookFacultyDto>>>
{
    public int UniversityId { get; set; }
}

public class GetPurchasedBooksByUniversityIdQueryHandler : IRequestHandler<GetPurchasedBooksByUniversityIdWithPaginationQuery, ServiceResult<List<PurchasedBookFacultyDto>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<List<PurchasedBookFacultyDto>>> Handle(GetPurchasedBooksByUniversityIdWithPaginationQuery request, CancellationToken cancellationToken)
    {
        //To do fix query
        var entities = await _dbContext.PurchasedBookFaculties
                        .Select(b => new PurchasedBookFaculty()
                        {
                            Id = b.Id,
                            BookId = b.BookId,
                            FacultyId = b.FacultyId,
                            Book = new Book()
                            {
                                Id = b.Book.Id,
                                Name = b.Book.Name,
                                Isbn = b.Book.Isbn,
                                Author = b.Book.Author,
                                CurrencyCode = b.Book.CurrencyCode,
                                Price = b.Book.Price,
                            },
                            Faculty = new Faculty()
                            {
                                Id = b.Faculty.Id,
                                Name = b.Faculty.Name,
                                UniversityId = b.Faculty.UniversityId,
                            },
                        })
                        .Where(p => p.Faculty.UniversityId == request.UniversityId)
                        .PaginatedListAsync(request.PageIndex, request.PageSize, cancellationToken);

        var query = _mapper.Map<List<PurchasedBookFacultyDto>>(entities);

        return query.Count > 0 ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}