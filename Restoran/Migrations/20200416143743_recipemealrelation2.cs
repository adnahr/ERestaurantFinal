using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class recipeMealRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
