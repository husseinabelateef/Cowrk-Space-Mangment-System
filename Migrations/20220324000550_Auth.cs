using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomming_Receptionist_Receptionst_Id",
                table: "Incomming");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Receptionist_RecpetionstId",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_RecpetionstId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Incomming_Receptionst_Id",
                table: "Incomming");

            migrationBuilder.DropColumn(
                name: "Receptionst_Id",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "RecpetionstId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "Receptionst_Id",
                table: "Incomming");

            migrationBuilder.AddColumn<string>(
                name: "AppuserID",
                table: "Reservation",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppuserID",
                table: "Receptionist",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppuserID",
                table: "Incomming",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceptionistId",
                table: "Incomming",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_AppuserID",
                table: "Reservation",
                column: "AppuserID");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionist_AppuserID",
                table: "Receptionist",
                column: "AppuserID");

            migrationBuilder.CreateIndex(
                name: "IX_Incomming_AppuserID",
                table: "Incomming",
                column: "AppuserID");

            migrationBuilder.CreateIndex(
                name: "IX_Incomming_ReceptionistId",
                table: "Incomming",
                column: "ReceptionistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomming_ApplicationUser_AppuserID",
                table: "Incomming",
                column: "AppuserID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomming_Receptionist_ReceptionistId",
                table: "Incomming",
                column: "ReceptionistId",
                principalTable: "Receptionist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receptionist_ApplicationUser_AppuserID",
                table: "Receptionist",
                column: "AppuserID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_ApplicationUser_AppuserID",
                table: "Reservation",
                column: "AppuserID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomming_ApplicationUser_AppuserID",
                table: "Incomming");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomming_Receptionist_ReceptionistId",
                table: "Incomming");

            migrationBuilder.DropForeignKey(
                name: "FK_Receptionist_ApplicationUser_AppuserID",
                table: "Receptionist");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_ApplicationUser_AppuserID",
                table: "Reservation");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_AppuserID",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Receptionist_AppuserID",
                table: "Receptionist");

            migrationBuilder.DropIndex(
                name: "IX_Incomming_AppuserID",
                table: "Incomming");

            migrationBuilder.DropIndex(
                name: "IX_Incomming_ReceptionistId",
                table: "Incomming");

            migrationBuilder.DropColumn(
                name: "AppuserID",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "AppuserID",
                table: "Receptionist");

            migrationBuilder.DropColumn(
                name: "AppuserID",
                table: "Incomming");

            migrationBuilder.DropColumn(
                name: "ReceptionistId",
                table: "Incomming");

            migrationBuilder.AddColumn<int>(
                name: "Receptionst_Id",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecpetionstId",
                table: "Reservation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Receptionist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Receptionst_Id",
                table: "Incomming",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RecpetionstId",
                table: "Reservation",
                column: "RecpetionstId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomming_Receptionst_Id",
                table: "Incomming",
                column: "Receptionst_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomming_Receptionist_Receptionst_Id",
                table: "Incomming",
                column: "Receptionst_Id",
                principalTable: "Receptionist",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Receptionist_RecpetionstId",
                table: "Reservation",
                column: "RecpetionstId",
                principalTable: "Receptionist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
