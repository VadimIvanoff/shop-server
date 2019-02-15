using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_server.Data.Migrations
{
    public partial class AddCategoryToProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Product",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Product",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
