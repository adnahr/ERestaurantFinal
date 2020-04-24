using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class MealCategoryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "meals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_meals_CategoryId",
                table: "meals",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_meals_categories_CategoryId",
                table: "meals",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_meals_categories_CategoryId",
                table: "meals");

            migrationBuilder.DropIndex(
                name: "IX_meals_CategoryId",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "meals");
        }
    }
}
