using Microsoft.EntityFrameworkCore.Migrations;

namespace AllupBackEndProject.Migrations
{
    public partial class SubscribeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SupportNumber",
                table: "Bios",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupportNumber",
                value: "+994 55 569 98 89");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.AlterColumn<int>(
                name: "SupportNumber",
                table: "Bios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupportNumber",
                value: 500500500);
        }
    }
}
