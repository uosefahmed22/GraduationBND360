using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ratingAndReviewModelForCraftsmens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ratingAndReviewModelForBusinesses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CraftsMen",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4ffc62-d6fa-4d6a-9a62-56c462901586", "1", "BussinesOwner", "BussinesOwner" },
                    { "72aa1b6d-3984-470a-a092-149275b3eed4", "0", "User", "User" },
                    { "d19c13ee-5f42-4a37-a772-56502ed8b963", "2", "ServiceProvider", "ServiceProvider" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4ffc62-d6fa-4d6a-9a62-56c462901586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72aa1b6d-3984-470a-a092-149275b3eed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d19c13ee-5f42-4a37-a772-56502ed8b963");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ratingAndReviewModelForCraftsmens");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ratingAndReviewModelForBusinesses");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CraftsMen");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Businesses");

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
    }
}
