using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "appAudit");

            migrationBuilder.CreateTable(
                name: "AuditRevisionEntity",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    revisionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRevisionEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AccountAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "bit", nullable: true),
                    parentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    parentId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    typeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    typeId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    currencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    currencyId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    holderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    holderId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    keeperId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    keeperId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    linkedAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    linkedAccountId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeAccountTypeLinkAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ancestorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ancestorId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    childId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    childId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeAccountTypeLinkAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountTypeAccountTypeLinkAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "bit", nullable: true),
                    classification = table.Column<int>(type: "int", nullable: true),
                    classification_MOD = table.Column<bool>(type: "bit", nullable: true),
                    hasCurrency = table.Column<bool>(type: "bit", nullable: true),
                    hasCurrency_MOD = table.Column<bool>(type: "bit", nullable: true),
                    hasHolder = table.Column<bool>(type: "bit", nullable: true),
                    hasHolder_MOD = table.Column<bool>(type: "bit", nullable: true),
                    hasKeeper = table.Column<bool>(type: "bit", nullable: true),
                    hasKeeper_MOD = table.Column<bool>(type: "bit", nullable: true),
                    hasLinkedAccount = table.Column<bool>(type: "bit", nullable: true),
                    hasLinkedAccount_MOD = table.Column<bool>(type: "bit", nullable: true),
                    hasInitialBalance = table.Column<bool>(type: "bit", nullable: true),
                    hasInitialBalance_MOD = table.Column<bool>(type: "bit", nullable: true),
                    calcFullTimeBalance = table.Column<bool>(type: "bit", nullable: true),
                    calcFullTimeBalance_MOD = table.Column<bool>(type: "bit", nullable: true),
                    canBeDeleted = table.Column<bool>(type: "bit", nullable: true),
                    canBeDeleted_MOD = table.Column<bool>(type: "bit", nullable: true),
                    canChangeActiveStatus = table.Column<bool>(type: "bit", nullable: true),
                    canChangeActiveStatus_MOD = table.Column<bool>(type: "bit", nullable: true),
                    canBeRenamed = table.Column<bool>(type: "bit", nullable: true),
                    canBeRenamed_MOD = table.Column<bool>(type: "bit", nullable: true),
                    canBeCreatedByUser = table.Column<bool>(type: "bit", nullable: true),
                    canBeCreatedByUser_MOD = table.Column<bool>(type: "bit", nullable: true),
                    checkAmountBeforeDeactivate = table.Column<bool>(type: "bit", nullable: true),
                    checkAmountBeforeDeactivate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    allowsTransactions = table.Column<bool>(type: "bit", nullable: true),
                    allowsTransactions_MOD = table.Column<bool>(type: "bit", nullable: true),
                    keeperGroup = table.Column<short>(type: "smallint", nullable: true),
                    keeperGroup_MOD = table.Column<bool>(type: "bit", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: true),
                    priority_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountTypeAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "bit", nullable: true),
                    code = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    code_MOD = table.Column<bool>(type: "bit", nullable: true),
                    iso4217 = table.Column<int>(type: "int", nullable: true),
                    iso4217_MOD = table.Column<bool>(type: "bit", nullable: true),
                    IsAccounting = table.Column<bool>(type: "bit", nullable: true),
                    IsAccounting_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_CurrencyAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HolderAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolderAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_HolderAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeeperAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeeperAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_KeeperAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    date = table.Column<DateTime>(type: "datetime", nullable: true),
                    date_MOD = table.Column<bool>(type: "bit", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true),
                    status_MOD = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "bit", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    comment_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItemAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: true),
                    amount_MOD = table.Column<bool>(type: "bit", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "bit", nullable: true),
                    accountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    accountId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    Account_MOD = table.Column<bool>(type: "bit", nullable: true),
                    transactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    transactionId_MOD = table.Column<bool>(type: "bit", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: true),
                    active_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    createdBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "bit", nullable: true),
                    modifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItemAudit", x => x.id);
                    table.ForeignKey(
                        name: "FK_TransactionItemAudit_Account_accountId",
                        column: x => x.accountId,
                        principalSchema: "app",
                        principalTable: "Account",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TransactionItemAudit_AuditRevisionEntity_rev",
                        column: x => x.rev,
                        principalSchema: "appAudit",
                        principalTable: "AuditRevisionEntity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAudit_rev",
                schema: "appAudit",
                table: "AccountAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeAccountTypeLinkAudit_rev",
                schema: "appAudit",
                table: "AccountTypeAccountTypeLinkAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeAudit_rev",
                schema: "appAudit",
                table: "AccountTypeAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyAudit_rev",
                schema: "appAudit",
                table: "CurrencyAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_HolderAudit_rev",
                schema: "appAudit",
                table: "HolderAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_KeeperAudit_rev",
                schema: "appAudit",
                table: "KeeperAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionAudit_rev",
                schema: "appAudit",
                table: "TransactionAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItemAudit_accountId",
                schema: "appAudit",
                table: "TransactionItemAudit",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItemAudit_rev",
                schema: "appAudit",
                table: "TransactionItemAudit",
                column: "rev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "AccountTypeAccountTypeLinkAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "AccountTypeAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "CurrencyAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "HolderAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "KeeperAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "TransactionAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "TransactionItemAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "AuditRevisionEntity",
                schema: "appAudit");
        }
    }
}
