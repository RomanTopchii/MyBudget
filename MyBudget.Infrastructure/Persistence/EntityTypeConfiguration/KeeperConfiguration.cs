using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Application.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class KeeperConfiguration : IEntityTypeConfiguration<Keeper>
{
    public void Configure(EntityTypeBuilder<Keeper> builder)
    {
        builder.ToTable("Keeper", "app");

        DictionaryEntityConfiguration.Configure(builder);

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.SmallInt)
            .IsRequired();

        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Keeper)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
