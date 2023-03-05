using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityBookShop.Domain.Entities;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations;

public class UniversityConfiguration : IEntityTypeConfiguration<University>
{
    public void Configure(EntityTypeBuilder<University> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Name).HasMaxLength(150);
        builder.Property(f => f.Description).HasMaxLength(255);
        builder.Property(f => f.TotalBookPrice)
            .HasColumnName("total_book_price").HasColumnType("decimal(10, 2)");

        builder
            .HasOne(u => u.CurrencyCodes)
            .WithOne(c => c.University)
            .HasForeignKey<CurrencyCode>(fk => fk.UniversitiesCurrencyCodesId);
    }
}
