using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;

public static class BaseEntityAuditConfiguration
{
    public static void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseEntityAudit
    {
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.RevId)
            .HasColumnName("rev");

        builder.Property(x => x.Active)
            .HasColumnName("active")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Active_MOD)
            .HasColumnName("active_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CreateDate)
            .HasColumnName("createDate")
            .HasColumnType(SqlDataTypes.DateTime);

        builder.Property(x => x.CreateDate_MOD)
            .HasColumnName("createDate_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CreatedBy)
            .HasColumnName("createdBy")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.CreatedBy_MOD)
            .HasColumnName("createdBy_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.ModifyDate)
            .HasColumnName("modifyDate")
            .HasColumnType(SqlDataTypes.DateTime);

        builder.Property(x => x.ModifyDate_MOD)
            .HasColumnName("modifyDate_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.ModifiedBy)
            .HasColumnName("modifiedBy")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.ModifiedBy_MOD)
            .HasColumnName("modifiedBy_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
