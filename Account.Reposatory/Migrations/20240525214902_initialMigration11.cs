using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2364dc2d-39d7-4e89-8d67-734aa9243028");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4515036a-9654-48f8-b224-25382e3b3c3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf85c74a-22bc-4c1f-b0ed-77116bc3726b");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "ServiceProvidersFavorites",
                newName: "CraftsmanId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8969b853-9c63-4af7-a454-f8d8b0ea4d0a", "1", "BussinesOwner", "BussinesOwner" },
                    { "92d86669-38c3-41c8-924b-643d6c735c2a", "2", "ServiceProvider", "ServiceProvider" },
                    { "b253c10c-164e-4505-8ba5-62ea2025c48b", "0", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8969b853-9c63-4af7-a454-f8d8b0ea4d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92d86669-38c3-41c8-924b-643d6c735c2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b253c10c-164e-4505-8ba5-62ea2025c48b");

            migrationBuilder.RenameColumn(
                name: "CraftsmanId",
                table: "ServiceProvidersFavorites",
                newName: "BusinessId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2364dc2d-39d7-4e89-8d67-734aa9243028", "1", "BussinesOwner", "BussinesOwner" },
                    { "4515036a-9654-48f8-b224-25382e3b3c3d", "0", "User", "User" },
                    { "cf85c74a-22bc-4c1f-b0ed-77116bc3726b", "2", "ServiceProvider", "ServiceProvider" }
                });
        }
    }
}
