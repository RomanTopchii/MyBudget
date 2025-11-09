using Microsoft.EntityFrameworkCore.Migrations;
using MyBudget.Infrastructure.Persistence.Migrations.Queries;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAccounttypeWithLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(InitiateAccountType.Query);
            migrationBuilder.Sql(InitiateAccountTypeAccountTypeLinks.Query);
        }
    }
}
