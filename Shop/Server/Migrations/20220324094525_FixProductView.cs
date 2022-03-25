using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Server.Migrations
{
    public partial class FixProductView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Descont",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descont",
                table: "Products");
        }
    }
}
