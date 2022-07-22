﻿// <auto-generated />
using System;
using AllupBackEndProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AllupBackEndProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220722154741_AddTagTable")]
    partial class AddTagTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AllupBackEndProject.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "banner-1.png"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "banner-2.png"
                        });
                });

            modelBuilder.Entity("AllupBackEndProject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UptadetAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 7, 22, 19, 47, 41, 58, DateTimeKind.Local).AddTicks(5465),
                            ImageUrl = "category-1.jpg",
                            IsDeleted = false,
                            Name = "Laptop"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 7, 22, 19, 47, 41, 59, DateTimeKind.Local).AddTicks(9568),
                            ImageUrl = "category-2.jpg",
                            IsDeleted = false,
                            Name = "Computer"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 7, 22, 19, 47, 41, 59, DateTimeKind.Local).AddTicks(9642),
                            ImageUrl = "category-3.jpg",
                            IsDeleted = false,
                            Name = "Smartphone"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "category-4.jpg",
                            IsDeleted = false,
                            Name = "Game Consoles"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "category-6.jpg",
                            IsDeleted = false,
                            Name = "Tops & Sets"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "category-7.jpg",
                            IsDeleted = false,
                            Name = "Audio & Video"
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2022, 7, 22, 19, 47, 41, 59, DateTimeKind.Local).AddTicks(9647),
                            ImageUrl = "category-8.jpg",
                            IsDeleted = false,
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "category-10.jpg",
                            IsDeleted = false,
                            Name = "Video Games"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Accessories & Parts",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Cables & Adapters",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "Batteries",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "Chargers",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 13,
                            IsDeleted = false,
                            Name = "Chargers",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 14,
                            IsDeleted = false,
                            Name = "Bags & Cases",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 15,
                            IsDeleted = false,
                            Name = "Electronic Cigarettes",
                            ParentId = 9
                        });
                });

            modelBuilder.Entity("AllupBackEndProject.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "slider-1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "slider-2.jpg"
                        });
                });

            modelBuilder.Entity("AllupBackEndProject.Models.SliderContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Offer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SliderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SliderId");

                    b.ToTable("SliderContents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform",
                            Name = "Fulldive VR.",
                            Offer = "Save $120 when you buy",
                            SliderId = 1,
                            Title = "2020 Virtual Reality"
                        },
                        new
                        {
                            Id = 2,
                            Desc = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform",
                            Name = "Sony Bravia.",
                            Offer = "Save $120 when you buy",
                            SliderId = 2,
                            Title = "4K HDR Smart TV 43"
                        });
                });

            modelBuilder.Entity("AllupBackEndProject.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Camera"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drone"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Memory"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gaming"
                        });
                });

            modelBuilder.Entity("AllupBackEndProject.Models.Category", b =>
                {
                    b.HasOne("AllupBackEndProject.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("AllupBackEndProject.Models.SliderContent", b =>
                {
                    b.HasOne("AllupBackEndProject.Models.Slider", "Slider")
                        .WithMany()
                        .HasForeignKey("SliderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}