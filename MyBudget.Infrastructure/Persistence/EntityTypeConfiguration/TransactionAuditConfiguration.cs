using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class TransactionAuditConfiguration : IEntityTypeConfiguration<TransactionAudit>
{
    public void Configure(EntityTypeBuilder<TransactionAudit> builder)
    {
        builder.ToTable("TransactionAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Date)
            .HasColumnName("date")
            .HasColumnType(SqlDataTypes.Timestamp);

        builder.Property(x => x.Date_MOD)
            .HasColumnName("date_MOD")
            .HasColumnType(SqlDataTypes.Boolean);

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType(SqlDataTypes.Smallint);

        builder.Property(x => x.Status_MOD)
            .HasColumnName("status_MOD")
            .HasColumnType(SqlDataTypes.Boolean);

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.Smallint);

        builder.Property(x => x.Type_MOD)
            .HasColumnName("type_MOD")
            .HasColumnType(SqlDataTypes.Boolean);

        builder.Property(x => x.Comment)
            .HasColumnName("comment")
            .HasColumnType(SqlDataTypes.VarChar255);

        builder.Property(x => x.Comment_MOD)
            .HasColumnName("comment_MOD")
            .HasColumnType(SqlDataTypes.Boolean);
    }
}
