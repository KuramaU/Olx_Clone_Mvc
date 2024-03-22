using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addfavouriteproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Has_Delivery",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FavouriteProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), false });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProducts_ProductId",
                table: "FavouriteProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteProducts");

            migrationBuilder.AlterColumn<bool>(
                name: "Has_Delivery",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "D_VIP", "Has_Delivery" },
                values: new object[] { new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Local), null });
        }
    }
}
