using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class KeeperAuditConfiguration : IEntityTypeConfiguration<KeeperAudit>
{
    public void Configure(EntityTypeBuilder<KeeperAudit> builder)
    {
        builder.ToTable("KeeperAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.Name_MOD)
            .HasColumnName("name_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.SmallInt);

        builder.Property(x => x.Type_MOD)
            .HasColumnName("type_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
