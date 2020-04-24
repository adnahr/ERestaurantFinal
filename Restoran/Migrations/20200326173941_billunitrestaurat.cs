using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class BillUnitRestaurat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUnitUnitId",
                table: "bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bills_RestaurantUnitUnitId",
                table: "bills",
                column: "RestaurantUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_restaurantUnits_RestaurantUnitUnitId",
                table: "bills",
                column: "RestaurantUnitUnitId",
                principalTable: "restaurantUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_restaurantUnits_RestaurantUnitUnitId",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_RestaurantUnitUnitId",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "RestaurantUnitUnitId",
                table: "bills");
        }
    }
}
