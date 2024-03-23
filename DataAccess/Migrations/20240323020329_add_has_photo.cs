using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class add_has_photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Has_Photo",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Has_Photo",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
