using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeAddedProperty",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "149e38e3-3a49-4b21-9cd6-fa643622ade7", "1", "BussinesOwner", "BussinesOwner" },
                    { "4e31223d-a997-44e5-9b2e-8146fcf0b482", "0", "User", "User" },
                    { "61699bf3-44e4-4840-8b20-d769b53f51af", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "149e38e3-3a49-4b21-9cd6-fa643622ade7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e31223d-a997-44e5-9b2e-8146fcf0b482");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61699bf3-44e4-4840-8b20-d769b53f51af");

            migrationBuilder.DropColumn(
                name: "TimeAddedProperty",
                table: "Properties");

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
    }
}
