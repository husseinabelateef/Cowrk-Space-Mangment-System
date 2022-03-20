﻿// <auto-generated />
using System;
using Cowrk_Space_Mangment_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cowrk_Space_Mangment_System.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.AssignDeals", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<int>("DealID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DealID");

                    b.ToTable("AssignDeals");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.AssignPackage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableHours")
                        .HasColumnType("int");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("PackageID");

                    b.ToTable("AssignPackage");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsClient")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Chair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Availability")
                        .HasColumnType("bit");

                    b.Property<int>("Room_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Room_ID");

                    b.ToTable("Chair");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ChairReserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Chair_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("End_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reservation_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Chair_Id");

                    b.HasIndex("Reservation_Id")
                        .IsUnique();

                    b.ToTable("chairReserve");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Faculty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QR_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ClientCart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cart_Id")
                        .HasColumnType("int");

                    b.Property<int>("Reservation_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Cart_Id");

                    b.HasIndex("Reservation_ID");

                    b.ToTable("clientCart");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Deal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassOffer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoffeeMachineOffer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IndividualOrSharedOffer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PromoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Deal");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Drink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RawProID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("RawProID");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Incomming", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Receptionst_Id")
                        .HasColumnType("int");

                    b.Property<double>("ShiftCloseCateringIncome")
                        .HasColumnType("float");

                    b.Property<double>("ShiftCloseReservationIncome")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Receptionst_Id");

                    b.ToTable("Incomming");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Loging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LogOut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Login")
                        .HasColumnType("datetime2");

                    b.Property<int>("Receptionst_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RecpetionstId")
                        .HasColumnType("int");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecpetionstId");

                    b.ToTable("Loging");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Outgoing", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Reciption_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Reciption_ID");

                    b.ToTable("Outgoing");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Package", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NumberOfDays")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfHours")
                        .HasColumnType("int");

                    b.Property<string>("Offer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ActualAmount")
                        .HasColumnType("int");

                    b.Property<double>("ActualPrice")
                        .HasColumnType("float");

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SellingPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ProductMovments", b =>
                {
                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OutgoingID")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("ProductID", "OutgoingID");

                    b.HasIndex("OutgoingID");

                    b.ToTable("ProductMovments");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RawProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("ActualAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NOC")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("RefrenceCupWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("RawProduct");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RawProductMovments", b =>
                {
                    b.Property<int>("Raw_ProductID")
                        .HasColumnType("int");

                    b.Property<int>("OutgoingID")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("Raw_ProductID", "OutgoingID");

                    b.HasIndex("OutgoingID");

                    b.ToTable("RawProductMovments");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Receptionist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("SalaryPerHour")
                        .HasColumnType("float");

                    b.Property<int>("TotalHours")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Receptionist");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientCart_ID")
                        .HasColumnType("int");

                    b.Property<int>("Client_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpextedHours")
                        .HasColumnType("int");

                    b.Property<double>("Hours_Price")
                        .HasColumnType("float");

                    b.Property<int>("Receptionst_Id")
                        .HasColumnType("int");

                    b.Property<int?>("RecpetionstId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start_Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("ClientCart_ID");

                    b.HasIndex("Client_ID");

                    b.HasIndex("RecpetionstId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RoomReserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("End_Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("Reservation_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rooom_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Reservation_Id");

                    b.HasIndex("Rooom_Id");

                    b.ToTable("RoomReserve");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.AssignDeals", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Deal", "Deal")
                        .WithMany()
                        .HasForeignKey("DealID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Deal");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.AssignPackage", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Package", "package")
                        .WithMany()
                        .HasForeignKey("PackageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("package");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Chair", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Room", "Room")
                        .WithMany("Chairs")
                        .HasForeignKey("Room_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ChairReserve", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Chair", "Chair")
                        .WithMany("ChairReserves")
                        .HasForeignKey("Chair_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Reservation", "Reservation")
                        .WithOne("ChairReserves")
                        .HasForeignKey("Cowrk_Space_Mangment_System.Models.ChairReserve", "Reservation_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chair");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ClientCart", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("Cart_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("Reservation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Drink", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Product", "Product")
                        .WithMany("Drinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.RawProduct", "RawProduct")
                        .WithMany("Drinks")
                        .HasForeignKey("RawProID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("RawProduct");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Incomming", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Receptionist", "Receptionst")
                        .WithMany("Incommings")
                        .HasForeignKey("Receptionst_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Receptionst");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Loging", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Receptionist", "Recpetionst")
                        .WithMany()
                        .HasForeignKey("RecpetionstId");

                    b.Navigation("Recpetionst");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Outgoing", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Receptionist", "reciption")
                        .WithMany()
                        .HasForeignKey("Reciption_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("reciption");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Product", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartID");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.ProductMovments", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Outgoing", "Outgoing")
                        .WithMany("ProductMovments")
                        .HasForeignKey("OutgoingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Product", "Product")
                        .WithMany("ProductMovments")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outgoing");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RawProductMovments", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Outgoing", "Outgoing")
                        .WithMany("RawProductMovments")
                        .HasForeignKey("OutgoingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.RawProduct", "RawProduct")
                        .WithMany("RawProductMovments")
                        .HasForeignKey("Raw_ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Outgoing");

                    b.Navigation("RawProduct");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Reservation", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.ClientCart", "ClientCart")
                        .WithMany()
                        .HasForeignKey("ClientCart_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("Client_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Receptionist", "Recpetionst")
                        .WithMany()
                        .HasForeignKey("RecpetionstId");

                    b.Navigation("Client");

                    b.Navigation("ClientCart");

                    b.Navigation("Recpetionst");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RoomReserve", b =>
                {
                    b.HasOne("Cowrk_Space_Mangment_System.Models.Reservation", "Reservation")
                        .WithMany("RoomReserve")
                        .HasForeignKey("Reservation_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cowrk_Space_Mangment_System.Models.Room", "Room")
                        .WithMany("RoomReserve")
                        .HasForeignKey("Rooom_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Chair", b =>
                {
                    b.Navigation("ChairReserves");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Outgoing", b =>
                {
                    b.Navigation("ProductMovments");

                    b.Navigation("RawProductMovments");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Product", b =>
                {
                    b.Navigation("Drinks");

                    b.Navigation("ProductMovments");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.RawProduct", b =>
                {
                    b.Navigation("Drinks");

                    b.Navigation("RawProductMovments");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Receptionist", b =>
                {
                    b.Navigation("Incommings");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Reservation", b =>
                {
                    b.Navigation("ChairReserves");

                    b.Navigation("RoomReserve");
                });

            modelBuilder.Entity("Cowrk_Space_Mangment_System.Models.Room", b =>
                {
                    b.Navigation("Chairs");

                    b.Navigation("RoomReserve");
                });
#pragma warning restore 612, 618
        }
    }
}
