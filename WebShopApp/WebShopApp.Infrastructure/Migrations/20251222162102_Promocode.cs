using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Promocode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PromoPercent",
                table: "Carts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "PromoPercent",
                table: "Carts");*/
        }
    }
}
