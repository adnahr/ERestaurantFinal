using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class ScheduleWorkPlaceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkPlaceWPId",
                table: "schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_WorkPlaceWPId",
                table: "schedules",
                column: "WorkPlaceWPId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_workPlaces_WorkPlaceWPId",
                table: "schedules",
                column: "WorkPlaceWPId",
                principalTable: "workPlaces",
                principalColumn: "WPId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_workPlaces_WorkPlaceWPId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_WorkPlaceWPId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "WorkPlaceWPId",
                table: "schedules");
        }
    }
}
