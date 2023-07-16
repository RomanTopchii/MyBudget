using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudget.Application.Domain.Core;
using MyBudget.Infrastructure.Persistence.Helpers;

namespace MyBudget.Infrastructure.Persistence.EntityTypeConfiguration.Core;

public static class DictionaryEntityConfiguration
{
    public static void Configure<T>(EntityTypeBuilder<T> builder) where T : DictionaryEntity
    {
        BaseEntityConfiguration.Configure(builder);
        
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasColumnType(SqlDataTypes.NvarChar255);

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}