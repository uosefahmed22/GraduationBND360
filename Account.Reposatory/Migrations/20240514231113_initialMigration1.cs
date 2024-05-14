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
                keyValue: "242fba15-0eb8-49ff-a8a9-5f94ffdef54d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553e49c1-1490-47fb-8085-8af9b771842d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5a88f66-e33c-403f-b0c6-543e0648bd9e");

            migrationBuilder.CreateTable(
                name: "crafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CraftsNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CraftsNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crafts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f708d6f-340a-49d4-aa34-114a8b9732d6", "2", "ServiceProvider", "ServiceProvider" },
                    { "cf042779-6f4c-47b0-8869-6b11589f80d8", "0", "User", "User" },
                    { "cf35365e-0e88-43da-a48a-be2627222783", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crafts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f708d6f-340a-49d4-aa34-114a8b9732d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf042779-6f4c-47b0-8869-6b11589f80d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf35365e-0e88-43da-a48a-be2627222783");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "242fba15-0eb8-49ff-a8a9-5f94ffdef54d", "1", "BussinesOwner", "BussinesOwner" },
                    { "553e49c1-1490-47fb-8085-8af9b771842d", "0", "User", "User" },
                    { "d5a88f66-e33c-403f-b0c6-543e0648bd9e", "2", "ServiceProvider", "ServiceProvider" }
                });
        }
    }
}
