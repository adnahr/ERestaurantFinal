using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class ScheduleUnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUnitUnitId",
                table: "schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_RestaurantUnitUnitId",
                table: "schedules",
                column: "RestaurantUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_restaurantUnits_RestaurantUnitUnitId",
                table: "schedules",
                column: "RestaurantUnitUnitId",
                principalTable: "restaurantUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_restaurantUnits_RestaurantUnitUnitId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_RestaurantUnitUnitId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "RestaurantUnitUnitId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "schedules");
        }
    }
}
