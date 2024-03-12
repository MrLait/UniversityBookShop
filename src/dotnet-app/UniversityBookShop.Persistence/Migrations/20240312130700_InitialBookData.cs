using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UniversityBookShop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialBookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "currency_code_id", "Isbn", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Alice Starlight", 1, "123456789012", "The Hidden Galaxy", 10m },
                    { 2, "David Nebula", 1, "234567890123", "Echoes of Eternity", 15m },
                    { 3, "Mia Moonshade", 1, "345678901234", "Serenade of Shadows", 20m },
                    { 4, "Elijah Stardust", 1, "456789012345", "Whispers in the Wind", 25m },
                    { 5, "Isabella Dreamweaver", 1, "567890123456", "The Enchanted Chronicles", 30m },
                    { 6, "Oliver Starcrafter", 1, "678901234567", "Chronicles of Arcadia", 35m },
                    { 7, "Sophia Silverleaf", 1, "789012345678", "Legends of Lumina", 40m },
                    { 8, "Gabriel Nightshade", 1, "890123456789", "Eternal Echoes", 45m },
                    { 9, "Aria Stardancer", 1, "901234567890", "Starlight Sonata", 50m },
                    { 10, "Liam Shadowcaster", 1, "012345678901", "Moonlit Whispers", 55m },
                    { 11, "Serena Dreamweaver", 1, "112233445566", "Wonders of Whimsy", 60m },
                    { 12, "Lucas Starborn", 1, "223344556677", "Stardust Serenade", 65m },
                    { 13, "Aurora Celestia", 1, "334455667788", "Realm of Radiance", 70m },
                    { 14, "Xander Nightshade", 1, "445566778899", "Midnight Mirage", 75m },
                    { 15, "Fiona Starlight", 1, "556677889900", "Twilight Tales", 80m },
                    { 16, "Zane Moonshadow", 1, "667788990011", "Cerulean Chronicles", 85m },
                    { 17, "Elena Stardust", 1, "778899001122", "Luminous Legends", 90m },
                    { 18, "Orion Starcrafter", 1, "889900112233", "Galactic Gala", 95m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
