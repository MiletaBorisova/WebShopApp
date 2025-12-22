using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePromoFromCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            /*migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Carts");*/

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
