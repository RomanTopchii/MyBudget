using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MyBudget.Infrastructure.Persistence.Migrations.Queries;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChnageAccountType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hasLinkedAccount",
                schema: "appAudit",
                table: "AccountTypeAudit");

            migrationBuilder.DropColumn(
                name: "hasLinkedAccount",
                schema: "app",
                table: "AccountType");

            migrationBuilder.RenameColumn(
                name: "hasLinkedAccount_MOD",
                schema: "appAudit",
                table: "AccountTypeAudit",
                newName: "linkedAccountTypeId_MOD");

            migrationBuilder.AddColumn<Guid>(
                name: "linkedAccountTypeId",
                schema: "appAudit",
                table: "AccountTypeAudit",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "linkedAccountTypeId",
                schema: "app",
                table: "AccountType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_linkedAccountTypeId",
                schema: "app",
                table: "AccountType",
                column: "linkedAccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountType_AccountType_linkedAccountTypeId",
                schema: "app",
                table: "AccountType",
                column: "linkedAccountTypeId",
                principalSchema: "app",
                principalTable: "AccountType",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountType_AccountType_linkedAccountTypeId",
                schema: "app",
                table: "AccountType");

            migrationBuilder.DropIndex(
                name: "IX_AccountType_linkedAccountTypeId",
                schema: "app",
                table: "AccountType");

            migrationBuilder.DropColumn(
                name: "linkedAccountTypeId",
                schema: "appAudit",
                table: "AccountTypeAudit");

            migrationBuilder.DropColumn(
                name: "linkedAccountTypeId",
                schema: "app",
                table: "AccountType");

            migrationBuilder.RenameColumn(
                name: "linkedAccountTypeId_MOD",
                schema: "appAudit",
                table: "AccountTypeAudit",
                newName: "hasLinkedAccount_MOD");

            migrationBuilder.AddColumn<bool>(
                name: "hasLinkedAccount",
                schema: "appAudit",
                table: "AccountTypeAudit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "hasLinkedAccount",
                schema: "app",
                table: "AccountType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
