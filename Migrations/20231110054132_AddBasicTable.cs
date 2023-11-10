using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMvc.Net.Migrations
{
    /// <inheritdoc />
    public partial class AddBasicTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CMND",
                table: "Users",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineName = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineId);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirportName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Classification = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportId);
                });

            migrationBuilder.CreateTable(
                name: "AnnualRevenues",
                columns: table => new
                {
                    AnnualRevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketByYear = table.Column<long>(type: "bigint", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualRevenues", x => x.AnnualRevenueId);
                });

            migrationBuilder.CreateTable(
                name: "BoardingPasses",
                columns: table => new
                {
                    BoardingPassId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FlightRouteId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardingPasses", x => x.BoardingPassId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    FlightDetailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntermediateAirport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LayoverTime = table.Column<float>(type: "real", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.FlightDetailId);
                });

            migrationBuilder.CreateTable(
                name: "FlightRoutes",
                columns: table => new
                {
                    FlightRouteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartureAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArrivalAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightRoutes", x => x.FlightRouteId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AirlineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightDetailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightTime = table.Column<float>(type: "real", nullable: false),
                    EcoSeat = table.Column<int>(type: "int", nullable: true),
                    DeluxeSeat = table.Column<int>(type: "int", nullable: true),
                    SkyBossSeat = table.Column<int>(type: "int", nullable: true),
                    SkyBossBusinessSeat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MonthlyRevenueId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyRevenues",
                columns: table => new
                {
                    MonthlyRevenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualRevenueId = table.Column<int>(type: "int", nullable: false),
                    TicketByMonth = table.Column<long>(type: "bigint", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyRevenues", x => x.MonthlyRevenueId);
                });

            migrationBuilder.CreateTable(
                name: "TicketClasses",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketClasses", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CMND = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FlightId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "UnitPrices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VND = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrices", x => x.PriceId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StaffId",
                table: "Invoices",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "AnnualRevenues");

            migrationBuilder.DropTable(
                name: "BoardingPasses");

            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "FlightRoutes");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "MonthlyRevenues");

            migrationBuilder.DropTable(
                name: "TicketClasses");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UnitPrices");

            migrationBuilder.DropColumn(
                name: "CMND",
                table: "Users");
        }
    }
}
