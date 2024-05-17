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
                keyValue: "5e67a631-8b7e-46dd-85b3-af676eddf85d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83eaaf2c-7917-4ba7-9c1a-4bb93713bec0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be1c1507-23e7-4304-a987-8e3d8624e600");

            migrationBuilder.RenameColumn(
                name: "ProfileName",
                table: "AspNetUsers",
                newName: "profileImageName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a995b84-fc73-41d5-8d9a-c9f7814360f2", "0", "User", "User" },
                    { "6ec018af-f656-48e8-8e4a-a1eba8fa8454", "1", "BussinesOwner", "BussinesOwner" },
                    { "b2a19cda-0907-441b-b59d-ed83cea73aea", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a995b84-fc73-41d5-8d9a-c9f7814360f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ec018af-f656-48e8-8e4a-a1eba8fa8454");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2a19cda-0907-441b-b59d-ed83cea73aea");

            migrationBuilder.RenameColumn(
                name: "profileImageName",
                table: "AspNetUsers",
                newName: "ProfileName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e67a631-8b7e-46dd-85b3-af676eddf85d", "1", "BussinesOwner", "BussinesOwner" },
                    { "83eaaf2c-7917-4ba7-9c1a-4bb93713bec0", "0", "User", "User" },
                    { "be1c1507-23e7-4304-a987-8e3d8624e600", "2", "ServiceProvider", "ServiceProvider" }
                });
        }
    }
}
