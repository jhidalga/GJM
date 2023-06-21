using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GJM.Migrations
{
    public partial class GameWithCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CategoryId",
                table: "Games",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CategoryId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Games");
        }
    }
}
