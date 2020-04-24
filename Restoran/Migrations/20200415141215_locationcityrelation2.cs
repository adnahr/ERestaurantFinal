using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class locationCityRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_locations_CityFK",
                table: "locations");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CityFK",
                table: "locations",
                column: "CityFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_locations_CityFK",
                table: "locations");

            migrationBuilder.CreateIndex(
                name: "IX_locations_CityFK",
                table: "locations",
                column: "CityFK",
                unique: true);
        }
    }
}
