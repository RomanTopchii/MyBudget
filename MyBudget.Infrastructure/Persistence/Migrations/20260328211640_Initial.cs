using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MyBudget.Infrastructure.Persistence.Migrations.Queries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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

            migrationBuilder.EnsureSchema(
                name: "appAudit");

            migrationBuilder.CreateTable(
                name: "AccountType",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    classification = table.Column<int>(type: "integer", nullable: true),
                    hasCurrency = table.Column<bool>(type: "boolean", nullable: false),
                    hasHolder = table.Column<bool>(type: "boolean", nullable: false),
                    hasKeeper = table.Column<bool>(type: "boolean", nullable: false),
                    linkedAccountTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    hasInitialBalance = table.Column<bool>(type: "boolean", nullable: false),
                    calcFullTimeBalance = table.Column<bool>(type: "boolean", nullable: false),
                    canBeDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    canChangeActiveStatus = table.Column<bool>(type: "boolean", nullable: false),
                    canBeRenamed = table.Column<bool>(type: "boolean", nullable: false),
                    canBeCreatedByUser = table.Column<bool>(type: "boolean", nullable: false),
                    checkAmountBeforeDeactivate = table.Column<bool>(type: "boolean", nullable: false),
                    allowsTransactions = table.Column<bool>(type: "boolean", nullable: false),
                    keeperGroup = table.Column<short>(type: "smallint", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.id);
                    table.ForeignKey(
                        name: "FK_AccountType_AccountType_linkedAccountTypeId",
                        column: x => x.linkedAccountTypeId,
                        principalSchema: "app",
                        principalTable: "AccountType",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AuditRevisionEntity",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    revisionDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    autor = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditRevisionEntity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false),
                    iso4217 = table.Column<int>(type: "integer", nullable: false),
                    isAccounting = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    comment = table.Column<string>(type: "varchar(255)", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ancestorId = table.Column<Guid>(type: "uuid", nullable: false),
                    childId = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true)
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
                name: "AccountAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    parentId = table.Column<Guid>(type: "uuid", nullable: true),
                    parentId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    typeId = table.Column<Guid>(type: "uuid", nullable: true),
                    typeId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    currencyId = table.Column<Guid>(type: "uuid", nullable: true),
                    currencyId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    holderId = table.Column<Guid>(type: "uuid", nullable: true),
                    holderId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    keeperId = table.Column<Guid>(type: "uuid", nullable: true),
                    keeperId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    linkedAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    linkedAccountId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ancestorId = table.Column<Guid>(type: "uuid", nullable: true),
                    ancestorId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    childId = table.Column<Guid>(type: "uuid", nullable: true),
                    childId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    classification = table.Column<int>(type: "integer", nullable: true),
                    classification_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    hasCurrency = table.Column<bool>(type: "boolean", nullable: true),
                    hasCurrency_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    hasHolder = table.Column<bool>(type: "boolean", nullable: true),
                    hasHolder_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    hasKeeper = table.Column<bool>(type: "boolean", nullable: true),
                    hasKeeper_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    linkedAccountTypeId = table.Column<Guid>(type: "uuid", nullable: true),
                    linkedAccountTypeId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    hasInitialBalance = table.Column<bool>(type: "boolean", nullable: true),
                    hasInitialBalance_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    calcFullTimeBalance = table.Column<bool>(type: "boolean", nullable: true),
                    calcFullTimeBalance_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    canBeDeleted = table.Column<bool>(type: "boolean", nullable: true),
                    canBeDeleted_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    canChangeActiveStatus = table.Column<bool>(type: "boolean", nullable: true),
                    canChangeActiveStatus_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    canBeRenamed = table.Column<bool>(type: "boolean", nullable: true),
                    canBeRenamed_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    canBeCreatedByUser = table.Column<bool>(type: "boolean", nullable: true),
                    canBeCreatedByUser_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    checkAmountBeforeDeactivate = table.Column<bool>(type: "boolean", nullable: true),
                    checkAmountBeforeDeactivate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    allowsTransactions = table.Column<bool>(type: "boolean", nullable: true),
                    allowsTransactions_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    keeperGroup = table.Column<short>(type: "smallint", nullable: true),
                    keeperGroup_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: true),
                    priority_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: true),
                    code_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    iso4217 = table.Column<int>(type: "integer", nullable: true),
                    iso4217_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    isAccounting = table.Column<bool>(type: "boolean", nullable: true),
                    isAccounting_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: true),
                    name_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp", nullable: true),
                    date_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: true),
                    status_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    comment = table.Column<string>(type: "varchar(255)", nullable: true),
                    comment_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                name: "Account",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parentId = table.Column<Guid>(type: "uuid", nullable: true),
                    typeId = table.Column<Guid>(type: "uuid", nullable: false),
                    currencyId = table.Column<Guid>(type: "uuid", nullable: true),
                    holderId = table.Column<Guid>(type: "uuid", nullable: true),
                    keeperId = table.Column<Guid>(type: "uuid", nullable: true),
                    linkedAccountId = table.Column<Guid>(type: "uuid", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
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
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    accountId = table.Column<Guid>(type: "uuid", nullable: false),
                    transactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TransactionItemAudit",
                schema: "appAudit",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<double>(type: "double precision", nullable: true),
                    amount_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    type = table.Column<short>(type: "smallint", nullable: true),
                    type_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    accountId = table.Column<Guid>(type: "uuid", nullable: true),
                    accountId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    Account_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    transactionId = table.Column<Guid>(type: "uuid", nullable: true),
                    transactionId_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    rev = table.Column<long>(type: "bigint", nullable: false),
                    RevType = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    active_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    createDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    createdBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    createdBy_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifyDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modifyDate_MOD = table.Column<bool>(type: "boolean", nullable: true),
                    modifiedBy = table.Column<string>(type: "varchar(255)", nullable: true),
                    modifiedBy_MOD = table.Column<bool>(type: "boolean", nullable: true)
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
                name: "IX_AccountAudit_rev",
                schema: "appAudit",
                table: "AccountAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_linkedAccountTypeId",
                schema: "app",
                table: "AccountType",
                column: "linkedAccountTypeId");

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
                name: "IX_CurrencyAudit_rev",
                schema: "appAudit",
                table: "CurrencyAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_Holder_name",
                schema: "app",
                table: "Holder",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HolderAudit_rev",
                schema: "appAudit",
                table: "HolderAudit",
                column: "rev");

            migrationBuilder.CreateIndex(
                name: "IX_Keeper_name",
                schema: "app",
                table: "Keeper",
                column: "name",
                unique: true);

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
                name: "IX_TransactionItem_accountId",
                schema: "app",
                table: "TransactionItem",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_transactionId",
                schema: "app",
                table: "TransactionItem",
                column: "transactionId");

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
            
            migrationBuilder.Sql(InitiateCurrency.Query);
            migrationBuilder.Sql(InitiateAccountType.Query);
            migrationBuilder.Sql(InitiateAccountTypeAccountTypeLinks.Query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "AccountTypeAccountTypeLink",
                schema: "app");

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
                name: "TransactionItem",
                schema: "app");

            migrationBuilder.DropTable(
                name: "TransactionItemAudit",
                schema: "appAudit");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "app");

            migrationBuilder.DropTable(
                name: "AuditRevisionEntity",
                schema: "appAudit");

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
