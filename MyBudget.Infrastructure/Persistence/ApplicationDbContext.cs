using Microsoft.EntityFrameworkCore;
using MyBudget.Domain.Audit.Generated;

namespace MyBudget.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");
    }

    public DbSet<AuditRevisionEntity> AuditRevisionEntity { get; set; }
}