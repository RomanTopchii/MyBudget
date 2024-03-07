using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction", "app");

        BaseEntityConfiguration.Configure(builder);

        builder.Property(x => x.Date)
            .HasColumnName("date")
            .HasColumnType(SqlDataTypes.DateTime)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasColumnName("status")
            .HasColumnType(SqlDataTypes.SmallInt)
            .IsRequired();

        builder.Property(x => x.Type)
            .HasColumnName("type")
            .HasColumnType(SqlDataTypes.SmallInt)
            .IsRequired();

        builder.Property(x => x.Comment)
            .HasColumnName("comment")
            .HasColumnType(SqlDataTypes.NvarChar255);
    }
}
