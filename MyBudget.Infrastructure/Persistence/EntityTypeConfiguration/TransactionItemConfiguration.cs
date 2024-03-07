using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class TransactionItemConfiguration : IEntityTypeConfiguration<TransactionItem>
{
    public void Configure(EntityTypeBuilder<TransactionItem> builder)
    {
        builder.ToTable("TransactionItem", "app");

        BaseEntityConfiguration.Configure(builder);

        builder.Property(x => x.Amount)
            .HasColumnName("amount")
            .HasColumnType(SqlDataTypes.Float)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.SmallInt)
            .IsRequired();

        builder.Property(x => x.AccountId)
            .HasColumnName("accountId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier)
            .IsRequired();

        builder.Property(x => x.TransactionId)
            .HasColumnName("transactionId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);
    }
}
