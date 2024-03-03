using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class add_VIP_and_TOP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "D_Up_one",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "D_Up_seven",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "D_VIP",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUp_one",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUp_seven",
                table: "Products",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "D_Up_one",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "D_Up_seven",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "D_VIP",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsUp_one",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsUp_seven",
                table: "Products");
        }
    }
}
