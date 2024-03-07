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
            .HasColumnType(SqlDataTypes.Uniqueidentifier);
        
        builder.Property(x => x.Active)
            .HasColumnName("active")
            .HasColumnType(SqlDataTypes.Bit);
        
        builder.Property(x => x.CreateDate)
            .HasColumnName("createDate")
            .HasColumnType(SqlDataTypes.DateTime);
        
        builder.Property(x => x.CreatedBy)
            .HasColumnName("createdBy")
            .HasColumnType(SqlDataTypes.NvarChar255);
        
        builder.Property(x => x.ModifyDate)
            .HasColumnName("modifyDate")
            .HasColumnType(SqlDataTypes.DateTime);
        
        builder.Property(x => x.ModifiedBy)
            .HasColumnName("modifiedBy")
            .HasColumnType(SqlDataTypes.NvarChar255);
    }
}