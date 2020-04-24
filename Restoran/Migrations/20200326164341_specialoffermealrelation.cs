using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class SpecialOfferMealRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "specialOffers",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_specialOffers_MealId",
                table: "specialOffers",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_specialOffers_meals_MealId",
                table: "specialOffers",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_specialOffers_meals_MealId",
                table: "specialOffers");

            migrationBuilder.DropIndex(
                name: "IX_specialOffers_MealId",
                table: "specialOffers");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "specialOffers");
        }
    }
}
