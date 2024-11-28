﻿// <auto-generated />
using System;
using InterGalacticConflict.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterGalacticConflict.Data.Migrations
{
    [DbContext(typeof(InterGalacticConflictContext))]
    [Migration("20241128152956_12PlanetsSSs")]
    partial class _12PlanetsSSs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IntergalacticConflict.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlanetID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ShipID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("IntergalacticConflict.Core.Domain.Planet", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountOfShipsonPlanet")
                        .HasColumnType("int");

                    b.Property<string>("CapitalCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GalaxyID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Major_cities")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlanetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlanetPopulation")
                        .HasColumnType("int");

                    b.Property<int>("PlanetType")
                        .HasColumnType("int");

                    b.Property<string>("SpaceStation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpaceStationType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Planets");
                });

            modelBuilder.Entity("IntergalacticConflict.Core.Domain.Ship", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ballistic")
                        .HasColumnType("int");

                    b.Property<int>("BallisticPower")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Heavy_Laser")
                        .HasColumnType("int");

                    b.Property<int>("Heavy_LaserPower")
                        .HasColumnType("int");

                    b.Property<int>("Light_Laser")
                        .HasColumnType("int");

                    b.Property<int>("Light_LaserPower")
                        .HasColumnType("int");

                    b.Property<int>("Missile")
                        .HasColumnType("int");

                    b.Property<int>("MissilePower")
                        .HasColumnType("int");

                    b.Property<int>("ShipClass")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShipDestroyed")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShipExperience")
                        .HasColumnType("int");

                    b.Property<int>("ShipHP")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipStatus")
                        .HasColumnType("int");

                    b.Property<int>("Torpedo")
                        .HasColumnType("int");

                    b.Property<int>("TorpedoPower")
                        .HasColumnType("int");

                    b.Property<int>("Turbolaser")
                        .HasColumnType("int");

                    b.Property<int>("TurbolaserPower")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ships");
                });
#pragma warning restore 612, 618
        }
    }
}
