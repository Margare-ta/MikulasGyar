﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MikulasGyar;

#nullable disable

namespace MikulasGyar.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241205125815_DbInitUpdate")]
    partial class DbInitUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("KidToy", b =>
                {
                    b.Property<int>("KidsId")
                        .HasColumnType("int");

                    b.Property<int>("ToysId")
                        .HasColumnType("int");

                    b.HasKey("KidsId", "ToysId");

                    b.HasIndex("ToysId");

                    b.ToTable("KidToy");
                });

            modelBuilder.Entity("MikulasGyar.Kid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("WasGood")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("MikulasGyar.Toy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("KidToy", b =>
                {
                    b.HasOne("MikulasGyar.Kid", null)
                        .WithMany()
                        .HasForeignKey("KidsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MikulasGyar.Toy", null)
                        .WithMany()
                        .HasForeignKey("ToysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}