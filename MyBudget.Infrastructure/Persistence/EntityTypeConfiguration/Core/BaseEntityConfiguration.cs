using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Domain.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;

public static class BaseEntityConfiguration
{
    public static void Configure<T>(EntityTypeBuilder<T> builder) where T : BaseEntity
    {
        builder.Property(x => x.Id)
            .HasColumnName("id")
            .HasColumnType(SqlDataTypes.Uuid);
        
        builder.Property(x => x.Active)
            .HasColumnName("active")
            .HasColumnType(SqlDataTypes.Boolean);
        
        builder.Property(x => x.CreateDate)
            .HasColumnName("createDate")
            .HasColumnType(SqlDataTypes.Timestamp);
        
        builder.Property(x => x.CreatedBy)
            .HasColumnName("createdBy")
            .HasColumnType(SqlDataTypes.VarChar255);
        
        builder.Property(x => x.ModifyDate)
            .HasColumnName("modifyDate")
            .HasColumnType(SqlDataTypes.Timestamp);
        
        builder.Property(x => x.ModifiedBy)
            .HasColumnName("modifiedBy")
            .HasColumnType(SqlDataTypes.VarChar255);
    }
}