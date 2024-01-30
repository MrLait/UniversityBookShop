using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class PurchasedBookFacultyConfiguration : IEntityTypeConfiguration<PurchasedBookFaculty>
{
    public void Configure(EntityTypeBuilder<PurchasedBookFaculty> builder)
    {
        builder.ToTable("purchased_books_faculty");
        builder.HasKey(f => f.Id);
    }
}
