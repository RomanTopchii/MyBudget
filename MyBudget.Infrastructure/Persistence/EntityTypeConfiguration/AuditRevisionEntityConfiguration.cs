using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AuditRevisionEntityConfiguration : IEntityTypeConfiguration<AuditRevisionEntity>
{
    public void Configure(EntityTypeBuilder<AuditRevisionEntity> builder)
    {
        builder.ToTable("AuditRevisionEntity", "appAudit");

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType(SqlDataTypes.BigInt)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.RevisionDate)
            .HasColumnName("revisionDate")
            .HasColumnType(SqlDataTypes.DateTime)
            .IsRequired();

        builder.Property(x => x.Author)
            .HasColumnName("autor")
            .HasColumnType(SqlDataTypes.NvarChar255);
    }
}
