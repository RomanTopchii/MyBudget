using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Audit.Generated;
using MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration;

public class AccountTypeAuditConfiguration : IEntityTypeConfiguration<AccountTypeAudit>
{
    public void Configure(EntityTypeBuilder<AccountTypeAudit> builder)
    {
        builder.ToTable("AccountTypeAudit", "appAudit");

        BaseEntityAuditConfiguration.Configure(builder);

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.Property(x => x.Name_MOD)
            .HasColumnName("name_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Classification)
            .HasColumnName("classification");

        builder.Property(x => x.Classification_MOD)
            .HasColumnName("classification_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasCurrency)
            .HasColumnName("hasCurrency")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasCurrency_MOD)
            .HasColumnName("hasCurrency_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasHolder)
            .HasColumnName("hasHolder")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasHolder_MOD)
            .HasColumnName("hasHolder_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasKeeper)
            .HasColumnName("hasKeeper")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasKeeper_MOD)
            .HasColumnName("hasKeeper_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasLinkedAccount)
            .HasColumnName("hasLinkedAccount")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasLinkedAccount_MOD)
            .HasColumnName("hasLinkedAccount_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasInitialBalance)
            .HasColumnName("hasInitialBalance")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.HasInitialBalance_MOD)
            .HasColumnName("hasInitialBalance_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CalcFullTimeBalance)
            .HasColumnName("calcFullTimeBalance")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CalcFullTimeBalance_MOD)
            .HasColumnName("calcFullTimeBalance_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanBeDeleted)
            .HasColumnName("canBeDeleted")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanBeDeleted_MOD)
            .HasColumnName("canBeDeleted_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanChangeActiveStatus)
            .HasColumnName("canChangeActiveStatus")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanChangeActiveStatus_MOD)
            .HasColumnName("canChangeActiveStatus_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanBeRenamed)
            .HasColumnName("canBeRenamed")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanBeRenamed_MOD)
            .HasColumnName("canBeRenamed_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CanBeCreatedByUser)
            .HasColumnName("canBeCreatedByUser")
            .HasColumnType(SqlDataTypes.Bit);
        
        builder.Property(x => x.CanBeCreatedByUser_MOD)
            .HasColumnName("canBeCreatedByUser_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CheckAmountBeforeDeactivate)
            .HasColumnName("checkAmountBeforeDeactivate")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.CheckAmountBeforeDeactivate_MOD)
            .HasColumnName("checkAmountBeforeDeactivate_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.AllowsTransactions)
            .HasColumnName("allowsTransactions")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.AllowsTransactions_MOD)
            .HasColumnName("allowsTransactions_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.KeeperGroup)
            .HasColumnName("keeperGroup")
            .HasColumnType(SqlDataTypes.SmallInt);

        builder.Property(x => x.KeeperGroup_MOD)
            .HasColumnName("keeperGroup_MOD")
            .HasColumnType(SqlDataTypes.Bit);

        builder.Property(x => x.Priority)
            .HasColumnName("priority")
            .HasColumnType(SqlDataTypes.Int);

        builder.Property(x => x.Priority_MOD)
            .HasColumnName("priority_MOD")
            .HasColumnType(SqlDataTypes.Bit);
    }
}
