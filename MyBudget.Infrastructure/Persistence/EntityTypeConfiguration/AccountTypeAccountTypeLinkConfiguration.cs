using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountTypeAccountTypeLinkConfiguration : IEntityTypeConfiguration<AccountTypeAccountTypeLink>
{
    public void Configure(EntityTypeBuilder<AccountTypeAccountTypeLink> builder)
    {
        builder.ToTable("AccountTypeAccountTypeLink", "app");

        BaseEntityConfiguration.Configure(builder);

        builder.Property(x => x.AncestorId)
            .HasColumnName("ancestorId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier);

        builder.Property(x => x.ChildId)
            .HasColumnName("childId")
            .HasColumnType(SqlDataTypes.Uniqueidentifier)
            .IsRequired();

        builder.HasIndex(x => new { x.AncestorId, x.ChildId })
            .IsUnique();
    }
}
