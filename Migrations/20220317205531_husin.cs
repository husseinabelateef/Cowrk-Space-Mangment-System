using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class husin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reciption_ID",
                table: "Outgoing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Outgoing_Reciption_ID",
                table: "Outgoing",
                column: "Reciption_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Outgoing_Receptionist_Reciption_ID",
                table: "Outgoing",
                column: "Reciption_ID",
                principalTable: "Receptionist",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Outgoing_Receptionist_Reciption_ID",
                table: "Outgoing");

            migrationBuilder.DropIndex(
                name: "IX_Outgoing_Reciption_ID",
                table: "Outgoing");

            migrationBuilder.DropColumn(
                name: "Reciption_ID",
                table: "Outgoing");
        }
    }
}
