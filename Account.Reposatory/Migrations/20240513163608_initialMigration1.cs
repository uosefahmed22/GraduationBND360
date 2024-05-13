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
            migrationBuilder.DropTable(
                name: "BusinessContact");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27d2cbcb-5ca0-4e13-b82d-83a5d3b2a99a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a21b7f5-4efc-4010-9f49-a854c860871b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e6d6dd9-d2ee-4a3c-84c9-d161c81c3070");

            migrationBuilder.DropColumn(
                name: "BusinessContactId",
                table: "Businesses");

            migrationBuilder.AddColumn<string>(
                name: "Emails",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phonenumbers",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "URls",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "132c249d-3790-480a-b69c-d9610b86ac1c", "1", "BussinesOwner", "BussinesOwner" },
                    { "134bfa8a-eca0-4456-900d-93d22827c53c", "0", "User", "User" },
                    { "c759c1e1-3662-4f49-a659-3e195dc130ff", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "132c249d-3790-480a-b69c-d9610b86ac1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134bfa8a-eca0-4456-900d-93d22827c53c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c759c1e1-3662-4f49-a659-3e195dc130ff");

            migrationBuilder.DropColumn(
                name: "Emails",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Phonenumbers",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "URls",
                table: "Businesses");

            migrationBuilder.AddColumn<int>(
                name: "BusinessContactId",
                table: "Businesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BusinessContact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessContactId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessContact_Businesses_BusinessContactId",
                        column: x => x.BusinessContactId,
                        principalTable: "Businesses",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "27d2cbcb-5ca0-4e13-b82d-83a5d3b2a99a", "0", "User", "User" },
                    { "4a21b7f5-4efc-4010-9f49-a854c860871b", "2", "ServiceProvider", "ServiceProvider" },
                    { "9e6d6dd9-d2ee-4a3c-84c9-d161c81c3070", "1", "BussinesOwner", "BussinesOwner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessContact_BusinessContactId",
                table: "BusinessContact",
                column: "BusinessContactId");
        }
    }
}
