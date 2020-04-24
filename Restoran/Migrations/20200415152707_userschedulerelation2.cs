using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class UserScheduleRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "schedules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedules_UserId",
                table: "schedules",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedules_AspNetUsers_UserId",
                table: "schedules",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedules_AspNetUsers_UserId",
                table: "schedules");

            migrationBuilder.DropIndex(
                name: "IX_schedules_UserId",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "schedules");
        }
    }
}
