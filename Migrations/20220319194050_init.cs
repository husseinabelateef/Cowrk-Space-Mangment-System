using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cowrk_Space_Mangment_System.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsClient = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QR_Code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Deal",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualOrSharedOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoffeeMachineOffer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deal", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Offer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfHours = table.Column<int>(type: "int", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RawProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualAmount = table.Column<double>(type: "float", nullable: false),
                    RefrenceCupWeight = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NOC = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RawProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receptionist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryPerHour = table.Column<double>(type: "float", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualPrice = table.Column<double>(type: "float", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualAmount = table.Column<int>(type: "int", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignDeals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignDeals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignDeals_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssignDeals_Deal_DealID",
                        column: x => x.DealID,
                        principalTable: "Deal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AssignPackage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageID = table.Column<int>(type: "int", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignPackage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AssignPackage_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AssignPackage_Package_PackageID",
                        column: x => x.PackageID,
                        principalTable: "Package",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Incomming",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftCloseReservationIncome = table.Column<double>(type: "float", nullable: false),
                    ShiftCloseCateringIncome = table.Column<double>(type: "float", nullable: false),
                    Receptionst_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomming", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomming_Receptionist_Receptionst_Id",
                        column: x => x.Receptionst_Id,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Loging",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: false),
                    Receptionst_Id = table.Column<int>(type: "int", nullable: false),
                    RecpetionstId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loging", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loging_Receptionist_RecpetionstId",
                        column: x => x.RecpetionstId,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Outgoing",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reciption_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outgoing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Outgoing_Receptionist_Reciption_ID",
                        column: x => x.Reciption_ID,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Chair",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Room_ID = table.Column<int>(type: "int", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chair", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chair_Room_Room_ID",
                        column: x => x.Room_ID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RawProID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drink_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drink_RawProduct_RawProID",
                        column: x => x.RawProID,
                        principalTable: "RawProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateTable(
                name: "clientCart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_ID = table.Column<int>(type: "int", nullable: false),
                    Cart_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientCart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_clientCart_Cart_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "Cart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpextedHours = table.Column<int>(type: "int", nullable: false),
                    Receptionst_Id = table.Column<int>(type: "int", nullable: false),
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    ClientCart_ID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours_Price = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    RecpetionstId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_clientCart_ClientCart_ID",
                        column: x => x.ClientCart_ID,
                        principalTable: "clientCart",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Reservation_Receptionist_RecpetionstId",
                        column: x => x.RecpetionstId,
                        principalTable: "Receptionist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "chairReserve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chair_Id = table.Column<int>(type: "int", nullable: false),
                    Reservation_Id = table.Column<int>(type: "int", nullable: false),
                    End_Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chairReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_chairReserve_Chair_Chair_Id",
                        column: x => x.Chair_Id,
                        principalTable: "Chair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_chairReserve_Reservation_Reservation_Id",
                        column: x => x.Reservation_Id,
                        principalTable: "Reservation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RoomReserve",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_Id = table.Column<int>(type: "int", nullable: false),
                    Rooom_Id = table.Column<int>(type: "int", nullable: false),
                    End_Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomReserve_Reservation_Reservation_Id",
                        column: x => x.Reservation_Id,
                        principalTable: "Reservation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RoomReserve_Room_Rooom_Id",
                        column: x => x.Rooom_Id,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignDeals_ClientID",
                table: "AssignDeals",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignDeals_DealID",
                table: "AssignDeals",
                column: "DealID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignPackage_ClientID",
                table: "AssignPackage",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_AssignPackage_PackageID",
                table: "AssignPackage",
                column: "PackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Chair_Room_ID",
                table: "Chair",
                column: "Room_ID");

            migrationBuilder.CreateIndex(
                name: "IX_chairReserve_Chair_Id",
                table: "chairReserve",
                column: "Chair_Id");

            migrationBuilder.CreateIndex(
                name: "IX_chairReserve_Reservation_Id",
                table: "chairReserve",
                column: "Reservation_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientCart_Cart_Id",
                table: "clientCart",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_clientCart_Reservation_ID",
                table: "clientCart",
                column: "Reservation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_ProductId",
                table: "Drink",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Drink_RawProID",
                table: "Drink",
                column: "RawProID");

            migrationBuilder.CreateIndex(
                name: "IX_Incomming_Receptionst_Id",
                table: "Incomming",
                column: "Receptionst_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loging_RecpetionstId",
                table: "Loging",
                column: "RecpetionstId");

            migrationBuilder.CreateIndex(
                name: "IX_Outgoing_Reciption_ID",
                table: "Outgoing",
                column: "Reciption_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartID",
                table: "Product",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovments_OutgoingID",
                table: "ProductMovments",
                column: "OutgoingID");

            migrationBuilder.CreateIndex(
                name: "IX_RawProductMovments_OutgoingID",
                table: "RawProductMovments",
                column: "OutgoingID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Client_ID",
                table: "Reservation",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientCart_ID",
                table: "Reservation",
                column: "ClientCart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RecpetionstId",
                table: "Reservation",
                column: "RecpetionstId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReserve_Reservation_Id",
                table: "RoomReserve",
                column: "Reservation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReserve_Rooom_Id",
                table: "RoomReserve",
                column: "Rooom_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_clientCart_Reservation_Reservation_ID",
                table: "clientCart",
                column: "Reservation_ID",
                principalTable: "Reservation",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Client_Client_ID",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_clientCart_Reservation_Reservation_ID",
                table: "clientCart");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AssignDeals");

            migrationBuilder.DropTable(
                name: "AssignPackage");

            migrationBuilder.DropTable(
                name: "chairReserve");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropTable(
                name: "Incomming");

            migrationBuilder.DropTable(
                name: "Loging");

            migrationBuilder.DropTable(
                name: "ProductMovments");

            migrationBuilder.DropTable(
                name: "RawProductMovments");

            migrationBuilder.DropTable(
                name: "RoomReserve");

            migrationBuilder.DropTable(
                name: "Deal");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Chair");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Outgoing");

            migrationBuilder.DropTable(
                name: "RawProduct");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "clientCart");

            migrationBuilder.DropTable(
                name: "Receptionist");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
