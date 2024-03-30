using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class TransactionItemAuditConfiguration : IEntityTypeConfiguration<TransactionItemAudit>
{
    public void Configure(EntityTypeBuilder<TransactionItemAudit> builder)
    {
        builder.ToTable("TransactionItemAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Amount)
            .HasColumnName("amount")
            .HasColumnType(SqlDataTypes.Float);

        builder.Property(x => x.Amount_MOD)
            .HasColumnName("amount_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.SmallInt);

        builder.Property(x => x.Type_MOD)
            .HasColumnName("type_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.AccountId)
            .HasColumnName("accountId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.AccountId_MOD)
            .HasColumnName("accountId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.TransactionId)
            .HasColumnName("transactionId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.TransactionId_MOD)
            .HasColumnName("transactionId_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
