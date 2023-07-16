using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Application.Domain;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
{
    public void Configure(EntityTypeBuilder<AccountType> builder)
    {
        builder.ToTable("AccountType", "app");

        DictionaryEntityConfiguration.Configure(builder);

        builder.Property(x => x.Classification)
            .HasColumnName("classification");

        builder.Property(x => x.HasCurrency)
            .HasColumnName("hasCurrency")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.HasHolder)
            .HasColumnName("hasHolder")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.HasKeeper)
            .HasColumnName("hasKeeper")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.HasInitialBalance)
            .HasColumnName("hasInitialBalance")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CalcFullTimeBalance)
            .HasColumnName("calcFullTimeBalance")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CanBeDeleted)
            .HasColumnName("canBeDeleted")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CanChangeActiveStatus)
            .HasColumnName("canChangeActiveStatus")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CanBeRenamed)
            .HasColumnName("canBeRenamed")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CanBeCreatedByUser)
            .HasColumnName("canBeCreatedByUser")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.CheckAmountBeforeDeactivate)
            .HasColumnName("checkAmountBeforeDeactivate")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.AllowsTransactions)
            .HasColumnName("allowsTransactions")
            .HasColumnType(SqlDataTypes.Bit)
            .IsRequired();

        builder.Property(x => x.KeeperGroup)
            .HasColumnName("keeperGroup")
            .HasColumnType(SqlDataTypes.SmallInt)
            .IsRequired();

        builder.Property(x => x.Priority)
            .HasColumnName("priority")
            .HasColumnType(SqlDataTypes.Int)
            .IsRequired();

        builder.HasMany(x => x.Accounts)
            .WithOne(x => x.Type)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.AncestorAccountTypeLinks)
            .WithOne(x => x.Ancestor)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.ChildAccountTypeLinks)
            .WithOne(x => x.Child)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
