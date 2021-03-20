using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Migrations
{
    public partial class FixEntitiesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItems_Items_OfferItemId",
                table: "OfferItems");

            migrationBuilder.DropIndex(
                name: "IX_OfferItems_OfferItemId",
                table: "OfferItems");

            migrationBuilder.DropColumn(
                name: "OfferItemId",
                table: "OfferItems");

            migrationBuilder.AddColumn<int>(
                name: "ContainedItemId",
                table: "OfferItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_ContainedItemId",
                table: "OfferItems",
                column: "ContainedItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItems_Items_ContainedItemId",
                table: "OfferItems",
                column: "ContainedItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferItems_Items_ContainedItemId",
                table: "OfferItems");

            migrationBuilder.DropIndex(
                name: "IX_OfferItems_ContainedItemId",
                table: "OfferItems");

            migrationBuilder.DropColumn(
                name: "ContainedItemId",
                table: "OfferItems");

            migrationBuilder.AddColumn<int>(
                name: "OfferItemId",
                table: "OfferItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_OfferItems_OfferItemId",
                table: "OfferItems",
                column: "OfferItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferItems_Items_OfferItemId",
                table: "OfferItems",
                column: "OfferItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
