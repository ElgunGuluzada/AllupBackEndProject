using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllupBackEndProject.Migrations
{
    public partial class addNewProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "brand-7.png");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BestSeller", "BrandId", "CategoryId", "CreatedAt", "DeletedAt", "DiscountPrice", "ImageUrl", "IsAvailability", "IsDeleted", "IsFeatured", "Name", "NewArrival", "Price", "ProductCode", "StockCount", "TaxPercent", "UptadetAt" },
                values: new object[] { 1, true, 7, 2, new DateTime(2022, 7, 24, 0, 46, 20, 31, DateTimeKind.Local).AddTicks(1359), null, 1800.0, null, false, false, true, "Macbook Pro", true, 2000.0, null, 20, 10.0, null });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "ImageUrl", "IsDeleted", "Name", "UptadetAt" },
                values: new object[] { 6, null, null, null, false, "Premium", null });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsMain", "ProductId" },
                values: new object[,]
                {
                    { 1, "product-21.jpg", true, 1 },
                    { 2, "product-18.jpg", false, 1 },
                    { 3, "product-19.jpg", false, 1 },
                    { 4, "product-20.jpg", false, 1 },
                    { 5, "product-22.jpg", false, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "Id", "ProductId", "TagId" },
                values: new object[] { 1, 1, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductTags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);
        }
    }
}
