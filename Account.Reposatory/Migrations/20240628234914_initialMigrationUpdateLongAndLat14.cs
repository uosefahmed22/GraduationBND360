using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Reposatory.Migrations
{
    /// <inheritdoc />
    public partial class initialMigrationUpdateLongAndLat14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Properties",
                type: "decimal(18,14)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Properties",
                type: "decimal(18,14)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Businesses",
                type: "decimal(18,14)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Businesses",
                type: "decimal(18,14)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,9)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Properties",
                type: "decimal(18,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Properties",
                type: "decimal(18,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Businesses",
                type: "decimal(18,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Businesses",
                type: "decimal(18,9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,14)");
        }
    }
}
