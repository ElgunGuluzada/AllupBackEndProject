using Microsoft.EntityFrameworkCore.Migrations;

namespace AllupBackEndProject.Migrations
{
    public partial class saleProductColumnAddedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaleCount",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleCount",
                table: "Products");
        }
    }
}
