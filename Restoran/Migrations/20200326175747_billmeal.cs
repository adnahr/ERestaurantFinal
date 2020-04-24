using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class BillMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "billMeals",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false),
                    MealId = table.Column<int>(nullable: false),
                    Col = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_billMeals", x => new { x.BillId, x.MealId });
                    table.ForeignKey(
                        name: "FK_billMeals_bills_BillId",
                        column: x => x.BillId,
                        principalTable: "bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_billMeals_meals_MealId",
                        column: x => x.MealId,
                        principalTable: "meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_billMeals_MealId",
                table: "billMeals",
                column: "MealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "billMeals");
        }
    }
}
