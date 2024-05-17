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
            migrationBuilder.DropForeignKey(
                name: "FK_JobsSaved_AspNetUsers_UserIdId",
                table: "JobsSaved");

            migrationBuilder.DropForeignKey(
                name: "FK_JobsSaved_Jobs_JobIdId",
                table: "JobsSaved");

            migrationBuilder.DropIndex(
                name: "IX_JobsSaved_JobIdId",
                table: "JobsSaved");

            migrationBuilder.DropIndex(
                name: "IX_JobsSaved_UserIdId",
                table: "JobsSaved");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c23da873-d9c9-4f33-9ee9-aac552d9be23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db65b316-f43f-467e-9c3b-c37ac200fb08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe661312-f3a9-41e2-b1eb-57a43cc13045");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "JobsSaved");

            migrationBuilder.RenameColumn(
                name: "JobIdId",
                table: "JobsSaved",
                newName: "JobId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "JobsSaved",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4c2be4e6-8f23-413a-9de0-86661e0fb8ee", "1", "BussinesOwner", "BussinesOwner" },
                    { "8fe97381-704d-411b-a2af-62093ffdd8d6", "2", "ServiceProvider", "ServiceProvider" },
                    { "a24a69be-596f-413e-ac4d-0c36d0ef8725", "0", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "UserId",
                table: "JobsSaved");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "JobsSaved",
                newName: "JobIdId");

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "JobsSaved",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c23da873-d9c9-4f33-9ee9-aac552d9be23", "2", "ServiceProvider", "ServiceProvider" },
                    { "db65b316-f43f-467e-9c3b-c37ac200fb08", "0", "User", "User" },
                    { "fe661312-f3a9-41e2-b1eb-57a43cc13045", "1", "BussinesOwner", "BussinesOwner" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobsSaved_JobIdId",
                table: "JobsSaved",
                column: "JobIdId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsSaved_UserIdId",
                table: "JobsSaved",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsSaved_AspNetUsers_UserIdId",
                table: "JobsSaved",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobsSaved_Jobs_JobIdId",
                table: "JobsSaved",
                column: "JobIdId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
