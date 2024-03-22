using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addbase_like : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProducts_Products_ProductId",
                table: "FavouriteProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteProducts",
                table: "FavouriteProducts");

            migrationBuilder.RenameTable(
                name: "FavouriteProducts",
                newName: "FavouriteProd");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteProducts_ProductId",
                table: "FavouriteProd",
                newName: "IX_FavouriteProd_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteProd",
                table: "FavouriteProd",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProd_Products_ProductId",
                table: "FavouriteProd",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProd_Products_ProductId",
                table: "FavouriteProd");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavouriteProd",
                table: "FavouriteProd");

            migrationBuilder.RenameTable(
                name: "FavouriteProd",
                newName: "FavouriteProducts");

            migrationBuilder.RenameIndex(
                name: "IX_FavouriteProd_ProductId",
                table: "FavouriteProducts",
                newName: "IX_FavouriteProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavouriteProducts",
                table: "FavouriteProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProducts_Products_ProductId",
                table: "FavouriteProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
