using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Models.ServicesModels;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByFacultyIdQuery : IRequest<ServiceResult<List<PurchasedBookByFacultyIdVm>>>
{
    public int FacultyId { get; set; }
}

public class GetPurchasedBooksByFacultyIdQueryHandler : IRequestHandler<GetPurchasedBooksByFacultyIdQuery, ServiceResult<List<PurchasedBookByFacultyIdVm>>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByFacultyIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<ServiceResult<List<PurchasedBookByFacultyIdVm>>> Handle(GetPurchasedBooksByFacultyIdQuery request, CancellationToken cancellationToken)
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
                        })
                        .Where(p => p.FacultyId == request.FacultyId)
                        .ToListAsync(cancellationToken);

        var query = _mapper.Map<List<PurchasedBookByFacultyIdVm>>(entities);

        return query.Count > 0 ? ServiceResult.Success(query) : ServiceResult.Failed(query, ServiceError.NotFound);
    }
}