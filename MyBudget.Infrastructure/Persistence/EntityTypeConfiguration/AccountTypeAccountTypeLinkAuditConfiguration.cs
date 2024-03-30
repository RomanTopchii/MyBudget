using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountTypeAccountTypeLinkAuditConfiguration : IEntityTypeConfiguration<AccountTypeAccountTypeLinkAudit>
{
    public void Configure(EntityTypeBuilder<AccountTypeAccountTypeLinkAudit> builder)
    {
        builder.ToTable("AccountTypeAccountTypeLinkAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.AncestorId)
            .HasColumnName("ancestorId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.AncestorId_MOD)
            .HasColumnName("ancestorId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.ChildId)
            .HasColumnName("childId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.ChildId_MOD)
            .HasColumnName("childId_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
