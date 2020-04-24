using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class UnitLocationRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Locationid",
                table: "restaurantUnits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_restaurantUnits_Locationid",
                table: "restaurantUnits",
                column: "Locationid");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurantUnits_locations_Locationid",
                table: "restaurantUnits",
                column: "Locationid",
                principalTable: "locations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurantUnits_locations_Locationid",
                table: "restaurantUnits");

            migrationBuilder.DropIndex(
                name: "IX_restaurantUnits_Locationid",
                table: "restaurantUnits");

            migrationBuilder.DropColumn(
                name: "Locationid",
                table: "restaurantUnits");
        }
    }
}
