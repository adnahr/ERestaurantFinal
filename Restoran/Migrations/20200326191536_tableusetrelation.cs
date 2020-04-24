using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class TableUsetRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "tables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tables_UserId",
                table: "tables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tables_AspNetUsers_UserId",
                table: "tables",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tables_AspNetUsers_UserId",
                table: "tables");

            migrationBuilder.DropIndex(
                name: "IX_tables_UserId",
                table: "tables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tables");
        }
    }
}
