using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesSaved_AspNetUsers_UserIdId",
                table: "PropertiesSaved");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesSaved_Properties_PropertyIdId",
                table: "PropertiesSaved");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesSaved_PropertyIdId",
                table: "PropertiesSaved");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesSaved_UserIdId",
                table: "PropertiesSaved");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c2be4e6-8f23-413a-9de0-86661e0fb8ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fe97381-704d-411b-a2af-62093ffdd8d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24a69be-596f-413e-ac4d-0c36d0ef8725");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "PropertiesSaved");

            migrationBuilder.RenameColumn(
                name: "PropertyIdId",
                table: "PropertiesSaved",
                newName: "PropertyId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PropertiesSaved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PropertiesSaved");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "PropertiesSaved",
                newName: "PropertyIdId");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "PropertiesSaved",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c2be4e6-8f23-413a-9de0-86661e0fb8ee", "1", "BussinesOwner", "BussinesOwner" },
                    { "8fe97381-704d-411b-a2af-62093ffdd8d6", "2", "ServiceProvider", "ServiceProvider" },
                    { "a24a69be-596f-413e-ac4d-0c36d0ef8725", "0", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesSaved_PropertyIdId",
                table: "PropertiesSaved",
                column: "PropertyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesSaved_UserIdId",
                table: "PropertiesSaved",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesSaved_AspNetUsers_UserIdId",
                table: "PropertiesSaved",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesSaved_Properties_PropertyIdId",
                table: "PropertiesSaved",
                column: "PropertyIdId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
