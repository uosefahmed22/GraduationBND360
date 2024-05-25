using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "2364dc2d-39d7-4e89-8d67-734aa9243028", "1", "BussinesOwner", "BussinesOwner" },
                    { "4515036a-9654-48f8-b224-25382e3b3c3d", "0", "User", "User" },
                    { "cf85c74a-22bc-4c1f-b0ed-77116bc3726b", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
