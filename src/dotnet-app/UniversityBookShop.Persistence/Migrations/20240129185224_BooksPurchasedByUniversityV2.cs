using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BooksPurchasedByUniversityV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_available_for_faculty_BooksPurchasedByUniversities_Boo~",
                table: "books_available_for_faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksPurchasedByUniversities_Books_BookId",
                table: "BooksPurchasedByUniversities");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksPurchasedByUniversities_Universities_UniversityId",
                table: "BooksPurchasedByUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksPurchasedByUniversities",
                table: "BooksPurchasedByUniversities");

            migrationBuilder.RenameTable(
                name: "BooksPurchasedByUniversities",
                newName: "books_purchased_by_university");

            migrationBuilder.RenameIndex(
                name: "IX_BooksPurchasedByUniversities_UniversityId",
                table: "books_purchased_by_university",
                newName: "IX_books_purchased_by_university_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksPurchasedByUniversities_BookId",
                table: "books_purchased_by_university",
                newName: "IX_books_purchased_by_university_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_books_purchased_by_university",
                table: "books_purchased_by_university",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_available_for_faculty_books_purchased_by_university_Bo~",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId",
                principalTable: "books_purchased_by_university",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_purchased_by_university_Books_BookId",
                table: "books_purchased_by_university",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_purchased_by_university_Universities_UniversityId",
                table: "books_purchased_by_university",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_available_for_faculty_books_purchased_by_university_Bo~",
                table: "books_available_for_faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_books_purchased_by_university_Books_BookId",
                table: "books_purchased_by_university");

            migrationBuilder.DropForeignKey(
                name: "FK_books_purchased_by_university_Universities_UniversityId",
                table: "books_purchased_by_university");

            migrationBuilder.DropPrimaryKey(
                name: "PK_books_purchased_by_university",
                table: "books_purchased_by_university");

            migrationBuilder.RenameTable(
                name: "books_purchased_by_university",
                newName: "BooksPurchasedByUniversities");

            migrationBuilder.RenameIndex(
                name: "IX_books_purchased_by_university_UniversityId",
                table: "BooksPurchasedByUniversities",
                newName: "IX_BooksPurchasedByUniversities_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_books_purchased_by_university_BookId",
                table: "BooksPurchasedByUniversities",
                newName: "IX_BooksPurchasedByUniversities_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksPurchasedByUniversities",
                table: "BooksPurchasedByUniversities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_available_for_faculty_BooksPurchasedByUniversities_Boo~",
                table: "books_available_for_faculty",
                column: "BooksPurchasedByUniversityId",
                principalTable: "BooksPurchasedByUniversities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksPurchasedByUniversities_Books_BookId",
                table: "BooksPurchasedByUniversities",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksPurchasedByUniversities_Universities_UniversityId",
                table: "BooksPurchasedByUniversities",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }
    }
}
