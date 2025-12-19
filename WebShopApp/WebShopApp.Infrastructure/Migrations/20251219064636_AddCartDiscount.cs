using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCartDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PromoCode",
                table: "PromoCode");

            migrationBuilder.RenameTable(
                name: "PromoCode",
                newName: "PromoCodes");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PromoCode",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromoCodes",
                table: "PromoCodes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PromoCodes",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "PromoCodes",
                newName: "PromoCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromoCode",
                table: "PromoCode",
                column: "Id");
        }
    }
}
