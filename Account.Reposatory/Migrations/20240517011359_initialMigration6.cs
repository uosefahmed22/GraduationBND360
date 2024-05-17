using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34f4a649-7e36-4486-8be9-b811f7724691");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb2e2fed-02b6-40b7-ba62-4b18bc0bdfda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f026acb0-b2e2-4128-9f04-ef336ca97c50");

            migrationBuilder.CreateTable(
                name: "BusinessFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessFavorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvidersFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvidersFavorites", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "681c68d7-848f-4df0-92ed-6246a0020c9a", "0", "User", "User" },
                    { "b350f615-4f8d-4dca-be9e-85815b364c7f", "2", "ServiceProvider", "ServiceProvider" },
                    { "fbef6b91-e15e-482c-a715-9e9af07e6d55", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessFavorites");

            migrationBuilder.DropTable(
                name: "ServiceProvidersFavorites");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "681c68d7-848f-4df0-92ed-6246a0020c9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b350f615-4f8d-4dca-be9e-85815b364c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbef6b91-e15e-482c-a715-9e9af07e6d55");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34f4a649-7e36-4486-8be9-b811f7724691", "2", "ServiceProvider", "ServiceProvider" },
                    { "cb2e2fed-02b6-40b7-ba62-4b18bc0bdfda", "0", "User", "User" },
                    { "f026acb0-b2e2-4128-9f04-ef336ca97c50", "1", "BussinesOwner", "BussinesOwner" }
                });
        }
    }
}
