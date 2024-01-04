using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _62132937_KieuNgocAnh.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_Order_62132937Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Order_62132937Id",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Order_62132937Id",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order_62132937Id",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Order_62132937Id",
                table: "Products",
                column: "Order_62132937Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_Order_62132937Id",
                table: "Products",
                column: "Order_62132937Id",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
