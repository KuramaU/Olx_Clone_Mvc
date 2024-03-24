using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updatepayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId1",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId1",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP" },
                values: new object[] { new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId1",
                table: "Payments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId1",
                table: "Payments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
