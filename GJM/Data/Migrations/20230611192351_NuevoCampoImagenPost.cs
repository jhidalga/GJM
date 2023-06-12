using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GJM.Data.Migrations
{
    public partial class NuevoCampoImagenPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadImage",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadImage",
                table: "Posts");
        }
    }
}
