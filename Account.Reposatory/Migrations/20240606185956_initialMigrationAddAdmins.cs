using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationAddAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertiesSaved",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77091b77-a65c-4678-820e-02420f80f685", "3", "Admin", "Admin" },
                    { "8f901d6a-c03d-416c-a2a9-81794e36fdea", "2", "ServiceProvider", "ServiceProvider" },
                    { "e1edf9e1-c960-4a36-9206-4fdc5a935511", "1", "BussinesOwner", "BussinesOwner" },
                    { "eae16506-b9e4-4098-9b34-a7580456e617", "0", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77091b77-a65c-4678-820e-02420f80f685");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f901d6a-c03d-416c-a2a9-81794e36fdea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1edf9e1-c960-4a36-9206-4fdc5a935511");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eae16506-b9e4-4098-9b34-a7580456e617");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyId",
                table: "PropertiesSaved",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
