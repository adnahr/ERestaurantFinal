using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class UserUnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantUnitUnitId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantUnitUnitId",
                table: "AspNetUsers",
                column: "RestaurantUnitUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_restaurantUnits_RestaurantUnitUnitId",
                table: "AspNetUsers",
                column: "RestaurantUnitUnitId",
                principalTable: "restaurantUnits",
                principalColumn: "UnitId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_restaurantUnits_RestaurantUnitUnitId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantUnitUnitId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantUnitUnitId",
                table: "AspNetUsers");
        }
    }
}
