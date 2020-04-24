using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class MealRestaurantUnitRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unitMenus",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    AllRestaurantUnitUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unitMenus", x => new { x.MealId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_unitMenus_restaurantUnits_AllRestaurantUnitUnitId",
                        column: x => x.AllRestaurantUnitUnitId,
                        principalTable: "restaurantUnits",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_unitMenus_meals_MealId",
                        column: x => x.MealId,
                        principalTable: "meals",
                        principalColumn: "MealId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_unitMenus_AllRestaurantUnitUnitId",
                table: "unitMenus",
                column: "AllRestaurantUnitUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unitMenus");
        }
    }
}
