using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Isbn).HasMaxLength(17);
        builder.Property(f => f.Name).HasMaxLength(150);
        builder.Property(f => f.Author).HasMaxLength(150);
        builder.Property(f => f.Price).HasColumnType("decimal(10, 2)");
        builder.Property(f => f.CurrencyCodesId).HasColumnName("currency_code_id");

        builder
            .HasOne(pb => pb.PurchasedBookFaculty)
            .WithOne(b => b.Book)
            .HasForeignKey<PurchasedBookFaculty>(fk => fk.BookId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(ba => ba.BooksAvailableForFaculty)
            .WithOne(f => f.Book)
            .HasForeignKey<BooksAvailableForFaculty>(fk => fk.BookId);

        builder
            .HasOne(ba => ba.BooksPurchasedByUniversity)
            .WithOne(f => f.Book)
            .HasForeignKey<BooksPurchasedByUniversity>(fk => fk.BookId);

        builder.HasIndex(x => x.CurrencyCodesId).IsUnique(false);
    }
}
