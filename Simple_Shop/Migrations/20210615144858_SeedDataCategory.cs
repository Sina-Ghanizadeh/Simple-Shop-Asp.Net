using Microsoft.EntityFrameworkCore.Migrations;

namespace Simple_Shop.Migrations
{
    public partial class SeedDataCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "کالاهای دیجیتال ", "کالاهای دیجیتال" },
                    { 2, "لباس و پوشاک ", "لباس و پوشاک" },
                    { 3, "لوازم خانگی", "لوازم خانگی" },
                    { 4, "لوازم بچه", "لوازم بچه" },
                    { 5, "لوازم ماشین", "لوازم ماشین" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
