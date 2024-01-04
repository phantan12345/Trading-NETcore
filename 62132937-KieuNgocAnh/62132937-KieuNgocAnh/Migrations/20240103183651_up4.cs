using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _62132937_KieuNgocAnh.Migrations
{
    public partial class up4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetail_OrderDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "OrderDetailId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDetailId",
                table: "Products",
                column: "OrderDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetail_OrderDetailId",
                table: "Products",
                column: "OrderDetailId",
                principalTable: "OrderDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
