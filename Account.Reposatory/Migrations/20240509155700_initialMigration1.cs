using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6af03e75-2fdc-4278-95f1-e63ea1c8ff80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2e39058-f963-4eb5-b01c-ebbc19f5d3f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edab9019-d699-4b08-96ff-683ca79494b8");

            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55336ece-3807-462f-b489-cde0e067866d", "1", "BussinesOwner", "BussinesOwner" },
                    { "888f667c-ec5c-42b4-b0d0-992453b521d2", "0", "User", "User" },
                    { "e197a018-5cd5-4f99-b66c-fbb2c87cded7", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55336ece-3807-462f-b489-cde0e067866d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "888f667c-ec5c-42b4-b0d0-992453b521d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e197a018-5cd5-4f99-b66c-fbb2c87cded7");

            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6af03e75-2fdc-4278-95f1-e63ea1c8ff80", "1", "BussinesOwner", "BussinesOwner" },
                    { "a2e39058-f963-4eb5-b01c-ebbc19f5d3f9", "0", "User", "User" },
                    { "edab9019-d699-4b08-96ff-683ca79494b8", "2", "ServiceProvider", "ServiceProvider" }
                });
        }
    }
}
