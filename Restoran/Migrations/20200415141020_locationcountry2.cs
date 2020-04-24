using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class locationCountry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_locations_CountryFK",
                table: "locations");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CountryFK",
                table: "locations",
                column: "CountryFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_locations_CountryFK",
                table: "locations");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CountryFK",
                table: "locations",
                column: "CountryFK",
                unique: true);
        }
    }
}
