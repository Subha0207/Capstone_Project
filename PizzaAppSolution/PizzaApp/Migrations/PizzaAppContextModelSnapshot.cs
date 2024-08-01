﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaApp.Contexts;

#nullable disable

namespace PizzaApp.Migrations
{
    [DbContext(typeof(PizzaAppContext))]
    partial class PizzaAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PizzaApp.Models.Beverage", b =>
                {
                    b.Property<int>("BeverageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BeverageId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Volume")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("BeverageId");

                    b.ToTable("Beverages");

                    b.HasData(
                        new
                        {
                            BeverageId = 1,
                            Cost = 30m,
                            Description = "A classic soft drink.",
                            Image = "https://images.unsplash.com/photo-1554866585-cd94860890b7?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = false,
                            IsBestSeller = true,
                            Name = "Coca Cola",
                            UploadDate = new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Volume = "200ml"
                        },
                        new
                        {
                            BeverageId = 2,
                            Cost = 19m,
                            Description = "Popular cola drink.",
                            Image = "https://images.unsplash.com/photo-1553456558-aff63285bdd1?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = false,
                            IsBestSeller = false,
                            Name = "Pepsi",
                            UploadDate = new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Volume = "100ml"
                        },
                        new
                        {
                            BeverageId = 3,
                            Cost = 29m,
                            Description = "Refreshing lemon-lime soda.",
                            Image = "https://images.unsplash.com/photo-1690988109041-458628590a9e?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = false,
                            IsBestSeller = false,
                            Name = "Sprite",
                            UploadDate = new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Volume = "200ml"
                        },
                        new
                        {
                            BeverageId = 4,
                            Cost = 39m,
                            Description = "Fruity orange soda.",
                            Image = "https://media.istockphoto.com/id/509533066/photo/fanta-orange-can.jpg?s=612x612&w=0&k=20&c=sbii6ppPvyuny-v0mx9xizy0QppblYH3sEvPLBr31tA=",
                            IsAvailable = false,
                            IsBestSeller = true,
                            Name = "Fanta",
                            UploadDate = new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Volume = "500ml"
                        },
                        new
                        {
                            BeverageId = 5,
                            Cost = 69m,
                            Description = "Citrus-flavored soda.",
                            Image = "https://images.unsplash.com/photo-1632134547266-ab2cb69602a1?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = false,
                            IsBestSeller = false,
                            Name = "Mountain Dew",
                            UploadDate = new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Volume = "1000ml"
                        });
                });

            modelBuilder.Entity("PizzaApp.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartId"), 1L, 1);

                    b.Property<bool>("IsCheckedOut")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("PizzaApp.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"), 1L, 1);

                    b.Property<decimal?>("BeverageCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BeverageDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BeverageFinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BeverageId")
                        .HasColumnType("int");

                    b.Property<int?>("BeverageQuantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("BeverageTotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("CrustId")
                        .HasColumnType("int");

                    b.Property<decimal?>("PizzaCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PizzaDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PizzaFinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("PizzaId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaQuantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("PizzaTotalPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("ToppingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("CrustId");

                    b.HasIndex("PizzaId");

                    b.HasIndex("SizeId");

                    b.HasIndex("ToppingId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("PizzaApp.Models.Crust", b =>
                {
                    b.Property<int>("CrustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrustId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CrustMultiplier")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("CrustId");

                    b.ToTable("Crusts");

                    b.HasData(
                        new
                        {
                            CrustId = 1,
                            Cost = 1m,
                            CrustMultiplier = 1m,
                            Name = 0
                        },
                        new
                        {
                            CrustId = 2,
                            Cost = 1m,
                            CrustMultiplier = 1.2m,
                            Name = 1
                        },
                        new
                        {
                            CrustId = 3,
                            Cost = 1m,
                            CrustMultiplier = 1.4m,
                            Name = 2
                        });
                });

            modelBuilder.Entity("PizzaApp.Models.DTOs.UserDTO", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("UserDTO");
                });

            modelBuilder.Entity("PizzaApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentId1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CartId");

                    b.HasIndex("PaymentId1");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaApp.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PizzaApp.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PizzaId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBestSeller")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PizzaId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            PizzaId = 1,
                            Cost = 199m,
                            Description = "Classic Margherita pizza with fresh mozzarella and basil.",
                            Image = "https://images.unsplash.com/photo-1544982503-9f984c14501a?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = true,
                            IsBestSeller = true,
                            IsVeg = true,
                            Name = "Margherita",
                            UploadDate = new DateTime(2024, 8, 1, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200)
                        },
                        new
                        {
                            PizzaId = 2,
                            Cost = 209m,
                            Description = "Pepperoni pizza with a crispy crust and rich tomato sauce.",
                            Image = "https://plus.unsplash.com/premium_photo-1661762555601-47d088a26b50?q=80&w=1792&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = true,
                            IsBestSeller = true,
                            IsVeg = false,
                            Name = "Pepperoni",
                            UploadDate = new DateTime(2024, 7, 19, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200)
                        },
                        new
                        {
                            PizzaId = 3,
                            Cost = 149m,
                            Description = "Loaded with fresh vegetables and a savory sauce.",
                            Image = "https://images.unsplash.com/photo-1593560708920-61dd98c46a4e?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = true,
                            IsBestSeller = false,
                            IsVeg = true,
                            Name = "Vegetarian Supreme",
                            UploadDate = new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200)
                        },
                        new
                        {
                            PizzaId = 4,
                            Cost = 299m,
                            Description = "Grilled chicken with BBQ sauce and red onions.",
                            Image = "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            IsAvailable = true,
                            IsBestSeller = false,
                            IsVeg = false,
                            Name = "BBQ Chicken",
                            UploadDate = new DateTime(2024, 7, 10, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200)
                        },
                        new
                        {
                            PizzaId = 5,
                            Cost = 279m,
                            Description = "Sweet pineapple and ham with a cheesy base.",
                            Image = "https://media.istockphoto.com/id/1442417585/photo/person-getting-a-piece-of-cheesy-pepperoni-pizza.jpg?s=1024x1024&w=is&k=20&c=faq73viCFGvfpKxcBuHcOI8kyT99B-p-jScipke-VuQ=",
                            IsAvailable = true,
                            IsBestSeller = false,
                            IsVeg = false,
                            Name = "Hawaiian",
                            UploadDate = new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200)
                        });
                });

            modelBuilder.Entity("PizzaApp.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<decimal>("SizeMultiplier")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SizeId");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            SizeId = 1,
                            Cost = 1m,
                            Name = 0,
                            SizeMultiplier = 1m
                        },
                        new
                        {
                            SizeId = 2,
                            Cost = 1m,
                            Name = 1,
                            SizeMultiplier = 1.2m
                        },
                        new
                        {
                            SizeId = 3,
                            Cost = 1m,
                            Name = 2,
                            SizeMultiplier = 1.4m
                        });
                });

            modelBuilder.Entity("PizzaApp.Models.Topping", b =>
                {
                    b.Property<int>("ToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ToppingId"), 1L, 1);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("ToppingId");

                    b.ToTable("Toppings");

                    b.HasData(
                        new
                        {
                            ToppingId = 2,
                            Cost = 29m,
                            Name = 1
                        },
                        new
                        {
                            ToppingId = 3,
                            Cost = 15m,
                            Name = 2
                        },
                        new
                        {
                            ToppingId = 4,
                            Cost = 20m,
                            Name = 3
                        });
                });

            modelBuilder.Entity("PizzaApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PizzaApp.Models.CartItem", b =>
                {
                    b.HasOne("PizzaApp.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaApp.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaApp.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId");

                    b.HasOne("PizzaApp.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaApp.Models.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Crust");

                    b.Navigation("Pizza");

                    b.Navigation("Size");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaApp.Models.Order", b =>
                {
                    b.HasOne("PizzaApp.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaApp.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaApp.Models.DTOs.UserDTO", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PizzaApp.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });
#pragma warning restore 612, 618
        }
    }
}
