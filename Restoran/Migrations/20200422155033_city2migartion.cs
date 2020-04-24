using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class city2Migartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "countries",
                newName: "CountryName");

            migrationBuilder.RenameIndex(
                name: "IX_countries_Name",
                table: "countries",
                newName: "IX_countries_CountryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "cities",
                newName: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "countries",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_countries_CountryName",
                table: "countries",
                newName: "IX_countries_Name");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "cities",
                newName: "Name");
        }
    }
}
