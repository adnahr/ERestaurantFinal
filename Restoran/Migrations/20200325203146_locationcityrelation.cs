using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class LocationCityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityFK",
                table: "locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_locations_CityFK",
                table: "locations",
                column: "CityFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_cities_CityFK",
                table: "locations",
                column: "CityFK",
                principalTable: "cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_cities_CityFK",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_CityFK",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "CityFK",
                table: "locations");
        }
    }
}
