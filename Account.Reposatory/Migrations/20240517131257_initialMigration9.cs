using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4ffc62-d6fa-4d6a-9a62-56c462901586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72aa1b6d-3984-470a-a092-149275b3eed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19c13ee-5f42-4a37-a772-56502ed8b963");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Businesses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Businesses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39873aea-ff33-4450-9bda-06d1f3eb713a", "2", "ServiceProvider", "ServiceProvider" },
                    { "4ff47a22-8397-4dbf-8025-3b551f57d679", "1", "BussinesOwner", "BussinesOwner" },
                    { "70a398ce-1ddf-453f-ad31-48aea1ed6308", "0", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39873aea-ff33-4450-9bda-06d1f3eb713a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ff47a22-8397-4dbf-8025-3b551f57d679");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70a398ce-1ddf-453f-ad31-48aea1ed6308");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Businesses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4ffc62-d6fa-4d6a-9a62-56c462901586", "1", "BussinesOwner", "BussinesOwner" },
                    { "72aa1b6d-3984-470a-a092-149275b3eed4", "0", "User", "User" },
                    { "d19c13ee-5f42-4a37-a772-56502ed8b963", "2", "ServiceProvider", "ServiceProvider" }
                });
        }
    }
}
