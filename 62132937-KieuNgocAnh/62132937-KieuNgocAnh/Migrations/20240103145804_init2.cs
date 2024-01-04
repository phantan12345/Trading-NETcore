using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _62132937_KieuNgocAnh.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Orderdetails_OrderId",
                table: "Orderdetails",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_Order_62132937Id",
                table: "Products",
                column: "Order_62132937Id",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_Order_62132937Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Order_62132937Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orderdetails_OrderId",
                table: "Orderdetails");

            migrationBuilder.DropColumn(
                name: "Order_62132937Id",
                table: "Products");
        }
    }
}
