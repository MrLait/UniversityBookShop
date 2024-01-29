using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BooksPurchasedByUniversity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksPurchasedByUniversities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UniversityId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksPurchasedByUniversities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BooksPurchasedByUniversities_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BooksPurchasedByUniversities_Universities_UniversityId",
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
                name: "IX_BooksPurchasedByUniversities_BookId",
                table: "BooksPurchasedByUniversities",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksPurchasedByUniversities_UniversityId",
                table: "BooksPurchasedByUniversities",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_available_for_faculty_BooksPurchasedByUniversities_Boo~",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId",
                principalTable: "BooksPurchasedByUniversities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_available_for_faculty_BooksPurchasedByUniversities_Boo~",
                table: "books_available_for_faculty");

            migrationBuilder.DropTable(
                name: "BooksPurchasedByUniversities");

            migrationBuilder.DropIndex(
                name: "IX_books_available_for_faculty_BooksPurchasedByUniversityId",
                table: "books_available_for_faculty");
        }
    }
}
