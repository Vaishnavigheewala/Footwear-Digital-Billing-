using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingSystem.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderShippings_OrderDetails_OrderDetailId",
                table: "orderShippings");

            migrationBuilder.DropIndex(
                name: "IX_orderShippings_OrderDetailId",
                table: "orderShippings");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "orderShippings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "orderShippings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderShippings_OrderDetailId",
                table: "orderShippings",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderShippings_OrderDetails_OrderDetailId",
                table: "orderShippings",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
