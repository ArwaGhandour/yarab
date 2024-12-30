﻿// <auto-generated />
using System;
using Bank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20241229203826_firstt")]
    partial class firstt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bank.Models.Entities.Accounts", b =>
                {
                    b.Property<int>("AccountsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountsID"));

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerIDD")
                        .HasColumnType("int");

                    b.HasKey("AccountsID");

                    b.HasIndex("CustomerIDD");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("Bank.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phonenumber")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Bank.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.Property<int>("AccountIDD")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Transdate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountIDD");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Bank.Models.Entities.Accounts", b =>
                {
                    b.HasOne("Bank.Models.Entities.Customer", "customer")
                        .WithMany("Accountss")
                        .HasForeignKey("CustomerIDD")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("customer");
                });

            modelBuilder.Entity("Bank.Models.Entities.Transaction", b =>
                {
                    b.HasOne("Bank.Models.Entities.Accounts", "Accounts")
                        .WithMany("transactions")
                        .HasForeignKey("AccountIDD")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Bank.Models.Entities.Accounts", b =>
                {
                    b.Navigation("transactions");
                });

            modelBuilder.Entity("Bank.Models.Entities.Customer", b =>
                {
                    b.Navigation("Accountss");
                });
#pragma warning restore 612, 618
        }
    }
}
