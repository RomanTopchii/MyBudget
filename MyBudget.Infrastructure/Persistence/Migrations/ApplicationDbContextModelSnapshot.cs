﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBudget.Infrastructure.Persistence;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Cyrillic_General_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBudget.Domain.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<Guid?>("CurrencyId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("currencyId");

                    b.Property<Guid?>("HolderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("holderId");

                    b.Property<Guid?>("KeeperId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("keeperId");

                    b.Property<Guid?>("LinkedAccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("linkedAccountId");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("parentId");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("typeId");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("HolderId");

                    b.HasIndex("KeeperId");

                    b.HasIndex("LinkedAccountId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TypeId");

                    b.ToTable("Account", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.AccountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<bool>("AllowsTransactions")
                        .HasColumnType("bit")
                        .HasColumnName("allowsTransactions");

                    b.Property<bool>("CalcFullTimeBalance")
                        .HasColumnType("bit")
                        .HasColumnName("calcFullTimeBalance");

                    b.Property<bool>("CanBeCreatedByUser")
                        .HasColumnType("bit")
                        .HasColumnName("canBeCreatedByUser");

                    b.Property<bool>("CanBeDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("canBeDeleted");

                    b.Property<bool>("CanBeRenamed")
                        .HasColumnType("bit")
                        .HasColumnName("canBeRenamed");

                    b.Property<bool>("CanChangeActiveStatus")
                        .HasColumnType("bit")
                        .HasColumnName("canChangeActiveStatus");

                    b.Property<bool>("CheckAmountBeforeDeactivate")
                        .HasColumnType("bit")
                        .HasColumnName("checkAmountBeforeDeactivate");

                    b.Property<int?>("Classification")
                        .HasColumnType("int")
                        .HasColumnName("classification");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<bool>("HasCurrency")
                        .HasColumnType("bit")
                        .HasColumnName("hasCurrency");

                    b.Property<bool>("HasHolder")
                        .HasColumnType("bit")
                        .HasColumnName("hasHolder");

                    b.Property<bool>("HasInitialBalance")
                        .HasColumnType("bit")
                        .HasColumnName("hasInitialBalance");

                    b.Property<bool>("HasKeeper")
                        .HasColumnType("bit")
                        .HasColumnName("hasKeeper");

                    b.Property<bool>("HasLinkedAccount")
                        .HasColumnType("bit")
                        .HasColumnName("hasLinkedAccount");

                    b.Property<short>("KeeperGroup")
                        .HasColumnType("smallint")
                        .HasColumnName("keeperGroup");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("Priority")
                        .HasColumnType("int")
                        .HasColumnName("priority");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("AccountType", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.AccountTypeAccountTypeLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<Guid>("AncestorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ancestorId");

                    b.Property<Guid>("ChildId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("childId");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("AncestorId", "ChildId")
                        .IsUnique();

                    b.ToTable("AccountTypeAccountTypeLink", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("code");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<bool>("IsAccounting")
                        .HasColumnType("bit");

                    b.Property<int>("Iso4217")
                        .HasColumnType("int")
                        .HasColumnName("iso4217");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("Iso4217")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Currency", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.Holder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Holder", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.Keeper", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Keeper", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("comment");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnName("status");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Transaction", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.TransactionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("accountId");

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<double>("Amount")
                        .HasColumnType("float")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("createDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("createdBy");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime")
                        .HasColumnName("modifyDate");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("transactionId");

                    b.Property<short>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionItem", "app");
                });

            modelBuilder.Entity("MyBudget.Domain.Account", b =>
                {
                    b.HasOne("MyBudget.Domain.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyBudget.Domain.Holder", "Holder")
                        .WithMany("Accounts")
                        .HasForeignKey("HolderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyBudget.Domain.Keeper", "Keeper")
                        .WithMany("Accounts")
                        .HasForeignKey("KeeperId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyBudget.Domain.Account", "LinkedAccount")
                        .WithMany()
                        .HasForeignKey("LinkedAccountId");

                    b.HasOne("MyBudget.Domain.Account", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyBudget.Domain.AccountType", "Type")
                        .WithMany("Accounts")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Holder");

                    b.Navigation("Keeper");

                    b.Navigation("LinkedAccount");

                    b.Navigation("Parent");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("MyBudget.Domain.AccountTypeAccountTypeLink", b =>
                {
                    b.HasOne("MyBudget.Domain.AccountType", "Ancestor")
                        .WithMany("AncestorAccountTypeLinks")
                        .HasForeignKey("AncestorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyBudget.Domain.AccountType", "Child")
                        .WithMany("ChildAccountTypeLinks")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ancestor");

                    b.Navigation("Child");
                });

            modelBuilder.Entity("MyBudget.Domain.TransactionItem", b =>
                {
                    b.HasOne("MyBudget.Domain.Account", "Account")
                        .WithMany("TransactionItems")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MyBudget.Domain.Transaction", "Transaction")
                        .WithMany("TransactionItems")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("MyBudget.Domain.Account", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("TransactionItems");
                });

            modelBuilder.Entity("MyBudget.Domain.AccountType", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("AncestorAccountTypeLinks");

                    b.Navigation("ChildAccountTypeLinks");
                });

            modelBuilder.Entity("MyBudget.Domain.Currency", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MyBudget.Domain.Holder", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MyBudget.Domain.Keeper", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("MyBudget.Domain.Transaction", b =>
                {
                    b.Navigation("TransactionItems");
                });
#pragma warning restore 612, 618
        }
    }
}
