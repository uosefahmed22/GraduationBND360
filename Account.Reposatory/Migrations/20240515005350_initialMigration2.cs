using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "CraftsMen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CraftsMenNameArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CraftsMenNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsModelId = table.Column<int>(type: "int", nullable: false),
                    CraftsMenDescriptionArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CraftsMenDescriptionEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsMenAddressArabic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CraftsMenAddressEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Holidays = table.Column<int>(type: "int", nullable: true),
                    Phonenumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URIs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opening = table.Column<int>(type: "int", nullable: false),
                    Closing = table.Column<int>(type: "int", nullable: false),
                    ProfileImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsMenImageName1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsMenImageName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsMenImageName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CraftsMenImageName4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CraftsMen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CraftsMen_crafts_CraftsModelId",
                        column: x => x.CraftsModelId,
                        principalTable: "crafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "038f6fec-3895-4613-8381-d1f00f3e51ae", "1", "BussinesOwner", "BussinesOwner" },
                    { "05883994-48c6-4904-a0c0-8d2a11756e00", "2", "ServiceProvider", "ServiceProvider" },
                    { "d834b08c-3ba7-4f93-ab98-4ac963b39c20", "0", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CraftsMen_CraftsModelId",
                table: "CraftsMen",
                column: "CraftsModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CraftsMen");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "038f6fec-3895-4613-8381-d1f00f3e51ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05883994-48c6-4904-a0c0-8d2a11756e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d834b08c-3ba7-4f93-ab98-4ac963b39c20");

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
    }
}
