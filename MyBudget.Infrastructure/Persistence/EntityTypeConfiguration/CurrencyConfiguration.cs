using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("Currency", "app");

        BaseEntityConfiguration.Configure(builder);

        builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasColumnType(SqlDataTypes.NvarChar3);

        builder.Property(x => x.Iso4217)
            .HasColumnName("iso4217")
            .HasColumnType(SqlDataTypes.Int)
            .IsRequired();

        builder.Property(x => x.IsAccounting)
            .HasColumnName("isAccounting")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.HasIndex(x => x.Iso4217)
            .IsUnique();

        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Currency)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
