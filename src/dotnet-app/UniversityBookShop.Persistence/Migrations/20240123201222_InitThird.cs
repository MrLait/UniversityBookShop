using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitThird : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_currency_codes_currency_code_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_currency_codes_currency_code_id",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "NameTwo",
                table: "Universities");

            migrationBuilder.AlterColumn<int>(
                name: "currency_code_id",
                table: "Universities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "currency_code_id",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_currency_codes_currency_code_id",
                table: "Books",
                column: "currency_code_id",
                principalTable: "currency_codes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_currency_codes_currency_code_id",
                table: "Universities",
                column: "currency_code_id",
                principalTable: "currency_codes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_currency_codes_currency_code_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_currency_codes_currency_code_id",
                table: "Universities");

            migrationBuilder.AlterColumn<int>(
                name: "currency_code_id",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameTwo",
                table: "Universities",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "currency_code_id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_currency_codes_currency_code_id",
                table: "Books",
                column: "currency_code_id",
                principalTable: "currency_codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_currency_codes_currency_code_id",
                table: "Universities",
                column: "currency_code_id",
                principalTable: "currency_codes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
