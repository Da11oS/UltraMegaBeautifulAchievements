using Microsoft.EntityFrameworkCore.Migrations;

namespace Achievements.Database.Migrations
{
    public partial class storedfileextensionandtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "StoredFiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "StoredFiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "StoredFiles");
        }
    }
}
