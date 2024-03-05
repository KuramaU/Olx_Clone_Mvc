using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addphotoforcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\elect.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\sport.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\beauty.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\home.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\children.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\transport.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\buildings.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\fixing.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\work.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\services.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\forfree.png");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                column: "URL",
                value: "D:\\Шаг\\mvc shop\\BAGShop 22.04.23\\AutoShop\\wwwroot\\orenda.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "Categories");
        }
    }
}
