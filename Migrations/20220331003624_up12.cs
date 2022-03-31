using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class up12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Cart_CartID",
                table: "CartProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartProducts_CartID",
                table: "CartProducts");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "CartProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Cart_Cart_Id",
                table: "CartProducts",
                column: "Cart_Id",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartProducts_Cart_Cart_Id",
                table: "CartProducts");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "CartProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartProducts_CartID",
                table: "CartProducts",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartProducts_Cart_CartID",
                table: "CartProducts",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
