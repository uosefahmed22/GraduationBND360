using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAddedProperty",
                table: "Properties",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAddedjob",
                table: "Jobs",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41b897e1-5c86-467e-be27-0271a95f0a62", "0", "User", "User" },
                    { "796105e8-7062-4d31-aa2f-2018d6637714", "2", "ServiceProvider", "ServiceProvider" },
                    { "ff57f366-42c2-4a66-a40f-6899875429d4", "1", "BussinesOwner", "BussinesOwner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41b897e1-5c86-467e-be27-0271a95f0a62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "796105e8-7062-4d31-aa2f-2018d6637714");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff57f366-42c2-4a66-a40f-6899875429d4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAddedProperty",
                table: "Properties",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeAddedjob",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
    }
}
