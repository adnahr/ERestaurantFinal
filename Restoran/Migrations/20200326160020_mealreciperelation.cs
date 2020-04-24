using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class MealRecipeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "recipes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_recipes_MealId",
                table: "recipes",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "MealId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_recipes_meals_MealId",
                table: "recipes");

            migrationBuilder.DropIndex(
                name: "IX_recipes_MealId",
                table: "recipes");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "recipes");
        }
    }
}
