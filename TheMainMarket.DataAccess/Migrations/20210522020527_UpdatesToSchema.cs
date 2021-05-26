using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMainMarket.DataAccess.Migrations
{
    public partial class UpdatesToSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
