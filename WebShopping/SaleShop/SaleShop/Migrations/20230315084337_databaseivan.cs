using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleShop.Migrations
{
    public partial class databaseivan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransactStatus",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "XemDonHangDonhang",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    cartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.cartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginViewModel",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginViewModel", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "MuaHangSuccessVM",
                columns: table => new
                {
                    DonHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuaHangSuccessVM", x => x.DonHangID);
                });

            migrationBuilder.CreateTable(
                name: "MuaHangVM",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuaHangVM", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "RegisterViewModel",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterViewModel", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "XemDonHang",
                columns: table => new
                {
                    Donhang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangOrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XemDonHang", x => x.Donhang);
                    table.ForeignKey(
                        name: "FK_XemDonHang_Orders_DonHangOrderID",
                        column: x => x.DonHangOrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_XemDonHangDonhang",
                table: "OrderDetails",
                column: "XemDonHangDonhang");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_XemDonHang_DonHangOrderID",
                table: "XemDonHang",
                column: "DonHangOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_XemDonHang_XemDonHangDonhang",
                table: "OrderDetails",
                column: "XemDonHangDonhang",
                principalTable: "XemDonHang",
                principalColumn: "Donhang");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransactStatus",
                table: "Orders",
                column: "TransactStatusID",
                principalTable: "TransactStatus",
                principalColumn: "TransactStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_XemDonHang_XemDonHangDonhang",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TransactStatus",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "LoginViewModel");

            migrationBuilder.DropTable(
                name: "MuaHangSuccessVM");

            migrationBuilder.DropTable(
                name: "MuaHangVM");

            migrationBuilder.DropTable(
                name: "RegisterViewModel");

            migrationBuilder.DropTable(
                name: "XemDonHang");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_XemDonHangDonhang",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "XemDonHangDonhang",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TransactStatus",
                table: "Orders",
                column: "TransactStatusID",
                principalTable: "TransactStatus",
                principalColumn: "TransactStatusID");
        }
    }
}
