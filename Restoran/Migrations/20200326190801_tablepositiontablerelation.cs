using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class TablePositionTableRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TablePositionTPId",
                table: "tables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tables_TablePositionTPId",
                table: "tables",
                column: "TablePositionTPId");

            migrationBuilder.AddForeignKey(
                name: "FK_tables_tablePositions_TablePositionTPId",
                table: "tables",
                column: "TablePositionTPId",
                principalTable: "tablePositions",
                principalColumn: "TPId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tables_tablePositions_TablePositionTPId",
                table: "tables");

            migrationBuilder.DropIndex(
                name: "IX_tables_TablePositionTPId",
                table: "tables");

            migrationBuilder.DropColumn(
                name: "TablePositionTPId",
                table: "tables");
        }
    }
}
