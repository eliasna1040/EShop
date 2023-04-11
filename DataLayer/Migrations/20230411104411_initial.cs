using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId");
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrdersOrderId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Disabled", "Name" },
                values: new object[] { 1, false, "bil" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Disabled", "Email", "Name", "Password" },
                values: new object[] { 1, "Hvor kragerne vender", false, "test@test.test", "Elias", "P@ssw0rd" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageData" },
                values: new object[] { 1, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 197, 0, 0, 0, 177, 8, 6, 0, 0, 0, 116, 139, 121, 39, 0, 0, 0, 1, 115, 82, 71, 66, 0, 174, 206, 28, 233, 0, 0, 0, 4, 103, 65, 77, 65, 0, 0, 177, 143, 11, 252, 97, 5, 0, 0, 0, 9, 112, 72, 89, 115, 0, 0, 18, 116, 0, 0, 18, 116, 1, 222, 102, 31, 120, 0, 0, 1, 199, 73, 68, 65, 84, 120, 94, 237, 211, 65, 13, 128, 64, 16, 192, 192, 5, 35, 235, 95, 37, 124, 46, 36, 84, 195, 204, 167, 10, 122, 237, 238, 51, 192, 231, 62, 5, 14, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 97, 10, 8, 83, 64, 152, 2, 194, 20, 16, 166, 128, 48, 5, 132, 41, 32, 76, 1, 63, 51, 47, 28, 63, 2, 190, 66, 109, 163, 82, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 } });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Disabled", "Name" },
                values: new object[] { 1, false, "Mercedes-Benz" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Disabled", "ImageId", "ManufacturerId", "Name", "Price" },
                values: new object[,]
                {
                    { 2, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 3, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 4, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 5, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 6, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 7, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 8, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 9, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 10, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 },
                    { 11, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductsProductId",
                table: "OrderProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImageId",
                table: "Products",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
