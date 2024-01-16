﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockCZ.Models;

#nullable disable

namespace StockCZ.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240115182324_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockCZ.Models.Item", b =>
                {
                    b.Property<int>("BaseId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BaseId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("StockCZ.Models.StockMovement", b =>
                {
                    b.Property<int>("BaseId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("BaseId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StoreId");

                    b.ToTable("StockMovements");
                });

            modelBuilder.Entity("StockCZ.Models.Store", b =>
                {
                    b.Property<int>("BaseId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BaseId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("StockCZ.Models.StockMovement", b =>
                {
                    b.HasOne("StockCZ.Models.Item", "Item")
                        .WithMany("StockMovements")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockCZ.Models.Store", "Store")
                        .WithMany("StockMovements")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("StockCZ.Models.Item", b =>
                {
                    b.Navigation("StockMovements");
                });

            modelBuilder.Entity("StockCZ.Models.Store", b =>
                {
                    b.Navigation("StockMovements");
                });
#pragma warning restore 612, 618
        }
    }
}
