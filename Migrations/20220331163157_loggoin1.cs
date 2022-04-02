using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class loggoin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartID",
                table: "Product",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartID",
                table: "Product",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
