﻿// <auto-generated />
using System;
using CruiseLover.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CruiseLover.DB.Migrations
{
    [DbContext(typeof(CLDbContext))]
    [Migration("20210314154432_AddedDiscountForCruiseDetails")]
    partial class AddedDiscountForCruiseDetails
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CruiseLover.DB.Entities.CruiseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<int?>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<bool>("HasDiscount")
                        .HasColumnType("bit");

                    b.Property<string>("Itinerary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nights")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ShipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId")
                        .IsUnique();

                    b.HasIndex("ShipId")
                        .IsUnique();

                    b.ToTable("CruiseDetails");
                });

            modelBuilder.Entity("CruiseLover.DB.Entities.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("CruiseLover.DB.Entities.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("CruiseLover.DB.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CruiseLover.DB.Entities.CruiseDetail", b =>
                {
                    b.HasOne("CruiseLover.DB.Entities.Destination", "Destination")
                        .WithOne("CruiseDetail")
                        .HasForeignKey("CruiseLover.DB.Entities.CruiseDetail", "DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CruiseLover.DB.Entities.Ship", "Ship")
                        .WithOne("CruiseDetail")
                        .HasForeignKey("CruiseLover.DB.Entities.CruiseDetail", "ShipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("CruiseLover.DB.Entities.Destination", b =>
                {
                    b.Navigation("CruiseDetail");
                });

            modelBuilder.Entity("CruiseLover.DB.Entities.Ship", b =>
                {
                    b.Navigation("CruiseDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
