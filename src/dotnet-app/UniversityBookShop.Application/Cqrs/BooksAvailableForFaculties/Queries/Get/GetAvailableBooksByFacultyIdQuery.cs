using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Dto.Vm;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Queries.Get;

public class GetAvailableBooksByFacultyIdQuery : IRequest<List<BooksAvailableToFacultyVm>>
{
    public int FacultyId { get; set; }
}

public class GetAvailableBooksByFacultyIdQueryHandler : IRequestHandler<GetAvailableBooksByFacultyIdQuery, List<BooksAvailableToFacultyVm>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetAvailableBooksByFacultyIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<List<BooksAvailableToFacultyVm>> Handle(GetAvailableBooksByFacultyIdQuery request, CancellationToken cancellationToken)
    {
        var entities = await _dbContext.BooksAvailableForFaculties
                        .Select(b => new BooksAvailableForFaculty()
                        {
                            Id = b.Id,
                            FacultyId = b.FacultyId,
                            BookId = b.BookId,
                            IsPurchased = b.IsPurchased,
                            UniversityId = b.UniversityId,
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

        var query = _mapper.Map<List<BooksAvailableToFacultyVm>>(entities);

        return query.Count > 0 ? query : new List<BooksAvailableToFacultyVm>(); // ToDo. I have to add failed message
    }
}