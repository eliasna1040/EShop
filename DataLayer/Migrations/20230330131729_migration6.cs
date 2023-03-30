using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Disabled", "Name" },
                values: new object[] { 1, false, "bil" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Disabled", "Email", "Name", "Password" },
                values: new object[] { 1, "Hvor kragerne vender", false, "test@test.test", "Elias", "P@ssw0rd" });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Disabled", "Name" },
                values: new object[] { 1, false, "Mercedes-Benz" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Disabled", "ImageId", "ManufacturerId", "Name", "Price" },
                values: new object[] { 1, 1, "en bil", false, null, 1, "g63 amg", 2000000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerId",
                keyValue: 1);
        }
    }
}
