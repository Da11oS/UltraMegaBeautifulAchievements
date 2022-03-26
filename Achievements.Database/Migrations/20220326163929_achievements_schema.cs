using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Achievements.Database.Migrations
{
    public partial class achievements_schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementScores");

            migrationBuilder.CreateTable(
                name: "AchievementGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AchievementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AchievementGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementTypes_AchievementGroups_AchievementGroupId",
                        column: x => x.AchievementGroupId,
                        principalTable: "AchievementGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AchievementInstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementTypeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ExpertId = table.Column<int>(type: "int", nullable: true),
                    CheckedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementInstances_AchievementTypes_AchievementTypeId",
                        column: x => x.AchievementTypeId,
                        principalTable: "AchievementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AchievementInstances_Users_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AchievementInstances_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataType = table.Column<byte>(type: "tinyint", nullable: false),
                    AchievementTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Columns_AchievementTypes_AchievementTypeId",
                        column: x => x.AchievementTypeId,
                        principalTable: "AchievementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AchievementValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnId = table.Column<int>(type: "int", nullable: true),
                    AchievementInstanceId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementValues_AchievementInstances_AchievementInstanceId",
                        column: x => x.AchievementInstanceId,
                        principalTable: "AchievementInstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AchievementValues_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementInstances_AchievementTypeId",
                table: "AchievementInstances",
                column: "AchievementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementInstances_ExpertId",
                table: "AchievementInstances",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementInstances_UserId",
                table: "AchievementInstances",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementTypes_AchievementGroupId",
                table: "AchievementTypes",
                column: "AchievementGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementValues_AchievementInstanceId",
                table: "AchievementValues",
                column: "AchievementInstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementValues_ColumnId",
                table: "AchievementValues",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_AchievementTypeId",
                table: "Columns",
                column: "AchievementTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementValues");

            migrationBuilder.DropTable(
                name: "AchievementInstances");

            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "AchievementTypes");

            migrationBuilder.DropTable(
                name: "AchievementGroups");

            migrationBuilder.CreateTable(
                name: "AchievementScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpertId = table.Column<int>(type: "int", nullable: false),
                    StoredFileId = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementScores_StoredFiles_StoredFileId",
                        column: x => x.StoredFileId,
                        principalTable: "StoredFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementScores_StoredFileId",
                table: "AchievementScores",
                column: "StoredFileId");
        }
    }
}
