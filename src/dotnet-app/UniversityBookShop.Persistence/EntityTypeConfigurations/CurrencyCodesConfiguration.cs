using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UniversityBookShop.Domain.Entities;
using System.Reflection.Emit;

namespace UniversityBookShop.Persistence.EntityTypeConfigurations
{
    public class CurrencyCodesConfiguration : IEntityTypeConfiguration<CurrencyCode>
    {
        public void Configure(EntityTypeBuilder<CurrencyCode> builder)
        {
            builder.ToTable("currency_codes");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Code).HasMaxLength(3);

            builder
                .HasOne(c => c.University)
                .WithOne(u => u.CurrencyCode)
                .HasForeignKey<University>(fk => fk.CurrencyCodesId);

            builder
                .HasOne(c => c.Book)
                .WithOne(u => u.CurrencyCode)
                .HasForeignKey<Book>(fk => fk.CurrencyCodesId);
        }
    }
}