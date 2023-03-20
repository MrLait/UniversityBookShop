using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class BooksAvailableForFacultyConfiguration : IEntityTypeConfiguration<BooksAvailableForFaculty>
{
    public void Configure(EntityTypeBuilder<BooksAvailableForFaculty> builder)
    {
        builder.ToTable("books_available_for_faculty");
        builder.HasKey(f => f.Id);

        builder
            .HasOne<BooksPurchasedByUniversity>(bp => bp.BooksPurchasedByUniversity)
            .WithMany(f => f.BooksAvailableForFaculty)
            .HasForeignKey(fk => fk.BooksPurchasedByUniversityId);
    }
}
