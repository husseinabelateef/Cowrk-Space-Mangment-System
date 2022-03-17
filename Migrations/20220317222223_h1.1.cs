using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class h11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "RawProduct");

            migrationBuilder.AddColumn<int>(
                name: "ActualAmount",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AvailableHours",
                table: "AssignPackage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductMovments",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutgoingID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovments", x => new { x.ProductID, x.OutgoingID });
                    table.ForeignKey(
                        name: "FK_ProductMovments_Outgoing_OutgoingID",
                        column: x => x.OutgoingID,
                        principalTable: "Outgoing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ProductMovments_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RawProductMovments",
                columns: table => new
                {
                    Raw_ProductID = table.Column<int>(type: "int", nullable: false),
                    OutgoingID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawProductMovments", x => new { x.Raw_ProductID, x.OutgoingID });
                    table.ForeignKey(
                        name: "FK_RawProductMovments_Outgoing_OutgoingID",
                        column: x => x.OutgoingID,
                        principalTable: "Outgoing",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RawProductMovments_RawProduct_Raw_ProductID",
                        column: x => x.Raw_ProductID,
                        principalTable: "RawProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovments_OutgoingID",
                table: "ProductMovments",
                column: "OutgoingID");

            migrationBuilder.CreateIndex(
                name: "IX_RawProductMovments_OutgoingID",
                table: "RawProductMovments",
                column: "OutgoingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMovments");

            migrationBuilder.DropTable(
                name: "RawProductMovments");

            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AvailableHours",
                table: "AssignPackage");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "RawProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
