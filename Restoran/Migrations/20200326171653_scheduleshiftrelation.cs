using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class ScheduleShiftRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_ShiftId",
                table: "schedules",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_shifts_ShiftId",
                table: "schedules",
                column: "ShiftId",
                principalTable: "shifts",
                principalColumn: "ShiftId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_shifts_ShiftId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_ShiftId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "schedules");
        }
    }
}
