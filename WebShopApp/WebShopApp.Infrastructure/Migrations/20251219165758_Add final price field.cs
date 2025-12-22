using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addfinalpricefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PromoCode",
                table: "Carts");*/

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Orders");

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
        }
    }
}
