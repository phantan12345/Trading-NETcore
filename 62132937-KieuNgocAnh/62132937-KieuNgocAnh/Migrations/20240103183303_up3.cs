using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _62132937_KieuNgocAnh.Migrations
{
    public partial class up3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetail_OrderDetail_62132937Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderDetail_62132937Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderDetail_62132937Id",
                table: "Products");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "OrderDetail_62132937Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderDetail_62132937Id",
                table: "Products",
                column: "OrderDetail_62132937Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrderDetail_OrderDetail_62132937Id",
                table: "Products",
                column: "OrderDetail_62132937Id",
                principalTable: "OrderDetail",
                principalColumn: "Id");
        }
    }
}
