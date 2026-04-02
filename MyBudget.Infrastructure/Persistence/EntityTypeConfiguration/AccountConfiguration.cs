using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Account", "app");

        BaseEntityConfiguration.Configure(builder);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.VarChar255)
            .IsRequired();

        builder.Property(x => x.ParentId)
            .HasColumnName("parentId")
            .HasColumnType(SqlDataTypes.Uuid);

        builder.Property(x => x.TypeId)
            .HasColumnName("typeId")
            .HasColumnType(SqlDataTypes.Uuid)
            .IsRequired();

        builder.Property(x => x.CurrencyId)
            .HasColumnName("currencyId")
            .HasColumnType(SqlDataTypes.Uuid);

        builder.Property(x => x.HolderId)
            .HasColumnName("holderId")
            .HasColumnType(SqlDataTypes.Uuid);

        builder.Property(x => x.KeeperId)
            .HasColumnName("keeperId")
            .HasColumnType(SqlDataTypes.Uuid);

        builder.Property(x => x.LinkedAccountId)
            .HasColumnName("linkedAccountId")
            .HasColumnType(SqlDataTypes.Uuid);

        builder.HasMany(x => x.Children)
            .WithOne(x => x.Parent)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.TransactionItems)
            .WithOne(x => x.Account)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
