using Microsoft.EntityFrameworkCore.Migrations;

namespace Achievements.Database.Migrations
{
    public partial class test_migr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StoredFiles");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "StoredFiles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoredFiles_UserId",
                table: "StoredFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_Users_UserId",
                table: "StoredFiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_Users_UserId",
                table: "StoredFiles");

            migrationBuilder.DropIndex(
                name: "IX_StoredFiles_UserId",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoredFiles");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "StoredFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StoredFiles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
