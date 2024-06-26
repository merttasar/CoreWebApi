﻿// <auto-generated />
using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoreWebApi.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20240203131326_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("CoreWebApi.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            IsActive = true,
                            Price = 60000m,
                            ProductName = "Iphone 13"
                        },
                        new
                        {
                            ProductId = 2,
                            IsActive = true,
                            Price = 70000m,
                            ProductName = "Iphone 14"
                        },
                        new
                        {
                            ProductId = 3,
                            IsActive = false,
                            Price = 80000m,
                            ProductName = "Iphone 15"
                        },
                        new
                        {
                            ProductId = 4,
                            IsActive = true,
                            Price = 90000m,
                            ProductName = "Iphone 16"
                        },
                        new
                        {
                            ProductId = 5,
                            IsActive = true,
                            Price = 95000m,
                            ProductName = "Iphone 17"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
