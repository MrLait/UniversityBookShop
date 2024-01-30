using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTableBooksPurchasedByUniversity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_available_for_faculty_books_purchased_by_university_Bo~",
                table: "books_available_for_faculty");

            migrationBuilder.DropTable(
                name: "books_purchased_by_university");

            migrationBuilder.DropIndex(
                name: "IX_books_available_for_faculty_BooksPurchasedByUniversityId",
                table: "books_available_for_faculty");

            migrationBuilder.DropColumn(
                name: "BooksPurchasedByUniversityId",
                table: "books_available_for_faculty");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BooksPurchasedByUniversityId",
                table: "books_available_for_faculty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "books_purchased_by_university",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_books_available_for_faculty_BooksPurchasedByUniversityId",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_books_purchased_by_university_BookId",
                table: "books_purchased_by_university",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_books_purchased_by_university_UniversityId",
                table: "books_purchased_by_university",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_available_for_faculty_books_purchased_by_university_Bo~",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId",
                principalTable: "books_purchased_by_university",
                principalColumn: "Id");
        }
    }
}
