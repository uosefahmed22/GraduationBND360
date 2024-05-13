using System;
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
                keyValue: "132c249d-3790-480a-b69c-d9610b86ac1c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "134bfa8a-eca0-4456-900d-93d22827c53c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c759c1e1-3662-4f49-a659-3e195dc130ff");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAddedjob",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58b6a76e-59e6-4dad-aa5a-b7ab4e330e02", "2", "ServiceProvider", "ServiceProvider" },
                    { "7f17e33d-6437-4162-9b0e-f55ef03c55a9", "0", "User", "User" },
                    { "8eeb4f16-af02-4fd3-b762-05662df4bd21", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58b6a76e-59e6-4dad-aa5a-b7ab4e330e02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f17e33d-6437-4162-9b0e-f55ef03c55a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eeb4f16-af02-4fd3-b762-05662df4bd21");

            migrationBuilder.DropColumn(
                name: "TimeAddedjob",
                table: "Jobs");

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
    }
}
