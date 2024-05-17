using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ratingAndReviewModelForBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    businessId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingAndReviewModelForBusinesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ratingAndReviewModelForCraftsmens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    CraftsmanId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratingAndReviewModelForCraftsmens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a9f411-7636-49ca-9856-63f5474f4132", "0", "User", "User" },
                    { "5b68754b-ee40-4737-a207-40691be6f348", "2", "ServiceProvider", "ServiceProvider" },
                    { "5e42e010-421f-44dc-83a2-ab57727c3edb", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ratingAndReviewModelForBusinesses");

            migrationBuilder.DropTable(
                name: "ratingAndReviewModelForCraftsmens");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a9f411-7636-49ca-9856-63f5474f4132");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b68754b-ee40-4737-a207-40691be6f348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e42e010-421f-44dc-83a2-ab57727c3edb");

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
    }
}
