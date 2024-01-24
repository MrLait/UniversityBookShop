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
    [Migration("20240123201222_InitThird")]
    partial class InitThird
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
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksAvailableForFaculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("BooksPurchasedByUniversityId")
                        .HasColumnType("int");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPurchased")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("BooksPurchasedByUniversityId");

                    b.HasIndex("FacultyId")
                        .IsUnique();

                    b.ToTable("books_available_for_faculty", (string)null);
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.HasIndex("UniversityId")
                        .IsUnique();

                    b.ToTable("books_purchased_by_university", (string)null);
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
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.PurchasedBookFaculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BookPurchasedBookFacultyId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int?>("FacultyPurchasedBookFacultyId")
                        .HasColumnType("int")
                        .HasColumnName("faculty_id");

                    b.HasKey("Id");

                    b.HasIndex("BookPurchasedBookFacultyId")
                        .IsUnique();

                    b.HasIndex("FacultyPurchasedBookFacultyId")
                        .IsUnique();

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
                        .WithOne("BooksAvailableForFaculty")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.BooksAvailableForFaculty", "BookId");

                    b.HasOne("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", "BooksPurchasedByUniversity")
                        .WithMany("BooksAvailableForFaculty")
                        .HasForeignKey("BooksPurchasedByUniversityId");

                    b.HasOne("UniversityBookShop.Domain.Entities.Faculty", "Faculty")
                        .WithOne("BooksAvailableForFaculty")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.BooksAvailableForFaculty", "FacultyId");

                    b.Navigation("Book");

                    b.Navigation("BooksPurchasedByUniversity");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", b =>
                {
                    b.HasOne("UniversityBookShop.Domain.Entities.Book", "Book")
                        .WithOne("BooksPurchasedByUniversity")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", "BookId");

                    b.HasOne("UniversityBookShop.Domain.Entities.University", "University")
                        .WithOne("BooksPurchasedByUniversity")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", "UniversityId");

                    b.Navigation("Book");

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
                        .WithOne("PurchasedBookFaculty")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.PurchasedBookFaculty", "BookPurchasedBookFacultyId");

                    b.HasOne("UniversityBookShop.Domain.Entities.Faculty", "Faculty")
                        .WithOne("PurchasedBookFaculty")
                        .HasForeignKey("UniversityBookShop.Domain.Entities.PurchasedBookFaculty", "FacultyPurchasedBookFacultyId");

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

                    b.Navigation("BooksPurchasedByUniversity");

                    b.Navigation("PurchasedBookFaculty");
                });

            modelBuilder.Entity("UniversityBookShop.Domain.Entities.BooksPurchasedByUniversity", b =>
                {
                    b.Navigation("BooksAvailableForFaculty");
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
                    b.Navigation("BooksPurchasedByUniversity");

                    b.Navigation("Faculties");
                });
#pragma warning restore 612, 618
        }
    }
}
