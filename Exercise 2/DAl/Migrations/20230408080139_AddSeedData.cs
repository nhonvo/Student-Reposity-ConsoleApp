using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Exercise_2.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "IsActive", "Name", "Phone", "Wallet" },
                values: new object[,]
                {
                    { 1, true, "Name1", "012345678", 500 },
                    { 2, true, "name2", "012345678", 500 },
                    { 3, false, "name3", "012345678", 500 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Product 1" },
                    { 2, "Product 2" },
                    { 3, "Product 3" },
                    { 4, "Product 4" }
                });

            migrationBuilder.InsertData(
                table: "ShippingCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Company 1" },
                    { 2, "Company 2" },
                    { 3, "Company 3" },
                    { 4, "Company 4" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Detail", "ShippingCompanyId" },
                values: new object[,]
                {
                    { 1, 1, 0, 1 },
                    { 2, 1, 0, 4 },
                    { 3, 3, 0, 1 },
                    { 4, 1, 0, 2 },
                    { 5, 1, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 4 },
                    { 4, 4 },
                    { 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingCompanies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
