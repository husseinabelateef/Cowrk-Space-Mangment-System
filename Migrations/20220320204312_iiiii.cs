using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class iiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Admin");

          
        }
    }
}
