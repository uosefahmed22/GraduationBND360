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
                keyValue: "0d8ed817-ccc8-4422-8060-a34a7b5558bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "209c5533-6f0f-4944-b9a8-22ebee9a0526");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24fb6af1-6192-406b-b291-ee077c0182c3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62097a04-a45a-422b-b28c-cda6caeb55b4", "1", "BussinesOwner", "BUSSINESOWNER" },
                    { "7db06c72-13c8-4ea2-a1dd-9d702f525463", "0", "User", "USER" },
                    { "b6dd7c63-88ab-40a2-973f-e1ab9e84f11d", "2", "ServiceProvider", "SERVICEPROVIDER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62097a04-a45a-422b-b28c-cda6caeb55b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7db06c72-13c8-4ea2-a1dd-9d702f525463");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6dd7c63-88ab-40a2-973f-e1ab9e84f11d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d8ed817-ccc8-4422-8060-a34a7b5558bc", "2", "ServiceProvider", "ServiceProvider" },
                    { "209c5533-6f0f-4944-b9a8-22ebee9a0526", "0", "User", "User" },
                    { "24fb6af1-6192-406b-b291-ee077c0182c3", "1", "BussinesOwner", "BussinesOwner" }
                });
        }
    }
}
