using Microsoft.EntityFrameworkCore.Migrations;

namespace Restoran.Migrations
{
    public partial class OrderBillRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BillFK",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_BillFK",
                table: "orders",
                column: "BillFK",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_bills_BillFK",
                table: "orders",
                column: "BillFK",
                principalTable: "bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_bills_BillFK",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_BillFK",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "BillFK",
                table: "orders");
        }
    }
}
