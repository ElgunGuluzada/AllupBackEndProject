using Microsoft.EntityFrameworkCore.Migrations;

namespace AllupBackEndProject.Migrations
{
    public partial class AddedBioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(nullable: true),
                    CouponCode = table.Column<string>(nullable: true),
                    SupportNumber = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    WorkTimes = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    CardsImageUrl = table.Column<string>(nullable: true),
                    NewsLetterImgUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "Address", "Author", "CardsImageUrl", "CouponCode", "Email", "Logo", "NewsLetterImgUrl", "Phone", "SupportNumber", "WorkTimes" },
                values: new object[] { 1, "45 Grand Central Terminal New York,NY 1017 United State USA", "Me Myself", "payment.png", "<p>Get FREE Shipping with <b>$35!</b> Code: FREESHIPPING</p>", "email@yourwebsitename.com", "logo.png", "bg-newletter.jpg", 123456789, 500500500, "Mon-Sat 9:00pm - 5:00pm Sun:Closed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bios");
        }
    }
}
