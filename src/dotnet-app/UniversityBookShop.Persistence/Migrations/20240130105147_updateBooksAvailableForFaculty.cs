using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateBooksAvailableForFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_books_available_for_faculty_UniversityId",
                table: "books_available_for_faculty",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_available_for_faculty_Universities_UniversityId",
                table: "books_available_for_faculty",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_available_for_faculty_Universities_UniversityId",
                table: "books_available_for_faculty");

            migrationBuilder.DropIndex(
                name: "IX_books_available_for_faculty_UniversityId",
                table: "books_available_for_faculty");
        }
    }
}
