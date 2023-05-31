using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GJM.Data.Migrations
{
    public partial class ModPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tittle",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tittle",
                table: "Posts");
        }
    }
}
