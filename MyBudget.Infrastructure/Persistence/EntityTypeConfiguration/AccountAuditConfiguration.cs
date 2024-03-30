using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountAuditConfiguration : IEntityTypeConfiguration<AccountAudit>
{
    public void Configure(EntityTypeBuilder<AccountAudit> builder)
    {
        builder.ToTable("AccountAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.Name_MOD)
            .HasColumnName("name_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.ParentId)
            .HasColumnName("parentId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.ParentId_MOD)
            .HasColumnName("parentId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.TypeId)
            .HasColumnName("typeId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.TypeId_MOD)
            .HasColumnName("typeId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CurrencyId)
            .HasColumnName("currencyId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.CurrencyId_MOD)
            .HasColumnName("currencyId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HolderId)
            .HasColumnName("holderId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.HolderId_MOD)
            .HasColumnName("holderId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.KeeperId)
            .HasColumnName("keeperId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.KeeperId_MOD)
            .HasColumnName("keeperId_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.LinkedAccountId)
            .HasColumnName("linkedAccountId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.LinkedAccountId_MOD)
            .HasColumnName("linkedAccountId_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
