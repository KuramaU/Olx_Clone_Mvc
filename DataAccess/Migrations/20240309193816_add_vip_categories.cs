using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class add_vip_categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_VIP_Id",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "URL" },
                values: new object[] { 13, "VIP-Оголошення", "orenda.png" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category_VIP_Id", "CreatedDate", "D_VIP" },
                values: new object[] { 13, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Local) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DropColumn(
                name: "Category_VIP_Id",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
