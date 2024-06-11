﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationNow4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CreatedAt",
                table: "ratingAndReviewModelForCraftsmens",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "CreatedAt",
                table: "ratingAndReviewModelForCraftsmens",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0),
                oldClrType: typeof(TimeOnly),
                oldType: "time",
                oldNullable: true);
        }
    }
}
