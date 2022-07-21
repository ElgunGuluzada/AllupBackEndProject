using Microsoft.EntityFrameworkCore.Migrations;

namespace AllupBackEndProject.Migrations
{
    public partial class initalProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SliderContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "SliderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SliderContents",
                keyColumn: "Id",
                keyValue: 2,
                column: "SliderId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SliderContents",
                keyColumn: "Id",
                keyValue: 1,
                column: "SliderId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "SliderContents",
                keyColumn: "Id",
                keyValue: 2,
                column: "SliderId",
                value: 0);
        }
    }
}
