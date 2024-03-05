﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ShopDbContextcs))]
    [Migration("20240303175248_updatedefaultproducts")]
    partial class updatedefaultproducts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Електроніка"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Хобі та спорт"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Мода і стиль"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Дім і сад"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Дитячі товари"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Транспорт"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Нерухомість"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Будівництво та ремонт"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Робота"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Послуги"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Віддам безкоштовно"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Оренда та прокат"
                        });
                });

            modelBuilder.Entity("Data.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Districts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Aвтономна Республiка Крим"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Вінницька"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Волинська"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Днiпропетровська"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Донецька"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Житомирська"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Закарпатська"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Запорiзька"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Iвано-Франкiвська"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Київська"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Кiровоградська"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Луганська"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Львiвська"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Миколаївська"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Одеська"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Полтавська"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Рiвненська"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Сумська"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Тернопiльська"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Харкiвська"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Херсонська"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Хмельницька"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Черкаська"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Чернiвецька"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Чернiгiвська"
                        });
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("D_Up_one")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("D_Up_seven")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("D_VIP")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal?>("Discout")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsUp_one")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsUp_seven")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVIP")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            D_VIP = new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DistrictId = 17,
                            ImageUrl = "https://image.ceneostatic.pl/data/products/97863463/i-apple-iphone-13-128gb-polnoc.jpg",
                            InStock = false,
                            Name = "iPhone 13 ",
                            Price = 37600m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            D_VIP = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            DistrictId = 17,
                            ImageUrl = "https://m.media-amazon.com/images/I/61h1ijknqhL._AC_SL1179_.jpg",
                            InStock = false,
                            Name = "Nike Monarh",
                            Price = 2600m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            D_VIP = new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            DistrictId = 17,
                            ImageUrl = "https://dedra.pl/eng_pl_Sand-shovel-with-metal-shaft-PCV-handle-26346_1.webp",
                            InStock = false,
                            Name = "Shovel",
                            Price = 2000m
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            D_VIP = new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            DistrictId = 17,
                            ImageUrl = "https://a.allegroimg.com/original/11607f/4b5e2f7b48ae92e420b90510ce2f/Magic-Yoyo-Y03-Profesjonalne-Yoyo-High-sp",
                            InStock = false,
                            Name = "Yoyo",
                            Price = 500m
                        });
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Product", b =>
                {
                    b.HasOne("Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.District", "District")
                        .WithMany("Products")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");

                    b.Navigation("Category");

                    b.Navigation("District");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Entities.District", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}