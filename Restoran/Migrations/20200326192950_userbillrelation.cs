using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class UserBillRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "bills",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_bills_UserId",
                table: "bills",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_bills_AspNetUsers_UserId",
                table: "bills",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bills_AspNetUsers_UserId",
                table: "bills");

            migrationBuilder.DropIndex(
                name: "IX_bills_UserId",
                table: "bills");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "bills");
        }
    }
}
