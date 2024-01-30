using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "currency_codes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currency_codes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Isbn = table.Column<string>(type: "varchar(17)", maxLength: 17, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    currency_code_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_currency_codes_currency_code_id",
                        column: x => x.currency_code_id,
                        principalTable: "currency_codes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    total_book_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    currency_code_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universities_currency_codes_currency_code_id",
                        column: x => x.currency_code_id,
                        principalTable: "currency_codes",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "books_purchased_by_university",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books_purchased_by_university", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_purchased_by_university_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_books_purchased_by_university_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculties_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "books_available_for_faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsPurchased = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    BooksPurchasedByUniversityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books_available_for_faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_available_for_faculty_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_books_available_for_faculty_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_books_available_for_faculty_books_purchased_by_university_Bo~",
                        column: x => x.BooksPurchasedByUniversityId,
                        principalTable: "books_purchased_by_university",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "purchased_books_faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    FacultyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchased_books_faculty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchased_books_faculty_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_purchased_books_faculty_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "currency_codes",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "$" },
                    { 2, "€" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_currency_code_id",
                table: "Books",
                column: "currency_code_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_available_for_faculty_BookId",
                table: "books_available_for_faculty",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_books_available_for_faculty_BooksPurchasedByUniversityId",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_books_available_for_faculty_FacultyId",
                table: "books_available_for_faculty",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_books_purchased_by_university_BookId",
                table: "books_purchased_by_university",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_books_purchased_by_university_UniversityId",
                table: "books_purchased_by_university",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_BookId",
                table: "purchased_books_faculty",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_FacultyId",
                table: "purchased_books_faculty",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_currency_code_id",
                table: "Universities",
                column: "currency_code_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books_available_for_faculty");

            migrationBuilder.DropTable(
                name: "purchased_books_faculty");

            migrationBuilder.DropTable(
                name: "books_purchased_by_university");

            migrationBuilder.DropTable(
                name: "Faculties");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "currency_codes");
        }
    }
}
