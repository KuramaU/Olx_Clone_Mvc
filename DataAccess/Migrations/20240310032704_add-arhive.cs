using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addarhive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IS_Arhive",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IS_Arhive",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
