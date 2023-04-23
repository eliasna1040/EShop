﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(EShopContext))]
    [Migration("20230422200616_nakjsdfnjkdsf")]
    partial class nakjsdfnjkdsf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Disabled = false,
                            Name = "bil"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "Hvor kragerne vender",
                            Admin = false,
                            Disabled = false,
                            Email = "test@test.test",
                            Name = "Elias",
                            Password = "P@ssw0rd"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImageId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = 1,
                            ImageData = new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 197, 0, 0, 0, 177, 8, 6, 0, 0, 0, 116, 139, 121, 39, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 18, 116, 0, 0, 18, 116, 1, 222, 102, 31, 120, 0, 0, 1, 199, 73, 68, 65, 84, 120, 94, 237, 211, 65, 13, 128, 64, 16, 192, 192, 5, 35, 235, 95, 37, 124, 46, 36, 84, 195, 204, 167, 10, 122, 237, 238, 51, 192, 231, 62, 5, 14, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 63, 51, 47, 28, 63, 2, 190, 66, 109, 163, 82, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Manufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ManufacturerId"));

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ManufacturerId");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            ManufacturerId = 1,
                            Disabled = false,
                            Name = "Mercedes-Benz"
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DataLayer.Entities.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disabled")
                        .HasColumnType("bit");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8:2)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId")
                        .IsUnique()
                        .HasFilter("[ImageId] IS NOT NULL");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 1,
                            Description = "en bil",
                            Disabled = false,
                            ManufacturerId = 1,
                            Name = "g63 amg",
                            Price = 2000000m
                        });
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.HasOne("DataLayer.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DataLayer.Entities.OrderProduct", b =>
                {
                    b.HasOne("DataLayer.Entities.Order", "Order")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Product", "Product")
                        .WithMany("OrdersProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.HasOne("DataLayer.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Entities.Image", "Image")
                        .WithOne("Product")
                        .HasForeignKey("DataLayer.Entities.Product", "ImageId");

                    b.HasOne("DataLayer.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("DataLayer.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DataLayer.Entities.Image", b =>
                {
                    b.Navigation("Product")
                        .IsRequired();
                });

            modelBuilder.Entity("DataLayer.Entities.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Entities.Order", b =>
                {
                    b.Navigation("OrdersProducts");
                });

            modelBuilder.Entity("DataLayer.Entities.Product", b =>
                {
                    b.Navigation("OrdersProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
