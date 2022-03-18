using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class Z : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "RawProduct",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "RawProduct");
        }
    }
}
