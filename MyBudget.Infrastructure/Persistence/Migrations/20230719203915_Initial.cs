using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    classification = table.Column<int>(type: "int", nullable: true),
                    hasCurrency = table.Column<bool>(type: "bit", nullable: false),
                    hasHolder = table.Column<bool>(type: "bit", nullable: false),
                    hasKeeper = table.Column<bool>(type: "bit", nullable: false),
                    hasLinkedAccount = table.Column<bool>(type: "bit", nullable: false),
                    hasInitialBalance = table.Column<bool>(type: "bit", nullable: false),
                    calcFullTimeBalance = table.Column<bool>(type: "bit", nullable: false),
                    canBeDeleted = table.Column<bool>(type: "bit", nullable: false),
                    canChangeActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    canBeRenamed = table.Column<bool>(type: "bit", nullable: false),
                    canBeCreatedByUser = table.Column<bool>(type: "bit", nullable: false),
                    checkAmountBeforeDeactivate = table.Column<bool>(type: "bit", nullable: false),
                    allowsTransactions = table.Column<bool>(type: "bit", nullable: false),
                    keeperGroup = table.Column<short>(type: "smallint", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    iso4217 = table.Column<int>(type: "int", nullable: false),
                    IsAccounting = table.Column<bool>(type: "bit", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Holder",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holder", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Keeper",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keeper", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeAccountTypeLink",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ancestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    childId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeAccountTypeLink", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountTypeAccountTypeLink_AccountType_ancestorId",
                        column: x => x.ancestorId,
                        principalSchema: "app",
                        principalTable: "AccountType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountTypeAccountTypeLink_AccountType_childId",
                        column: x => x.childId,
                        principalSchema: "app",
                        principalTable: "AccountType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    typeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    currencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    holderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    keeperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    linkedAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.id);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_typeId",
                        column: x => x.typeId,
                        principalSchema: "app",
                        principalTable: "AccountType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Account_linkedAccountId",
                        column: x => x.linkedAccountId,
                        principalSchema: "app",
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Account_Account_parentId",
                        column: x => x.parentId,
                        principalSchema: "app",
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Currency_currencyId",
                        column: x => x.currencyId,
                        principalSchema: "app",
                        principalTable: "Currency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Holder_holderId",
                        column: x => x.holderId,
                        principalSchema: "app",
                        principalTable: "Holder",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Keeper_keeperId",
                        column: x => x.keeperId,
                        principalSchema: "app",
                        principalTable: "Keeper",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItem",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionItem_Account_accountId",
                        column: x => x.accountId,
                        principalSchema: "app",
                        principalTable: "Account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionItem_Transaction_transactionId",
                        column: x => x.transactionId,
                        principalSchema: "app",
                        principalTable: "Transaction",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_currencyId",
                schema: "app",
                table: "Account",
                column: "currencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_holderId",
                schema: "app",
                table: "Account",
                column: "holderId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_keeperId",
                schema: "app",
                table: "Account",
                column: "keeperId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_linkedAccountId",
                schema: "app",
                table: "Account",
                column: "linkedAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_parentId",
                schema: "app",
                table: "Account",
                column: "parentId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_typeId",
                schema: "app",
                table: "Account",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_name",
                schema: "app",
                table: "AccountType",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeAccountTypeLink_ancestorId_childId",
                schema: "app",
                table: "AccountTypeAccountTypeLink",
                columns: new[] { "ancestorId", "childId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeAccountTypeLink_childId",
                schema: "app",
                table: "AccountTypeAccountTypeLink",
                column: "childId");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_code",
                schema: "app",
                table: "Currency",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_iso4217",
                schema: "app",
                table: "Currency",
                column: "iso4217",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Currency_name",
                schema: "app",
                table: "Currency",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holder_name",
                schema: "app",
                table: "Holder",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Keeper_name",
                schema: "app",
                table: "Keeper",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_accountId",
                schema: "app",
                table: "TransactionItem",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_transactionId",
                schema: "app",
                table: "TransactionItem",
                column: "transactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypeAccountTypeLink",
                schema: "app");

            migrationBuilder.DropTable(
                name: "TransactionItem",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AccountType",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Holder",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Keeper",
                schema: "app");
        }
    }
}
