using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Migrations
{
    public partial class UpdateOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "OrderedItems");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OrderedItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OrderedItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "OrderedItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
