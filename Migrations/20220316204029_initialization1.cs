using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class initialization1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Cart_Cart_ID",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "Cart_ID",
                table: "Reservation",
                newName: "ClientCart_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_Cart_ID",
                table: "Reservation",
                newName: "IX_Reservation_ClientCart_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_clientCart_ClientCart_ID",
                table: "Reservation",
                column: "ClientCart_ID",
                principalTable: "clientCart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_clientCart_ClientCart_ID",
                table: "Reservation");

            migrationBuilder.RenameColumn(
                name: "ClientCart_ID",
                table: "Reservation",
                newName: "Cart_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_ClientCart_ID",
                table: "Reservation",
                newName: "IX_Reservation_Cart_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Cart_Cart_ID",
                table: "Reservation",
                column: "Cart_ID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
