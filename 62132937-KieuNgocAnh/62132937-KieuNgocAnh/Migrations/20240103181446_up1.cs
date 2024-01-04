using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _62132937_KieuNgocAnh.Migrations
{
    public partial class up1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orderdetails_OrderDetailId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderdetails",
                table: "Orderdetails");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProdcutId",
                table: "Orderdetails");

            migrationBuilder.RenameTable(
                name: "Orderdetails",
                newName: "OrderDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Orderdetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_OrderDetail_Orders_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrderDetail_OrderDetailId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "Orderdetails");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "Orderdetails",
                newName: "IX_Orderdetails_OrderId");

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdcutId",
                table: "Orderdetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderdetails",
                table: "Orderdetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orderdetails_Orders_OrderId",
                table: "Orderdetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orderdetails_OrderDetailId",
                table: "Products",
                column: "OrderDetailId",
                principalTable: "Orderdetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
