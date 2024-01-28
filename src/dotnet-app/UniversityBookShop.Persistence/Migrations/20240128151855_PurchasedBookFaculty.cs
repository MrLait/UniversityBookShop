using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PurchasedBookFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchased_books_faculty_Books_BookId",
                table: "purchased_books_faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_purchased_books_faculty_Faculties_FacultyId",
                table: "purchased_books_faculty");

            migrationBuilder.DropIndex(
                name: "IX_purchased_books_faculty_BookId",
                table: "purchased_books_faculty");

            migrationBuilder.DropIndex(
                name: "IX_purchased_books_faculty_FacultyId",
                table: "purchased_books_faculty");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_BookId",
                table: "purchased_books_faculty",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_FacultyId",
                table: "purchased_books_faculty",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchased_books_faculty_Books_BookId",
                table: "purchased_books_faculty",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchased_books_faculty_Faculties_FacultyId",
                table: "purchased_books_faculty",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchased_books_faculty_Books_BookId",
                table: "purchased_books_faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_purchased_books_faculty_Faculties_FacultyId",
                table: "purchased_books_faculty");

            migrationBuilder.DropIndex(
                name: "IX_purchased_books_faculty_BookId",
                table: "purchased_books_faculty");

            migrationBuilder.DropIndex(
                name: "IX_purchased_books_faculty_FacultyId",
                table: "purchased_books_faculty");

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_BookId",
                table: "purchased_books_faculty",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchased_books_faculty_FacultyId",
                table: "purchased_books_faculty",
                column: "FacultyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_purchased_books_faculty_Books_BookId",
                table: "purchased_books_faculty",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchased_books_faculty_Faculties_FacultyId",
                table: "purchased_books_faculty",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id");
        }
    }
}
