using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class OrderUnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUnitUnitId",
                table: "orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_RestaurantUnitUnitId",
                table: "orders",
                column: "RestaurantUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_restaurantUnits_RestaurantUnitUnitId",
                table: "orders",
                column: "RestaurantUnitUnitId",
                principalTable: "restaurantUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_restaurantUnits_RestaurantUnitUnitId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_RestaurantUnitUnitId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "RestaurantUnitUnitId",
                table: "orders");
        }
    }
}
