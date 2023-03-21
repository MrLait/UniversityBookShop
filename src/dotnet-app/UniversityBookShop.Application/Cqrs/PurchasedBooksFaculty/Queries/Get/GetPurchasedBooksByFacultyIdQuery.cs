using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByFacultyIdQuery : IRequest<List<PurchasedBookByFacultyIdVm>>
{
    public int FacultyId { get; set; }
}

public class GetPurchasedBooksByFacultyIdQueryHandler : IRequestHandler<GetPurchasedBooksByFacultyIdQuery, List<PurchasedBookByFacultyIdVm>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByFacultyIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<PurchasedBookByFacultyIdVm>> Handle(GetPurchasedBooksByFacultyIdQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.PurchasedBookFaculties
                        .Select(b => new PurchasedBookFaculty()
                        {
                            Id = b.Id,
                            BookPurchasedBookFacultyId = b.BookPurchasedBookFacultyId,
                            FacultyPurchasedBookFacultyId = b.FacultyPurchasedBookFacultyId,
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
                        .Where(p => p.FacultyPurchasedBookFacultyId == request.FacultyId)
                        .ToListAsync(cancellationToken);

        var query = _mapper.Map<List<PurchasedBookByFacultyIdVm>>(entities);

        return query.Count > 0 ? query : new List<PurchasedBookByFacultyIdVm>(); // ToDo. I have to add failed message
    }
}