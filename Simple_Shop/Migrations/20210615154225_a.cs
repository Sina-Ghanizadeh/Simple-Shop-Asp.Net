using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple_Shop.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Category_CategoryId",
                table: "CategoryToProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProduct_Products_ProductId",
                table: "CategoryToProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryToProduct",
                newName: "CategoryToProducts");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProduct_ProductId",
                table: "CategoryToProducts",
                newName: "IX_CategoryToProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Categories_CategoryId",
                table: "CategoryToProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryToProducts_Products_ProductId",
                table: "CategoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryToProducts",
                table: "CategoryToProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "CategoryToProducts",
                newName: "CategoryToProduct");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryToProducts_ProductId",
                table: "CategoryToProduct",
                newName: "IX_CategoryToProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryToProduct",
                table: "CategoryToProduct",
                columns: new[] { "CategoryId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Category_CategoryId",
                table: "CategoryToProduct",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryToProduct_Products_ProductId",
                table: "CategoryToProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
