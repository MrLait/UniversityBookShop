﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityBookShop.Persistence;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240312130700_InitialBookData")]
    partial class InitialBookData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("CurrencyCodesId")
                        .HasColumnType("int")
                        .HasColumnName("currency_code_id");

                    b.Property<string>("Isbn")
                        .HasMaxLength(17)
                        .HasColumnType("varchar(17)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCodesId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Alice Starlight",
                            CurrencyCodesId = 1,
                            Isbn = "123456789012",
                            Name = "The Hidden Galaxy",
                            Price = 10m
                        },
                        new
                        {
                            Id = 2,
                            Author = "David Nebula",
                            CurrencyCodesId = 1,
                            Isbn = "234567890123",
                            Name = "Echoes of Eternity",
                            Price = 15m
                        },
                        new
                        {
                            Id = 3,
                            Author = "Mia Moonshade",
                            CurrencyCodesId = 1,
                            Isbn = "345678901234",
                            Name = "Serenade of Shadows",
                            Price = 20m
                        },
                        new
                        {
                            Id = 4,
                            Author = "Elijah Stardust",
                            CurrencyCodesId = 1,
                            Isbn = "456789012345",
                            Name = "Whispers in the Wind",
                            Price = 25m
                        },
                        new
                        {
                            Id = 5,
                            Author = "Isabella Dreamweaver",
                            CurrencyCodesId = 1,
                            Isbn = "567890123456",
                            Name = "The Enchanted Chronicles",
                            Price = 30m
                        },
                        new
                        {
                            Id = 6,
                            Author = "Oliver Starcrafter",
                            CurrencyCodesId = 1,
                            Isbn = "678901234567",
                            Name = "Chronicles of Arcadia",
                            Price = 35m
                        },
                        new
                        {
                            Id = 7,
                            Author = "Sophia Silverleaf",
                            CurrencyCodesId = 1,
                            Isbn = "789012345678",
                            Name = "Legends of Lumina",
                            Price = 40m
                        },
                        new
                        {
                            Id = 8,
                            Author = "Gabriel Nightshade",
                            CurrencyCodesId = 1,
                            Isbn = "890123456789",
                            Name = "Eternal Echoes",
                            Price = 45m
                        },
                        new
                        {
                            Id = 9,
                            Author = "Aria Stardancer",
                            CurrencyCodesId = 1,
                            Isbn = "901234567890",
                            Name = "Starlight Sonata",
                            Price = 50m
                        },
                        new
                        {
                            Id = 10,
                            Author = "Liam Shadowcaster",
                            CurrencyCodesId = 1,
                            Isbn = "012345678901",
                            Name = "Moonlit Whispers",
                            Price = 55m
                        },
                        new
                        {
                            Id = 11,
                            Author = "Serena Dreamweaver",
                            CurrencyCodesId = 1,
                            Isbn = "112233445566",
                            Name = "Wonders of Whimsy",
                            Price = 60m
                        },
                        new
                        {
                            Id = 12,
                            Author = "Lucas Starborn",
                            CurrencyCodesId = 1,
                            Isbn = "223344556677",
                            Name = "Stardust Serenade",
                            Price = 65m
                        },
                        new
                        {
                            Id = 13,
                            Author = "Aurora Celestia",
                            CurrencyCodesId = 1,
                            Isbn = "334455667788",
                            Name = "Realm of Radiance",
                            Price = 70m
                        },
                        new
                        {
                            Id = 14,
                            Author = "Xander Nightshade",
                            CurrencyCodesId = 1,
                            Isbn = "445566778899",
                            Name = "Midnight Mirage",
                            Price = 75m
                        },
                        new
                        {
                            Id = 15,
                            Author = "Fiona Starlight",
                            CurrencyCodesId = 1,
                            Isbn = "556677889900",
                            Name = "Twilight Tales",
                            Price = 80m
                        },
                        new
                        {
                            Id = 16,
                            Author = "Zane Moonshadow",
                            CurrencyCodesId = 1,
                            Isbn = "667788990011",
                            Name = "Cerulean Chronicles",
                            Price = 85m
                        },
                        new
                        {
                            Id = 17,
                            Author = "Elena Stardust",
                            CurrencyCodesId = 1,
                            Isbn = "778899001122",
                            Name = "Luminous Legends",
                            Price = 90m
                        },
                        new
                        {
                            Id = 18,
                            Author = "Orion Starcrafter",
                            CurrencyCodesId = 1,
                            Isbn = "889900112233",
                            Name = "Galactic Gala",
                            Price = 95m
                        });
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksAvailableForFaculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPurchased")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UniversityId");

                    b.ToTable("books_available_for_faculty", (string)null);
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.CurrencyCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id");

                    b.ToTable("currency_codes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "$"
                        },
                        new
                        {
                            Id = 2,
                            Code = "€"
                        });
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.PurchasedBookFaculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("FacultyId");

                    b.ToTable("purchased_books_faculty", (string)null);
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CurrencyCodesId")
                        .HasColumnType("int")
                        .HasColumnName("currency_code_id");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal?>("TotalBookPrice")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("total_book_price");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyCodesId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Book", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.CurrencyCode", "CurrencyCode")
                        .WithOne("Book")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.Book", "CurrencyCodesId");

                    b.Navigation("CurrencyCode");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksAvailableForFaculty", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.Book", "Book")
                        .WithMany("BooksAvailableForFaculty")
                        .HasForeignKey("BookId");

                    b.HasOne("UniversityBookShop.Domain.Entities.Faculty", "Faculty")
                        .WithMany("BooksAvailableForFaculty")
                        .HasForeignKey("FacultyId");

                    b.HasOne("UniversityBookShop.Domain.Entities.University", "University")
                        .WithMany("BooksAvailableForFaculties")
                        .HasForeignKey("UniversityId");

                    b.Navigation("Book");

                    b.Navigation("Faculty");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Faculty", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.PurchasedBookFaculty", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.Book", "Book")
                        .WithMany("PurchasedBookFaculty")
                        .HasForeignKey("BookId");

                    b.HasOne("UniversityBookShop.Domain.Entities.Faculty", "Faculty")
                        .WithMany("PurchasedBookFaculty")
                        .HasForeignKey("FacultyId");

                    b.Navigation("Book");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.University", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.CurrencyCode", "CurrencyCode")
                        .WithOne("University")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.University", "CurrencyCodesId");

                    b.Navigation("CurrencyCode");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Book", b =>
                {
                    b.Navigation("BooksAvailableForFaculty");

                    b.Navigation("PurchasedBookFaculty");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.CurrencyCode", b =>
                {
                    b.Navigation("Book");

                    b.Navigation("University");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.Faculty", b =>
                {
                    b.Navigation("BooksAvailableForFaculty");

                    b.Navigation("PurchasedBookFaculty");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.University", b =>
                {
                    b.Navigation("BooksAvailableForFaculties");

                    b.Navigation("Faculties");
                });
#pragma warning restore 612, 618
        }
    }
}
