using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class TableUnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUnitUnitId",
                table: "tables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tables_RestaurantUnitUnitId",
                table: "tables",
                column: "RestaurantUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_tables_restaurantUnits_RestaurantUnitUnitId",
                table: "tables",
                column: "RestaurantUnitUnitId",
                principalTable: "restaurantUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tables_restaurantUnits_RestaurantUnitUnitId",
                table: "tables");

            migrationBuilder.DropIndex(
                name: "IX_tables_RestaurantUnitUnitId",
                table: "tables");

            migrationBuilder.DropColumn(
                name: "RestaurantUnitUnitId",
                table: "tables");
        }
    }
}
