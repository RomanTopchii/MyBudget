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
            .HasColumnType(SqlDataTypes.NvarChar255)
            .IsRequired();

        builder.Property(x => x.ParentId)
            .HasColumnName("parentId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.TypeId)
            .HasColumnName("typeId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier)
            .IsRequired();

        builder.Property(x => x.CurrencyId)
            .HasColumnName("currencyId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.HolderId)
            .HasColumnName("holderId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.KeeperId)
            .HasColumnName("keeperId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.LinkedAccountId)
            .HasColumnName("linkedAccountId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.HasMany(x => x.Children)
            .WithOne(x => x.Parent)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.TransactionItems)
            .WithOne(x => x.Account)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
