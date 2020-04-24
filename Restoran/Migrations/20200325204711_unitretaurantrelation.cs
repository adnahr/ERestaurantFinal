using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class UnitRetaurantRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "restaurantUnits",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_restaurantUnits_RestaurantId",
                table: "restaurantUnits",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_restaurantUnits_restaurants_RestaurantId",
                table: "restaurantUnits",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_restaurantUnits_restaurants_RestaurantId",
                table: "restaurantUnits");

            migrationBuilder.DropIndex(
                name: "IX_restaurantUnits_RestaurantId",
                table: "restaurantUnits");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "restaurantUnits");
        }
    }
}
