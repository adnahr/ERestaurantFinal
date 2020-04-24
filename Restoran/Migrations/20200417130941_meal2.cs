using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class meal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "meals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "meals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "meals");
        }
    }
}
