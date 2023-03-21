using UniversityBookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace UniversityBookShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Faculty> Faculties { get; set; }
    DbSet<University> Universities { get; set; }
    DbSet<CurrencyCode> CurrencyCodes { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<PurchasedBookFaculty> PurchasedBookFaculties { get; set; }
    DbSet<BooksAvailableForFaculty> BooksAvailableForFaculties { get; set; }
    DbSet<BooksPurchasedByUniversity> BooksPurchasedByUniversities { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
