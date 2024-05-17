using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "ratingAndReviewModelForCraftsmens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "ratingAndReviewModelForBusinesses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00820c92-5bce-486f-b809-98db18aeac73", "0", "User", "User" },
                    { "591270dd-cb49-48cf-90fc-57ca869c2b19", "2", "ServiceProvider", "ServiceProvider" },
                    { "f276a22f-aa3d-4622-8843-a4906e50021f", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00820c92-5bce-486f-b809-98db18aeac73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "591270dd-cb49-48cf-90fc-57ca869c2b19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f276a22f-aa3d-4622-8843-a4906e50021f");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "ratingAndReviewModelForCraftsmens",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "ratingAndReviewModelForBusinesses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
