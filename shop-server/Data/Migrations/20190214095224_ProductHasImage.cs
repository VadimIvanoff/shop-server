using Microsoft.EntityFrameworkCore.Migrations;

namespace shop_server.Data.Migrations
{
    public partial class ProductHasImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasImage",
                table: "Product",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasImage",
                table: "Product");
        }
    }
}
