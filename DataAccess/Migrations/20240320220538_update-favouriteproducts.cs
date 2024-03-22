using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updatefavouriteproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProd_Products_ProductId",
                table: "FavouriteProd");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteProd_ProductId",
                table: "FavouriteProd");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "FavouriteProd",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProd_userId",
                table: "FavouriteProd",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProd_AspNetUsers_userId",
                table: "FavouriteProd",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteProd_AspNetUsers_userId",
                table: "FavouriteProd");

            migrationBuilder.DropIndex(
                name: "IX_FavouriteProd_userId",
                table: "FavouriteProd");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "FavouriteProd");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProd_ProductId",
                table: "FavouriteProd",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteProd_Products_ProductId",
                table: "FavouriteProd",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
