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
                keyValue: "038f6fec-3895-4613-8381-d1f00f3e51ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05883994-48c6-4904-a0c0-8d2a11756e00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d834b08c-3ba7-4f93-ab98-4ac963b39c20");

            migrationBuilder.CreateTable(
                name: "JobsSaved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobIdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsSaved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobsSaved_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobsSaved_Jobs_JobIdId",
                        column: x => x.JobIdId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesSaved",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PropertyIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesSaved", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertiesSaved_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertiesSaved_Properties_PropertyIdId",
                        column: x => x.PropertyIdId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesSaved_PropertyIdId",
                table: "PropertiesSaved",
                column: "PropertyIdId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesSaved_UserIdId",
                table: "PropertiesSaved",
                column: "UserIdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobsSaved");

            migrationBuilder.DropTable(
                name: "PropertiesSaved");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "038f6fec-3895-4613-8381-d1f00f3e51ae", "1", "BussinesOwner", "BussinesOwner" },
                    { "05883994-48c6-4904-a0c0-8d2a11756e00", "2", "ServiceProvider", "ServiceProvider" },
                    { "d834b08c-3ba7-4f93-ab98-4ac963b39c20", "0", "User", "User" }
                });
        }
    }
}
