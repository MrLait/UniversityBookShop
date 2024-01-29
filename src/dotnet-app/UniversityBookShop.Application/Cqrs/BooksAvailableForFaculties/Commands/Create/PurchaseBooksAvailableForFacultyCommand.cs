using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Application.Common.Interfaces;
using UniversityBookShop.Application.Common.Mappings;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Application.Cqrs.BooksAvailableForFaculties.Commands.Create;

public class PurchaseBooksAvailableForFacultyCommand : IRequest<int>, IMapWith<BooksAvailableForFaculty>
{
    public int? BookId { get; set; }
    public int? FacultyId { get; set; }
    public int? UniversityId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<PurchaseBooksAvailableForFacultyCommand, BooksAvailableForFaculty>();
        //.ForMember(c => c.BooksPurchasedByUniversityId, opt => opt.MapFrom(src => src.UniversityId));
    }
}

public class PurchaseBooksAvailableForFacultyCommandHandler : IRequestHandler<PurchaseBooksAvailableForFacultyCommand, int>
{
    private protected IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public PurchaseBooksAvailableForFacultyCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<int> Handle(PurchaseBooksAvailableForFacultyCommand request, CancellationToken cancellationToken)
    {
        var purchasedByUniversity = await _dbContext.BooksPurchasedByUniversities
                        .Select(b => new BooksPurchasedByUniversity()
                        {
                            Id = b.Id,
                            UniversityId = b.UniversityId,
                            BookId = b.BookId,
                            BooksAvailableForFaculty = b.BooksAvailableForFaculty
                        })
                        .Where(p => p.BookId == request.BookId && p.UniversityId == request.UniversityId).FirstOrDefaultAsync();
        var purchasedBook = new BooksAvailableForFaculty()
        {
            BookId = request.BookId,
            FacultyId = request.FacultyId
        };

        if (purchasedByUniversity == null)
        {
            purchasedByUniversity = new BooksPurchasedByUniversity() { BookId = request.BookId, UniversityId = request.UniversityId };
            await _dbContext.BooksPurchasedByUniversities.AddAsync(purchasedByUniversity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            purchasedBook.BooksPurchasedByUniversityId = purchasedByUniversity.Id;
            purchasedBook.IsPurchased = true;

            await _dbContext.BooksAvailableForFaculties.AddAsync(purchasedBook, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return purchasedBook.Id;
        }

        if (purchasedByUniversity != null)
        {
            var IsPurchasedByFaculty = purchasedByUniversity.BooksAvailableForFaculty.Any(m => m.FacultyId == request.FacultyId);
            if (IsPurchasedByFaculty) throw new Exception("This book already purchased for this faculty");

            purchasedBook.BooksPurchasedByUniversityId = purchasedByUniversity.Id;
            purchasedBook.IsPurchased = false;
            await _dbContext.BooksAvailableForFaculties.AddAsync(purchasedBook, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        return purchasedBook.Id;
    }
}