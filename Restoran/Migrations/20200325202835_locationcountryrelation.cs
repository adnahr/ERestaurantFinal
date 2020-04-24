using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class LocationCountryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryFK",
                table: "locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_locations_CountryFK",
                table: "locations",
                column: "CountryFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_locations_countries_CountryFK",
                table: "locations",
                column: "CountryFK",
                principalTable: "countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_locations_countries_CountryFK",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "IX_locations_CountryFK",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "CountryFK",
                table: "locations");
        }
    }
}
