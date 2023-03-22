using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAvailableBooksByFacultyIdAndBookIdQuery : IRequest<BooksAvailableToFacultyVm>
{
    public int FacultyId { get; set; }
    public int BookId { get; set; }
}

public class GetAvailableBooksByFacultyIdAndBookIdQueryHandler : IRequestHandler<GetAvailableBooksByFacultyIdAndBookIdQuery, BooksAvailableToFacultyVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAvailableBooksByFacultyIdAndBookIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<BooksAvailableToFacultyVm> Handle(GetAvailableBooksByFacultyIdAndBookIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.BooksAvailableForFaculties
                        .Select(b => new BooksAvailableForFaculty()
                        {
                            Id = b.Id,
                            FacultyId = b.FacultyId,
                            BookId = b.BookId,
                            IsPurchased = b.IsPurchased,
                            BooksPurchasedByUniversityId = b.BooksPurchasedByUniversityId,
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
                        .Where(p => p.FacultyId == request.FacultyId && p.BookId == request.BookId)
                        .FirstOrDefaultAsync(cancellationToken);

        var query = _mapper.Map<BooksAvailableToFacultyVm>(entity);

        return query; // ToDo. I have to add failed message
    }
}