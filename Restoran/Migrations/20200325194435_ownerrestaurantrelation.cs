using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class OwnerRestaurantRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "owners",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_owners_RestaurantId",
                table: "owners",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_owners_restaurants_RestaurantId",
                table: "owners",
                column: "RestaurantId",
                principalTable: "restaurants",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_owners_restaurants_RestaurantId",
                table: "owners");

            migrationBuilder.DropIndex(
                name: "IX_owners_RestaurantId",
                table: "owners");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "owners");
        }
    }
}
