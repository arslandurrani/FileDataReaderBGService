﻿// <auto-generated />
using System;
using FileDataReaderBGService.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FileDataReaderBGService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("FileDataReaderBGService.Entities.ELDEvents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("Enginestate")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longtitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Odometer")
                        .HasColumnType("REAL");

                    b.Property<double>("RPM")
                        .HasColumnType("REAL");

                    b.Property<double>("Speed")
                        .HasColumnType("REAL");

                    b.Property<double>("TripDistance")
                        .HasColumnType("REAL");

                    b.Property<string>("VIN")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ELDEvents");
                });

            modelBuilder.Entity("FileDataReaderBGService.Entities.ELDEventsServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("Enginestate")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longtitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Odometer")
                        .HasColumnType("REAL");

                    b.Property<double>("RPM")
                        .HasColumnType("REAL");

                    b.Property<double>("Speed")
                        .HasColumnType("REAL");

                    b.Property<double>("TripDistance")
                        .HasColumnType("REAL");

                    b.Property<Guid>("Unique_Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("VIN")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ELDEventsServer");
                });
#pragma warning restore 612, 618
        }
    }
}
