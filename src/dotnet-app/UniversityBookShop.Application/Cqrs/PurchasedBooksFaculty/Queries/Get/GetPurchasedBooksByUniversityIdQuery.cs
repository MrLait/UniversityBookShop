using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.PurchasedBooksFaculty.Queries.Get;

public class GetPurchasedBooksByUniversityIdQuery : IRequest<List<PurchasedBookFacultyDto>>
{
    public int UniversityId { get; set; }
}

public class GetPurchasedBooksByUniversityIdQueryHandler : IRequestHandler<GetPurchasedBooksByUniversityIdQuery, List<PurchasedBookFacultyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetPurchasedBooksByUniversityIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<PurchasedBookFacultyDto>> Handle(GetPurchasedBooksByUniversityIdQuery request, CancellationToken cancellationToken)
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
                            Faculty = new Faculty()
                            {
                                Id = b.Faculty.Id,
                                Name = b.Faculty.Name,
                                UniversityId = b.Faculty.UniversityId,
                            },
                        })
                        .Where(p => p.Faculty.UniversityId == request.UniversityId)
                        .ToListAsync(cancellationToken);

        var query = _mapper.Map<List<PurchasedBookFacultyDto>>(entities);

        return query.Count > 0 ? query : new List<PurchasedBookFacultyDto>(); // ToDo. I have to add failed message
    }
}