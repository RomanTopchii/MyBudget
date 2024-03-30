using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class CurrencyAuditConfiguration : IEntityTypeConfiguration<CurrencyAudit>
{
    public void Configure(EntityTypeBuilder<CurrencyAudit> builder)
    {
        builder.ToTable("CurrencyAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.Name_MOD)
            .HasColumnName("name_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Code)
            .HasColumnName("code")
            .HasColumnType(SqlDataTypes.NvarChar3);

        builder.Property(x => x.Code_MOD)
            .HasColumnName("code_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Iso4217)
            .HasColumnName("iso4217")
            .HasColumnType(SqlDataTypes.Int);

        builder.Property(x => x.Iso4217_MOD)
            .HasColumnName("iso4217_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
